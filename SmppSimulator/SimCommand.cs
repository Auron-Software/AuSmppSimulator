//-----------------------------------------------------------------------
// <copyright file="SimSettings.cs" company="Auron Software">
//     Copyright (c) Auron Software All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace SmppSimulator
{
    public class SimCommand
    {
        public enum ECommandId { DROPSESSION, SENDMESSAGE, RESPONSECODE, MESSAGESDELTA }

        #region variables
        private ECommandId m_eCommandId;
        private int m_nSessionId;
        private SimMessage m_objMessage;
        private int m_nLastError;
        private string m_strLastErrorDescription;
        private List<SimMessage> m_lsMessagesUpdated;
        private List<SimMessage> m_lsMessagesReceived;
        private List<SimMessage> m_lsMessagesGenerated;
        private List<SimSession> m_lsSessions;
        #endregion

        #region properties
        public ECommandId CommandId
        {
            get { return m_eCommandId; }
            set { m_eCommandId = value; }
        }
        public int SessionId
        {
            get { return m_nSessionId; }
            set { m_nSessionId = value; }
        }
        public SimMessage Message
        {
            get { return m_objMessage; }
            set { m_objMessage = value; }
        }
        public int LastError
        {
            get { return m_nLastError; }
            set { m_nLastError = value; }
        }
        public string LastErrorDescription
        {
            get { return m_strLastErrorDescription; }
            set { m_strLastErrorDescription = value; }
        }
        public List<SimMessage> MessagesGenerated
        {
            get { return m_lsMessagesGenerated; }
            set { m_lsMessagesGenerated = value; }
        }
        public List<SimMessage> MessagesReceived
        {
            get { return m_lsMessagesReceived; }
            set { m_lsMessagesReceived = value; }
        }
        public List<SimMessage> MessagesUpdated
        {
            get { return m_lsMessagesUpdated; }
            set { m_lsMessagesUpdated = value; }
        }
        public List<SimSession> Sessions
        {
            get { return m_lsSessions; }
            set { m_lsSessions = value; }
        }
        #endregion        

        public SimCommand(SimCommand objOther)
        {
        }

        public SimCommand() 
        {
        }
    }
}
