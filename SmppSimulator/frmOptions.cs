using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmppSimulator
{
  public partial class frmOptions : Form
  {
    private AxSms.Constants m_objConstants = new AxSms.Constants();

    private SimModel m_objSimModel;

    public frmOptions(SimModel objSimModel)
    {
      InitializeComponent();
      m_objSimModel = objSimModel;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      int iPduTimeout = 0;
      int iEnquireInterval = 0;

      try
      {
        iPduTimeout = int.Parse(txtPduTimeout.Text);
        iEnquireInterval = int.Parse(txtEnquireInterval.Text);
      }
      catch
      {
        MessageBox.Show("Pdu Timeout and Enquire Interval need to be positive numbers.",
            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      // Save values
      m_objSimModel.LastReference = int.Parse(txtLastMessageReference.Text, System.Globalization.NumberStyles.HexNumber);
      m_objSimModel.UseGsmEncoding = (int)cbxGsmEncoding.SelectedValue;
      m_objSimModel.MultipartMode = (int)cbxMultipart.SelectedValue;
      m_objSimModel.DeliverMode = (int)cbxDeliverMode.SelectedValue;
      m_objSimModel.PduTimeout = iPduTimeout;
      m_objSimModel.EnquireInterval = iEnquireInterval;
      m_objSimModel.CertificateStore = (int)cbxCertificateStore.SelectedValue;

      DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void frmOptions_Load(object sender, EventArgs e)
    {
      // Fill comboboxes
      var dctGsmEncoding = new Dictionary<String, int>();
      dctGsmEncoding.Add("SMPP_USEGSMENCODING_DISABLED", m_objConstants.SMPP_USEGSMENCODING_DISABLED);
      dctGsmEncoding.Add("SMPP_USEGSMENCODING_INANDOUT", m_objConstants.SMPP_USEGSMENCODING_INANDOUT);
      dctGsmEncoding.Add("SMPP_USEGSMENCODING_INCOMING", m_objConstants.SMPP_USEGSMENCODING_INCOMING);
      dctGsmEncoding.Add("SMPP_USEGSMENCODING_OUTGOING", m_objConstants.SMPP_USEGSMENCODING_OUTGOING);
      dctGsmEncoding.Add("SMPP_USEGSMENCODING_INCHARSET", m_objConstants.SMPP_USEGSMENCODING_INCHARSET);
      dctGsmEncoding.Add("SMPP_USEGSMENCODING_OUTCHARSET", m_objConstants.SMPP_USEGSMENCODING_OUTCHARSET);
      cbxGsmEncoding.DisplayMember = "Key";
      cbxGsmEncoding.ValueMember = "Value";
      cbxGsmEncoding.DataSource = new BindingSource(dctGsmEncoding, null);

      var dctMultipart = new Dictionary<String, int>();
      dctMultipart.Add("SMPP_MULTIPARTMODE_UDH", m_objConstants.SMPP_MULTIPARTMODE_UDH);
      dctMultipart.Add("SMPP_MULTIPARTMODE_UDH16BIT", m_objConstants.SMPP_MULTIPARTMODE_UDH16BIT);
      dctMultipart.Add("SMPP_MULTIPARTMODE_SARTLV", m_objConstants.SMPP_MULTIPARTMODE_SARTLV);
      dctMultipart.Add("SMPP_MULTIPARTMODE_PAYLOADTLV", m_objConstants.SMPP_MULTIPARTMODE_PAYLOADTLV);
      cbxMultipart.DisplayMember = "Key";
      cbxMultipart.ValueMember = "Value";
      cbxMultipart.DataSource = new BindingSource(dctMultipart, null);

      var dctDeliverMode = new Dictionary<String, int>();
      dctDeliverMode.Add("SMPP_DELIVERMODE_DELIVERSM", m_objConstants.SMPP_DELIVERMODE_DELIVERSM);
      dctDeliverMode.Add("SMPP_DELIVERMODE_DATASM", m_objConstants.SMPP_DELIVERMODE_DATASM);
      cbxDeliverMode.DisplayMember = "Key";
      cbxDeliverMode.ValueMember = "Value";
      cbxDeliverMode.DataSource = new BindingSource(dctDeliverMode, null);

      var dctCertificateStore = new Dictionary<String, int>();
      dctCertificateStore.Add("SMPP_CERTIFICATESTORE_LOCALMACHINE", m_objConstants.SMPP_CERTIFICATESTORE_LOCALMACHINE);
      dctCertificateStore.Add("SMPP_CERTIFICATESTORE_CURRENTUSER", m_objConstants.SMPP_CERTIFICATESTORE_CURRENTUSER);
      cbxCertificateStore.DisplayMember = "Key";
      cbxCertificateStore.ValueMember = "Value";
      cbxCertificateStore.DataSource = new BindingSource(dctCertificateStore, null);

      // Set values
      cbxGsmEncoding.SelectedValue = m_objSimModel.UseGsmEncoding;
      cbxMultipart.SelectedValue = m_objSimModel.MultipartMode;
      cbxDeliverMode.SelectedValue = m_objSimModel.DeliverMode;
      txtPduTimeout.Text = m_objSimModel.PduTimeout.ToString();
      txtEnquireInterval.Text = m_objSimModel.EnquireInterval.ToString();
      txtLastMessageReference.Text = string.Format("{0:X8}", m_objSimModel.LastReference);
      cbxCertificateStore.SelectedValue = m_objSimModel.CertificateStore;
    }

    private void cbxDeliverMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateControls();
    }

    private void UpdateControls()
    {
      if (cbxDeliverMode.SelectedValue != null &&
          (int)cbxDeliverMode.SelectedValue == m_objConstants.SMPP_DELIVERMODE_DATASM)
      {
        cbxMultipart.SelectedValue = m_objConstants.SMPP_MULTIPARTMODE_PAYLOADTLV;
        cbxMultipart.Enabled = false;
      }
      else cbxMultipart.Enabled = true;
    }
  }
}
