//-----------------------------------------------------------------------
// <copyright file="SimWorker.cs" company="Auron Software">
//     Copyright (c) Auron Software All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SmppSimulator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Diagnostics;
    using System.Threading;
    using AxSms;
    using Microsoft.Win32;
    using Properties;

    public class SimWorker
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern long GetTickCount();

        private static int AUTOMESSAGE_RELOAD_TOMS = 3000;
        private static int REPLIES_RELOAD_TOMS = 1000;
        private static int MAX_OUTGOING = 100;

        #region variables
        private BackgroundWorker m_objServerWorker = new BackgroundWorker();
        private Queue<SimCommand> m_qToWorker = new Queue<SimCommand>();
        private Queue<SimCommand> m_qToGui = new Queue<SimCommand>();
        private SimModel m_objSimModel = new SimModel();
        private Smpp m_objSplitSms = null;
        #endregion

        #region properties
        public SimModel SimModel
        {
            get { return m_objSimModel; }
            set { m_objSimModel = value; }
        }
        #endregion

        public void PushWorker(SimCommand objCmd)
        {
            lock (this)
            {
                m_qToWorker.Enqueue(objCmd);
            }
        }

        public void PushGui(SimCommand objCmd)
        {
            lock (this)
            {
                m_qToGui.Enqueue(objCmd);
            }
        }

        public SimCommand PollWorker()
        {
            lock (this)
            {
                if (m_qToGui.Count > 0)
                    return m_qToGui.Dequeue();
                else return null;
            }
        }

        public SimCommand PollGui()
        {
            lock (this)
            {
                if (m_qToWorker.Count > 0)
                    return m_qToWorker.Dequeue();
                else return null;
            }
        }

        public SimWorker()
        {
            m_objServerWorker.WorkerSupportsCancellation = true;
            m_objServerWorker.DoWork += new DoWorkEventHandler(bw_Startup);            
        }

        public void StartServer()
        {
            if (!m_objServerWorker.IsBusy)
                m_objServerWorker.RunWorkerAsync();
        }

        public void StopServer()
        {
            if (!m_objServerWorker.CancellationPending)
                m_objServerWorker.CancelAsync();
        }

        private void bw_Startup(object objSender, DoWorkEventArgs objWorkEvent)
        {
            Logger objLogger = new Logger(Settings.Default.WorkerLogFile);
            objLogger.WriteLine(">> Started worker thread");

            AxSms.SmppServer objServer = null;

            // Catchall so the thread won't silently exit on an exception
            try
            {
                objServer = new AxSms.SmppServer();
                bw_DoWork((BackgroundWorker)objSender, objLogger, objServer);
            }
            catch (Exception e)
            {
                objLogger.WriteLine("Exception: {0}", e.ToString());
            }

            // close-up properly or the GUI thread may hang waiting for the server to stop.
            if (objServer != null) objServer.Stop();
            m_objSimModel.IsServerStarted = false;
            objWorkEvent.Cancel = true;

            objLogger.WriteLine("<< Exit worker thread");
        }

        private void bw_DoWork(BackgroundWorker objWorker, Logger objLogger, AxSms.SmppServer objServer)
        {
            if (m_objSimModel.IsServerLogEnabled)
                objServer.LogFile = m_objSimModel.ServerLog;

            AxSms.Constants objSmsConsts = new AxSms.Constants();

            objServer.LastReference = m_objSimModel.LastReference;
            objServer.Start(m_objSimModel.Port, m_objSimModel.IpVersion, m_objSimModel.Certificate);
            
            SimCommand objCommand = new SimCommand();
            objCommand.CommandId = SimCommand.ECommandId.RESPONSECODE;
            objCommand.LastError = objServer.LastError;
            objCommand.LastErrorDescription = objServer.GetErrorDescription(objServer.LastError);
            m_objSimModel.IsServerStarted = objServer.LastError == 0;
            PushGui(objCommand);

            if (objServer.LastError != 0)
            {
                objLogger.WriteLine("SmppServer, failed: [{0}:{1}]", objCommand.LastError, objCommand.LastErrorDescription);
                return;
            }
            else
                objLogger.WriteLine("SmppServer started");

            // Initialize Smpp instance to do SMS splitting
            // This is very convenient because we don't need to use the orginal SmppSession object
            m_objSplitSms = new AxSms.Smpp();
            m_objSplitSms.MultipartMode = m_objSimModel.MultipartMode;
            m_objSplitSms.UseGsmEncoding = m_objSimModel.UseGsmEncoding;

            // Replies
            long nLastReloadReplies = GetTickCount();
            bool bEcho = m_objSimModel.Echo;
            SimErrorRates objErrorRates = m_objSimModel.GetErrorRates();

            // Auto messages
            long nLastReloadAutoMsg = GetTickCount();
            var lsAutoMessages = new List<SimMessage>();
            lsAutoMessages = m_objSimModel.GetAutoMessages();
            int nGeneratePerMinute = m_objSimModel.GeneratePerMinute;
            bool bRandomOrder = m_objSimModel.RandomOrder;
            int nAutoMsgIndex = 0;
            Random objRandom = new Random();

            var dctWrkSessions = new Dictionary<int, WrkSession>();
            while (!objWorker.CancellationPending)
            {
                var lsMessagesUpdated = new List<SimMessage>();
                var lsMessagesGenerated = new List<SimMessage>();
                var lsMessagesReceived = new List<SimMessage>();

                // Check if the GUI has some requests
                while ((objCommand = PollGui()) != null)
                {
                    WrkSession objWrkSession = null;
                    dctWrkSessions.TryGetValue(objCommand.SessionId, out objWrkSession);
                    switch (objCommand.CommandId)
                    {
                        case SimCommand.ECommandId.DROPSESSION:
                            if (objWrkSession != null) objWrkSession.bDrop = true;
                            break;
                        case SimCommand.ECommandId.SENDMESSAGE:
                            if (objWrkSession != null)
                                bw_AddOutgoing(objCommand.Message, objWrkSession.qOutMessages, lsMessagesGenerated, true);
                            break;
                    }
                }

                // Quit if the server stopped for some reason
                if (!objServer.IsStarted)
                {
                    m_objSimModel.IsServerStarted = false;
                    break;
                }

                // Reset statistics count
                int nRecvPerSecond = 0, nSentPerSecond = 0;
                // Handle connected sessions
                var lsSessions = new List<SimSession>();
                AxSms.SmppSession objSession = objServer.GetFirstSession();
                while (objServer.LastError == 0)
                {   // Creating objSimSession object early and only access it's properties since
                    // accessing ActiveX properties (and methods) seems to be expensive in C#
                    SimSession objSimSession = new SimSession(objSession);
                    lsSessions.Add(objSimSession);

                    // Get the current worker session
                    WrkSession objWrkSession = null;
                    if (!dctWrkSessions.ContainsKey(objSession.Id))
                        dctWrkSessions[objSession.Id] = objWrkSession = new WrkSession(objSimSession, GetTickCount());
                    else
                        objWrkSession = dctWrkSessions[objSession.Id];

                    // Handle session bind requests
                    if (objSimSession.ConnectionState == objSmsConsts.SMPP_SESSIONSTATE_BINDING)
                    {
                        // Respond to a bind required. If authentication is required test sysid
                        int iResponse = 0;
                        if (m_objSimModel.IsAuthRequired &&
                           (objSimSession.SystemId != m_objSimModel.SystemId ||
                            objSimSession.Password != m_objSimModel.Password))
                            iResponse = objSmsConsts.SMPP_ESME_RINVPASWD;
                        objSession.RespondToBind(iResponse);

                        // Generate a logfile path and set it
                        if (m_objSimModel.IsSessionLogEnabled)
                        {
                            string strLogIp;
                            if (objSimSession.Ip.Contains("."))
                            {   // IPv4; np
                                strLogIp = objSimSession.Ip;
                            }
                            else
                            {   // IPv6, can't have ':''s in a filename !
                                strLogIp = string.Format("[{0}]", objSimSession.Ip).Replace(':', '_');
                            }

                            string strLogPath = string.Format("{0}{1}_{2}.log",
                                m_objSimModel.SessionLog, strLogIp, objSimSession.Port);
                            objSession.LogPduDetails = m_objSimModel.IsPduLogEnabled;
                            objSession.LogFile = strLogPath;
                        }

                        // Apply server settings
                        objSession.PduTimeout = m_objSimModel.PduTimeout;
                        objSession.EnquireInterval = m_objSimModel.EnquireInterval;
                        objSession.UseGsmEncoding = m_objSimModel.UseGsmEncoding;
                        objSession.DeliverMode = m_objSimModel.DeliverMode;
                    }

                    // Generate auto-messages.
                    int iNumMessages = objWrkSession.CalculateMessagesToSend(GetTickCount(), nGeneratePerMinute);
                    if (lsAutoMessages.Count > 0)
                    {
                        for (int i = 0; i < iNumMessages; i++)
                        {   // Determine the message index of the auto-message to sent
                            if (bRandomOrder)
                                nAutoMsgIndex = objRandom.Next(lsAutoMessages.Count);
                            else
                            {
                                if (nAutoMsgIndex < lsAutoMessages.Count - 1)
                                    nAutoMsgIndex++;
                                else nAutoMsgIndex = 0;
                            }

                            // If there's room in the output queue, add it to the output queue
                            // othewise, reject the message, queue full..
                            SimMessage objMessage = new SimMessage(lsAutoMessages[nAutoMsgIndex]);
                            objMessage.SessionId = objSimSession.Id;
                            objMessage.SystemId = objSimSession.SystemId;                            
                            bw_AddOutgoing(objMessage, objWrkSession.qOutMessages, lsMessagesGenerated, true);
                        }
                    }

                    // Sent SMS messages in sent queue
                    int nOut = objSession.CountSmsDeliverySpace();
                    while (objWrkSession.qOutMessages.Count > 0 && nOut > 0)
                    {
                        SimMessage objSimMessage = objWrkSession.qOutMessages.Dequeue();
                        AxSms.Message objMessage = objSimMessage.CreateAxSms();

                        // reject multipart messages because they should all have been splitup before beeing
                        // added to the output queue.
                        objSession.DeliverSms(objMessage, objSmsConsts.MULTIPART_REJECT);
                        if (objSession.LastError != 0)
                            objSimMessage.Status = string.Format("SUBMITERROR({0})", objSession.LastError);
                        else
                            objSimMessage.Status = "DELIVERED";

                        lsMessagesUpdated.Add(objSimMessage);
                    }

                    // Fetch updates for messages that have been sent
                    AxSms.Message objResponse = objSession.ReceiveDeliverResponse();
                    while (objSession.LastError == 0)
                    {
                        SimMessage objSimMessage = new SimMessage(objResponse);
                        objSimMessage.SystemId = objSimSession.SystemId;
                        objSimMessage.SessionId = objSimSession.Id;
                        objSimMessage.Status = objSmsConsts.SmppEsmeToString(objSimMessage.CommandStatus).Replace("SMPP_ESME_", "");
                        lsMessagesUpdated.Add(objSimMessage);
                        objResponse = objSession.ReceiveDeliverResponse();
                    }

                    // Fetch received messages
                    AxSms.Message objReceived = objSession.ReceiveSubmitSms();
                    while (objSession.LastError == 0)
                    {
                        SimMessage objSimMessage = new SimMessage(objReceived);
                        objSimMessage.SystemId = objSimSession.SystemId;
                        objSimMessage.SessionId = objSimSession.Id;

                        // Determine command status
                        int nCommandStatus = 0;
                        int nRandCmdStatus = objRandom.Next(100);
                        int nRandCmdStatusOffs = 0;
                        foreach (SimMessageErrorRate objErrr in objErrorRates.MessageErrorRates)
                        {
                            nRandCmdStatusOffs += objErrr.Occurance;
                            if (nRandCmdStatus <= nRandCmdStatusOffs)
                            {
                                nCommandStatus = objErrr.StatusCode;
                                break;
                            }
                        }

                        // Respond to SMS message
                        objReceived.SmppCommandStatus = objSimMessage.CommandStatus = nCommandStatus;
                        objSession.RespondToSubmitSms(objReceived);

                        // Set message status text and add it to the 'received' list
                        // generate a usertag for received messages as well. The GUI relies on every message to have a unique ID
                        objSimMessage.Status = objSmsConsts.SmppEsmeToString(objSimMessage.CommandStatus).Replace("SMPP_ESME_", "");
                        objSimMessage.UserTag = m_objSimModel.GetAndIncLastUserTag();
                        lsMessagesReceived.Add(objSimMessage);

                        // Determine command status
                        if (objSimMessage.RequestDeliveryReport && nCommandStatus == 0)
                        {
                            int nRandDlrStatus = objRandom.Next(100);
                            int nRandDlrStatusOffs = 0;
                            int nStatusCode = objSmsConsts.SMPP_MESSAGESTATE_DELIVERED;
                            string strStatusText = "DELIVRD";
                            foreach (SimDeliveryErrorRate objErrr in objErrorRates.DeliveryErrorRates)
                            {
                                nRandDlrStatusOffs += objErrr.Occurance;
                                if (nRandDlrStatus <= nRandDlrStatusOffs)
                                {
                                    nStatusCode = objErrr.Code;
                                    strStatusText = objErrr.Text;
                                    break;
                                }
                            }
                            SimMessage objDlr = bw_CreateDlr(objSimMessage, objSimSession.Version, nStatusCode, strStatusText, objSmsConsts);
                            bw_AddOutgoing(objDlr, objWrkSession.qOutMessages, lsMessagesGenerated, false);
                        }

                        if (bEcho)
                        {
                            SimMessage objEcho = new SimMessage(objSimMessage);
                            objEcho.FromAddress = objSimMessage.ToAddress;
                            objEcho.FromAddressNpi = objSimMessage.ToAddressNpi;
                            objEcho.FromAddressTon = objSimMessage.ToAddressTon;
                            objEcho.ToAddress = objSimMessage.FromAddress;
                            objEcho.ToAddressNpi = objSimMessage.FromAddressNpi;
                            objEcho.ToAddressTon = objSimMessage.FromAddressTon;
                            bw_AddOutgoing(objEcho, objWrkSession.qOutMessages, lsMessagesGenerated, false);
                        }

                        objReceived = objSession.ReceiveSubmitSms();
                    }

                    // Don't support SMS queries
                    objReceived = objSession.ReceiveQuerySms();
                    while (objSession.LastError == 0)
                    {   // Just immediately respond with an error.
                        objReceived.SmppCommandStatus = objSmsConsts.SMPP_ESME_RINVCMDID;
                        objSession.RespondToQuerySms(objReceived);
                        objReceived = objSession.ReceiveQuerySms();
                    }

                    if (objWrkSession.bDrop) objSession.Disconnect();

                    // Update statistics
                    nRecvPerSecond += objSession.SmsReceivedPerSecond;
                    nSentPerSecond += objSession.SmsSentPerSecond;

                    objSession = objServer.GetNextSession();
                }

                // Make a list of disconnected sessions
                var lsDisconnected = new List<SimSession>();
                objSession = objServer.GetClosedSession();
                while (objServer.LastError == 0)
                {
                    SimSession objSimSession = new SimSession(objSession);
                    lsDisconnected.Add(objSimSession);
                    dctWrkSessions.Remove(objSimSession.Id);
                    objSession = objServer.GetClosedSession();
                }

                // Set global stats
                m_objSimModel.RecvPerSecond = nRecvPerSecond;
                m_objSimModel.SentPerSecond = nSentPerSecond;
                m_objSimModel.LastReference = objServer.LastReference;

                // See if there's a need to sent the delta messages to the GUI
                if (lsMessagesUpdated.Count > 0 ||
                    lsMessagesReceived.Count > 0 ||
                    lsMessagesGenerated.Count > 0)
                {
                    objCommand = new SimCommand();
                    objCommand.CommandId = SimCommand.ECommandId.MESSAGESDELTA;
                    objCommand.MessagesUpdated = lsMessagesUpdated;
                    objCommand.MessagesReceived = lsMessagesReceived;
                    objCommand.MessagesGenerated = lsMessagesGenerated;
                    PushGui(objCommand);
                }

                if (lsDisconnected.Count > 0)
                {
                    objCommand = new SimCommand();
                    objCommand.CommandId = SimCommand.ECommandId.DROPSESSION;
                    objCommand.Sessions = lsDisconnected;
                    PushGui(objCommand);
                }

                // Don't continuously refresh the auto-messages. They are not updated that often and
                // a small lag here is not very noticable.
                if (GetTickCount() - nLastReloadAutoMsg > AUTOMESSAGE_RELOAD_TOMS)
                {
                    nLastReloadAutoMsg = GetTickCount();
                    lsAutoMessages = m_objSimModel.GetAutoMessages();
                    nGeneratePerMinute = m_objSimModel.GeneratePerMinute;
                    bRandomOrder = m_objSimModel.RandomOrder;
                }

                // Don't continuously refresh reply settings, but do refresh them a bit
                // more often than the autoreply settings because its very visible.
                if (GetTickCount() - nLastReloadReplies > REPLIES_RELOAD_TOMS)
                {
                    nLastReloadReplies = GetTickCount();
                    bEcho = m_objSimModel.Echo;
                    objErrorRates = m_objSimModel.GetErrorRates();
                }

                m_objSimModel.SetSessions(lsSessions);

                Thread.Sleep(100);
            }
        }

        void bw_AddOutgoing(SimMessage objMessage, Queue<SimMessage> qOut, List<SimMessage> lsGenerated, bool bCouldBeMultipart)
        {
            var lsParts = new List<SimMessage>();

            if (bCouldBeMultipart)
            {
                AxSms.Message objRoot = objMessage.CreateAxSms();                
                if (m_objSplitSms.CountParts(objRoot) > 1)
                {
                   AxSms.Message objPart = m_objSplitSms.GetFirstPart(objRoot);
                    while (m_objSplitSms.LastError == 0)
                    {
                        lsParts.Add(new SimMessage(objPart));
                        objPart = m_objSplitSms.GetNextPart();
                    }
                }
            }

            if (lsParts.Count == 0) lsParts.Add(objMessage);

            if (qOut.Count > MAX_OUTGOING)
            {
                foreach (SimMessage objPart in lsParts)
                {
                    objPart.Status = "SIMQFULL";
                    lsGenerated.Add(objPart);
                }
            }
            else
            {
                foreach (SimMessage objPart in lsParts)
                {
                    objPart.Status = "QUEUED";
                    objPart.UserTag = m_objSimModel.GetAndIncLastUserTag();
                    lsGenerated.Add(objPart);
                    qOut.Enqueue(objPart);
                }
            }
        }

        SimMessage bw_CreateDlr(SimMessage objIn, int nVersion, int nStatusCode, string strStatusText, AxSms.Constants objSmsConst)
        {
            SimMessage objDlr = new SimMessage();
            
            // Swap adress
            objDlr.FromAddress = objIn.ToAddress;
            objDlr.FromAddressNpi = objIn.ToAddressNpi;
            objDlr.FromAddressTon = objIn.FromAddressTon;
            objDlr.ToAddress = "";
            objDlr.ToAddressNpi = 0;
            objDlr.ToAddressTon = objSmsConst.TON_ALPHANUMERIC;

            // Set session information
            objDlr.SessionId = objIn.SessionId;
            objDlr.SystemId = objIn.SystemId;

            // Add TLV's, only for 3.4 or 5.0 clients.            
            if (nVersion != objSmsConst.SMPP_VERSION_33)
            {
                objDlr.Tlvs.Clear();
                AxSms.Tlv objAxTlv = new AxSms.Tlv();
                
                SimTlv objTlv = new SimTlv();
                objTlv.Tag = objSmsConst.SMPP_TLV_MESSAGE_STATE;
                objAxTlv.ValueAsInt8 = nStatusCode;

                objTlv.TlvType = SimTlv.TlvTypes.HEX;
                objTlv.TypedValue = objAxTlv.ValueAsHexString;
                objTlv.HexValue = objTlv.TypedValue;
                objDlr.Tlvs.Add(objTlv);

                objTlv = new SimTlv();
                objTlv.Tag = objSmsConst.SMPP_TLV_RECEIPTED_MESSAGE_ID;
                objAxTlv.ValueAsString = objIn.Reference;

                objTlv.TlvType = SimTlv.TlvTypes.HEX;
                objTlv.TypedValue = objAxTlv.ValueAsHexString;
                objTlv.HexValue = objTlv.TypedValue;
                objDlr.Tlvs.Add(objTlv);
            }
            
            // NOTE: submit date and done date are the same!
            
            string strExcerpt = objIn.Body.Substring(0, Math.Min(objIn.Body.Length, 60));
            int iNumSmsDelivered = nStatusCode == objSmsConst.SMPP_MESSAGESTATE_DELIVERED ? 1: 0;
            string strBody = string.Format("id:{0} sub:001 dlvrd:{1:D3} submit date:{2:yyMMddHHmmss} done date:{2:yyMMddHHmmss} stat:{3} err:000 text:{4}",
                objIn.Reference, iNumSmsDelivered, DateTime.Now, strStatusText, strExcerpt);

            // Complete delivery report formatting
            objDlr.IsDeliveryReport = true;
            objDlr.Body = strBody.Substring(0, Math.Min(strBody.Length, 160));

            return objDlr;
        }
    }

    // This is a helper class which contains some additional session related context for
    // use in the worker class only.
    class WrkSession
    {
        public WrkSession(SimSession objSession, long nTickCount)
        {
            nId = objSession.Id;
            strSystemId = objSession.SystemId;
            nLastMinute = nTickCount;
        }

        public int CalculateMessagesToSend(long nTickCount, int nMsgPerMinute)
        {
            long nElapsed = nTickCount - nLastMinute;
            if (nElapsed > 60000)
            {
                nLastMinute += 60000;
                nElapsed -= 60000;
                nSent -= nMsgPerMinute;
            }
            float rSend = ((float)nElapsed / 60000F) * (float)nMsgPerMinute;
            float rDelta = rSend - (float)nSent;

            int iNumMessages = (int)rDelta;
            nSent += iNumMessages;

            return iNumMessages;
        }

        public long nLastMinute;
        public int nSent;
        public int nId;
        public string strSystemId;
        public bool bDrop;
        public Queue<SimMessage> qOutMessages = new Queue<SimMessage>();
    }
}