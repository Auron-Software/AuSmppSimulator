using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmppSimulator
{
    public partial class frmSimTlv : Form
    {
        public enum EFrmType { ADD, EDIT, VIEW }
        private const int CUSTOM_TAG = -1;

        private SimTlv m_objSimTlv;
        private EFrmType m_eFrmType;

        private Dictionary<String, int> dctTags;

        public SimTlv Tlv
        {
            get { return m_objSimTlv; }
            set { m_objSimTlv = value; }
        }

        public frmSimTlv(SimTlv objTlv, EFrmType eFrmType)
        {
            InitializeComponent();

            m_eFrmType = eFrmType;
            switch (m_eFrmType)
            {
                case EFrmType.ADD:
                    Text = "Create new Tlv";
                    break;
                case EFrmType.EDIT:
                    Text = "Edit Tlv";
                    break;
            }

            if (objTlv == null) m_objSimTlv = new SimTlv();
            else m_objSimTlv = objTlv;
        }

        private void frmSimTlv_Load(object sender, EventArgs e)
        {
            // Fill comboboxes
            AxSms.Constants objConstants = new AxSms.Constants();

            dctTags = new Dictionary<String, int>();
            dctTags.Add("<Custom Tag>", CUSTOM_TAG);
            dctTags.Add("SMPP_TLV_DEST_ADDR_SUBUNIT", objConstants.SMPP_TLV_DEST_ADDR_SUBUNIT);
            dctTags.Add("SMPP_TLV_DEST_NETWORK_TYPE", objConstants.SMPP_TLV_DEST_NETWORK_TYPE);
            dctTags.Add("SMPP_TLV_DEST_BEARER_TYPE", objConstants.SMPP_TLV_DEST_BEARER_TYPE);
            dctTags.Add("SMPP_TLV_DEST_TELEMATICS_ID", objConstants.SMPP_TLV_DEST_TELEMATICS_ID);
            dctTags.Add("SMPP_TLV_SOURCE_ADDR_SUBUNIT", objConstants.SMPP_TLV_SOURCE_ADDR_SUBUNIT);
            dctTags.Add("SMPP_TLV_SOURCE_NETWORK_TYPE", objConstants.SMPP_TLV_SOURCE_NETWORK_TYPE);
            dctTags.Add("SMPP_TLV_SOURCE_BEARER_TYPE", objConstants.SMPP_TLV_SOURCE_BEARER_TYPE);
            dctTags.Add("SMPP_TLV_SOURCE_TELEMATICS_ID", objConstants.SMPP_TLV_SOURCE_TELEMATICS_ID);
            dctTags.Add("SMPP_TLV_QOS_TIME_TO_LIVE", objConstants.SMPP_TLV_QOS_TIME_TO_LIVE);
            dctTags.Add("SMPP_TLV_PAYLOAD_TYPE", objConstants.SMPP_TLV_PAYLOAD_TYPE);
            dctTags.Add("SMPP_TLV_ADDITIONAL_STATUS_INFO_TEXT", objConstants.SMPP_TLV_ADDITIONAL_STATUS_INFO_TEXT);
            dctTags.Add("SMPP_TLV_RECEIPTED_MESSAGE_ID", objConstants.SMPP_TLV_RECEIPTED_MESSAGE_ID);
            dctTags.Add("SMPP_TLV_MS_MSG_WAIT_FACILITIES", objConstants.SMPP_TLV_MS_MSG_WAIT_FACILITIES);
            dctTags.Add("SMPP_TLV_PRIVACY_INDICATOR", objConstants.SMPP_TLV_PRIVACY_INDICATOR);
            dctTags.Add("SMPP_TLV_SOURCE_SUBADDRESS", objConstants.SMPP_TLV_SOURCE_SUBADDRESS);
            dctTags.Add("SMPP_TLV_DEST_SUBADDRESS", objConstants.SMPP_TLV_DEST_SUBADDRESS);
            dctTags.Add("SMPP_TLV_USER_MESSAGE_REFERENCE", objConstants.SMPP_TLV_USER_MESSAGE_REFERENCE);
            dctTags.Add("SMPP_TLV_USER_RESPONSE_CODE", objConstants.SMPP_TLV_USER_RESPONSE_CODE);
            dctTags.Add("SMPP_TLV_SOURCE_PORT", objConstants.SMPP_TLV_SOURCE_PORT);
            dctTags.Add("SMPP_TLV_DESTINATION_PORT", objConstants.SMPP_TLV_DESTINATION_PORT);
            dctTags.Add("SMPP_TLV_SAR_MSG_REF_NUM", objConstants.SMPP_TLV_SAR_MSG_REF_NUM);
            dctTags.Add("SMPP_TLV_LANGUAGE_INDICATOR", objConstants.SMPP_TLV_LANGUAGE_INDICATOR);
            dctTags.Add("SMPP_TLV_SAR_TOTAL_SEGMENTS", objConstants.SMPP_TLV_SAR_TOTAL_SEGMENTS);
            dctTags.Add("SMPP_TLV_SAR_SEGMENT_SEQNUM", objConstants.SMPP_TLV_SAR_SEGMENT_SEQNUM);
            dctTags.Add("SMPP_TLV_SC_INTERFACE_VERSION", objConstants.SMPP_TLV_SC_INTERFACE_VERSION);
            dctTags.Add("SMPP_TLV_CALLBACK_NUM_PRES_IND", objConstants.SMPP_TLV_CALLBACK_NUM_PRES_IND);
            dctTags.Add("SMPP_TLV_CALLBACK_NUM_ATAG", objConstants.SMPP_TLV_CALLBACK_NUM_ATAG);
            dctTags.Add("SMPP_TLV_NUMBER_OF_MESSAGES", objConstants.SMPP_TLV_NUMBER_OF_MESSAGES);
            dctTags.Add("SMPP_TLV_CALLBACK_NUM", objConstants.SMPP_TLV_CALLBACK_NUM);
            dctTags.Add("SMPP_TLV_DPF_RESULT", objConstants.SMPP_TLV_DPF_RESULT);
            dctTags.Add("SMPP_TLV_SET_DPF", objConstants.SMPP_TLV_SET_DPF);
            dctTags.Add("SMPP_TLV_MS_AVAILABILITY_STATUS", objConstants.SMPP_TLV_MS_AVAILABILITY_STATUS);
            dctTags.Add("SMPP_TLV_NETWORK_ERROR_CODE", objConstants.SMPP_TLV_NETWORK_ERROR_CODE);
            dctTags.Add("SMPP_TLV_MESSAGE_PAYLOAD", objConstants.SMPP_TLV_MESSAGE_PAYLOAD);
            dctTags.Add("SMPP_TLV_DELIVERY_FAILURE_REASON", objConstants.SMPP_TLV_DELIVERY_FAILURE_REASON);
            dctTags.Add("SMPP_TLV_MORE_MESSAGES_TO_SEND", objConstants.SMPP_TLV_MORE_MESSAGES_TO_SEND);
            dctTags.Add("SMPP_TLV_MESSAGE_STATE", objConstants.SMPP_TLV_MESSAGE_STATE);
            dctTags.Add("SMPP_TLV_CONGESTION_STATE", objConstants.SMPP_TLV_CONGESTION_STATE);
            dctTags.Add("SMPP_TLV_USSD_SERVICE_OP", objConstants.SMPP_TLV_USSD_SERVICE_OP);
            dctTags.Add("SMPP_TLV_DISPLAY_TIME", objConstants.SMPP_TLV_DISPLAY_TIME);
            dctTags.Add("SMPP_TLV_SMS_SIGNAL", objConstants.SMPP_TLV_SMS_SIGNAL);
            dctTags.Add("SMPP_TLV_MS_VALIDITY", objConstants.SMPP_TLV_MS_VALIDITY);
            dctTags.Add("SMPP_TLV_ALERT_ON_MESSAGE_DELIVERY", objConstants.SMPP_TLV_ALERT_ON_MESSAGE_DELIVERY);
            dctTags.Add("SMPP_TLV_ITS_REPLY_TYPE", objConstants.SMPP_TLV_ITS_REPLY_TYPE);
            dctTags.Add("SMPP_TLV_ITS_SESSION_INFO", objConstants.SMPP_TLV_ITS_SESSION_INFO);

            cbxTag.DisplayMember = "Key";
            cbxTag.ValueMember = "Value";
            cbxTag.DataSource = new BindingSource(dctTags, null);

            var dctTypes = new Dictionary<String, SimTlv.TlvTypes>();
            dctTypes.Add("Hex", SimTlv.TlvTypes.HEX);
            dctTypes.Add("String", SimTlv.TlvTypes.STRING);
            dctTypes.Add("Int32", SimTlv.TlvTypes.INT32);
            dctTypes.Add("Int16", SimTlv.TlvTypes.INT16);
            dctTypes.Add("Int8", SimTlv.TlvTypes.INT8);

            cbxType.DisplayMember = "Key";
            cbxType.ValueMember = "Value";
            cbxType.DataSource = new BindingSource(dctTypes, null);

            // Set properties
            if (dctTags.ContainsValue(m_objSimTlv.Tag))
                cbxTag.SelectedValue = m_objSimTlv.Tag;
            else
                cbxTag.SelectedValue = CUSTOM_TAG;
            txtTag.Text = m_objSimTlv.Tag.ToString();

            cbxType.SelectedValue = m_objSimTlv.TlvType;
            AxSms.Tlv objTlv = new AxSms.Tlv();
            objTlv.ValueAsHexString = m_objSimTlv.HexValue;
            switch (m_objSimTlv.TlvType)
            {
                case SimTlv.TlvTypes.HEX:
                    txtValue.Text = objTlv.ValueAsHexString;
                    break;
                case SimTlv.TlvTypes.STRING:
                    txtValue.Text = objTlv.ValueAsString;
                    break;
                case SimTlv.TlvTypes.INT32:
                    txtValue.Text = Convert.ToString(objTlv.ValueAsInt32);
                    break;
                case SimTlv.TlvTypes.INT16:
                    txtValue.Text = Convert.ToString(objTlv.ValueAsInt16);
                    break;
                case SimTlv.TlvTypes.INT8:
                    txtValue.Text = Convert.ToString(objTlv.ValueAsInt8);
                    break;
            }

            UpdateControls();
        }

        private void UpdateControls()
        {
            cbxTag.Enabled = m_eFrmType == EFrmType.ADD;
            txtTag.Enabled = m_eFrmType == EFrmType.ADD && (int)cbxTag.SelectedValue == CUSTOM_TAG;

            cbxType.Enabled = m_eFrmType != EFrmType.VIEW;
            txtValue.Enabled = m_eFrmType != EFrmType.VIEW;

            if ((int)cbxTag.SelectedValue != CUSTOM_TAG)
                txtTag.Text = Convert.ToString((int)cbxTag.SelectedValue);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            // Set the tag number, either from the combobox or from the text field.
            int nTagNumber = (int)cbxTag.SelectedValue;
            if (nTagNumber == CUSTOM_TAG)
            {
                if (int.TryParse(txtTag.Text, out nTagNumber) == false)
                {
                    MessageBox.Show("The tag number should be a positive integer.", "Format error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            m_objSimTlv.Tag = nTagNumber;
            m_objSimTlv.TypedValue = txtValue.Text;
            m_objSimTlv.TlvType = (SimTlv.TlvTypes)cbxType.SelectedValue;
            AxSms.Tlv objTlv = new AxSms.Tlv();
            try
            {
                switch (m_objSimTlv.TlvType)
                {
                    case SimTlv.TlvTypes.HEX:
                        objTlv.ValueAsHexString = txtValue.Text;
                        break;
                    case SimTlv.TlvTypes.STRING:
                        objTlv.ValueAsString = txtValue.Text;
                        break;
                    case SimTlv.TlvTypes.INT32:
                        objTlv.ValueAsInt32 = int.Parse(txtValue.Text);
                        break;
                    case SimTlv.TlvTypes.INT16:
                        objTlv.ValueAsInt16 = int.Parse(txtValue.Text);
                        break;
                    case SimTlv.TlvTypes.INT8:
                        objTlv.ValueAsInt8 = int.Parse(txtValue.Text);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("If either 'Int32', 'Int16' or 'Int8' the tag number should be an integer.", "Format error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            m_objSimTlv.HexValue = objTlv.ValueAsHexString;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbxTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }
    }
}
