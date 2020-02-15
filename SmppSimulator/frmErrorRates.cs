//-----------------------------------------------------------------------
// <copyright file="frmStatusErrors.cs" company="Auron Software">
//     Copyright (c) Auron Software All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SmppSimulator
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using AxSms;
    using Microsoft.Win32;

    public partial class frmErrorRates : Form
    {
        private const string ESME_PREFIX = "SMPP_ESME_";

        private const int MESSAGE_STATUS = 0;
        private const int MESSAGE_OCCURANCE = 1;

        private const int DELIVERY_TEXT = 0;
        private const int DELIVERY_CODE = 1;
        private const int DELIVERY_OCCURANCE = 2;

        private const string DRSTATUS_TEXT_EXPIRED = "EXPIRED";
        private const string DRSTATUS_TEXT_DELETED = "DELETED";
        private const string DRSTATUS_TEXT_UNDELIVERABLE = "UNDELIV";
        private const string DRSTATUS_TEXT_ACCEPTED = "ACCEPTD";
        private const string DRSTATUS_TEXT_UNKNOWN = "UNKNOWN";
        private const string DRSTATUS_TEXT_REJECTED = "REJECTD";

        private SimErrorRates m_objSimErrorRates = null;
        private AxSms.Constants m_objSmsConstants = null;

        public SimErrorRates ErrorRates
        {
            get { return m_objSimErrorRates; }
        }

        public frmErrorRates(SimErrorRates objErrorRates)
        {
            InitializeComponent();

            m_objSimErrorRates = objErrorRates;
        }

        private void frmStatusErrors_Load(object sender, EventArgs e)
        {
            m_objSmsConstants = new AxSms.Constants();
            // 
            var dctMessageStatusses = new Dictionary<int, string>();            
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVMSGLEN, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVMSGLEN));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVCMDLEN, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVCMDLEN));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVCMDID, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVCMDID));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVBNDSTS, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVBNDSTS));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RALYBND, EsmeToString(m_objSmsConstants.SMPP_ESME_RALYBND));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVPRTFLG, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVPRTFLG));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVREGDLVFLG, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVREGDLVFLG));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RSYSERR, EsmeToString(m_objSmsConstants.SMPP_ESME_RSYSERR));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVSRCADR, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVSRCADR));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVDSTADR, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVDSTADR));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVMSGID, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVMSGID));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RBINDFAIL, EsmeToString(m_objSmsConstants.SMPP_ESME_RBINDFAIL));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVPASWD, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVPASWD));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVSYSID, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVSYSID));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RCANCELFAIL, EsmeToString(m_objSmsConstants.SMPP_ESME_RCANCELFAIL));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RREPLACEFAIL, EsmeToString(m_objSmsConstants.SMPP_ESME_RREPLACEFAIL));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RMSGQFUL, EsmeToString(m_objSmsConstants.SMPP_ESME_RMSGQFUL));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVSERTYP, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVSERTYP));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVNUMDESTS, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVNUMDESTS));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVDLNAME, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVDLNAME));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVDESTFLAG, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVDESTFLAG));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVSUBREP, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVSUBREP));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVESMCLASS, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVESMCLASS));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RCNTSUBDL, EsmeToString(m_objSmsConstants.SMPP_ESME_RCNTSUBDL));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RSUBMITFAIL, EsmeToString(m_objSmsConstants.SMPP_ESME_RSUBMITFAIL));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVSRCTON, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVSRCTON));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVSRCNPI, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVSRCNPI));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVDSTTON, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVDSTTON));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVDSTNPI, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVDSTNPI));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVSYSTYP, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVSYSTYP));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVREPFLAG, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVREPFLAG));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVNUMMSGS, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVNUMMSGS));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RTHROTTLED, EsmeToString(m_objSmsConstants.SMPP_ESME_RTHROTTLED));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVSCHED, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVSCHED));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVEXPIRY, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVEXPIRY));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVDFTMSGID, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVDFTMSGID));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RX_T_APPN, EsmeToString(m_objSmsConstants.SMPP_ESME_RX_T_APPN));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RX_P_APPN, EsmeToString(m_objSmsConstants.SMPP_ESME_RX_P_APPN));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RX_R_APPN, EsmeToString(m_objSmsConstants.SMPP_ESME_RX_R_APPN));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RQUERYFAIL, EsmeToString(m_objSmsConstants.SMPP_ESME_RQUERYFAIL));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVOPTPARSTREAM, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVOPTPARSTREAM));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_ROPTPARNOTALLWD, EsmeToString(m_objSmsConstants.SMPP_ESME_ROPTPARNOTALLWD));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVPARLEN, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVPARLEN));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RMISSINGOPTPARAM, EsmeToString(m_objSmsConstants.SMPP_ESME_RMISSINGOPTPARAM));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RINVOPTPARAMVAL, EsmeToString(m_objSmsConstants.SMPP_ESME_RINVOPTPARAMVAL));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RDELIVERYFAILURE, EsmeToString(m_objSmsConstants.SMPP_ESME_RDELIVERYFAILURE));
            dctMessageStatusses.Add(m_objSmsConstants.SMPP_ESME_RUNKNOWNERR, EsmeToString(m_objSmsConstants.SMPP_ESME_RUNKNOWNERR));

            cbxMsgStatusPreDefined.ValueMember = "Key";
            cbxMsgStatusPreDefined.DisplayMember = "Value";
            cbxMsgStatusPreDefined.DataSource = new BindingSource(dctMessageStatusses, null);
            
            var dctDeliveryStatusses = new Dictionary<string, SimDeliveryErrorRate>();
            dctDeliveryStatusses.Add(DRSTATUS_TEXT_EXPIRED, new SimDeliveryErrorRate(DRSTATUS_TEXT_EXPIRED, 3, 0));
            dctDeliveryStatusses.Add(DRSTATUS_TEXT_DELETED, new SimDeliveryErrorRate(DRSTATUS_TEXT_DELETED, 4, 0));
            dctDeliveryStatusses.Add(DRSTATUS_TEXT_UNDELIVERABLE, new SimDeliveryErrorRate(DRSTATUS_TEXT_UNDELIVERABLE, 5, 0));
            dctDeliveryStatusses.Add(DRSTATUS_TEXT_ACCEPTED, new SimDeliveryErrorRate(DRSTATUS_TEXT_ACCEPTED, 6, 0));
            dctDeliveryStatusses.Add(DRSTATUS_TEXT_UNKNOWN, new SimDeliveryErrorRate(DRSTATUS_TEXT_UNKNOWN, 7, 0));
            dctDeliveryStatusses.Add(DRSTATUS_TEXT_REJECTED, new SimDeliveryErrorRate(DRSTATUS_TEXT_REJECTED, 8, 0));

            cbxDeliveryStatus.ValueMember = "Value";
            cbxDeliveryStatus.DisplayMember = "Key";
            cbxDeliveryStatus.DataSource = new BindingSource(dctDeliveryStatusses, null);

            // Make sure to update all the MESSAGE_ constants when changing stuff here !!!!
            lvMessageStatus.Columns.Add("Status", (int)(lvMessageStatus.Width * .75), HorizontalAlignment.Left);
            lvMessageStatus.Columns.Add("Occurance", (int)(lvMessageStatus.Width * .20), HorizontalAlignment.Left);

            // Make sure to update all the DELIVERY_ constants when changing stuff here !!!!
            lvDeliveryStatus.Columns.Add("Text", (int)(lvDeliveryStatus.Width * .40), HorizontalAlignment.Left);
            lvDeliveryStatus.Columns.Add("Code", (int)(lvDeliveryStatus.Width * .35), HorizontalAlignment.Left);
            lvDeliveryStatus.Columns.Add("Occurance", (int)(lvDeliveryStatus.Width * .20), HorizontalAlignment.Left);

            cbxDeliveryStatus.SelectedIndex = 0;
            cbxMsgStatusPreDefined.SelectedValue = m_objSmsConstants.SMPP_ESME_RINVMSGLEN;
            rbMsgStatusPreDefined.Checked = true;
            txtMessageStatusOccurance.Text = "10";
            txtDeliveryStatusOccurance.Text = "10";
            txtMsgStatusCustom.Text = "0";

            // Set error rates
            foreach (SimMessageErrorRate objErrr in m_objSimErrorRates.MessageErrorRates)
            {                
                ListViewItem objLvi = new ListViewItem(
                    new string[] { EsmeToString(objErrr.StatusCode), objErrr.Occurance.ToString() });
                objLvi.Tag = new SimMessageErrorRate(objErrr);
                lvMessageStatus.Items.Add(objLvi);
            }

            foreach (SimDeliveryErrorRate objErrr in m_objSimErrorRates.DeliveryErrorRates)
            {
                ListViewItem objLvi = new ListViewItem(
                    new string[] { objErrr.Text, objErrr.Code.ToString(), objErrr.Occurance.ToString() });
                objLvi.Tag = new SimDeliveryErrorRate(objErrr);
                lvDeliveryStatus.Items.Add(objLvi);
            }

            UpdateControls();
        }

        private void UpdateControls()
        {
            cbxMsgStatusPreDefined.Enabled = rbMsgStatusPreDefined.Checked;
            txtMsgStatusCustom.Enabled = !rbMsgStatusPreDefined.Checked;

            int nMessageStatusSuccess = 100;
            foreach (ListViewItem objLvi in lvMessageStatus.Items)
            {
                SimMessageErrorRate objErrr = (SimMessageErrorRate)objLvi.Tag;
                nMessageStatusSuccess -= objErrr.Occurance;
            }
            lblMessageStatusSuccess.Text = string.Format("{0}% ROK", nMessageStatusSuccess);

            int nDeliveryStatusSuccess = 100;
            foreach (ListViewItem objLvi in lvDeliveryStatus.Items)
            {
                SimDeliveryErrorRate objErrr = (SimDeliveryErrorRate)objLvi.Tag;
                nDeliveryStatusSuccess -= objErrr.Occurance;
            }
            lblDeliveryStatusSuccess.Text = string.Format("{0}% DELIVRD", nDeliveryStatusSuccess);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            m_objSimErrorRates.DeliveryErrorRates.Clear();
            m_objSimErrorRates.MessageErrorRates.Clear();

            foreach (ListViewItem objLvi in lvMessageStatus.Items)
            {
                SimMessageErrorRate objErrr = (SimMessageErrorRate)objLvi.Tag;
                m_objSimErrorRates.MessageErrorRates.Add(objErrr);
            }

            foreach (ListViewItem objLvi in lvDeliveryStatus.Items)
            {
                SimDeliveryErrorRate objErrr = (SimDeliveryErrorRate)objLvi.Tag;
                m_objSimErrorRates.DeliveryErrorRates.Add(objErrr);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void rbMsgStatus_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void txtNummeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtNumeric_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextbox = (TextBox)sender;
            if (objTextbox.Text == "") objTextbox.Text = "0";
        }

        private void btnDeleteMessageStatus_Click(object sender, EventArgs e)
        {
            if (lvMessageStatus.SelectedItems.Count <= 0) return;
            lvMessageStatus.Items.Remove(lvMessageStatus.SelectedItems[0]);
            UpdateControls();
        }

        private void btnDeleteDeliveryStatus_Click(object sender, EventArgs e)
        {
            if (lvDeliveryStatus.SelectedItems.Count <= 0) return;
            lvDeliveryStatus.Items.Remove(lvDeliveryStatus.SelectedItems[0]);
            UpdateControls();
        }

        private void btnInsertMessageStatus_Click(object sender, EventArgs e)
        {
            SimMessageErrorRate objMsgError = new SimMessageErrorRate();

            // Set message error structure
            objMsgError.Occurance = int.Parse(txtMessageStatusOccurance.Text);
            if (rbMsgStatusCustom.Checked)
                objMsgError.StatusCode = int.Parse(txtMsgStatusCustom.Text);
            else
                objMsgError.StatusCode = (int)cbxMsgStatusPreDefined.SelectedValue;

            // Calculate total error rate
            int nTotal = 0;
            foreach (ListViewItem objLvi in lvMessageStatus.Items)
            {
                SimMessageErrorRate objErrr = (SimMessageErrorRate)objLvi.Tag;
                nTotal += objErrr.Occurance;
            }

            // Validate input
            if (objMsgError.Occurance < 1 || objMsgError.Occurance > 100)
            {
                MessageBox.Show("Error occurrence can not be < 1% or > 100%.", 
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nTotal + objMsgError.Occurance > 100)
            {
                MessageBox.Show("Total error occurrence can not be < 1% or > 100%.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // First; try to see if we can update an existing item with the same status
            foreach (ListViewItem objLvi in lvMessageStatus.Items)
            {
                SimMessageErrorRate objErrr = (SimMessageErrorRate)objLvi.Tag;
                if (objErrr.StatusCode == objMsgError.StatusCode)
                {
                    objErrr.Occurance += objMsgError.Occurance;
                    objLvi.SubItems[MESSAGE_OCCURANCE].Text = objErrr.Occurance.ToString();
                    UpdateControls();
                    return;
                }
            }

            // If not; add a new status
            ListViewItem objNewLvi = new ListViewItem(
                new string[] { EsmeToString(objMsgError.StatusCode), 
                    objMsgError.Occurance.ToString() });
            objNewLvi.Tag = objMsgError;
            lvMessageStatus.Items.Add(objNewLvi);
                
            UpdateControls();
        }

        private void btnInsertDeliveryStatus_Click(object sender, EventArgs e)
        {
            // Set error rate structure
            SimDeliveryErrorRate objDlrError = new SimDeliveryErrorRate((SimDeliveryErrorRate)cbxDeliveryStatus.SelectedValue);
            objDlrError.Occurance = int.Parse(txtDeliveryStatusOccurance.Text);

            // Calculate total error rate
            int nTotal = 0;
            foreach (ListViewItem objLvi in lvDeliveryStatus.Items)
            {
                SimDeliveryErrorRate objErrr = (SimDeliveryErrorRate)objLvi.Tag;
                nTotal += objErrr.Occurance;
            }

            // validate input
            if (objDlrError.Occurance < 1 || objDlrError.Occurance > 100)
            {
                MessageBox.Show("Error occurrence can not be < 1% or > 100%.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nTotal + objDlrError.Occurance > 100)
            {
                MessageBox.Show("Total error occurrence can not be < 1% or > 100%.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // First; try to see if we can update an existing item with the same status
            foreach (ListViewItem objLvi in lvDeliveryStatus.Items)
            {
                SimDeliveryErrorRate objErrr = (SimDeliveryErrorRate)objLvi.Tag;
                if (objErrr.Code == objDlrError.Code &&
                    objDlrError.Text == objDlrError.Text)
                {
                    objErrr.Occurance += objDlrError.Occurance;
                    objLvi.SubItems[DELIVERY_OCCURANCE].Text = objErrr.Occurance.ToString();
                    UpdateControls();
                    return;
                }
            }

            // If not; add a new status
            ListViewItem objNewLvi = new ListViewItem(
                new string[] { objDlrError.Text, objDlrError.Code.ToString(), objDlrError.Occurance.ToString() });
            objNewLvi.Tag = objDlrError;
            lvDeliveryStatus.Items.Add(objNewLvi);

            UpdateControls();
        }

        private void cbxDeliveryStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxDeliveryStatus.Text.Length == 7 && e.KeyChar != (char)Keys.Return && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private string EsmeToString(int nEsme)
        {
            return m_objSmsConstants.SmppEsmeToString(nEsme).Replace(ESME_PREFIX, "");
        }
    }
}