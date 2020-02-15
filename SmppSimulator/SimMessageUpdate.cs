//-----------------------------------------------------------------------
// <copyright file="SimMessageUpdate.cs" company="Auron Software">
//     Copyright (c) Auron Software All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SmppSimulator
{    
    public class SimMessageUpdate
    {
        #region variables
        private int m_nUserTag; 
        private string m_strMessageState;
        private string m_strReference;
        #endregion

        #region properties
        public int UserTag              {   get { return m_nUserTag; }          }
        public string MessageState      {   get { return m_strMessageState; }   }
        public string Reference         {   get { return m_strReference; }
                                            set { m_strReference = value; }     }
        #endregion

        public SimMessageUpdate(int nUserTag, string strMessageState, string strReference)
        {
            m_nUserTag = nUserTag;
            m_strMessageState = strMessageState;
            m_strReference = strReference;
        }

        public SimMessageUpdate(SimMessageUpdate other)
        {
            m_nUserTag = other.m_nUserTag;
            m_strMessageState = other.m_strMessageState;
            m_strReference = other.m_strReference;
        }
    }
}
