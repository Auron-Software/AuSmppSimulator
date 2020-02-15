namespace SmppSimulator
{
    partial class frmOptions
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.cbxMultipart = new System.Windows.Forms.ComboBox();
      this.cbxGsmEncoding = new System.Windows.Forms.ComboBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cbxDeliverMode = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.txtEnquireInterval = new System.Windows.Forms.TextBox();
      this.txtPduTimeout = new System.Windows.Forms.TextBox();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txtLastMessageReference = new System.Windows.Forms.TextBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.label9 = new System.Windows.Forms.Label();
      this.cbxCertificateStore = new System.Windows.Forms.ComboBox();
      this.label10 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(16, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Pdu Timeout:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 50);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(84, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Enquire Interval:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(16, 22);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(79, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Gsm Encoding:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(16, 77);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(80, 13);
      this.label4.TabIndex = 2;
      this.label4.Text = "Multipart Mode:";
      // 
      // cbxMultipart
      // 
      this.cbxMultipart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxMultipart.FormattingEnabled = true;
      this.cbxMultipart.Location = new System.Drawing.Point(132, 74);
      this.cbxMultipart.Name = "cbxMultipart";
      this.cbxMultipart.Size = new System.Drawing.Size(298, 21);
      this.cbxMultipart.TabIndex = 3;
      // 
      // cbxGsmEncoding
      // 
      this.cbxGsmEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxGsmEncoding.FormattingEnabled = true;
      this.cbxGsmEncoding.Location = new System.Drawing.Point(132, 19);
      this.cbxGsmEncoding.Name = "cbxGsmEncoding";
      this.cbxGsmEncoding.Size = new System.Drawing.Size(298, 21);
      this.cbxGsmEncoding.TabIndex = 1;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.cbxDeliverMode);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.cbxMultipart);
      this.groupBox1.Controls.Add(this.cbxGsmEncoding);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Location = new System.Drawing.Point(15, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(445, 106);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // cbxDeliverMode
      // 
      this.cbxDeliverMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxDeliverMode.FormattingEnabled = true;
      this.cbxDeliverMode.Location = new System.Drawing.Point(132, 46);
      this.cbxDeliverMode.Name = "cbxDeliverMode";
      this.cbxDeliverMode.Size = new System.Drawing.Size(298, 21);
      this.cbxDeliverMode.TabIndex = 7;
      this.cbxDeliverMode.SelectedIndexChanged += new System.EventHandler(this.cbxDeliverMode_SelectedIndexChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(16, 50);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(73, 13);
      this.label5.TabIndex = 6;
      this.label5.Text = "Deliver Mode:";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Controls.Add(this.txtEnquireInterval);
      this.groupBox2.Controls.Add(this.txtPduTimeout);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Location = new System.Drawing.Point(15, 124);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(445, 81);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(266, 48);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(20, 13);
      this.label7.TabIndex = 5;
      this.label7.Text = "ms";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(266, 22);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(20, 13);
      this.label6.TabIndex = 2;
      this.label6.Text = "ms";
      // 
      // txtEnquireInterval
      // 
      this.txtEnquireInterval.Location = new System.Drawing.Point(132, 45);
      this.txtEnquireInterval.Name = "txtEnquireInterval";
      this.txtEnquireInterval.Size = new System.Drawing.Size(127, 20);
      this.txtEnquireInterval.TabIndex = 4;
      // 
      // txtPduTimeout
      // 
      this.txtPduTimeout.Location = new System.Drawing.Point(132, 19);
      this.txtPduTimeout.Name = "txtPduTimeout";
      this.txtPduTimeout.Size = new System.Drawing.Size(127, 20);
      this.txtPduTimeout.TabIndex = 1;
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(303, 363);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 2;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(385, 363);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.label8);
      this.groupBox3.Controls.Add(this.txtLastMessageReference);
      this.groupBox3.Location = new System.Drawing.Point(15, 212);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(445, 52);
      this.groupBox3.TabIndex = 4;
      this.groupBox3.TabStop = false;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(19, 21);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(83, 13);
      this.label8.TabIndex = 1;
      this.label8.Text = "Last Reference:";
      // 
      // txtLastMessageReference
      // 
      this.txtLastMessageReference.Location = new System.Drawing.Point(132, 18);
      this.txtLastMessageReference.Name = "txtLastMessageReference";
      this.txtLastMessageReference.Size = new System.Drawing.Size(127, 20);
      this.txtLastMessageReference.TabIndex = 0;
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.label10);
      this.groupBox4.Controls.Add(this.cbxCertificateStore);
      this.groupBox4.Controls.Add(this.label9);
      this.groupBox4.Location = new System.Drawing.Point(15, 274);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(445, 83);
      this.groupBox4.TabIndex = 5;
      this.groupBox4.TabStop = false;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(19, 24);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(85, 13);
      this.label9.TabIndex = 0;
      this.label9.Text = "Certificate Store:";
      // 
      // cbxCertificateStore
      // 
      this.cbxCertificateStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxCertificateStore.FormattingEnabled = true;
      this.cbxCertificateStore.Location = new System.Drawing.Point(132, 20);
      this.cbxCertificateStore.Name = "cbxCertificateStore";
      this.cbxCertificateStore.Size = new System.Drawing.Size(298, 21);
      this.cbxCertificateStore.TabIndex = 1;
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(132, 48);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(307, 31);
      this.label10.TabIndex = 2;
      this.label10.Text = "The SMPP Server will look in the \'My\' (Personal) location for certificates that i" +
    "nclude \'Server\' in their purpose.";
      // 
      // frmOptions
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(472, 400);
      this.Controls.Add(this.groupBox4);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "frmOptions";
      this.Text = "Server options";
      this.Load += new System.EventHandler(this.frmOptions_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxMultipart;
        private System.Windows.Forms.ComboBox cbxGsmEncoding;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEnquireInterval;
        private System.Windows.Forms.TextBox txtPduTimeout;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbxDeliverMode;
        private System.Windows.Forms.Label label5;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtLastMessageReference;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.ComboBox cbxCertificateStore;
    private System.Windows.Forms.Label label9;
  }
}