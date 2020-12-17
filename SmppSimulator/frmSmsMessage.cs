//-----------------------------------------------------------------------
// <copyright file="frmSmsMessageDetails.cs" company="Auron Software">
//     Copyright (c) Auron Software All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SmppSimulator
{
    using System;
    using System.Windows.Forms;
    using AxSms;
    using System.Collections.Generic;

    public partial class frmSmsMessage : Form
    {
        public enum EFrmType { CREATE, EDIT, VIEW, SEND }

        private SimMessage m_objMessage;
        
        private AxSms.Constants m_objConstants;
        private AxSms.Smpp m_objSmsAsm;
        private EFrmType m_eFrmType;
        private List<SimMessage> m_lsParts = new List<SimMessage>();
        private bool m_bLoading;

        public List<SimMessage> Parts
        {
            get { return m_lsParts; }
            set { m_lsParts = value; }
        }

        public SimMessage Message
        {
            get { return m_objMessage; }
            set { m_objMessage = value; }
        }

        public AxSms.Smpp SmsAsm
        {
            get { return m_objSmsAsm; }
            set { m_objSmsAsm = value; }
        }

        public frmSmsMessage(SimSession objSession, SimMessage objMessage, EFrmType eType, int nMultipartMode, int nUseGsmEncoding)
        {
            InitializeComponent();

            m_objConstants = new AxSms.Constants();
            m_objSmsAsm = new AxSms.Smpp();
            m_objSmsAsm.MultipartMode = nMultipartMode;
            m_objSmsAsm.UseGsmEncoding = nUseGsmEncoding;
            m_eFrmType = eType;

            switch (m_eFrmType)
            {
                case EFrmType.CREATE:
                    Text = "Create new SMS message";
                    btnSend.Text = "Ok";
                    break;
                case EFrmType.EDIT:
                    Text = "Edit SMS message";
                    btnSend.Text = "Ok";
                    break;
                case EFrmType.VIEW:
                    Text = "View SMS message";
                    btnCancel.Text = "Close";
                    btnSend.Visible = false;
                    break;
                case EFrmType.SEND:
                    Text = "Send SMS message";
                    btnSend.Text = "Send";
                    break;
            }

            if (objSession != null)
            {
                if (objSession.Ip.Contains("."))
                {   // IPv4 notation
                    lblIp.Text = string.Format("{0}:{1}", objSession.Ip, objSession.Port);
                }
                else
                {   // IPv6 notiation
                    lblIp.Text = string.Format("[{0}]:{1}", objSession.Ip, objSession.Port);
                }
                lblSystemId.Text = objSession.SystemId;
            }

            if (objMessage == null) m_objMessage = new SimMessage();
            else m_objMessage = objMessage;
        }

        private void frmSmsMessage_Load(object sender, EventArgs e)
        {
            m_bLoading = true;

            // Load comboboxes
            var dctTon = new Dictionary<String, int>();
            dctTon.Add("Unknown", m_objConstants.TON_UNKNOWN);
            dctTon.Add("International Number", m_objConstants.TON_INTERNATIONAL);
            dctTon.Add("National Number", m_objConstants.TON_NATIONAL);
            dctTon.Add("Network Specific Number", m_objConstants.TON_NETWORK_SPECIFIC);
            dctTon.Add("Subscriber Number", m_objConstants.TON_SUBSCRIBER_NUMBER);
            dctTon.Add("Alphanumeric Number", m_objConstants.TON_ALPHANUMERIC);
            dctTon.Add("Abbreviated Number", m_objConstants.SMPP_TON_ABBREVIATED);

            cbxFromTon.DisplayMember = "Key";
            cbxFromTon.ValueMember = "Value";
            cbxFromTon.DataSource = new BindingSource(dctTon, null);
            cbxToTon.DisplayMember = "Key";
            cbxToTon.ValueMember = "Value";
            cbxToTon.DataSource = new BindingSource(dctTon, null);

            var dctNpi = new Dictionary<String, int>();
            dctNpi.Add("Unknown", m_objConstants.NPI_UNKNOWN);
            dctNpi.Add("ISDN / Telephone", m_objConstants.NPI_ISDN);
            dctNpi.Add("Data", m_objConstants.NPI_DATA);
            dctNpi.Add("Telex", m_objConstants.NPI_TELEX);
            dctNpi.Add("Land Mobile", m_objConstants.NPI_LAND_MOBILE);
            dctNpi.Add("National", m_objConstants.NPI_NATIONAL);
            dctNpi.Add("Ermes", m_objConstants.NPI_ERMES);
            dctNpi.Add("Internet", m_objConstants.SMPP_NPI_INTERNET);

            cbxFromNpi.DisplayMember = "Key";
            cbxFromNpi.ValueMember = "Value";
            cbxFromNpi.DataSource = new BindingSource(dctNpi, null);
            cbxToNpi.DisplayMember = "Key";
            cbxToNpi.ValueMember = "Value";
            cbxToNpi.DataSource = new BindingSource(dctNpi, null);

            var dctBodyFormat = new Dictionary<String, int>();
            dctBodyFormat.Add("Text", m_objConstants.BODYFORMAT_TEXT);
            dctBodyFormat.Add("Hex", m_objConstants.BODYFORMAT_HEX);

            cbxBodyFormat.DisplayMember = "Key";
            cbxBodyFormat.ValueMember = "Value";
            cbxBodyFormat.DataSource = new BindingSource(dctBodyFormat, null);

            var dctDataCoding = new Dictionary<String, int>();
            dctDataCoding.Add("Text", m_objConstants.DATACODING_DEFAULT);
            dctDataCoding.Add("Unicode", m_objConstants.DATACODING_UNICODE);
            dctDataCoding.Add("Data", m_objConstants.DATACODING_8BIT_DATA);
            dctDataCoding.Add("Flash", m_objConstants.DATACODING_FLASH);
            dctDataCoding.Add("Flash Unicode", 24); // Unicode (8) | Flash (16)

            cbxDataCoding.DisplayMember = "Key";
            cbxDataCoding.ValueMember = "Value";
            cbxDataCoding.DataSource = new BindingSource(dctDataCoding, null);

            var dctLanguageShift = new Dictionary<String, int>();
            dctLanguageShift.Add("Basic"     , m_objConstants.LANGUAGE_SINGLESHIFT_BASIC);
            dctLanguageShift.Add("Turkish"   , m_objConstants.LANGUAGE_SINGLESHIFT_TURKISH);
            dctLanguageShift.Add("Portuguese", m_objConstants.LANGUAGE_SINGLESHIFT_SPANISH);
            dctLanguageShift.Add("Spanish"   , m_objConstants.LANGUAGE_SINGLESHIFT_PORTUGUESE);
            dctLanguageShift.Add("Bengali"   , m_objConstants.LANGUAGE_SINGLESHIFT_BENGALI);
            dctLanguageShift.Add("Gujarati"  , m_objConstants.LANGUAGE_SINGLESHIFT_GUJARATI);
            dctLanguageShift.Add("Hindi"     , m_objConstants.LANGUAGE_SINGLESHIFT_HINDI);
            dctLanguageShift.Add("Kannada"   , m_objConstants.LANGUAGE_SINGLESHIFT_KANNADA);
            dctLanguageShift.Add("Malayalam" , m_objConstants.LANGUAGE_SINGLESHIFT_MALAYALAM);
            dctLanguageShift.Add("Oriya"     , m_objConstants.LANGUAGE_SINGLESHIFT_ORIYA);
            dctLanguageShift.Add("Punjabi"   , m_objConstants.LANGUAGE_SINGLESHIFT_PUNJABI);
            dctLanguageShift.Add("Tamil"     , m_objConstants.LANGUAGE_SINGLESHIFT_TAMIL);
            dctLanguageShift.Add("Telugu"    , m_objConstants.LANGUAGE_SINGLESHIFT_TELUGU);
            dctLanguageShift.Add("Urdu"      , m_objConstants.LANGUAGE_SINGLESHIFT_URDU);

            cbxLanguageShift.DisplayMember = "Key";
            cbxLanguageShift.ValueMember = "Value";
            cbxLanguageShift.DataSource = new BindingSource(dctLanguageShift, null);

            // Setup TLV table
            lvTlvs.Columns.Add("Tag", 230, HorizontalAlignment.Left);
            lvTlvs.Columns.Add("Type", 115, HorizontalAlignment.Left);
            lvTlvs.Columns.Add("Value", lvTlvs.Width - 350, HorizontalAlignment.Left);

            // Set properties
            txtFromAddress.Text = m_objMessage.FromAddress;
            cbxFromNpi.SelectedValue = m_objMessage.FromAddressNpi;
            cbxFromTon.SelectedValue = m_objMessage.FromAddressTon;
            txtToAddress.Text = m_objMessage.ToAddress;
            cbxToNpi.SelectedValue = m_objMessage.ToAddressNpi;
            cbxToTon.SelectedValue = m_objMessage.ToAddressTon;
            cbxDataCoding.SelectedValue = m_objMessage.DataCoding;
            cbxLanguageShift.SelectedValue = m_objMessage.LanguageShift;
            cbxBodyFormat.SelectedValue = m_objMessage.BodyFormat;
            cbUDH.Checked = m_objMessage.HasUdh;
            cbDeliveryReport.Checked = m_objMessage.IsDeliveryReport;
            txtBody.Text = m_objMessage.Body;
            foreach (SimTlv objTlv in m_objMessage.Tlvs)
            {
                ListViewItem item = new ListViewItem(new String[] {
                    m_objConstants.SmppTlvToString(objTlv.Tag).Replace("SMPP_TLV_", ""),
                    objTlv.TlvType.ToString(), objTlv.TypedValue
                });
                item.Tag = new SimTlv(objTlv);
                lvTlvs.Items.Insert(0, item);
            }

            if (m_eFrmType == EFrmType.VIEW)
            {
                lbDirection.Text = m_objMessage.Direction.ToString();
                lbStatus.Text = m_objMessage.Status;
            }
            else
            {
                lbDirection.Text = "n/a";
                lbStatus.Text = "n/a";
            }

            m_bLoading = false;            

            UpdateControls();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // Validate input
            if (txtToAddress.Text == "")
            {
                MessageBox.Show("A 'To Address' is required.", "Format error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string strBody = txtBody.Text;
            if ((int)cbxBodyFormat.SelectedValue == m_objConstants.BODYFORMAT_HEX)
            {
                strBody = strBody.ToLower();
                strBody = strBody.Replace(" ", "");
                strBody = strBody.Replace("\r", "");
                strBody = strBody.Replace("\n", "");

                bool bNotHex = false;
                foreach (char c in strBody)
                {
                    if (!((c >= '0' && c <= '9') ||
                          (c >= 'a' && c <= 'f')))
                    {
                        bNotHex = true;
                        break;
                    }
                }

                if (bNotHex || strBody.Length % 2 != 0)
                {
                    MessageBox.Show("If the 'Body Format' is 'HEX' the body should be empty or contain an even" +
                        " number or hexadecimal digits (0..f).", "Format error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
                strBody = strBody.Replace("\r", "");

            // Set properties
            m_objMessage.FromAddress = txtFromAddress.Text;
            m_objMessage.FromAddressNpi = (int)cbxFromNpi.SelectedValue;
            m_objMessage.FromAddressTon = (int)cbxFromTon.SelectedValue;
            m_objMessage.ToAddress = txtToAddress.Text;
            m_objMessage.ToAddressNpi = (int)cbxToNpi.SelectedValue;
            m_objMessage.ToAddressTon = (int)cbxToTon.SelectedValue;
            m_objMessage.DataCoding = (int)cbxDataCoding.SelectedValue;
            m_objMessage.BodyFormat = (int)cbxBodyFormat.SelectedValue;
            m_objMessage.LanguageShift = (int)cbxLanguageShift.SelectedValue;
            m_objMessage.HasUdh = cbUDH.Checked;
            m_objMessage.IsDeliveryReport = cbDeliveryReport.Checked;
            m_objMessage.Body = strBody;
            m_objMessage.Tlvs.Clear();
            foreach (ListViewItem lvi in lvTlvs.Items)
                m_objMessage.Tlvs.Add((SimTlv)lvi.Tag);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void UpdateControls()
        {
            bool bNoNls = cbxDataCoding.SelectedValue != null && 
              (((int)cbxDataCoding.SelectedValue & m_objConstants.DATACODING_UNICODE) == m_objConstants.DATACODING_UNICODE ||
              ((int)cbxDataCoding.SelectedValue & m_objConstants.DATACODING_8BIT_DATA) == m_objConstants.DATACODING_8BIT_DATA);

            txtToAddress.Enabled = m_eFrmType != EFrmType.VIEW;
            cbxToNpi.Enabled = m_eFrmType != EFrmType.VIEW;
            cbxToTon.Enabled = m_eFrmType != EFrmType.VIEW;
            txtFromAddress.Enabled = m_eFrmType != EFrmType.VIEW;
            cbxFromNpi.Enabled = m_eFrmType != EFrmType.VIEW;
            cbxFromTon.Enabled = m_eFrmType != EFrmType.VIEW;
            cbxDataCoding.Enabled = m_eFrmType != EFrmType.VIEW;
            cbxBodyFormat.Enabled = m_eFrmType != EFrmType.VIEW;
            cbxLanguageShift.Enabled = m_eFrmType != EFrmType.VIEW && !bNoNls;
            cbUDH.Enabled = m_eFrmType != EFrmType.VIEW;
            cbDeliveryReport.Enabled = m_eFrmType != EFrmType.VIEW;            
            btAdd.Enabled = btEdit.Enabled = btRemove.Enabled = m_eFrmType != EFrmType.VIEW;

            txtBody.ReadOnly = m_eFrmType == EFrmType.VIEW;
            lvTlvs.Enabled = !(m_eFrmType == EFrmType.VIEW && lvTlvs.Items.Count == 0);

            btnShowComplete.Enabled = m_lsParts.Count > 1;

            UpdateCharacterCount();
        }

        public void UpdateCharacterCount()
        {
            // Don't let this function trigger while still filling the comboboxes in 'onLoad'
            if (m_bLoading) return;

            AxSms.Message objSms = new AxSms.Message();
            objSms.ToAddress = "1234567890";    // make up a 'ToAddress' to pass validation
            objSms.BodyFormat = cbxBodyFormat.SelectedValue == null ? 0: (int)cbxBodyFormat.SelectedValue;
            objSms.DataCoding = cbxDataCoding.SelectedValue == null ? 0: (int)cbxDataCoding.SelectedValue;
            objSms.HasUdh = cbUDH.Checked;

            string strText = txtBody.Text;
            string strParts = "";
            int nChars = 0;
            if (objSms.BodyFormat == m_objConstants.BODYFORMAT_HEX)
            {   // Count SMS size based on HEX input
                strText = strText.Replace(" ", "");
                strText = strText.Replace("\r", "");
                strText = strText.Replace("\n", "");
                nChars = strText.Length / 2;
                if ((strText.Length & 1) == 1)
                    strText = strText.Remove(strText.Length - 1);
            }
            else
            {   // Count SMS size based on regular text
                strText = strText.Replace("\r", "");
                nChars = strText.Length;
            }

            // Count the message parts, only if we don't already know
            if (strParts == "")
            {
                objSms.Body = strText;
                int nParts = m_objSmsAsm.CountParts(objSms);
                int nLastError = m_objSmsAsm.LastError;
                strParts = nParts > 0 ? nParts.ToString() : "?";
            }

            lblCharacters.Text = string.Format("{0} Characters / {1} Parts", nChars, strParts);
        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {
            UpdateCharacterCount();
        }

        private void cbxBodyFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmSimTlv frm = new frmSimTlv(null, frmSimTlv.EFrmType.ADD);
            if (frm.ShowDialog() == DialogResult.Cancel) return;
            SimTlv objTlv = frm.Tlv;

            // If there's already a TLV with the tag, remove it.
            foreach (ListViewItem li in lvTlvs.Items)
            {
                SimTlv objInfo = (SimTlv)li.Tag;
                if (objInfo.Tag == objTlv.Tag) lvTlvs.Items.Remove(li);
            }

            // Add the newly created TLV value to the listview
            ListViewItem item = new ListViewItem(new String[] {
                m_objConstants.SmppTlvToString(objTlv.Tag).Replace("SMPP_TLV_", ""),
                objTlv.TlvType.ToString(), objTlv.TypedValue
            });
            item.Tag = frm.Tlv;
            lvTlvs.Items.Insert(0, item);
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (lvTlvs.SelectedItems.Count <= 0) return;

            SimTlv objEditted = (SimTlv)lvTlvs.SelectedItems[0].Tag;
            frmSimTlv frm = new frmSimTlv(objEditted, m_eFrmType == EFrmType.VIEW ? frmSimTlv.EFrmType.VIEW : frmSimTlv.EFrmType.EDIT);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListViewItem item = lvTlvs.SelectedItems[0];
                item.SubItems[1].Text = frm.Tlv.TlvType.ToString();
                item.SubItems[2].Text = frm.Tlv.TypedValue;
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (lvTlvs.SelectedItems.Count <= 0) return;
            lvTlvs.Items.Remove(lvTlvs.SelectedItems[0]);
        }

        private void cbxDataCoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void cbUDH_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void btnShowComplete_Click(object sender, EventArgs e)
        {   // Assemble from the parts we have            
            m_objSmsAsm.ResetSmsAssembler();
            foreach (SimMessage objMessage in m_lsParts)
            {
                AxSms.Message objAxMsg = objMessage.CreateAxSms();
                m_objSmsAsm.AssembleSms(objAxMsg);
            }
            AxSms.Message objAssembled = m_objSmsAsm.GetAssembledSms(true);

            // Set all of the properties that may have changed
            m_bLoading = true;  // make sure updatecontrols is not triggered

            txtBody.Text = objAssembled.Body;
            txtToAddress.Text = objAssembled.ToAddress;
            txtFromAddress.Text = objAssembled.FromAddress;
            cbxBodyFormat.SelectedValue = objAssembled.BodyFormat;
            cbUDH.Checked = objAssembled.HasUdh;

            m_bLoading = false;

            // Make sure character and parts count is set correctly
            UpdateCharacterCount();

            // Disable this button; there's no going back now .. 
            btnShowComplete.Enabled = false;
        }

        private void lvTlvs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btEdit_Click(null, null);
        }
    }
       
}
