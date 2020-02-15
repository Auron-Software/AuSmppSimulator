namespace SmppSimulator
{
    partial class frmErrorRates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmErrorRates));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMessageStatusSuccess = new System.Windows.Forms.Label();
            this.btnDeleteMessageStatus = new System.Windows.Forms.Button();
            this.lvMessageStatus = new System.Windows.Forms.ListView();
            this.btnInsertMessageStatus = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessageStatusOccurance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMsgStatusCustom = new System.Windows.Forms.TextBox();
            this.rbMsgStatusCustom = new System.Windows.Forms.RadioButton();
            this.cbxMsgStatusPreDefined = new System.Windows.Forms.ComboBox();
            this.rbMsgStatusPreDefined = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDeliveryStatusSuccess = new System.Windows.Forms.Label();
            this.btnDeleteDeliveryStatus = new System.Windows.Forms.Button();
            this.btnInsertDeliveryStatus = new System.Windows.Forms.Button();
            this.lvDeliveryStatus = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeliveryStatusOccurance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDeliveryStatus = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMessageStatusSuccess);
            this.groupBox1.Controls.Add(this.btnDeleteMessageStatus);
            this.groupBox1.Controls.Add(this.lvMessageStatus);
            this.groupBox1.Controls.Add(this.btnInsertMessageStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMessageStatusOccurance);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMsgStatusCustom);
            this.groupBox1.Controls.Add(this.rbMsgStatusCustom);
            this.groupBox1.Controls.Add(this.cbxMsgStatusPreDefined);
            this.groupBox1.Controls.Add(this.rbMsgStatusPreDefined);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message Status";
            // 
            // lblMessageStatusSuccess
            // 
            this.lblMessageStatusSuccess.AutoSize = true;
            this.lblMessageStatusSuccess.Location = new System.Drawing.Point(443, 168);
            this.lblMessageStatusSuccess.Name = "lblMessageStatusSuccess";
            this.lblMessageStatusSuccess.Size = new System.Drawing.Size(55, 13);
            this.lblMessageStatusSuccess.TabIndex = 10;
            this.lblMessageStatusSuccess.Text = "##% ROK";
            // 
            // btnDeleteMessageStatus
            // 
            this.btnDeleteMessageStatus.Location = new System.Drawing.Point(509, 46);
            this.btnDeleteMessageStatus.Name = "btnDeleteMessageStatus";
            this.btnDeleteMessageStatus.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMessageStatus.TabIndex = 8;
            this.btnDeleteMessageStatus.Text = "Delete";
            this.btnDeleteMessageStatus.UseVisualStyleBackColor = true;
            this.btnDeleteMessageStatus.Click += new System.EventHandler(this.btnDeleteMessageStatus_Click);
            // 
            // lvMessageStatus
            // 
            this.lvMessageStatus.FullRowSelect = true;
            this.lvMessageStatus.Location = new System.Drawing.Point(18, 48);
            this.lvMessageStatus.MultiSelect = false;
            this.lvMessageStatus.Name = "lvMessageStatus";
            this.lvMessageStatus.Size = new System.Drawing.Size(482, 113);
            this.lvMessageStatus.TabIndex = 9;
            this.lvMessageStatus.UseCompatibleStateImageBehavior = false;
            this.lvMessageStatus.View = System.Windows.Forms.View.Details;
            // 
            // btnInsertMessageStatus
            // 
            this.btnInsertMessageStatus.Location = new System.Drawing.Point(509, 16);
            this.btnInsertMessageStatus.Name = "btnInsertMessageStatus";
            this.btnInsertMessageStatus.Size = new System.Drawing.Size(75, 23);
            this.btnInsertMessageStatus.TabIndex = 7;
            this.btnInsertMessageStatus.Text = "Insert";
            this.btnInsertMessageStatus.UseVisualStyleBackColor = true;
            this.btnInsertMessageStatus.Click += new System.EventHandler(this.btnInsertMessageStatus_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "%";
            // 
            // txtMessageStatusOccurance
            // 
            this.txtMessageStatusOccurance.Location = new System.Drawing.Point(459, 19);
            this.txtMessageStatusOccurance.Name = "txtMessageStatusOccurance";
            this.txtMessageStatusOccurance.Size = new System.Drawing.Size(25, 20);
            this.txtMessageStatusOccurance.TabIndex = 5;
            this.txtMessageStatusOccurance.TextChanged += new System.EventHandler(this.txtNumeric_TextChanged);
            this.txtMessageStatusOccurance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNummeric_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Occurrence:";
            // 
            // txtMsgStatusCustom
            // 
            this.txtMsgStatusCustom.Location = new System.Drawing.Point(286, 20);
            this.txtMsgStatusCustom.Name = "txtMsgStatusCustom";
            this.txtMsgStatusCustom.Size = new System.Drawing.Size(94, 20);
            this.txtMsgStatusCustom.TabIndex = 3;
            this.txtMsgStatusCustom.TextChanged += new System.EventHandler(this.txtNumeric_TextChanged);
            this.txtMsgStatusCustom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNummeric_KeyPress);
            // 
            // rbMsgStatusCustom
            // 
            this.rbMsgStatusCustom.AutoSize = true;
            this.rbMsgStatusCustom.Location = new System.Drawing.Point(266, 22);
            this.rbMsgStatusCustom.Name = "rbMsgStatusCustom";
            this.rbMsgStatusCustom.Size = new System.Drawing.Size(14, 13);
            this.rbMsgStatusCustom.TabIndex = 2;
            this.rbMsgStatusCustom.TabStop = true;
            this.rbMsgStatusCustom.UseVisualStyleBackColor = true;
            // 
            // cbxMsgStatusPreDefined
            // 
            this.cbxMsgStatusPreDefined.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMsgStatusPreDefined.FormattingEnabled = true;
            this.cbxMsgStatusPreDefined.Location = new System.Drawing.Point(40, 19);
            this.cbxMsgStatusPreDefined.Name = "cbxMsgStatusPreDefined";
            this.cbxMsgStatusPreDefined.Size = new System.Drawing.Size(220, 21);
            this.cbxMsgStatusPreDefined.TabIndex = 1;
            // 
            // rbMsgStatusPreDefined
            // 
            this.rbMsgStatusPreDefined.AutoSize = true;
            this.rbMsgStatusPreDefined.Location = new System.Drawing.Point(20, 22);
            this.rbMsgStatusPreDefined.Name = "rbMsgStatusPreDefined";
            this.rbMsgStatusPreDefined.Size = new System.Drawing.Size(14, 13);
            this.rbMsgStatusPreDefined.TabIndex = 0;
            this.rbMsgStatusPreDefined.TabStop = true;
            this.rbMsgStatusPreDefined.UseVisualStyleBackColor = true;
            this.rbMsgStatusPreDefined.CheckedChanged += new System.EventHandler(this.rbMsgStatus_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDeliveryStatusSuccess);
            this.groupBox2.Controls.Add(this.btnDeleteDeliveryStatus);
            this.groupBox2.Controls.Add(this.btnInsertDeliveryStatus);
            this.groupBox2.Controls.Add(this.lvDeliveryStatus);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDeliveryStatusOccurance);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbxDeliveryStatus);
            this.groupBox2.Location = new System.Drawing.Point(12, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(595, 192);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delivery Status";
            // 
            // lblDeliveryStatusSuccess
            // 
            this.lblDeliveryStatusSuccess.AutoSize = true;
            this.lblDeliveryStatusSuccess.Location = new System.Drawing.Point(419, 169);
            this.lblDeliveryStatusSuccess.Name = "lblDeliveryStatusSuccess";
            this.lblDeliveryStatusSuccess.Size = new System.Drawing.Size(79, 13);
            this.lblDeliveryStatusSuccess.TabIndex = 7;
            this.lblDeliveryStatusSuccess.Text = "##% DELIVRD";
            // 
            // btnDeleteDeliveryStatus
            // 
            this.btnDeleteDeliveryStatus.Location = new System.Drawing.Point(509, 46);
            this.btnDeleteDeliveryStatus.Name = "btnDeleteDeliveryStatus";
            this.btnDeleteDeliveryStatus.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDeliveryStatus.TabIndex = 5;
            this.btnDeleteDeliveryStatus.Text = "Delete";
            this.btnDeleteDeliveryStatus.UseVisualStyleBackColor = true;
            this.btnDeleteDeliveryStatus.Click += new System.EventHandler(this.btnDeleteDeliveryStatus_Click);
            // 
            // btnInsertDeliveryStatus
            // 
            this.btnInsertDeliveryStatus.Location = new System.Drawing.Point(509, 16);
            this.btnInsertDeliveryStatus.Name = "btnInsertDeliveryStatus";
            this.btnInsertDeliveryStatus.Size = new System.Drawing.Size(75, 23);
            this.btnInsertDeliveryStatus.TabIndex = 4;
            this.btnInsertDeliveryStatus.Text = "Insert";
            this.btnInsertDeliveryStatus.UseVisualStyleBackColor = true;
            this.btnInsertDeliveryStatus.Click += new System.EventHandler(this.btnInsertDeliveryStatus_Click);
            // 
            // lvDeliveryStatus
            // 
            this.lvDeliveryStatus.FullRowSelect = true;
            this.lvDeliveryStatus.Location = new System.Drawing.Point(18, 48);
            this.lvDeliveryStatus.MultiSelect = false;
            this.lvDeliveryStatus.Name = "lvDeliveryStatus";
            this.lvDeliveryStatus.Size = new System.Drawing.Size(480, 113);
            this.lvDeliveryStatus.TabIndex = 6;
            this.lvDeliveryStatus.UseCompatibleStateImageBehavior = false;
            this.lvDeliveryStatus.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(481, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "%";
            // 
            // txtDeliveryStatusOccurance
            // 
            this.txtDeliveryStatusOccurance.Location = new System.Drawing.Point(457, 19);
            this.txtDeliveryStatusOccurance.Name = "txtDeliveryStatusOccurance";
            this.txtDeliveryStatusOccurance.Size = new System.Drawing.Size(25, 20);
            this.txtDeliveryStatusOccurance.TabIndex = 2;
            this.txtDeliveryStatusOccurance.TextChanged += new System.EventHandler(this.txtNumeric_TextChanged);
            this.txtDeliveryStatusOccurance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNummeric_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Occurrence:";
            // 
            // cbxDeliveryStatus
            // 
            this.cbxDeliveryStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDeliveryStatus.FormattingEnabled = true;
            this.cbxDeliveryStatus.Location = new System.Drawing.Point(18, 19);
            this.cbxDeliveryStatus.Name = "cbxDeliveryStatus";
            this.cbxDeliveryStatus.Size = new System.Drawing.Size(360, 21);
            this.cbxDeliveryStatus.TabIndex = 0;
            this.cbxDeliveryStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxDeliveryStatus_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(532, 411);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(446, 411);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmErrorRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 441);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmErrorRates";
            this.Text = "Auron SMPP Simulator";
            this.Load += new System.EventHandler(this.frmStatusErrors_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbMsgStatusCustom;
        private System.Windows.Forms.ComboBox cbxMsgStatusPreDefined;
        private System.Windows.Forms.RadioButton rbMsgStatusPreDefined;
        private System.Windows.Forms.Button btnInsertMessageStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessageStatusOccurance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMsgStatusCustom;
        internal System.Windows.Forms.ListView lvMessageStatus;
        private System.Windows.Forms.Button btnDeleteMessageStatus;
        private System.Windows.Forms.Label lblMessageStatusSuccess;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnInsertDeliveryStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeliveryStatusOccurance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxDeliveryStatus;
        private System.Windows.Forms.Label lblDeliveryStatusSuccess;
        private System.Windows.Forms.Button btnDeleteDeliveryStatus;
        internal System.Windows.Forms.ListView lvDeliveryStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
    }
}