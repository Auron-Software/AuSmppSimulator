//-----------------------------------------------------------------------
// <copyright file="SimErrorRates.cs" company="Auron Software">
//     Copyright (c) Auron Software All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SmppSimulator
{
    using System.Collections.Generic;

    public class SimErrorRates
    {
        private List<SimMessageErrorRate> m_lsMessageErrorRates = new List<SimMessageErrorRate>();
        private List<SimDeliveryErrorRate> m_lsDeliveryErrorRates = new List<SimDeliveryErrorRate>();

        public List<SimDeliveryErrorRate> DeliveryErrorRates
        {
            get { return m_lsDeliveryErrorRates; }
        }

        public List<SimMessageErrorRate> MessageErrorRates
        {
            get { return m_lsMessageErrorRates; }
        }

        public SimErrorRates() { }

        public SimErrorRates(SimErrorRates objOther)
        {
            foreach (SimMessageErrorRate objRate in objOther.m_lsMessageErrorRates)
                m_lsMessageErrorRates.Add(new SimMessageErrorRate(objRate));

            foreach (SimDeliveryErrorRate objRate in objOther.m_lsDeliveryErrorRates)
                m_lsDeliveryErrorRates.Add(new SimDeliveryErrorRate(objRate));
        }
    }

    public class SimDeliveryErrorRate
    {
        private int m_nCode, m_nOccurance;
        private string m_strText;

        public string Text
        {
            get { return m_strText; }
            set { m_strText = value; }
        }

        public int Code
        {
            get { return m_nCode; }
            set { m_nCode = value; }
        }

        public int Occurance
        {
            get { return m_nOccurance; }
            set { m_nOccurance = value; }
        }

        public SimDeliveryErrorRate() { }

        public SimDeliveryErrorRate(string strText, int nCode, int nOccurance)
        {
            m_strText = strText;
            m_nCode = nCode;
            m_nOccurance = nOccurance;
        }

        public SimDeliveryErrorRate(SimDeliveryErrorRate other)
        {
            m_strText = other.m_strText;
            m_nCode = other.m_nCode;
            m_nOccurance = other.m_nOccurance;
        }
    }

    public class SimMessageErrorRate
    {
        private int m_nStatusCode, m_nOccurance;

        public int StatusCode
        {
            get { return m_nStatusCode; }
            set { m_nStatusCode = value; }
        }

        public int Occurance
        {
            get { return m_nOccurance; }
            set { m_nOccurance = value; }
        }

        public SimMessageErrorRate() { }

        public SimMessageErrorRate(int nStatusCode, int nOccurance)
        {
            m_nStatusCode = nStatusCode;
            m_nOccurance = nOccurance;
        }

        public SimMessageErrorRate(SimMessageErrorRate other)
        {
            m_nStatusCode = other.m_nStatusCode;
            m_nOccurance = other.m_nOccurance;
        }
    }
}
