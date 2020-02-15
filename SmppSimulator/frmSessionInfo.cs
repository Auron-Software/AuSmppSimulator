//-----------------------------------------------------------------------
// <copyright file="frmSessionInfo.cs" company="Auron Software">
//     Copyright (c) Auron Software All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SmppSimulator
{
    using System;
    using System.Windows.Forms;
    using AxSms;

    public partial class frmSessionInfo : Form
    {
        public frmSessionInfo(SimSession objSimSession)
        {
            
            InitializeComponent();
            AxSms.Constants objSmsConstants = new AxSms.Constants();

            lblIp.Text = objSimSession.Ip;
            lblPort.Text = objSimSession.Port.ToString();
            lblVersion.Text = objSmsConstants.SmppVersionToString(objSimSession.Version);
            lblSystemID.Text = objSimSession.SystemId;
            lblPassword.Text = objSimSession.Password;
            lblSystemType.Text = objSimSession.SystemType;
            lblAddressRange.Text = objSimSession.AddressRange;
            lblAddressRangeNPI.Text = objSmsConstants.NpiToString(objSimSession.AddressRangeNpi);
            lblAddressRangeTON.Text = objSmsConstants.TonToString(objSimSession.AddressRangeTon);
            lblConnectionState.Text = objSmsConstants.SmppSessionStateToString(objSimSession.ConnectionState);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
