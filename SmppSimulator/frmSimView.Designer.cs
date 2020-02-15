namespace SmppSimulator
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
      this.grbControlPanel = new System.Windows.Forms.GroupBox();
      this.cbxCertificate = new System.Windows.Forms.ComboBox();
      this.btnServerOptions = new System.Windows.Forms.Button();
      this.cbxIpVersion = new System.Windows.Forms.ComboBox();
      this.btnStop = new System.Windows.Forms.Button();
      this.btnStart = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.grbSessions = new System.Windows.Forms.GroupBox();
      this.cbAuthentication = new System.Windows.Forms.CheckBox();
      this.lvSessions = new System.Windows.Forms.ListView();
      this.lblSessionsCount = new System.Windows.Forms.Label();
      this.btnSendSession = new System.Windows.Forms.Button();
      this.btnInfoSession = new System.Windows.Forms.Button();
      this.btnDropSession = new System.Windows.Forms.Button();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtSystemId = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.grbMessages = new System.Windows.Forms.GroupBox();
      this.btnErrors = new System.Windows.Forms.Button();
      this.lblActualReceivedMessages = new System.Windows.Forms.Label();
      this.lblActualSendMessages = new System.Windows.Forms.Label();
      this.lvMessages = new System.Windows.Forms.ListView();
      this.label5 = new System.Windows.Forms.Label();
      this.txtKeepNumberMessages = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.lblNumberMessagesSecond = new System.Windows.Forms.Label();
      this.lblNumberMessages = new System.Windows.Forms.Label();
      this.btnClear = new System.Windows.Forms.Button();
      this.cbEcho = new System.Windows.Forms.CheckBox();
      this.grbAutoMessages = new System.Windows.Forms.GroupBox();
      this.btnLoadAutoMessage = new System.Windows.Forms.Button();
      this.cbRandom = new System.Windows.Forms.CheckBox();
      this.lvAutoMessage = new System.Windows.Forms.ListView();
      this.lblMaxSendPerMinute = new System.Windows.Forms.Label();
      this.txtMaxSendPerMinute = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.btnEditAutoMessage = new System.Windows.Forms.Button();
      this.btnSaveAutoMessage = new System.Windows.Forms.Button();
      this.btnDeleteAutoMessage = new System.Windows.Forms.Button();
      this.btnAddAutoMessage = new System.Windows.Forms.Button();
      this.grbLogging = new System.Windows.Forms.GroupBox();
      this.cbEnablePduLog = new System.Windows.Forms.CheckBox();
      this.btnBrowseSessionLogFolder = new System.Windows.Forms.Button();
      this.btnBrowseServerLogFile = new System.Windows.Forms.Button();
      this.cbEnableSessionLog = new System.Windows.Forms.CheckBox();
      this.txtSessionLog = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.cbEnableServerLog = new System.Windows.Forms.CheckBox();
      this.txtServerLog = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.tmrServer = new System.Windows.Forms.Timer(this.components);
      this.pnlBranding = new System.Windows.Forms.Panel();
      this.llblAxLink = new System.Windows.Forms.LinkLabel();
      this.llblFooterText = new System.Windows.Forms.LinkLabel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.splitTop = new System.Windows.Forms.Splitter();
      this.panel3 = new System.Windows.Forms.Panel();
      this.splitBottom = new System.Windows.Forms.Splitter();
      this.panel4 = new System.Windows.Forms.Panel();
      this.pbLogo = new System.Windows.Forms.PictureBox();
      this.pbInfo = new System.Windows.Forms.PictureBox();
      this.grbControlPanel.SuspendLayout();
      this.grbSessions.SuspendLayout();
      this.grbMessages.SuspendLayout();
      this.grbAutoMessages.SuspendLayout();
      this.grbLogging.SuspendLayout();
      this.pnlBranding.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
      this.SuspendLayout();
      // 
      // grbControlPanel
      // 
      this.grbControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grbControlPanel.Controls.Add(this.cbxCertificate);
      this.grbControlPanel.Controls.Add(this.btnServerOptions);
      this.grbControlPanel.Controls.Add(this.cbxIpVersion);
      this.grbControlPanel.Controls.Add(this.btnStop);
      this.grbControlPanel.Controls.Add(this.btnStart);
      this.grbControlPanel.Controls.Add(this.label1);
      this.grbControlPanel.Controls.Add(this.txtPort);
      this.grbControlPanel.Location = new System.Drawing.Point(15, 58);
      this.grbControlPanel.Name = "grbControlPanel";
      this.grbControlPanel.Size = new System.Drawing.Size(755, 50);
      this.grbControlPanel.TabIndex = 1;
      this.grbControlPanel.TabStop = false;
      this.grbControlPanel.Text = "Server";
      // 
      // cbxCertificate
      // 
      this.cbxCertificate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxCertificate.FormattingEnabled = true;
      this.cbxCertificate.Location = new System.Drawing.Point(213, 20);
      this.cbxCertificate.Name = "cbxCertificate";
      this.cbxCertificate.Size = new System.Drawing.Size(222, 21);
      this.cbxCertificate.TabIndex = 8;
      // 
      // btnServerOptions
      // 
      this.btnServerOptions.Location = new System.Drawing.Point(656, 19);
      this.btnServerOptions.Name = "btnServerOptions";
      this.btnServerOptions.Size = new System.Drawing.Size(91, 23);
      this.btnServerOptions.TabIndex = 7;
      this.btnServerOptions.Text = "Options...";
      this.btnServerOptions.UseVisualStyleBackColor = true;
      this.btnServerOptions.Click += new System.EventHandler(this.btnServerOptions_Click);
      // 
      // cbxIpVersion
      // 
      this.cbxIpVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxIpVersion.FormattingEnabled = true;
      this.cbxIpVersion.Location = new System.Drawing.Point(132, 20);
      this.cbxIpVersion.Name = "cbxIpVersion";
      this.cbxIpVersion.Size = new System.Drawing.Size(74, 21);
      this.cbxIpVersion.TabIndex = 2;
      // 
      // btnStop
      // 
      this.btnStop.Location = new System.Drawing.Point(557, 19);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(92, 23);
      this.btnStop.TabIndex = 6;
      this.btnStop.Text = "Stop";
      this.btnStop.UseVisualStyleBackColor = true;
      this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(458, 19);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(92, 23);
      this.btnStart.TabIndex = 5;
      this.btnStart.Text = "Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(16, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(29, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "&Port:";
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(51, 20);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(74, 20);
      this.txtPort.TabIndex = 1;
      this.txtPort.Text = "2775";
      this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
      // 
      // grbSessions
      // 
      this.grbSessions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grbSessions.Controls.Add(this.cbAuthentication);
      this.grbSessions.Controls.Add(this.lvSessions);
      this.grbSessions.Controls.Add(this.lblSessionsCount);
      this.grbSessions.Controls.Add(this.btnSendSession);
      this.grbSessions.Controls.Add(this.btnInfoSession);
      this.grbSessions.Controls.Add(this.btnDropSession);
      this.grbSessions.Controls.Add(this.txtPassword);
      this.grbSessions.Controls.Add(this.label3);
      this.grbSessions.Controls.Add(this.txtSystemId);
      this.grbSessions.Controls.Add(this.label2);
      this.grbSessions.Location = new System.Drawing.Point(15, 114);
      this.grbSessions.Name = "grbSessions";
      this.grbSessions.Size = new System.Drawing.Size(755, 133);
      this.grbSessions.TabIndex = 2;
      this.grbSessions.TabStop = false;
      this.grbSessions.Text = "Sessions";
      // 
      // cbAuthentication
      // 
      this.cbAuthentication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbAuthentication.AutoSize = true;
      this.cbAuthentication.Location = new System.Drawing.Point(18, 108);
      this.cbAuthentication.Name = "cbAuthentication";
      this.cbAuthentication.Size = new System.Drawing.Size(94, 17);
      this.cbAuthentication.TabIndex = 4;
      this.cbAuthentication.Text = "&Authentication";
      this.cbAuthentication.UseVisualStyleBackColor = true;
      this.cbAuthentication.CheckedChanged += new System.EventHandler(this.cbAuthentication_CheckedChanged);
      // 
      // lvSessions
      // 
      this.lvSessions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvSessions.FullRowSelect = true;
      this.lvSessions.Location = new System.Drawing.Point(18, 18);
      this.lvSessions.MultiSelect = false;
      this.lvSessions.Name = "lvSessions";
      this.lvSessions.Size = new System.Drawing.Size(630, 80);
      this.lvSessions.TabIndex = 0;
      this.lvSessions.UseCompatibleStateImageBehavior = false;
      this.lvSessions.View = System.Windows.Forms.View.Details;
      this.lvSessions.SelectedIndexChanged += new System.EventHandler(this.lvSessions_SelectedIndexChanged);
      this.lvSessions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSessions_MouseDoubleClick);
      // 
      // lblSessionsCount
      // 
      this.lblSessionsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblSessionsCount.AutoSize = true;
      this.lblSessionsCount.Location = new System.Drawing.Point(654, 110);
      this.lblSessionsCount.Name = "lblSessionsCount";
      this.lblSessionsCount.Size = new System.Drawing.Size(58, 13);
      this.lblSessionsCount.TabIndex = 9;
      this.lblSessionsCount.Text = "0 Sessions";
      // 
      // btnSendSession
      // 
      this.btnSendSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSendSession.Enabled = false;
      this.btnSendSession.Location = new System.Drawing.Point(656, 48);
      this.btnSendSession.Name = "btnSendSession";
      this.btnSendSession.Size = new System.Drawing.Size(91, 23);
      this.btnSendSession.TabIndex = 2;
      this.btnSendSession.Text = "Send...";
      this.btnSendSession.UseVisualStyleBackColor = true;
      this.btnSendSession.Click += new System.EventHandler(this.btnSendSession_Click);
      // 
      // btnInfoSession
      // 
      this.btnInfoSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnInfoSession.Enabled = false;
      this.btnInfoSession.Location = new System.Drawing.Point(656, 19);
      this.btnInfoSession.Name = "btnInfoSession";
      this.btnInfoSession.Size = new System.Drawing.Size(91, 23);
      this.btnInfoSession.TabIndex = 1;
      this.btnInfoSession.Text = "Info...";
      this.btnInfoSession.UseVisualStyleBackColor = true;
      this.btnInfoSession.Click += new System.EventHandler(this.btnInfoSession_Click);
      // 
      // btnDropSession
      // 
      this.btnDropSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDropSession.Enabled = false;
      this.btnDropSession.Location = new System.Drawing.Point(656, 77);
      this.btnDropSession.Name = "btnDropSession";
      this.btnDropSession.Size = new System.Drawing.Size(91, 23);
      this.btnDropSession.TabIndex = 3;
      this.btnDropSession.Text = "Drop";
      this.btnDropSession.UseVisualStyleBackColor = true;
      this.btnDropSession.Click += new System.EventHandler(this.btnDropSession_Click);
      // 
      // txtPassword
      // 
      this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtPassword.Enabled = false;
      this.txtPassword.Location = new System.Drawing.Point(463, 106);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(112, 20);
      this.txtPassword.TabIndex = 8;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(401, 109);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(56, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "Pass&word:";
      // 
      // txtSystemId
      // 
      this.txtSystemId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtSystemId.Enabled = false;
      this.txtSystemId.Location = new System.Drawing.Point(190, 106);
      this.txtSystemId.Name = "txtSystemId";
      this.txtSystemId.Size = new System.Drawing.Size(112, 20);
      this.txtSystemId.TabIndex = 6;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(128, 109);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "&SystemID:";
      // 
      // grbMessages
      // 
      this.grbMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grbMessages.Controls.Add(this.btnErrors);
      this.grbMessages.Controls.Add(this.lblActualReceivedMessages);
      this.grbMessages.Controls.Add(this.lblActualSendMessages);
      this.grbMessages.Controls.Add(this.lvMessages);
      this.grbMessages.Controls.Add(this.label5);
      this.grbMessages.Controls.Add(this.txtKeepNumberMessages);
      this.grbMessages.Controls.Add(this.label4);
      this.grbMessages.Controls.Add(this.lblNumberMessagesSecond);
      this.grbMessages.Controls.Add(this.lblNumberMessages);
      this.grbMessages.Controls.Add(this.btnClear);
      this.grbMessages.Controls.Add(this.cbEcho);
      this.grbMessages.Location = new System.Drawing.Point(15, 6);
      this.grbMessages.Name = "grbMessages";
      this.grbMessages.Size = new System.Drawing.Size(755, 160);
      this.grbMessages.TabIndex = 0;
      this.grbMessages.TabStop = false;
      this.grbMessages.Text = "Messages";
      // 
      // btnErrors
      // 
      this.btnErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnErrors.Location = new System.Drawing.Point(656, 48);
      this.btnErrors.Name = "btnErrors";
      this.btnErrors.Size = new System.Drawing.Size(91, 23);
      this.btnErrors.TabIndex = 2;
      this.btnErrors.Text = "Failure Rate...";
      this.btnErrors.UseVisualStyleBackColor = true;
      this.btnErrors.Click += new System.EventHandler(this.btnErrors_Click);
      // 
      // lblActualReceivedMessages
      // 
      this.lblActualReceivedMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblActualReceivedMessages.AutoSize = true;
      this.lblActualReceivedMessages.Location = new System.Drawing.Point(653, 113);
      this.lblActualReceivedMessages.Name = "lblActualReceivedMessages";
      this.lblActualReceivedMessages.Size = new System.Drawing.Size(86, 13);
      this.lblActualReceivedMessages.TabIndex = 6;
      this.lblActualReceivedMessages.Text = "0 Recv msg/sec";
      // 
      // lblActualSendMessages
      // 
      this.lblActualSendMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblActualSendMessages.AutoSize = true;
      this.lblActualSendMessages.Location = new System.Drawing.Point(653, 100);
      this.lblActualSendMessages.Name = "lblActualSendMessages";
      this.lblActualSendMessages.Size = new System.Drawing.Size(82, 13);
      this.lblActualSendMessages.TabIndex = 5;
      this.lblActualSendMessages.Text = "0 Sent msg/sec";
      // 
      // lvMessages
      // 
      this.lvMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvMessages.FullRowSelect = true;
      this.lvMessages.Location = new System.Drawing.Point(18, 19);
      this.lvMessages.MultiSelect = false;
      this.lvMessages.Name = "lvMessages";
      this.lvMessages.Size = new System.Drawing.Size(630, 109);
      this.lvMessages.TabIndex = 0;
      this.lvMessages.UseCompatibleStateImageBehavior = false;
      this.lvMessages.View = System.Windows.Forms.View.Details;
      this.lvMessages.DoubleClick += new System.EventHandler(this.lvMessages_DoubleClick);
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(307, 137);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(55, 13);
      this.label5.TabIndex = 10;
      this.label5.Text = "Messages";
      // 
      // txtKeepNumberMessages
      // 
      this.txtKeepNumberMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtKeepNumberMessages.Location = new System.Drawing.Point(189, 134);
      this.txtKeepNumberMessages.Name = "txtKeepNumberMessages";
      this.txtKeepNumberMessages.Size = new System.Drawing.Size(112, 20);
      this.txtKeepNumberMessages.TabIndex = 9;
      this.txtKeepNumberMessages.Text = "100";
      this.txtKeepNumberMessages.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
      this.txtKeepNumberMessages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(127, 137);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(35, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "&Keep:";
      // 
      // lblNumberMessagesSecond
      // 
      this.lblNumberMessagesSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblNumberMessagesSecond.AutoSize = true;
      this.lblNumberMessagesSecond.Location = new System.Drawing.Point(653, 87);
      this.lblNumberMessagesSecond.Name = "lblNumberMessagesSecond";
      this.lblNumberMessagesSecond.Size = new System.Drawing.Size(58, 13);
      this.lblNumberMessagesSecond.TabIndex = 4;
      this.lblNumberMessagesSecond.Text = "0 Msg/sec";
      // 
      // lblNumberMessages
      // 
      this.lblNumberMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblNumberMessages.AutoSize = true;
      this.lblNumberMessages.Location = new System.Drawing.Point(653, 74);
      this.lblNumberMessages.Name = "lblNumberMessages";
      this.lblNumberMessages.Size = new System.Drawing.Size(64, 13);
      this.lblNumberMessages.TabIndex = 3;
      this.lblNumberMessages.Text = "0 Messages";
      // 
      // btnClear
      // 
      this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClear.Location = new System.Drawing.Point(656, 19);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(91, 23);
      this.btnClear.TabIndex = 1;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // cbEcho
      // 
      this.cbEcho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbEcho.AutoSize = true;
      this.cbEcho.Location = new System.Drawing.Point(18, 136);
      this.cbEcho.Name = "cbEcho";
      this.cbEcho.Size = new System.Drawing.Size(51, 17);
      this.cbEcho.TabIndex = 7;
      this.cbEcho.Text = "&Echo";
      this.cbEcho.UseVisualStyleBackColor = true;
      // 
      // grbAutoMessages
      // 
      this.grbAutoMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grbAutoMessages.Controls.Add(this.btnLoadAutoMessage);
      this.grbAutoMessages.Controls.Add(this.cbRandom);
      this.grbAutoMessages.Controls.Add(this.lvAutoMessage);
      this.grbAutoMessages.Controls.Add(this.lblMaxSendPerMinute);
      this.grbAutoMessages.Controls.Add(this.txtMaxSendPerMinute);
      this.grbAutoMessages.Controls.Add(this.label7);
      this.grbAutoMessages.Controls.Add(this.btnEditAutoMessage);
      this.grbAutoMessages.Controls.Add(this.btnSaveAutoMessage);
      this.grbAutoMessages.Controls.Add(this.btnDeleteAutoMessage);
      this.grbAutoMessages.Controls.Add(this.btnAddAutoMessage);
      this.grbAutoMessages.Location = new System.Drawing.Point(15, 6);
      this.grbAutoMessages.Name = "grbAutoMessages";
      this.grbAutoMessages.Size = new System.Drawing.Size(755, 164);
      this.grbAutoMessages.TabIndex = 0;
      this.grbAutoMessages.TabStop = false;
      this.grbAutoMessages.Text = "Auto Messages";
      // 
      // btnLoadAutoMessage
      // 
      this.btnLoadAutoMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnLoadAutoMessage.Location = new System.Drawing.Point(656, 106);
      this.btnLoadAutoMessage.Name = "btnLoadAutoMessage";
      this.btnLoadAutoMessage.Size = new System.Drawing.Size(91, 23);
      this.btnLoadAutoMessage.TabIndex = 4;
      this.btnLoadAutoMessage.Text = "Load...";
      this.btnLoadAutoMessage.UseVisualStyleBackColor = true;
      this.btnLoadAutoMessage.Click += new System.EventHandler(this.btnLoadAutoMessage_Click);
      // 
      // cbRandom
      // 
      this.cbRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbRandom.AutoSize = true;
      this.cbRandom.Location = new System.Drawing.Point(18, 135);
      this.cbRandom.Name = "cbRandom";
      this.cbRandom.Size = new System.Drawing.Size(66, 17);
      this.cbRandom.TabIndex = 6;
      this.cbRandom.Text = "&Random";
      this.cbRandom.UseVisualStyleBackColor = true;
      // 
      // lvAutoMessage
      // 
      this.lvAutoMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvAutoMessage.FullRowSelect = true;
      this.lvAutoMessage.Location = new System.Drawing.Point(18, 19);
      this.lvAutoMessage.MultiSelect = false;
      this.lvAutoMessage.Name = "lvAutoMessage";
      this.lvAutoMessage.Size = new System.Drawing.Size(630, 110);
      this.lvAutoMessage.TabIndex = 0;
      this.lvAutoMessage.UseCompatibleStateImageBehavior = false;
      this.lvAutoMessage.View = System.Windows.Forms.View.Details;
      this.lvAutoMessage.DoubleClick += new System.EventHandler(this.lvAutoReply_DoubleClick);
      // 
      // lblMaxSendPerMinute
      // 
      this.lblMaxSendPerMinute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblMaxSendPerMinute.AutoSize = true;
      this.lblMaxSendPerMinute.Location = new System.Drawing.Point(307, 138);
      this.lblMaxSendPerMinute.Name = "lblMaxSendPerMinute";
      this.lblMaxSendPerMinute.Size = new System.Drawing.Size(70, 13);
      this.lblMaxSendPerMinute.TabIndex = 9;
      this.lblMaxSendPerMinute.Text = "Msg / Minute";
      // 
      // txtMaxSendPerMinute
      // 
      this.txtMaxSendPerMinute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtMaxSendPerMinute.Location = new System.Drawing.Point(189, 135);
      this.txtMaxSendPerMinute.Name = "txtMaxSendPerMinute";
      this.txtMaxSendPerMinute.Size = new System.Drawing.Size(112, 20);
      this.txtMaxSendPerMinute.TabIndex = 8;
      this.txtMaxSendPerMinute.Text = "0";
      this.txtMaxSendPerMinute.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
      this.txtMaxSendPerMinute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(128, 138);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(35, 13);
      this.label7.TabIndex = 7;
      this.label7.Text = "&Send:";
      // 
      // btnEditAutoMessage
      // 
      this.btnEditAutoMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnEditAutoMessage.Location = new System.Drawing.Point(656, 77);
      this.btnEditAutoMessage.Name = "btnEditAutoMessage";
      this.btnEditAutoMessage.Size = new System.Drawing.Size(91, 23);
      this.btnEditAutoMessage.TabIndex = 3;
      this.btnEditAutoMessage.Text = "Edit...";
      this.btnEditAutoMessage.UseVisualStyleBackColor = true;
      this.btnEditAutoMessage.Click += new System.EventHandler(this.btnEditAutoMessage_Click);
      // 
      // btnSaveAutoMessage
      // 
      this.btnSaveAutoMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSaveAutoMessage.Location = new System.Drawing.Point(656, 135);
      this.btnSaveAutoMessage.Name = "btnSaveAutoMessage";
      this.btnSaveAutoMessage.Size = new System.Drawing.Size(91, 23);
      this.btnSaveAutoMessage.TabIndex = 5;
      this.btnSaveAutoMessage.Text = "Save...";
      this.btnSaveAutoMessage.UseVisualStyleBackColor = true;
      this.btnSaveAutoMessage.Click += new System.EventHandler(this.btnSaveAutoMessage_Click);
      // 
      // btnDeleteAutoMessage
      // 
      this.btnDeleteAutoMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDeleteAutoMessage.Location = new System.Drawing.Point(656, 48);
      this.btnDeleteAutoMessage.Name = "btnDeleteAutoMessage";
      this.btnDeleteAutoMessage.Size = new System.Drawing.Size(91, 23);
      this.btnDeleteAutoMessage.TabIndex = 2;
      this.btnDeleteAutoMessage.Text = "Delete";
      this.btnDeleteAutoMessage.UseVisualStyleBackColor = true;
      this.btnDeleteAutoMessage.Click += new System.EventHandler(this.btnDeleteAutoMessage_Click);
      // 
      // btnAddAutoMessage
      // 
      this.btnAddAutoMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAddAutoMessage.Location = new System.Drawing.Point(656, 19);
      this.btnAddAutoMessage.Name = "btnAddAutoMessage";
      this.btnAddAutoMessage.Size = new System.Drawing.Size(91, 23);
      this.btnAddAutoMessage.TabIndex = 1;
      this.btnAddAutoMessage.Text = "Add...";
      this.btnAddAutoMessage.UseVisualStyleBackColor = true;
      this.btnAddAutoMessage.Click += new System.EventHandler(this.btnAddAutoMessage_Click);
      // 
      // grbLogging
      // 
      this.grbLogging.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grbLogging.Controls.Add(this.cbEnablePduLog);
      this.grbLogging.Controls.Add(this.btnBrowseSessionLogFolder);
      this.grbLogging.Controls.Add(this.btnBrowseServerLogFile);
      this.grbLogging.Controls.Add(this.cbEnableSessionLog);
      this.grbLogging.Controls.Add(this.txtSessionLog);
      this.grbLogging.Controls.Add(this.label10);
      this.grbLogging.Controls.Add(this.cbEnableServerLog);
      this.grbLogging.Controls.Add(this.txtServerLog);
      this.grbLogging.Controls.Add(this.label9);
      this.grbLogging.Location = new System.Drawing.Point(15, 176);
      this.grbLogging.Name = "grbLogging";
      this.grbLogging.Size = new System.Drawing.Size(755, 78);
      this.grbLogging.TabIndex = 1;
      this.grbLogging.TabStop = false;
      this.grbLogging.Text = "Log";
      // 
      // cbEnablePduLog
      // 
      this.cbEnablePduLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbEnablePduLog.AutoSize = true;
      this.cbEnablePduLog.Enabled = false;
      this.cbEnablePduLog.Location = new System.Drawing.Point(599, 47);
      this.cbEnablePduLog.Name = "cbEnablePduLog";
      this.cbEnablePduLog.Size = new System.Drawing.Size(49, 17);
      this.cbEnablePduLog.TabIndex = 6;
      this.cbEnablePduLog.Text = "&PDU";
      this.cbEnablePduLog.UseVisualStyleBackColor = true;
      // 
      // btnBrowseSessionLogFolder
      // 
      this.btnBrowseSessionLogFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnBrowseSessionLogFolder.Enabled = false;
      this.btnBrowseSessionLogFolder.Location = new System.Drawing.Point(657, 43);
      this.btnBrowseSessionLogFolder.Name = "btnBrowseSessionLogFolder";
      this.btnBrowseSessionLogFolder.Size = new System.Drawing.Size(28, 23);
      this.btnBrowseSessionLogFolder.TabIndex = 7;
      this.btnBrowseSessionLogFolder.Text = "...";
      this.btnBrowseSessionLogFolder.UseVisualStyleBackColor = true;
      this.btnBrowseSessionLogFolder.Click += new System.EventHandler(this.btnBrowseSessionLogFolder_Click);
      // 
      // btnBrowseServerLogFile
      // 
      this.btnBrowseServerLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnBrowseServerLogFile.Enabled = false;
      this.btnBrowseServerLogFile.Location = new System.Drawing.Point(657, 16);
      this.btnBrowseServerLogFile.Name = "btnBrowseServerLogFile";
      this.btnBrowseServerLogFile.Size = new System.Drawing.Size(28, 23);
      this.btnBrowseServerLogFile.TabIndex = 2;
      this.btnBrowseServerLogFile.Text = "...";
      this.btnBrowseServerLogFile.UseVisualStyleBackColor = true;
      this.btnBrowseServerLogFile.Click += new System.EventHandler(this.btnBrowseServerLogFile_Click);
      // 
      // cbEnableSessionLog
      // 
      this.cbEnableSessionLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbEnableSessionLog.AutoSize = true;
      this.cbEnableSessionLog.Location = new System.Drawing.Point(691, 47);
      this.cbEnableSessionLog.Name = "cbEnableSessionLog";
      this.cbEnableSessionLog.Size = new System.Drawing.Size(59, 17);
      this.cbEnableSessionLog.TabIndex = 8;
      this.cbEnableSessionLog.Text = "Ena&ble";
      this.cbEnableSessionLog.UseVisualStyleBackColor = true;
      this.cbEnableSessionLog.CheckedChanged += new System.EventHandler(this.cbEnableSessionLog_CheckedChanged);
      // 
      // txtSessionLog
      // 
      this.txtSessionLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSessionLog.Enabled = false;
      this.txtSessionLog.Location = new System.Drawing.Point(131, 45);
      this.txtSessionLog.Name = "txtSessionLog";
      this.txtSessionLog.ReadOnly = true;
      this.txtSessionLog.Size = new System.Drawing.Size(462, 20);
      this.txtSessionLog.TabIndex = 5;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(15, 48);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(68, 13);
      this.label10.TabIndex = 4;
      this.label10.Text = "Sess&ion Log:";
      // 
      // cbEnableServerLog
      // 
      this.cbEnableServerLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbEnableServerLog.AutoSize = true;
      this.cbEnableServerLog.Location = new System.Drawing.Point(691, 21);
      this.cbEnableServerLog.Name = "cbEnableServerLog";
      this.cbEnableServerLog.Size = new System.Drawing.Size(59, 17);
      this.cbEnableServerLog.TabIndex = 3;
      this.cbEnableServerLog.Text = "E&nable";
      this.cbEnableServerLog.UseVisualStyleBackColor = true;
      this.cbEnableServerLog.CheckedChanged += new System.EventHandler(this.cbEnableServerLog_CheckedChanged);
      // 
      // txtServerLog
      // 
      this.txtServerLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtServerLog.Enabled = false;
      this.txtServerLog.Location = new System.Drawing.Point(130, 19);
      this.txtServerLog.Name = "txtServerLog";
      this.txtServerLog.ReadOnly = true;
      this.txtServerLog.Size = new System.Drawing.Size(518, 20);
      this.txtServerLog.TabIndex = 1;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(15, 22);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(62, 13);
      this.label9.TabIndex = 0;
      this.label9.Text = "Ser&ver Log:";
      // 
      // tmrServer
      // 
      this.tmrServer.Interval = 500;
      this.tmrServer.Tick += new System.EventHandler(this.tmrServer_Tick);
      // 
      // pnlBranding
      // 
      this.pnlBranding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlBranding.BackColor = System.Drawing.Color.White;
      this.pnlBranding.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.pnlBranding.Controls.Add(this.pbLogo);
      this.pnlBranding.Controls.Add(this.llblAxLink);
      this.pnlBranding.Location = new System.Drawing.Point(15, 12);
      this.pnlBranding.Name = "pnlBranding";
      this.pnlBranding.Size = new System.Drawing.Size(756, 40);
      this.pnlBranding.TabIndex = 0;
      // 
      // llblAxLink
      // 
      this.llblAxLink.AutoSize = true;
      this.llblAxLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.llblAxLink.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
      this.llblAxLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.llblAxLink.Location = new System.Drawing.Point(486, 23);
      this.llblAxLink.Name = "llblAxLink";
      this.llblAxLink.Size = new System.Drawing.Size(33, 13);
      this.llblAxLink.TabIndex = 0;
      this.llblAxLink.Text = "[Link]";
      // 
      // llblFooterText
      // 
      this.llblFooterText.AutoSize = true;
      this.llblFooterText.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
      this.llblFooterText.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.llblFooterText.Location = new System.Drawing.Point(32, 4);
      this.llblFooterText.Name = "llblFooterText";
      this.llblFooterText.Size = new System.Drawing.Size(55, 13);
      this.llblFooterText.TabIndex = 0;
      this.llblFooterText.Text = "linkLabel1";
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Controls.Add(this.llblFooterText);
      this.panel1.Controls.Add(this.pbInfo);
      this.panel1.Location = new System.Drawing.Point(15, 261);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(755, 32);
      this.panel1.TabIndex = 2;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.pnlBranding);
      this.panel2.Controls.Add(this.grbSessions);
      this.panel2.Controls.Add(this.grbControlPanel);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(780, 253);
      this.panel2.TabIndex = 0;
      // 
      // splitTop
      // 
      this.splitTop.BackColor = System.Drawing.SystemColors.Control;
      this.splitTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.splitTop.Location = new System.Drawing.Point(0, 253);
      this.splitTop.Name = "splitTop";
      this.splitTop.Size = new System.Drawing.Size(780, 3);
      this.splitTop.TabIndex = 56;
      this.splitTop.TabStop = false;
      this.splitTop.Paint += new System.Windows.Forms.PaintEventHandler(this.splitter_Paint);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.grbMessages);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(0, 256);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(780, 178);
      this.panel3.TabIndex = 1;
      // 
      // splitBottom
      // 
      this.splitBottom.BackColor = System.Drawing.SystemColors.Control;
      this.splitBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splitBottom.Location = new System.Drawing.Point(0, 431);
      this.splitBottom.Name = "splitBottom";
      this.splitBottom.Size = new System.Drawing.Size(780, 3);
      this.splitBottom.TabIndex = 3;
      this.splitBottom.TabStop = false;
      this.splitBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.splitter_Paint);
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.grbLogging);
      this.panel4.Controls.Add(this.grbAutoMessages);
      this.panel4.Controls.Add(this.panel1);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel4.Location = new System.Drawing.Point(0, 434);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(780, 303);
      this.panel4.TabIndex = 4;
      // 
      // pbLogo
      // 
      this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.pbLogo.Image = global::SmppSimulator.Properties.Resources.logo;
      this.pbLogo.Location = new System.Drawing.Point(0, -1);
      this.pbLogo.Name = "pbLogo";
      this.pbLogo.Size = new System.Drawing.Size(301, 40);
      this.pbLogo.TabIndex = 6;
      this.pbLogo.TabStop = false;
      // 
      // pbInfo
      // 
      this.pbInfo.Image = global::SmppSimulator.Properties.Resources.information_balloon_center;
      this.pbInfo.Location = new System.Drawing.Point(0, 2);
      this.pbInfo.Name = "pbInfo";
      this.pbInfo.Size = new System.Drawing.Size(34, 27);
      this.pbInfo.TabIndex = 49;
      this.pbInfo.TabStop = false;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(780, 737);
      this.Controls.Add(this.splitBottom);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.splitTop);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel4);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(796, 776);
      this.Name = "frmMain";
      this.Text = "Auron SMPP Simulator";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
      this.Resize += new System.EventHandler(this.frmMain_Resize);
      this.grbControlPanel.ResumeLayout(false);
      this.grbControlPanel.PerformLayout();
      this.grbSessions.ResumeLayout(false);
      this.grbSessions.PerformLayout();
      this.grbMessages.ResumeLayout(false);
      this.grbMessages.PerformLayout();
      this.grbAutoMessages.ResumeLayout(false);
      this.grbAutoMessages.PerformLayout();
      this.grbLogging.ResumeLayout(false);
      this.grbLogging.PerformLayout();
      this.pnlBranding.ResumeLayout(false);
      this.pnlBranding.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbControlPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox grbSessions;
        private System.Windows.Forms.Label lblSessionsCount;
        private System.Windows.Forms.Button btnSendSession;
        private System.Windows.Forms.Button btnInfoSession;
        private System.Windows.Forms.Button btnDropSession;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbMessages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKeepNumberMessages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNumberMessagesSecond;
        private System.Windows.Forms.Label lblNumberMessages;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grbAutoMessages;
        private System.Windows.Forms.CheckBox cbEcho;
        private System.Windows.Forms.Button btnEditAutoMessage;
        private System.Windows.Forms.Button btnSaveAutoMessage;
        private System.Windows.Forms.Button btnDeleteAutoMessage;
        private System.Windows.Forms.Button btnAddAutoMessage;
        private System.Windows.Forms.Label lblMaxSendPerMinute;
        private System.Windows.Forms.TextBox txtMaxSendPerMinute;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grbLogging;
        private System.Windows.Forms.CheckBox cbEnableSessionLog;
        private System.Windows.Forms.TextBox txtSessionLog;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbEnableServerLog;
        private System.Windows.Forms.TextBox txtServerLog;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer tmrServer;
        internal System.Windows.Forms.ListView lvSessions;
        internal System.Windows.Forms.ListView lvMessages;
        internal System.Windows.Forms.ListView lvAutoMessage;
        private System.Windows.Forms.CheckBox cbAuthentication;
        private System.Windows.Forms.Button btnLoadAutoMessage;
        private System.Windows.Forms.CheckBox cbRandom;
        private System.Windows.Forms.Button btnBrowseSessionLogFolder;
        private System.Windows.Forms.Button btnBrowseServerLogFile;
        private System.Windows.Forms.CheckBox cbEnablePduLog;
        private System.Windows.Forms.Panel pnlBranding;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.LinkLabel llblAxLink;
        private System.Windows.Forms.LinkLabel llblFooterText;
        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitTop;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitBottom;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblActualSendMessages;
        private System.Windows.Forms.Label lblActualReceivedMessages;
        private System.Windows.Forms.Button btnErrors;
        private System.Windows.Forms.ComboBox cbxIpVersion;
        private System.Windows.Forms.Button btnServerOptions;
    private System.Windows.Forms.ComboBox cbxCertificate;
  }
}

