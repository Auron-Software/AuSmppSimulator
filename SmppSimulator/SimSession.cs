//-----------------------------------------------------------------------
// <copyright file="SimSession.cs" company="Auron Software">
//     Copyright (c) Auron Software All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SmppSimulator
{
    using System;
    using System.Collections.Generic;

    [Serializable()]
    public class SimSession
    {
        #region variables
        //https://www.auronsoftware.com/kb/ausms-api-smppserver-properties-methods/
        private string m_strIP;
        private int m_nPort;
        private int m_nVersion;
        private string m_strSystemID;
        private string m_strPassword;
        private string m_strSystemType;
        private string m_strAddressRange;
        private int m_nAddressRangeTon;
        private int m_nAddressRangeNpi;
        private int m_nConnectionState;
        private int m_nRequestedBind;
        private int m_nId;        
        #endregion

        #region properties
        public string Ip                        {   get { return m_strIP; }             }
        public int Port                         {   get { return m_nPort; }             }
        public int Version                      {   get { return m_nVersion; }          }
        public string SystemId                  {   get { return m_strSystemID; }       }
        public string Password                  {   get { return m_strPassword; }       }
        public string SystemType                {   get { return m_strSystemType; }     }
        public string AddressRange              {   get { return m_strAddressRange; }   }
        public int AddressRangeTon              {   get { return m_nAddressRangeTon; }  }
        public int AddressRangeNpi              {   get { return m_nAddressRangeNpi; }  }
        public int ConnectionState              {   get { return m_nConnectionState; }  }
        public int RequestedBind                {   get { return m_nRequestedBind; }    }
        public int Id                           {   get { return m_nId; }               }
        #endregion
        
        public SimSession(AxSms.SmppSession objSession)
        {
            m_nId = objSession.Id;
            m_strIP = objSession.Ip;
            m_nPort = objSession.Port;
            m_nVersion = objSession.Version;
            m_strSystemID = objSession.SystemId;
            m_strPassword = objSession.Password;
            m_strSystemType = objSession.SystemType;
            m_strAddressRange = objSession.AddressRange;
            m_nAddressRangeTon = objSession.AddressRangeTon;
            m_nAddressRangeNpi = objSession.AddressRangeNpi;
            m_nConnectionState = objSession.ConnectionState;
            m_nRequestedBind = objSession.RequestedBind;
        }

        public SimSession(SimSession other)
        {
            this.m_nId = other.m_nId;
            this.m_strIP = other.m_strIP;
            this.m_nPort = other.m_nPort;
            this.m_nVersion = other.m_nVersion;
            this.m_strSystemID = other.m_strSystemID;
            this.m_strPassword = other.m_strPassword;
            this.m_strSystemType = other.m_strSystemType;
            this.m_strAddressRange = other.m_strAddressRange;
            this.m_nAddressRangeTon = other.m_nAddressRangeTon;
            this.m_nAddressRangeNpi = other.m_nAddressRangeNpi;
            this.m_nConnectionState = other.m_nConnectionState;
            this.m_nRequestedBind = other.m_nRequestedBind;
        }

        public override bool Equals(object other)
        {
            if (other == null || other.GetType() != typeof(SimSession)) return false;           
            return (m_nId == ((SimSession)other).m_nId);
        }

        public override int GetHashCode()
        {
            return m_strIP.GetHashCode() ^ m_strIP.GetHashCode();
        }
    }
}
