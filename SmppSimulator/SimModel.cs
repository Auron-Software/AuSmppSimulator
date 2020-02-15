//-----------------------------------------------------------------------
// <copyright file="SimModel.cs" company="Auron Software">
//     Copyright (c) Auron Software All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SmppSimulator
{
  using System;
  using System.Collections.Generic;
  using System.Configuration;
  using Microsoft.Win32;

  public class SimModel
  {
    #region variables        
    private bool m_bIsServerStarted;

    private int m_nLastReference;
    private int m_nLastUserTag;

    private int m_nPort;
    private int m_nIpVersion;

    private bool m_bIsAuthRequired;
    private string m_strSystemId;
    private string m_strPassword;

    private bool m_bIsPduLogEnabled;
    private bool m_bIsServerLogEnabled;
    private bool m_bIsSessionLogEnabled;
    private string m_strServerLog;
    private string m_strSessionLog;

    private int m_nGeneratePerMinute;
    private bool m_bRandomOrder;

    private bool m_bEcho;

    private int m_nSentPerSecond;
    private int m_nRecvPerSecond;

    private int m_iPduTimeout;
    private int m_iEnquireInterval;
    private int m_iUseGsmEncoding;
    private int m_iMultipartMode;
    private int m_iDeliverMode;

    private int m_iCertificateStore;

    private string m_sCertificate;

    private SimErrorRates m_objErrorRates = new SimErrorRates();

    private List<SimSession> m_lsSession = new List<SimSession>();
    private List<SimSession> m_lsDisconnected = new List<SimSession>();
    private List<SimMessage> m_lsAutoMessages = new List<SimMessage>();
    #endregion

    #region properties

    public int LastReference
    {
      get { lock (this) { return m_nLastReference; } }
      set { lock (this) { m_nLastReference = value; } }
    }
    public int LastUserTag
    {
      get { lock (this) { return m_nLastUserTag; } }
      set { lock (this) { m_nLastUserTag = value; } }
    }
    public int Port
    {
      get { lock (this) { return m_nPort; } }
      set { lock (this) { m_nPort = value; } }
    }
    public int IpVersion
    {
      get { lock (this) { return m_nIpVersion; } }
      set { lock (this) { m_nIpVersion = value; } }
    }
    public string SystemId
    {
      get { lock (this) { return m_strSystemId; } }
      set { lock (this) { m_strSystemId = value; } }
    }
    public string Password
    {
      get { lock (this) { return m_strPassword; } }
      set { lock (this) { m_strPassword = value; } }
    }
    public bool IsAuthRequired
    {
      get { lock (this) { return m_bIsAuthRequired; } }
      set { lock (this) { m_bIsAuthRequired = value; } }
    }
    public bool IsPduLogEnabled
    {
      get { lock (this) { return m_bIsPduLogEnabled; } }
      set { lock (this) { m_bIsPduLogEnabled = value; } }
    }
    public bool IsServerLogEnabled
    {
      get { lock (this) { return m_bIsServerLogEnabled; } }
      set { lock (this) { m_bIsServerLogEnabled = value; } }
    }
    public bool IsSessionLogEnabled
    {
      get { lock (this) { return m_bIsSessionLogEnabled; } }
      set { lock (this) { m_bIsSessionLogEnabled = value; } }
    }
    public string ServerLog
    {
      get { lock (this) { return m_strServerLog; } }
      set { lock (this) { m_strServerLog = value; } }
    }
    public string SessionLog
    {
      get { lock (this) { return m_strSessionLog; } }
      set { lock (this) { m_strSessionLog = value; } }
    }
    public bool IsServerStarted
    {
      get { lock (this) { return m_bIsServerStarted; } }
      set { lock (this) { m_bIsServerStarted = value; } }
    }
    public int GeneratePerMinute
    {
      get { lock (this) { return m_nGeneratePerMinute; } }
      set { lock (this) { m_nGeneratePerMinute = value; } }
    }
    public bool RandomOrder
    {
      get { lock (this) { return m_bRandomOrder; } }
      set { lock (this) { m_bRandomOrder = value; } }
    }
    public int SentPerSecond
    {
      get { lock (this) { return m_nSentPerSecond; } }
      set { lock (this) { m_nSentPerSecond = value; } }
    }
    public int RecvPerSecond
    {
      get { lock (this) { return m_nRecvPerSecond; } }
      set { lock (this) { m_nRecvPerSecond = value; } }
    }
    public bool Echo
    {
      get { lock (this) { return m_bEcho; } }
      set { lock (this) { m_bEcho = value; } }
    }
    public int EnquireInterval
    {
      get { lock (this) { return m_iEnquireInterval; } }
      set { lock (this) { m_iEnquireInterval = value; } }
    }
    public int PduTimeout
    {
      get { lock (this) { return m_iPduTimeout; } }
      set { lock (this) { m_iPduTimeout = value; } }
    }
    public int UseGsmEncoding
    {
      get { lock (this) { return m_iUseGsmEncoding; } }
      set { lock (this) { m_iUseGsmEncoding = value; } }
    }
    public int MultipartMode
    {
      get { lock (this) { return m_iMultipartMode; } }
      set { lock (this) { m_iMultipartMode = value; } }
    }
    public int DeliverMode
    {
      get { lock (this) { return m_iDeliverMode; } }
      set { lock (this) { m_iDeliverMode = value; } }
    }
    public int CertificateStore
    {
      get { lock (this) { return m_iCertificateStore;  } }
      set { lock (this) { m_iCertificateStore = value; } }
    }    
    public string Certificate
    {
      get { lock (this) { return m_sCertificate;  } }
      set { lock (this) { m_sCertificate = value; } }
    }
    #endregion

    public SimModel()
    {
    }

    public int GetAndIncLastUserTag()
    {
      lock (this)
      {
        return ++m_nLastUserTag;
      }
    }

    public void SetErrorRates(SimErrorRates objErrorRates)
    {
      lock (this)
      {
        m_objErrorRates = new SimErrorRates(objErrorRates);
      }
    }

    public SimErrorRates GetErrorRates()
    {
      lock (this)
      {
        return new SimErrorRates(m_objErrorRates);
      }
    }

    public void SetAutoMessages(List<SimMessage> lsMessages)
    {
      lock (this)
      {
        m_lsAutoMessages.Clear();
        foreach (SimMessage objMessage in lsMessages)
          m_lsAutoMessages.Add(new SimMessage(objMessage));
      }
    }

    public List<SimMessage> GetAutoMessages()
    {
      var lsAutoMessages = new List<SimMessage>();
      lock (this)
      {
        foreach (SimMessage objMessage in m_lsAutoMessages)
          lsAutoMessages.Add(new SimMessage(objMessage));
      }
      return lsAutoMessages;
    }

    public void SetSessions(List<SimSession> lsSessions)
    {
      lock (this)
      {
        m_lsSession.Clear();
        foreach (SimSession objSession in lsSessions)
          m_lsSession.Add(new SimSession(objSession));
      }
    }

    public List<SimSession> GetSessions()
    {
      var lsSessions = new List<SimSession>();
      lock (this)
      {
        foreach (SimSession objSession in m_lsSession)
          lsSessions.Add(new SimSession(objSession));
      }
      return lsSessions;
    }

    public void SetDisconnected(List<SimSession> lsSessions)
    {
      lock (this)
      {
        m_lsDisconnected.Clear();
        foreach (SimSession objSession in lsSessions)
          m_lsDisconnected.Add(new SimSession(objSession));
      }
    }

    public List<SimSession> GetDisconnected()
    {
      var lsSessions = new List<SimSession>();
      lock (this)
      {
        foreach (SimSession objSession in m_lsDisconnected)
          lsSessions.Add(new SimSession(objSession));
      }
      return lsSessions;
    }
  }
}
