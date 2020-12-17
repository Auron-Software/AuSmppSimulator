//-----------------------------------------------------------------------
// <copyright file="SimMessage.cs" company="Auron Software">
//     Copyright (c) Auron Software All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SmppSimulator
{
    using AxSms;
    using System.Collections.Generic;

    public class SimMessage
    {
        public enum EMsgDir { IN, OUT }

        #region variables
        private int m_nUserTag;
        private string m_strToAddress;
        private string m_strFromAddress;
        private string m_strBody;
        private bool m_bRequestDeliveryReport;
        private int m_nToAddressTon;
        private int m_nToAddressNpi;
        private int m_nFromAddressTon;
        private int m_nFromAddressNpi;
        private string m_strReference;
        private int m_nDataCoding;
        private int m_nBodyFormat;
        private bool m_bHasUdh;
        private bool m_bIsDeliveryReport;
        private int m_nCommandStatus;
        private int m_nSequenceNumber;
        private int m_nTotalParts;
        private int m_nPartNumber;
        private int m_nMultipartReference;
        private int m_nLanguageShift;
        private List<SimTlv> m_lsTlvs = new List<SimTlv>();

        private int m_nSessionId;
        private string m_strSystemId;
        private string m_strStatus;

        EMsgDir m_eDirection;

        #endregion

        #region properties
        public int UserTag
        {
            get { return m_nUserTag; }
            set { m_nUserTag = value; }
        }
        public string ToAddress
        {
            get { return m_strToAddress; }
            set { m_strToAddress = value; }
        }
        public string FromAddress
        {
            get { return m_strFromAddress; }
            set { m_strFromAddress = value; }
        }
        public string Body
        {
            get { return m_strBody; }
            set { m_strBody = value; }
        }
        public bool RequestDeliveryReport
        {
            get { return m_bRequestDeliveryReport; }
            set { m_bRequestDeliveryReport = value; }
        }
        public int ToAddressTon
        {
            get { return m_nToAddressTon; }
            set { m_nToAddressTon = value; }
        }
        public int ToAddressNpi
        {
            get { return m_nToAddressNpi; }
            set { m_nToAddressNpi = value; }
        }
        public int FromAddressTon
        {
            get { return m_nFromAddressTon; }
            set { m_nFromAddressTon = value; }
        }
        public int FromAddressNpi
        {
            get { return m_nFromAddressNpi; }
            set { m_nFromAddressNpi = value; }
        }
        public string Reference
        {
            get { return m_strReference; }
            set { m_strReference = value; }
        }
        public int DataCoding
        {
            get { return m_nDataCoding; }
            set { m_nDataCoding = value; }
        }
        public int LanguageShift
        {
            get { return m_nLanguageShift; }
            set { m_nLanguageShift = value; }
        }
        public int BodyFormat
        {
            get { return m_nBodyFormat; }
            set { m_nBodyFormat = value; }
        }
        public bool HasUdh
        {
            get { return m_bHasUdh; }
            set { m_bHasUdh = value; }
        }
        public bool IsDeliveryReport
        {
            get { return m_bIsDeliveryReport; }
            set { m_bIsDeliveryReport = value; }
        }
        public int CommandStatus
        {
            get { return m_nCommandStatus; }
            set { m_nCommandStatus = value; }
        }
        public int SequenceNumber
        {
            get { return m_nSequenceNumber; }
            set { m_nSequenceNumber = value; }
        }
        public int SessionId
        {
            get { return m_nSessionId; }
            set { m_nSessionId = value; }
        }
        public string SystemId
        {
            get { return m_strSystemId; }
            set { m_strSystemId = value; }
        }
        public List<SimTlv> Tlvs
        {
            get { return m_lsTlvs; }
            set { m_lsTlvs = value; }
        }
        public string Status
        {
            get { return m_strStatus; }
            set { m_strStatus = value; }
        }
        public int TotalParts
        {
            get { return m_nTotalParts; }
            set { m_nTotalParts = value; }
        }
        public int PartNumber
        {
            get { return m_nPartNumber; }
            set { m_nPartNumber = value; }
        }
        public int MultipartReference
        {
            get { return m_nMultipartReference; }
            set { m_nMultipartReference = value; }
        }
        public EMsgDir Direction
        {
            get { return m_eDirection; }
            set { m_eDirection = value; }
        }
        #endregion

        public SimMessage() { }

        public SimMessage(string strToAddress, string strFromAddress, string strBody)
        {
            ToAddress = strToAddress;
            FromAddress = strFromAddress;
            Body = strBody;
        }

        public SimMessage(SimMessage objOther)
        {
            m_nUserTag = objOther.m_nUserTag;
            m_strToAddress = objOther.m_strToAddress;
            m_strFromAddress = objOther.m_strFromAddress;
            m_strBody = objOther.m_strBody;
            m_bRequestDeliveryReport = objOther.m_bRequestDeliveryReport;
            m_nToAddressTon = objOther.m_nToAddressTon;
            m_nToAddressNpi = objOther.m_nToAddressNpi;
            m_nFromAddressTon = objOther.m_nFromAddressTon;
            m_nFromAddressNpi = objOther.m_nFromAddressNpi;
            m_strReference = objOther.m_strReference;
            m_nDataCoding = objOther.m_nDataCoding;
            m_nBodyFormat = objOther.m_nBodyFormat;
            m_bHasUdh = objOther.m_bHasUdh;
            m_bIsDeliveryReport = objOther.m_bIsDeliveryReport;
            m_nCommandStatus = objOther.m_nCommandStatus;
            m_nSequenceNumber = objOther.m_nSequenceNumber;
            m_nTotalParts = objOther.m_nTotalParts;
            m_nPartNumber = objOther.m_nPartNumber;
            m_nMultipartReference = objOther.m_nMultipartReference;
            m_nLanguageShift = objOther.m_nLanguageShift;

            m_nSessionId = objOther.m_nSessionId;
            m_strSystemId = objOther.m_strSystemId;
            m_strStatus = objOther.m_strStatus;

            m_eDirection = objOther.m_eDirection;

            foreach (SimTlv objTlv in objOther.m_lsTlvs)
                m_lsTlvs.Add(new SimTlv(objTlv));
        }

        public SimMessage(AxSms.Message objMessage)
        {
            m_nUserTag = objMessage.UserTag;
            m_strFromAddress = objMessage.FromAddress;
            m_strToAddress = objMessage.ToAddress;
            m_strBody = objMessage.Body;
            m_bRequestDeliveryReport = objMessage.RequestDeliveryReport;
            m_nToAddressNpi = objMessage.ToAddressNPI;
            m_nToAddressTon = objMessage.ToAddressTON;
            m_nFromAddressNpi = objMessage.FromAddressNPI;
            m_nFromAddressTon = objMessage.FromAddressTON;
            m_strReference = objMessage.Reference;
            m_nDataCoding = objMessage.DataCoding;
            m_nBodyFormat = objMessage.BodyFormat;
            m_bHasUdh = objMessage.HasUdh;
            m_bIsDeliveryReport = objMessage.SmppIsDeliveryReport;
            m_nCommandStatus = objMessage.SmppCommandStatus;
            m_nSequenceNumber = objMessage.SmppSequenceNumber;
            m_nTotalParts = objMessage.TotalParts;
            m_nPartNumber = objMessage.PartNumber;
            m_nMultipartReference = objMessage.MultipartRef;
            m_nLanguageShift = objMessage.LanguageSingleShift;

            AxSms.Tlv objTlv = objMessage.SmppGetFirstTlv();
            while (objMessage.LastError == 0)
            {
                m_lsTlvs.Add(new SimTlv(objTlv));
                objTlv = objMessage.SmppGetNextTlv();
            }
        }
                
        public AxSms.Message CreateAxSms()
        {
            AxSms.Message objResult = new AxSms.Message();
            objResult.UserTag = UserTag;
            objResult.FromAddress = FromAddress;
            objResult.ToAddress = ToAddress;
            objResult.Body = Body;
            objResult.RequestDeliveryReport = RequestDeliveryReport;
            objResult.ToAddressNPI = ToAddressNpi;
            objResult.ToAddressTON = ToAddressTon;
            objResult.FromAddressNPI = FromAddressNpi;
            objResult.FromAddressTON = FromAddressTon;
            objResult.Reference = Reference;
            objResult.DataCoding = DataCoding;
            objResult.BodyFormat = BodyFormat;
            objResult.HasUdh = HasUdh;            
            objResult.SmppIsDeliveryReport = IsDeliveryReport;
            objResult.SmppCommandStatus = CommandStatus;
            objResult.LanguageSingleShift = LanguageShift;
            objResult.LanguageLockingShift = LanguageShift;

            foreach (SimTlv objTlv in Tlvs)
            {
                AxSms.Tlv objAxTlv = new AxSms.Tlv();
                objAxTlv.Tag = objTlv.Tag;
                objAxTlv.ValueAsHexString = objTlv.HexValue;
                objResult.SmppAddTlv(objAxTlv);
            }

            return objResult;
        }
    }
}
