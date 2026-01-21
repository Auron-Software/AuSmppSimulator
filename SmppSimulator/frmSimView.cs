//-----------------------------------------------------------------------
// <copyright file="frmSimView.cs" company="Auron Software">
//     Copyright (c) Auron Software All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SmppSimulator
{
  using System;
  using System.Collections.Generic;
  using System.Configuration;
  using System.Diagnostics;
  using System.Drawing;
  using System.IO;
  using System.Runtime.InteropServices;
  using System.Threading;
  using System.Windows.Forms;
  using System.Xml;
  using Properties;
  using AxSms;
  using Microsoft.Win32;

  public partial class frmMain : Form
  {
    private const int LVI_SESSION_IP = 0;
    private const int LVI_SESSION_PORT = 1;
    private const int LVI_SESSION_SYSTEMID = 2;
    private const int LVI_SESSION_CONNECTIONSTATE = 3;

    private const int LVI_MESSAGE_DIRECTION = 0;
    private const int LVI_MESSAGE_SYSTEMID = 1;
    private const int LVI_MESSAGE_TOADDRESS = 2;
    private const int LVI_MESSAGE_REFERENCE = 3;
    private const int LVI_MESSAGE_STATE = 4;
    private const int LVI_MESSAGE_BODY = 5;

    private const int AUTOMESSAGE_FROMADDRESS = 0;
    private const int AUTOMESSAGE_TOADDRESS = 1;
    private const int AUTOMESSAGE_BODY = 2;

    private const int DEFAULT_KEEPMESSAGES = 100;

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern short GlobalAddAtom(string atomName);

    [DllImport("kernel32.dll")]
    private static extern long GetTickCount();


    private SimWorker m_objSimWorker;
    private SimModel m_objSimModel;

    private Logger m_Logger;
    private AxSms.Constants m_objSmsConstants;

    private int m_nTotalMessages;
    private int m_nKeepMaxMessages = DEFAULT_KEEPMESSAGES;
    private string m_strAutoMessagesFile;

    public frmMain()
    {
      InitializeComponent();
      if (!IsToolkitInstalled())
      {
        MessageBox.Show(string.Format("Either the Auron SMS Component is not installed " +
            "or it is of the wrong version. The SMPP Simulator requires version {0} to be " +
            "installed. Please download and install the latest version of the SMPP Simulator",
            SimConstants.AXSMS_REQ_BUILD), "Auron SMPP Simulator", MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
        Environment.Exit(-1);
      }
    }

    private bool IsToolkitInstalled()
    {
      // Try to make an instance. If this fails the component is not installed correctly.
      AxSms.SmppServer objServer = null;
      try
      {
        objServer = new AxSms.SmppServer();
      }
      catch
      {
        return false;
      }

      // Test the version of the component. Test the major version number or if it's a debug build.
      if (!objServer.Build.StartsWith(SimConstants.AXSMS_REQ_BUILD) &&
          !objServer.Build.StartsWith("${")) return false;

      return true;
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      var objSettings = Settings.Default;

      // force save settings right away
      objSettings.LastReference = objSettings.LastReference;
      objSettings.Save();
      
      m_Logger = new Logger(objSettings.ViewLogFile);
      m_Logger.WriteLine("Startup SMPP Simulator");

      m_objSimWorker = new SimWorker();
      m_objSimModel = m_objSimWorker.SimModel;
      m_objSmsConstants = new AxSms.Constants();

      // IP Version combo box
      var dctIpVersion = new Dictionary<string, int>();
      dctIpVersion.Add("IPv6/IPv4", m_objSmsConstants.SMPP_IPVERSION_BOTH);
      dctIpVersion.Add("IPv6", m_objSmsConstants.SMPP_IPVERSION_6);
      dctIpVersion.Add("IPv4", m_objSmsConstants.SMPP_IPVERSION_4);

      cbxIpVersion.DisplayMember = "Key";
      cbxIpVersion.ValueMember = "Value";
      cbxIpVersion.DataSource = new BindingSource(dctIpVersion, null);

      // Make sure to update all the SESSION_ constants when changing stuff here !!!!
      lvSessions.Columns.Add("Client IP", (int)(lvSessions.Width * .25), HorizontalAlignment.Left);
      lvSessions.Columns.Add("Client Port", (int)(lvSessions.Width * .25), HorizontalAlignment.Left);
      lvSessions.Columns.Add("SystemID", (int)(lvSessions.Width * .24), HorizontalAlignment.Left);
      lvSessions.Columns.Add("Connection State", (int)(lvSessions.Width * .25), HorizontalAlignment.Left);
      lvSessions.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);

      // Make sure to update all the MESSAGE_ constants when changing stuff here !!!!
      lvMessages.Columns.Add("Dir.", (int)(lvMessages.Width * .1), HorizontalAlignment.Left);
      lvMessages.Columns.Add("SystemID", (int)(lvMessages.Width * .20), HorizontalAlignment.Left);
      lvMessages.Columns.Add("ToAddress", (int)(lvMessages.Width * .15), HorizontalAlignment.Left);
      lvMessages.Columns.Add("Reference", (int)(lvMessages.Width * .15), HorizontalAlignment.Left);
      lvMessages.Columns.Add("State", (int)(lvMessages.Width * .15), HorizontalAlignment.Left);
      lvMessages.Columns.Add("Body", -2, HorizontalAlignment.Left);

      // Make sure to update all the AUTOMESSAGE_ constants when changing stuff here !!!!
      lvAutoMessage.Columns.Add("FromAddress", (int)(lvAutoMessage.Width * .20), HorizontalAlignment.Left);
      lvAutoMessage.Columns.Add("ToAddress", (int)(lvAutoMessage.Width * .20), HorizontalAlignment.Left);
      lvAutoMessage.Columns.Add("Body", (int)(lvAutoMessage.Width * .59), HorizontalAlignment.Left);

      // Set the hyperlinks in the GUI
      llblAxLink.Text = "Try other SMS software products by Auron Software.";
      llblAxLink.Links.Add(llblAxLink.Text.IndexOf("SMS software products"), "SMS software products".Length, "https://www.auronsoftware.com/products/");
      llblAxLink.LinkClicked += new LinkLabelLinkClickedEventHandler(llblAxLink_LinkClicked);

      llblFooterText.Text = "Auron SMPP Simulator is freeware. It uses Auron SMS Component.\r\n";
      llblFooterText.Text += "For more information on Auron SMS products, click here.";
      llblFooterText.Links.Add(llblFooterText.Text.IndexOf("click here"), "click here".Length, "https://www.auronsoftware.com/products/");
      llblFooterText.LinkClicked += new LinkLabelLinkClickedEventHandler(llblAxLink_LinkClicked);

      // Initialize model
      m_objSimModel.LastReference = objSettings.LastReference + SimConstants.ADDREFERENCES_ONAPPSTART;
      m_objSimModel.Port = objSettings.Port;
      m_objSimModel.IpVersion = objSettings.IpVersion;
      m_objSimModel.IsAuthRequired = objSettings.AuthRequired;
      m_objSimModel.SystemId = objSettings.SystemId;
      m_objSimModel.Password = objSettings.Password;
      m_objSimModel.IsPduLogEnabled = objSettings.PduLogEnabled;
      m_objSimModel.IsServerLogEnabled = objSettings.ServerLogEnabled;
      m_objSimModel.IsSessionLogEnabled = objSettings.SessionLogEnabled;
      m_objSimModel.ServerLog = objSettings.ServerLog;
      m_objSimModel.SessionLog = objSettings.SessionLog;
      m_objSimModel.GeneratePerMinute = objSettings.GeneratePerMinute;
      m_objSimModel.RandomOrder = objSettings.RandomOrder;
      m_objSimModel.Echo = objSettings.Echo;
      m_objSimModel.PduTimeout = objSettings.PduTimeout;
      m_objSimModel.EnquireInterval = objSettings.EnquireInterval;
      m_objSimModel.UseGsmEncoding = objSettings.UseGsmEncoding;
      m_objSimModel.MultipartMode = objSettings.MultipartMode;
      m_objSimModel.DeliverMode = objSettings.DeliverMode;
      m_objSimModel.CertificateStore = objSettings.CertificateStore;

      m_nKeepMaxMessages = objSettings.KeepMessages;
      m_strAutoMessagesFile = objSettings.AutoMessageFile;

      // pre-load auto messages
      if (LoadAutoMessages(m_strAutoMessagesFile) != 0)
      {
        SimMessage objMessage = null;
        AddToAutoMessage(new SimMessage("+123123123", SimConstants.DEFAULT_FROMADDRESS, "Hello, World!"));
        AddToAutoMessage(objMessage = new SimMessage("+321321321", SimConstants.DEFAULT_FROMADDRESS, "مرحبا، العالم"));
        objMessage.DataCoding = m_objSmsConstants.DATACODING_UNICODE;
        AddToAutoMessage(objMessage = new SimMessage("+231231231", SimConstants.DEFAULT_FROMADDRESS, "नमस्ते दुनिया"));
        objMessage.DataCoding = m_objSmsConstants.DATACODING_DEFAULT;
        objMessage.LanguageShift = m_objSmsConstants.LANGUAGE_SINGLESHIFT_HINDI;
        AddToAutoMessage(objMessage = new SimMessage("+123123123", SimConstants.DEFAULT_FROMADDRESS, "48656c6c6f2c20576f726c6421"));
        objMessage.BodyFormat = m_objSmsConstants.BODYFORMAT_HEX;
      }
      PushAutoMessages();

      // Push error rates to model.
      SimErrorRates objErrorRates = new SimErrorRates();
      string strMessageRates = objSettings.MessageErrorRates;
      string strDeliveryRates = objSettings.DeliveryErrorRates;

      string[] aMessageRates = strMessageRates.Split(';');
      try
      {
        foreach (string strMessageRate in aMessageRates)
        {
          SimMessageErrorRate objErrr = new SimMessageErrorRate();
          string[] aMessageRate = strMessageRate.Split(',');
          objErrr.StatusCode = int.Parse(aMessageRate[0]);
          objErrr.Occurance = int.Parse(aMessageRate[1]);
          objErrorRates.MessageErrorRates.Add(objErrr);
        }
      }
      catch (Exception x)
      {
        m_Logger.WriteLine("Error while parsing message rates: {0}", x.ToString());
      }

      string[] aDeliveryRates = strDeliveryRates.Split(';');
      try
      {
        foreach (string strDeliveryRate in aDeliveryRates)
        {
          SimDeliveryErrorRate objErrr = new SimDeliveryErrorRate();
          string[] aDeliveryRate = strDeliveryRate.Split(',');
          objErrr.Code = int.Parse(aDeliveryRate[0]);
          objErrr.Text = aDeliveryRate[1];
          objErrr.Occurance = int.Parse(aDeliveryRate[2]);
          objErrorRates.DeliveryErrorRates.Add(objErrr);
        }
      }
      catch (Exception x)
      {
        m_Logger.WriteLine("Error while parsing delivery rates: {0}", x.ToString());
      }

      m_objSimModel.SetErrorRates(objErrorRates);

      // Set other control values
      txtServerLog.Text = m_objSimModel.ServerLog;
      txtSessionLog.Text = m_objSimModel.SessionLog;
      cbEnableServerLog.Checked = m_objSimModel.IsServerLogEnabled;
      cbEnableSessionLog.Checked = m_objSimModel.IsSessionLogEnabled;
      cbEnablePduLog.Checked = m_objSimModel.IsPduLogEnabled;
      cbAuthentication.Checked = m_objSimModel.IsAuthRequired;
      txtSystemId.Text = m_objSimModel.SystemId;
      txtPassword.Text = m_objSimModel.Password;
      txtMaxSendPerMinute.Text = m_objSimModel.GeneratePerMinute.ToString();
      cbRandom.Checked = m_objSimModel.RandomOrder;
      cbEcho.Checked = m_objSimModel.Echo;

      ReloadCertificates();

      objSettings.Save();
      UpdateControls();
    }

    private void ReloadCertificates()
    {
      var objSmppServer = new AxSms.SmppServer();

      if (cbxCertificate.DataSource != null)
        ((BindingSource)cbxCertificate.DataSource).Clear();

      var dctCertficates = new Dictionary<string, string>();
      dctCertficates.Add("<< Not Secured >>", "");
      objSmppServer.CertificateStore = m_objSimModel.CertificateStore;
      var sCertficateName = objSmppServer.FindFirstMyServerCertificate();
      while (objSmppServer.LastError == 0)
      {
        if (!dctCertficates.ContainsKey(sCertficateName))
          dctCertficates.Add(sCertficateName, sCertficateName);
        sCertficateName = objSmppServer.FindNextMyServerCertificate();
      }
      if (objSmppServer.LastError != SimConstants.ERRORCODE_NOMORE_CERTIFICATES)
      {
        MessageBox.Show("Could not open certificate store to inspect certificates.\r\n\r\n" +
          "Administrator rights are required to be able to open the Local Machine certificate store.",
          this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
      cbxCertificate.DisplayMember = "Key";
      cbxCertificate.ValueMember = "Value";
      cbxCertificate.DataSource = new BindingSource(dctCertficates, null);
    }


    private void UpdateControls()
    {
      bool bStarted = m_objSimModel.IsServerStarted;

      btnStart.Enabled = !bStarted;
      txtPort.Enabled = !bStarted;
      cbxIpVersion.Enabled = !bStarted;
      cbxCertificate.Enabled = !bStarted;
      btnServerOptions.Enabled = !bStarted;

      btnStop.Enabled = bStarted;
      grbMessages.Enabled = bStarted;
      grbSessions.Enabled = bStarted;

      btnInfoSession.Enabled = lvSessions.SelectedIndices.Count > 0;
      btnDropSession.Enabled = lvSessions.SelectedIndices.Count > 0;
      btnSendSession.Enabled = lvSessions.SelectedIndices.Count > 0;

      txtPassword.Enabled = cbAuthentication.Checked;
      txtSystemId.Enabled = cbAuthentication.Checked;

      cbEnableServerLog.Enabled = !bStarted;
      cbEnableSessionLog.Enabled = !bStarted;
      txtServerLog.Enabled = cbEnableServerLog.Checked && !bStarted;
      btnBrowseServerLogFile.Enabled = cbEnableServerLog.Checked && !bStarted;
      txtSessionLog.Enabled = cbEnableSessionLog.Checked && !bStarted;
      btnBrowseSessionLogFolder.Enabled = cbEnableSessionLog.Checked && !bStarted;
      cbEnablePduLog.Enabled = cbEnableSessionLog.Checked && !bStarted;
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      // This can take a second
      WaitCursor wait = new WaitCursor();

      // Set global atom to put the SMS Component into 'freeware mode'. 
      // The atom will be cleared by the SMS Component on detection.
      GlobalAddAtom(SimConstants.ATOM_FREEWAREMODE);
      if (txtPort.Text == string.Empty)
      {
        MessageBox.Show("Please enter a port number", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      // Set global settings 
      m_objSimModel.Port = int.Parse(txtPort.Text);
      m_objSimModel.IpVersion = (int)cbxIpVersion.SelectedValue;
      m_objSimModel.ServerLog = txtServerLog.Text;
      m_objSimModel.SessionLog = txtSessionLog.Text;
      m_objSimModel.IsPduLogEnabled = cbEnablePduLog.Checked;
      m_objSimModel.IsServerLogEnabled = cbEnableServerLog.Checked;
      m_objSimModel.IsSessionLogEnabled = cbEnableSessionLog.Checked;
      m_objSimModel.Certificate = (string)cbxCertificate.SelectedValue;
      SaveSettings();

      // flush worker command queue
      SimCommand objCommand = null;
      while ((objCommand = m_objSimWorker.PollWorker()) != null) { }

      m_objSimWorker.StartServer();

      // Wait a second for the server to start
      long lEndTo = GetTickCount() + 2000;
      objCommand = null;
      while ((objCommand = m_objSimWorker.PollWorker()) == null &&
          GetTickCount() < lEndTo) Thread.Sleep(10);

      // Display error
      if (objCommand != null && objCommand.LastError != 0)
      {
        string strMsg = string.Format("Error while starting SMPP server: {0}", objCommand.LastErrorDescription);
        MessageBox.Show(strMsg, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }
      else if (objCommand == null)
      {   // This is kindof a weird situation; try to clean everything up nicely..                
        MessageBox.Show("Error while starting SMPP server: startup timed out.",
            Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        btnStop.PerformClick();
        return;
      }

      tmrServer.Start();
      UpdateControls();
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      // This can take a second
      WaitCursor wait = new WaitCursor();

      tmrServer.Stop();
      m_objSimWorker.StopServer();
      lvSessions.Items.Clear();

      // Wait a second for the server to stop            
      while (m_objSimModel.IsServerStarted) Thread.Sleep(10);

      UpdateControls();
      SaveSettings();

      UpdateLables(0, 0);
    }

    private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
        e.Handled = true;
    }

    private void txtBox_TextChanged(object sender, EventArgs e)
    {
      TextBox textbox = ((TextBox)sender);
      if (textbox.Text.Length == 0)
        textbox.Text = "0";
      UpdateControls();
    }

    private void tmrServer_Tick(object sender, EventArgs e)
    {
      ////////////////////////////////////////////////////////////////////////////////
      // Update server status
      ////////////////////////////////////////////////////////////////////////////////
      if (!m_objSimModel.IsServerStarted)
      {
        tmrServer.Stop();
        UpdateControls();
        return;
      }

      ////////////////////////////////////////////////////////////////////////////////
      // Update session information
      ////////////////////////////////////////////////////////////////////////////////
      var lsSessions = m_objSimModel.GetSessions();
      foreach (SimSession objSession in lsSessions)
      {
        ListViewItem[] lvs = lvSessions.Items.Find(objSession.Id.ToString(), false);
        if (lvs.Length == 0)
        {   // Add new session information
          ListViewItem lvi = new ListViewItem(new String[]
          {
                        objSession.Ip, objSession.Port.ToString(), objSession.SystemId,
                        getSessionStateString(objSession.ConnectionState)
          });
          lvi.Tag = objSession;
          lvi.Name = objSession.Id.ToString();
          lvSessions.Items.Add(lvi);
        }
        else
        {   // Update session information
          ListViewItem lvi = lvs[0];
          lvi.SubItems[LVI_SESSION_SYSTEMID].Text = objSession.SystemId;
          lvi.SubItems[LVI_SESSION_CONNECTIONSTATE].Text =
              getSessionStateString(objSession.ConnectionState);
        }
      }

      ////////////////////////////////////////////////////////////////////////////////
      // Handle worker messages
      ////////////////////////////////////////////////////////////////////////////////

      SimCommand objCommand = null;
      while ((objCommand = m_objSimWorker.PollWorker()) != null)
      {
        if (objCommand.CommandId == SimCommand.ECommandId.DROPSESSION)
        {
          foreach (SimSession objSession in objCommand.Sessions)
            lvSessions.Items.RemoveByKey(objSession.Id.ToString());
        }
        else if (objCommand.CommandId == SimCommand.ECommandId.MESSAGESDELTA)
        {

          // These are new SMS messages that have been gerenated inside the worker thread
          m_nTotalMessages += objCommand.MessagesGenerated.Count;
          foreach (SimMessage objSms in objCommand.MessagesGenerated)
          {
            SimMessage objMessage = new SimMessage(objSms);
            objMessage.Direction = SimMessage.EMsgDir.OUT;
            AddToMessages(objMessage);
          }

          // These are SMS messages that are received in the worker thread
          m_nTotalMessages += objCommand.MessagesReceived.Count;
          foreach (SimMessage objSms in objCommand.MessagesReceived)
          {
            SimMessage objMessage = new SimMessage(objSms);
            objMessage.Direction = SimMessage.EMsgDir.IN;
            AddToMessages(objMessage);
          }

          // These are updates for SMS messages we already know about
          foreach (SimMessage objSms in objCommand.MessagesUpdated)
          {
            ListViewItem[] lvs = lvMessages.Items.Find(objSms.UserTag.ToString(), false);
            if (lvs.Length == 0) continue;

            ListViewItem objLvi = lvs[0];
            objLvi.SubItems[LVI_MESSAGE_STATE].Text = objSms.Status;
            if (objSms.Reference != null) objLvi.SubItems[LVI_MESSAGE_REFERENCE].Text = objSms.Reference;

            SimMessage objOther = (SimMessage)objLvi.Tag;
            objOther.Reference = objSms.Reference;
          }
        }
      }

      ////////////////////////////////////////////////////////////////////////////////
      // Update settings
      ////////////////////////////////////////////////////////////////////////////////

      m_objSimModel.SystemId = txtSystemId.Text;
      m_objSimModel.Password = txtPassword.Text;
      m_objSimModel.IsAuthRequired = cbAuthentication.Checked;

      m_objSimModel.GeneratePerMinute = int.Parse(txtMaxSendPerMinute.Text);
      m_objSimModel.RandomOrder = cbRandom.Checked;

      m_objSimModel.Echo = cbEcho.Checked;

      m_nKeepMaxMessages = int.Parse(txtKeepNumberMessages.Text);

      int nReceived = m_objSimModel.RecvPerSecond;
      int nSent = m_objSimModel.SentPerSecond;

      UpdateLables(nReceived, nSent);
    }

    private void UpdateLables(int nReceived, int nSent)
    {
      lblNumberMessages.Text = string.Format("{0} Message{1}", m_nTotalMessages, m_nTotalMessages == 1 ? "" : "s");
      lblActualSendMessages.Text = string.Format("{0} Sent msg/sec", nSent);
      lblActualReceivedMessages.Text = string.Format("{0} Recv msg/sec", nReceived);
      lblNumberMessagesSecond.Text = string.Format("{0} Msg/sec", nSent + nReceived);

      int nSessions = lvSessions.Items.Count;
      lblSessionsCount.Text = string.Format("{0} Session{1}", nSessions, nSessions == 1 ? "" : "s");
    }

    private void cbAuthentication_CheckedChanged(object sender, EventArgs e)
    {
      UpdateControls();
    }

    private void cbEnableServerLog_CheckedChanged(object sender, EventArgs e)
    {
      UpdateControls();
    }

    private void cbEnableSessionLog_CheckedChanged(object sender, EventArgs e)
    {
      UpdateControls();
    }

    private void btnInfoSession_Click(object sender, EventArgs e)
    {
      if (lvSessions.SelectedItems.Count == 0) return;

      SimSession objSession = (SimSession)lvSessions.SelectedItems[0].Tag;
      frmSessionInfo frm = new frmSessionInfo(objSession);
      frm.ShowDialog();
    }

    private void btnDropSession_Click(object sender, EventArgs e)
    {
      if (lvSessions.SelectedItems.Count == 0) return;
      SimSession objSession = (SimSession)lvSessions.SelectedItems[0].Tag;

      SimCommand objCommand = new SimCommand();
      objCommand.CommandId = SimCommand.ECommandId.DROPSESSION;
      objCommand.SessionId = objSession.Id;

      m_objSimWorker.PushWorker(objCommand);
    }

    private void btnSendSession_Click(object sender, EventArgs e)
    {
      if (lvSessions.SelectedItems.Count == 0) return;

      SimSession objSession = (SimSession)lvSessions.SelectedItems[0].Tag;
      frmSmsMessage frm = new frmSmsMessage(objSession, null, frmSmsMessage.EFrmType.SEND, m_objSimModel.MultipartMode, m_objSimModel.UseGsmEncoding);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        SimMessage objMessage = frm.Message;
        objMessage.SessionId = objSession.Id;
        objMessage.SystemId = objSession.SystemId;

        SimCommand objCommand = new SimCommand();
        objCommand.CommandId = SimCommand.ECommandId.SENDMESSAGE;
        objCommand.Message = new SimMessage(objMessage);
        objCommand.SessionId = objSession.Id;

        // Sending a new message is a kind of 'fire and forget', this
        // is because the message will be added to the back of the queue
        // in the worker thread. Actually waiting for the message to be
        // submitted to the session for delivery may take a while when
        // doing stress tests.
        m_objSimWorker.PushWorker(objCommand);
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      lvMessages.Items.Clear();
      m_nTotalMessages = 0;
    }

    private void btnAddAutoMessage_Click(object sender, EventArgs e)
    {
      frmSmsMessage frm = new frmSmsMessage(null, null, frmSmsMessage.EFrmType.CREATE, m_objSimModel.MultipartMode, m_objSimModel.UseGsmEncoding);
      if (frm.ShowDialog() == DialogResult.OK) AddToAutoMessage(frm.Message);
      PushAutoMessages();
    }

    private void btnEditAutoMessage_Click(object sender, EventArgs e)
    {
      if (lvAutoMessage.SelectedItems.Count <= 0) return;

      SimMessage objMessage = (SimMessage)lvAutoMessage.SelectedItems[0].Tag;
      frmSmsMessage frm = new frmSmsMessage(null, objMessage, frmSmsMessage.EFrmType.EDIT, m_objSimModel.MultipartMode, m_objSimModel.UseGsmEncoding);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        ListViewItem lvi = lvAutoMessage.SelectedItems[0];
        lvi.SubItems[AUTOMESSAGE_FROMADDRESS].Text = objMessage.FromAddress;
        lvi.SubItems[AUTOMESSAGE_TOADDRESS].Text = objMessage.ToAddress;
        lvi.SubItems[AUTOMESSAGE_BODY].Text = objMessage.Body;
      }
      PushAutoMessages();
    }

    private void btnDeleteAutoMessage_Click(object sender, EventArgs e)
    {
      if (lvAutoMessage.SelectedItems.Count <= 0) return;
      lvAutoMessage.Items.Remove(lvAutoMessage.SelectedItems[0]);
      PushAutoMessages();
    }

    private void btnLoadAutoMessage_Click(object sender, EventArgs e)
    {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.Filter = "XML Files|*.xml";

      if (dlg.ShowDialog() != DialogResult.OK) return;
      if (LoadAutoMessages(dlg.FileName) == 0)
      {   // If loading was successful make this the default
        m_strAutoMessagesFile = dlg.FileName;
        SaveSettings();
      }
      else
        MessageBox.Show("Error while loading XML file.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private int LoadAutoMessages(string strFile)
    {
      XmlTextReader objXml = null;

      try
      {
        var lsAutoMsg = new List<SimMessage>();
        objXml = new XmlTextReader(strFile);
        SimMessage objMessage = null;
        while (objXml.Read())
        {
          if (objXml.NodeType == XmlNodeType.Element &&
              objXml.Name == SimConstants.XML_AUTOMESSAGE_ELEMENT_NODE)
          {
            objMessage = new SimMessage(objXml[SimConstants.XML_AUTOMESSAGE_FIELD_TOADDRESS],
                objXml[SimConstants.XML_AUTOMESSAGE_FIELD_FROMADDRESS], objXml[SimConstants.XML_AUTOMESSAGE_FIELD_BODY]);
            objMessage.ToAddressNpi = int.Parse(objXml[SimConstants.XML_AUTOMESSAGE_FIELD_TONPI]);
            objMessage.ToAddressTon = int.Parse(objXml[SimConstants.XML_AUTOMESSAGE_FIELD_TOTON]);
            objMessage.FromAddressNpi = int.Parse(objXml[SimConstants.XML_AUTOMESSAGE_FIELD_FROMNPI]);
            objMessage.FromAddressTon = int.Parse(objXml[SimConstants.XML_AUTOMESSAGE_FIELD_FROMTON]);
            objMessage.HasUdh = bool.Parse(objXml[SimConstants.XML_AUTOMESSAGE_FIELD_HASUDH]);
            objMessage.IsDeliveryReport = bool.Parse(objXml[SimConstants.XML_AUTOMESSAGE_FIELD_ISDLR]);
            objMessage.DataCoding = int.Parse(objXml[SimConstants.XML_AUTOMESSAGE_FIELD_DATACODING]);
            objMessage.BodyFormat = int.Parse(objXml[SimConstants.XML_AUTOMESSAGE_FIELD_BODYFORMAT]);
            objMessage.LanguageShift = int.Parse(objXml[SimConstants.XML_AUTOMESSAGE_FIELD_LANGUAGESHIFT]);
            lsAutoMsg.Add(objMessage);
          }
          else if (objXml.NodeType == XmlNodeType.Element &&
              objXml.Name == SimConstants.XML_AUTOMESSAGE_ELEMENT_TLV)
          {
            SimTlv objTlv = new SimTlv();
            objTlv.Tag = int.Parse(objXml[SimConstants.XML_AUTOMESSAGE_FIELD_TAG]);
            objTlv.TlvType = (SimTlv.TlvTypes)Enum.Parse(typeof(SimTlv.TlvTypes), objXml[SimConstants.XML_AUTOMESSAGE_FIELD_TYPE]);
            objTlv.HexValue = objXml[SimConstants.XML_AUTOMESSAGE_FIELD_HEXVALUE];
            objTlv.TypedValue = objXml[SimConstants.XML_AUTOMESSAGE_FIELD_TYPEDVALUE];
            if (objMessage != null) objMessage.Tlvs.Add(objTlv);
          }
        }

        lvAutoMessage.Items.Clear();
        foreach (SimMessage objSms in lsAutoMsg)
          AddToAutoMessage(objSms);
        PushAutoMessages();
      }
      catch (Exception e)
      {   // Error while reading the XML file
        m_Logger.WriteLine("LoadAutoMessages failed, exception: {0}", e.ToString());
        return 1;
      }

      if (objXml != null) objXml.Close();

      return 0;
    }

    private void btnSaveAutoMessage_Click(object sender, EventArgs e)
    {
      SaveFileDialog dlg = new SaveFileDialog();
      dlg.Filter = "XML Files|*.xml";
      if (dlg.ShowDialog() != DialogResult.OK) return;

      XmlWriter objXmlWriter = null;

      try
      {   // Save to an XML file
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;

        objXmlWriter = XmlWriter.Create(dlg.FileName, settings);
        objXmlWriter.WriteStartDocument();
        objXmlWriter.WriteStartElement(SimConstants.XML_AUTOMESSAGE_ROOT_NODE);
        foreach (ListViewItem objLvi in lvAutoMessage.Items)
        {
          SimMessage objMessage = (SimMessage)objLvi.Tag;
          objXmlWriter.WriteStartElement(SimConstants.XML_AUTOMESSAGE_ELEMENT_NODE);
          objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_TOADDRESS, objMessage.ToAddress);
          objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_TONPI, objMessage.ToAddressNpi.ToString());
          objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_TOTON, objMessage.ToAddressTon.ToString());
          objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_FROMADDRESS, objMessage.FromAddress);
          objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_FROMNPI, objMessage.FromAddressNpi.ToString());
          objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_FROMTON, objMessage.FromAddressTon.ToString());
          objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_BODY, objMessage.Body);
          objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_HASUDH, objMessage.HasUdh.ToString());
          objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_ISDLR, objMessage.IsDeliveryReport.ToString());
          objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_BODYFORMAT, objMessage.BodyFormat.ToString());
          objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_DATACODING, objMessage.DataCoding.ToString());
          objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_LANGUAGESHIFT, objMessage.LanguageShift.ToString());
          foreach (SimTlv objTlv in objMessage.Tlvs)
          {
            objXmlWriter.WriteStartElement(SimConstants.XML_AUTOMESSAGE_ELEMENT_TLV);
            objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_TAG, objTlv.Tag.ToString());
            objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_TYPE, objTlv.TlvType.ToString());
            objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_HEXVALUE, objTlv.HexValue);
            objXmlWriter.WriteAttributeString(SimConstants.XML_AUTOMESSAGE_FIELD_TYPEDVALUE, objTlv.TypedValue);
            objXmlWriter.WriteEndElement();
          }
          objXmlWriter.WriteEndElement();
        }
        objXmlWriter.WriteEndElement();
        objXmlWriter.WriteEndDocument();
      }
      catch
      {
        m_Logger.WriteLine("SaveAutoMessages failed, exception: {0}", e.ToString());
        MessageBox.Show("Error while saving XML file.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }

      if (objXmlWriter != null) objXmlWriter.Close();
    }

    private void PushAutoMessages()
    {
      var lsAutoMessages = new List<SimMessage>();
      foreach (ListViewItem objLvi in lvAutoMessage.Items)
        lsAutoMessages.Add((SimMessage)objLvi.Tag);
      m_objSimModel.SetAutoMessages(lsAutoMessages);
    }

    private void AddToMessages(SimMessage objMessage)
    {
      string strReference = objMessage.Reference;
      if (objMessage.Direction == SimMessage.EMsgDir.OUT) strReference = "n/a";

      // Add new item to the top of the listview
      ListViewItem objLvi = null;
      lvMessages.Items.Insert(0, objLvi = new ListViewItem(new string[]
      {
                objMessage.Direction.ToString(), objMessage.SystemId, objMessage.ToAddress, strReference,
                objMessage.Status, objMessage.Body
      }));
      objLvi.Name = objMessage.UserTag.ToString();
      objLvi.Tag = objMessage;

      while (lvMessages.Items.Count > m_nKeepMaxMessages)
        lvMessages.Items.RemoveAt(lvMessages.Items.Count - 1);
    }

    private void AddToAutoMessage(SimMessage objMessage)
    {
      ListViewItem objLvi = null;
      lvAutoMessage.Items.Add(objLvi = new ListViewItem(new string[]
          {
                    objMessage.FromAddress, objMessage.ToAddress, objMessage.Body
          }));
      objLvi.Tag = objMessage;
    }

    private void btnBrowseServerLogFile_Click(object sender, EventArgs e)
    {
      SaveFileDialog dlg = new SaveFileDialog();
      dlg.Filter = "LOG files|*.log|Text Files|*.txt";
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        txtServerLog.Text = dlg.FileName;
      }
    }

    private void btnBrowseSessionLogFolder_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog dlg = new FolderBrowserDialog();

      if (dlg.ShowDialog() == DialogResult.OK)
      {
        txtSessionLog.Text = dlg.SelectedPath;
        if (!txtSessionLog.Text.EndsWith("\\"))
          txtSessionLog.Text += "\\";
      }
    }

    private void txtLastMessageReference_KeyPress(object sender, KeyPressEventArgs e)
    {
      char c = e.KeyChar;
      if (c != '\b' && !((c <= 'F' && c >= 'A') || (c <= 'f' && c >= 'a') || (c >= '0' && c <= '9')))
        e.Handled = true;
    }

    private void frmMain_SizeChanged(object sender, EventArgs e)
    {
      // Forces the listview to resize it's last collumn when the form resizes.
      // It does not do this automagically
      lvSessions.Columns[lvSessions.Columns.Count - 1].Width = -2;
      lvAutoMessage.Columns[lvAutoMessage.Columns.Count - 1].Width = -2;
      lvMessages.Columns[lvMessages.Columns.Count - 1].Width = -2;
    }

    void llblAxLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(e.Link.LinkData.ToString());
    }

    private void splitter_Paint(object sender, PaintEventArgs e)
    {
      Splitter splitter = (Splitter)sender;

      //Paint the three dots
      Point[] points = new Point[3];
      int w = splitter.Width;
      int h = splitter.Height;

      points[0] = new Point((w / 2));
      points[1] = new Point((points[0].X - 10));
      points[2] = new Point((points[0].X + 10));

      foreach (Point p in points)
      {
        p.Offset(-2, -2);
        e.Graphics.FillEllipse(SystemBrushes.ControlText,
            new Rectangle(p, new Size(3, 3)));

        p.Offset(1, 1);
        e.Graphics.FillEllipse(SystemBrushes.ControlLight,
            new Rectangle(p, new Size(3, 3)));
      }
    }

    private void lvSessions_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      btnInfoSession.PerformClick();
    }

    private void lvAutoReply_DoubleClick(object sender, EventArgs e)
    {
      btnEditAutoMessage.PerformClick();
    }

    private void lvMessages_DoubleClick(object sender, EventArgs e)
    {
      if (lvMessages.SelectedItems.Count <= 0) return;
      SimMessage objMessage = (SimMessage)lvMessages.SelectedItems[0].Tag;

      // See if I can find an active session for this message as well.
      // It's no problem if it's no longer there.
      SimSession objSession = null;
      ListViewItem[] lvs = lvSessions.Items.Find(objMessage.SessionId.ToString(), false);
      if (lvs.Length > 0) objSession = (SimSession)lvs[0].Tag;

      frmSmsMessage frm = new frmSmsMessage(objSession, objMessage, frmSmsMessage.EFrmType.VIEW, m_objSimModel.MultipartMode, m_objSimModel.UseGsmEncoding);

      // if it's a multipart message, try to find the rest of the parts as well
      if (objMessage.TotalParts > 1)
      {
        var lsParts = new List<SimMessage>();
        foreach (ListViewItem lvi in lvMessages.Items)
        {
          SimMessage objPart = (SimMessage)lvi.Tag;
          if (objPart.TotalParts > 1 &&
              objPart.MultipartReference == objMessage.MultipartReference &&
              objPart.Direction == objMessage.Direction)
          {
            lsParts.Add(objPart);
            if (lsParts.Count == objMessage.TotalParts)
              break;
          }
        }
        frm.Parts = lsParts;
      }

      frm.ShowDialog();
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      // If the server is started, press stop first .. 
      if (m_objSimModel.IsServerStarted)
        btnStop.PerformClick();
      SaveSettings();
    }

    private void SaveSettings()
    {
      var objSettings = Settings.Default;
      objSettings.LastReference = m_objSimModel.LastReference;
      objSettings.Port = m_objSimModel.Port;
      objSettings.IpVersion = m_objSimModel.IpVersion;
      objSettings.AuthRequired = m_objSimModel.IsAuthRequired;
      objSettings.SystemId = m_objSimModel.SystemId;
      objSettings.Password = m_objSimModel.Password;
      objSettings.PduLogEnabled = m_objSimModel.IsPduLogEnabled;
      objSettings.ServerLogEnabled = m_objSimModel.IsServerLogEnabled;
      objSettings.SessionLogEnabled = m_objSimModel.IsSessionLogEnabled;
      objSettings.ServerLog = m_objSimModel.ServerLog;
      objSettings.SessionLog = m_objSimModel.SessionLog;
      objSettings.GeneratePerMinute = m_objSimModel.GeneratePerMinute;
      objSettings.RandomOrder = m_objSimModel.RandomOrder;
      objSettings.Echo = m_objSimModel.Echo;
      objSettings.PduTimeout = m_objSimModel.PduTimeout;
      objSettings.EnquireInterval = m_objSimModel.EnquireInterval;
      objSettings.UseGsmEncoding = m_objSimModel.UseGsmEncoding;
      objSettings.MultipartMode = m_objSimModel.MultipartMode;
      objSettings.DeliverMode = m_objSimModel.DeliverMode;

      objSettings.KeepMessages = m_nKeepMaxMessages;
      objSettings.AutoMessageFile = m_strAutoMessagesFile;

      SimErrorRates objErrorRates = m_objSimModel.GetErrorRates();

      string strMessageRates = "";
      foreach (SimMessageErrorRate objErrr in objErrorRates.MessageErrorRates)
        strMessageRates += string.Format("{0},{1};", objErrr.StatusCode, objErrr.Occurance);
      strMessageRates = strMessageRates.TrimEnd(';');

      string strDeliveryRates = "";
      foreach (SimDeliveryErrorRate objErrr in objErrorRates.DeliveryErrorRates)
        strDeliveryRates += string.Format("{0},{1},{2};", objErrr.Code, objErrr.Text, objErrr.Occurance);
      strDeliveryRates = strDeliveryRates.TrimEnd(';');

      objSettings.MessageErrorRates = strMessageRates;
      objSettings.DeliveryErrorRates = strDeliveryRates;

      objSettings.Save();
    }

    private void btnErrors_Click(object sender, EventArgs e)
    {
      frmErrorRates objFrmErrorRates = new frmErrorRates(m_objSimModel.GetErrorRates());
      if (objFrmErrorRates.ShowDialog() == DialogResult.OK)
      {
        m_objSimModel.SetErrorRates(objFrmErrorRates.ErrorRates);
        SaveSettings();
      }
    }

    public string getSessionStateString(int nConnectionState)
    {
      return m_objSmsConstants.SmppSessionStateToString(nConnectionState).Replace("AXSMS_SMPP_SESSIONSTATE_", "");
    }

    private void frmMain_Resize(object sender, EventArgs e)
    {
      splitBottom.Invalidate();
      splitTop.Invalidate();
    }

    private void lvSessions_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateControls();
    }

    private void btnServerOptions_Click(object sender, EventArgs e)
    {
      frmOptions frm = new frmOptions(m_objSimModel);
      if (frm.ShowDialog() == DialogResult.OK)
      {        
        SaveSettings();
        ReloadCertificates();
      }        
    }
  }

  // Helper class for creating a waitcursor. Automatically reset on early return.
  public class WaitCursor
  {
    public WaitCursor()
    {
      Cursor.Current = Cursors.WaitCursor;
    }
    ~WaitCursor()
    {
      Cursor.Current = Cursors.Default;
    }
  }
}