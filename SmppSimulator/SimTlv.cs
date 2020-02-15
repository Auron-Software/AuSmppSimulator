using System;
using System.Collections.Generic;
using System.Text;
using AxSms;

namespace SmppSimulator
{
    public class SimTlv
    {
        public enum TlvTypes { STRING, HEX, INT32, INT16, INT8 }
                
        private int m_nTag;
        private TlvTypes m_eTlvType;
        private string m_stTypedValue;      // The value as entered by the user
        private string m_strHexValue;       // The binary value

        public int Tag
        {
            get { return m_nTag; }
            set { m_nTag = value; }
        }

        public string TypedValue
        {
            get { return m_stTypedValue; }
            set { m_stTypedValue = value; }
        }

        public string HexValue
        {
            get { return m_strHexValue; }
            set { m_strHexValue = value; }
        }

        public TlvTypes TlvType
        {
            get { return m_eTlvType; }
            set { m_eTlvType = value; }
        }

        public SimTlv() { }
        public SimTlv(SimTlv objOther)
        {
            m_nTag = objOther.m_nTag;
            m_eTlvType = objOther.m_eTlvType;
            m_stTypedValue = objOther.m_stTypedValue;
            m_strHexValue = objOther.m_strHexValue;
        }
        public SimTlv(Tlv objTlv)
        {
            m_nTag = objTlv.Tag;
            m_eTlvType = TlvTypes.HEX;
            m_stTypedValue = objTlv.ValueAsHexString;
            m_strHexValue = m_stTypedValue;
        }
    }
}
