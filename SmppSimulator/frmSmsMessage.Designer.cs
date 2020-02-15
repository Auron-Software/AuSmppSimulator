namespace SmppSimulator
{
    partial class frmSmsMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSmsMessage));
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSystemId = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnShowComplete = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxBodyFormat = new System.Windows.Forms.ComboBox();
            this.cbxDataCoding = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbDeliveryReport = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxFromNpi = new System.Windows.Forms.ComboBox();
            this.cbxFromTon = new System.Windows.Forms.ComboBox();
            this.txtFromAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxToNpi = new System.Windows.Forms.ComboBox();
            this.cbxToTon = new System.Windows.Forms.ComboBox();
            this.lblCharacters = new System.Windows.Forms.Label();
            this.cbUDH = new System.Windows.Forms.CheckBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtToAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btRemove = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.lvTlvs = new System.Windows.Forms.ListView();
            this.lbDirection = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(377, 511);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(103, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(486, 511);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSystemId
            // 
            this.lblSystemId.AutoSize = true;
            this.lblSystemId.Location = new System.Drawing.Point(79, 42);
            this.lblSystemId.Name = "lblSystemId";
            this.lblSystemId.Size = new System.Drawing.Size(24, 13);
            this.lblSystemId.TabIndex = 3;
            this.lblSystemId.Text = "n/a";
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(79, 19);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(24, 13);
            this.lblIp.TabIndex = 1;
            this.lblIp.Text = "n/a";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "SystemID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Controls.Add(this.lbDirection);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblSystemId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblIp);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(287, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Status:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(287, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Direction:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnShowComplete);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbxBodyFormat);
            this.groupBox2.Controls.Add(this.cbxDataCoding);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cbDeliveryReport);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbxFromNpi);
            this.groupBox2.Controls.Add(this.cbxFromTon);
            this.groupBox2.Controls.Add(this.txtFromAddress);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbxToNpi);
            this.groupBox2.Controls.Add(this.cbxToTon);
            this.groupBox2.Controls.Add(this.lblCharacters);
            this.groupBox2.Controls.Add(this.cbUDH);
            this.groupBox2.Controls.Add(this.txtBody);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtToAddress);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(576, 270);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message";
            // 
            // btnShowComplete
            // 
            this.btnShowComplete.Location = new System.Drawing.Point(81, 238);
            this.btnShowComplete.Name = "btnShowComplete";
            this.btnShowComplete.Size = new System.Drawing.Size(200, 23);
            this.btnShowComplete.TabIndex = 21;
            this.btnShowComplete.Text = "Show Complete Message";
            this.btnShowComplete.UseVisualStyleBackColor = true;
            this.btnShowComplete.Click += new System.EventHandler(this.btnShowComplete_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Format:";
            // 
            // cbxBodyFormat
            // 
            this.cbxBodyFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBodyFormat.FormattingEnabled = true;
            this.cbxBodyFormat.Location = new System.Drawing.Point(81, 128);
            this.cbxBodyFormat.Name = "cbxBodyFormat";
            this.cbxBodyFormat.Size = new System.Drawing.Size(200, 21);
            this.cbxBodyFormat.TabIndex = 9;
            this.cbxBodyFormat.SelectedIndexChanged += new System.EventHandler(this.cbxBodyFormat_SelectedIndexChanged);
            // 
            // cbxDataCoding
            // 
            this.cbxDataCoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDataCoding.FormattingEnabled = true;
            this.cbxDataCoding.Location = new System.Drawing.Point(81, 101);
            this.cbxDataCoding.Name = "cbxDataCoding";
            this.cbxDataCoding.Size = new System.Drawing.Size(200, 21);
            this.cbxDataCoding.TabIndex = 7;
            this.cbxDataCoding.SelectedIndexChanged += new System.EventHandler(this.cbxDataCoding_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Data Coding:";
            // 
            // cbDeliveryReport
            // 
            this.cbDeliveryReport.AutoSize = true;
            this.cbDeliveryReport.Location = new System.Drawing.Point(424, 130);
            this.cbDeliveryReport.Name = "cbDeliveryReport";
            this.cbDeliveryReport.Size = new System.Drawing.Size(110, 17);
            this.cbDeliveryReport.TabIndex = 17;
            this.cbDeliveryReport.Text = "Is Delivery Report";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "From NPI:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(286, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "From TON:";
            // 
            // cbxFromNpi
            // 
            this.cbxFromNpi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFromNpi.FormattingEnabled = true;
            this.cbxFromNpi.Location = new System.Drawing.Point(367, 77);
            this.cbxFromNpi.Name = "cbxFromNpi";
            this.cbxFromNpi.Size = new System.Drawing.Size(200, 21);
            this.cbxFromNpi.TabIndex = 15;
            // 
            // cbxFromTon
            // 
            this.cbxFromTon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFromTon.FormattingEnabled = true;
            this.cbxFromTon.Location = new System.Drawing.Point(367, 50);
            this.cbxFromTon.Name = "cbxFromTon";
            this.cbxFromTon.Size = new System.Drawing.Size(200, 21);
            this.cbxFromTon.TabIndex = 13;
            // 
            // txtFromAddress
            // 
            this.txtFromAddress.Location = new System.Drawing.Point(367, 21);
            this.txtFromAddress.Name = "txtFromAddress";
            this.txtFromAddress.Size = new System.Drawing.Size(200, 20);
            this.txtFromAddress.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "From Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To NPI:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "To TON:";
            // 
            // cbxToNpi
            // 
            this.cbxToNpi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToNpi.FormattingEnabled = true;
            this.cbxToNpi.Location = new System.Drawing.Point(81, 74);
            this.cbxToNpi.Name = "cbxToNpi";
            this.cbxToNpi.Size = new System.Drawing.Size(200, 21);
            this.cbxToNpi.TabIndex = 5;
            // 
            // cbxToTon
            // 
            this.cbxToTon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToTon.FormattingEnabled = true;
            this.cbxToTon.Location = new System.Drawing.Point(81, 47);
            this.cbxToTon.Name = "cbxToTon";
            this.cbxToTon.Size = new System.Drawing.Size(200, 21);
            this.cbxToTon.TabIndex = 3;
            // 
            // lblCharacters
            // 
            this.lblCharacters.Location = new System.Drawing.Point(292, 238);
            this.lblCharacters.Name = "lblCharacters";
            this.lblCharacters.Size = new System.Drawing.Size(275, 13);
            this.lblCharacters.TabIndex = 20;
            this.lblCharacters.Text = "[Characters / parts]";
            this.lblCharacters.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbUDH
            // 
            this.cbUDH.AutoSize = true;
            this.cbUDH.Location = new System.Drawing.Point(368, 130);
            this.cbUDH.Name = "cbUDH";
            this.cbUDH.Size = new System.Drawing.Size(50, 17);
            this.cbUDH.TabIndex = 16;
            this.cbUDH.Text = "UDH";
            this.cbUDH.UseVisualStyleBackColor = true;
            this.cbUDH.CheckedChanged += new System.EventHandler(this.cbUDH_CheckedChanged);
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(81, 155);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBody.Size = new System.Drawing.Size(486, 80);
            this.txtBody.TabIndex = 19;
            this.txtBody.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Body:";
            // 
            // txtToAddress
            // 
            this.txtToAddress.Location = new System.Drawing.Point(81, 21);
            this.txtToAddress.Name = "txtToAddress";
            this.txtToAddress.Size = new System.Drawing.Size(200, 20);
            this.txtToAddress.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "To Address:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btRemove);
            this.groupBox3.Controls.Add(this.btEdit);
            this.groupBox3.Controls.Add(this.btAdd);
            this.groupBox3.Controls.Add(this.lvTlvs);
            this.groupBox3.Location = new System.Drawing.Point(13, 360);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(576, 145);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TLV\'s";
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(168, 112);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(75, 23);
            this.btRemove.TabIndex = 3;
            this.btRemove.Text = "Remove";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btEdit
            // 
            this.btEdit.Location = new System.Drawing.Point(87, 112);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(75, 23);
            this.btEdit.TabIndex = 2;
            this.btEdit.Text = "Edit...";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(6, 112);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "Add...";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // lvTlvs
            // 
            this.lvTlvs.FullRowSelect = true;
            this.lvTlvs.Location = new System.Drawing.Point(6, 19);
            this.lvTlvs.MultiSelect = false;
            this.lvTlvs.Name = "lvTlvs";
            this.lvTlvs.Size = new System.Drawing.Size(561, 87);
            this.lvTlvs.TabIndex = 0;
            this.lvTlvs.UseCompatibleStateImageBehavior = false;
            this.lvTlvs.View = System.Windows.Forms.View.Details;
            this.lvTlvs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvTlvs_MouseDoubleClick);
            // 
            // lbDirection
            // 
            this.lbDirection.AutoSize = true;
            this.lbDirection.Location = new System.Drawing.Point(366, 19);
            this.lbDirection.Name = "lbDirection";
            this.lbDirection.Size = new System.Drawing.Size(24, 13);
            this.lbDirection.TabIndex = 6;
            this.lbDirection.Text = "n/a";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(366, 42);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(24, 13);
            this.lbStatus.TabIndex = 7;
            this.lbStatus.Text = "n/a";
            // 
            // frmSmsMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 546);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSmsMessage";
            this.Text = "frmSmsMessage";
            this.Load += new System.EventHandler(this.frmSmsMessage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSystemId;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtToAddress;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbUDH;
        private System.Windows.Forms.Label lblCharacters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxToNpi;
        private System.Windows.Forms.ComboBox cbxToTon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.ListView lvTlvs;
        internal System.Windows.Forms.CheckBox cbDeliveryReport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxFromNpi;
        private System.Windows.Forms.ComboBox cbxFromTon;
        private System.Windows.Forms.TextBox txtFromAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxDataCoding;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxBodyFormat;
        private System.Windows.Forms.Button btnShowComplete;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbDirection;
    }
}