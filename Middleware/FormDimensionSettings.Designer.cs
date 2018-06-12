namespace Middleware
{
    partial class FormDimensionSettings
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
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.txtBitLength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStopBits = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtParity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPw = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.btnListStatus = new System.Windows.Forms.Button();
            this.btnClearStatus = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnClearMessages = new System.Windows.Forms.Button();
            this.btnListMessages = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optBinary = new System.Windows.Forms.RadioButton();
            this.optString = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(101, 17);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(254, 21);
            this.cmbPort.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Baud Rate";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(101, 47);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(154, 20);
            this.txtBaudRate.TabIndex = 6;
            // 
            // txtBitLength
            // 
            this.txtBitLength.Location = new System.Drawing.Point(101, 73);
            this.txtBitLength.Name = "txtBitLength";
            this.txtBitLength.Size = new System.Drawing.Size(154, 20);
            this.txtBitLength.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Bit Length";
            // 
            // txtStopBits
            // 
            this.txtStopBits.Location = new System.Drawing.Point(101, 99);
            this.txtStopBits.Name = "txtStopBits";
            this.txtStopBits.Size = new System.Drawing.Size(154, 20);
            this.txtStopBits.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Stop Bits";
            // 
            // txtParity
            // 
            this.txtParity.Location = new System.Drawing.Point(101, 125);
            this.txtParity.Name = "txtParity";
            this.txtParity.Size = new System.Drawing.Size(154, 20);
            this.txtParity.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Parity";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(393, 51);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(154, 20);
            this.txtUsername.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(393, 80);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(154, 20);
            this.txtPassword.TabIndex = 17;
            // 
            // lblPw
            // 
            this.lblPw.AutoSize = true;
            this.lblPw.Location = new System.Drawing.Point(334, 83);
            this.lblPw.Name = "lblPw";
            this.lblPw.Size = new System.Drawing.Size(53, 13);
            this.lblPw.TabIndex = 16;
            this.lblPw.Text = "Password";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(101, 155);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(446, 20);
            this.txtUrl.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "LIMS Address";
            // 
            // txtMessages
            // 
            this.txtMessages.Location = new System.Drawing.Point(15, 192);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtMessages.Size = new System.Drawing.Size(532, 185);
            this.txtMessages.TabIndex = 24;
            // 
            // btnListStatus
            // 
            this.btnListStatus.Location = new System.Drawing.Point(553, 192);
            this.btnListStatus.Name = "btnListStatus";
            this.btnListStatus.Size = new System.Drawing.Size(97, 23);
            this.btnListStatus.TabIndex = 25;
            this.btnListStatus.Text = "List Status";
            this.btnListStatus.UseVisualStyleBackColor = true;
            this.btnListStatus.Click += new System.EventHandler(this.btnListStatus_Click);
            // 
            // btnClearStatus
            // 
            this.btnClearStatus.Location = new System.Drawing.Point(553, 221);
            this.btnClearStatus.Name = "btnClearStatus";
            this.btnClearStatus.Size = new System.Drawing.Size(97, 23);
            this.btnClearStatus.TabIndex = 26;
            this.btnClearStatus.Text = "Clear Status";
            this.btnClearStatus.UseVisualStyleBackColor = true;
            this.btnClearStatus.Click += new System.EventHandler(this.btnClearStatus_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(553, 78);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(553, 49);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 27;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Port";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(656, 192);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtStatus.Size = new System.Drawing.Size(243, 185);
            this.txtStatus.TabIndex = 30;
            // 
            // btnClearMessages
            // 
            this.btnClearMessages.Location = new System.Drawing.Point(553, 279);
            this.btnClearMessages.Name = "btnClearMessages";
            this.btnClearMessages.Size = new System.Drawing.Size(97, 23);
            this.btnClearMessages.TabIndex = 32;
            this.btnClearMessages.Text = "Clear Messages";
            this.btnClearMessages.UseVisualStyleBackColor = true;
            this.btnClearMessages.Click += new System.EventHandler(this.btnClearMessages_Click);
            // 
            // btnListMessages
            // 
            this.btnListMessages.Location = new System.Drawing.Point(553, 250);
            this.btnListMessages.Name = "btnListMessages";
            this.btnListMessages.Size = new System.Drawing.Size(97, 23);
            this.btnListMessages.TabIndex = 31;
            this.btnListMessages.Text = "List Messages";
            this.btnListMessages.UseVisualStyleBackColor = true;
            this.btnListMessages.Click += new System.EventHandler(this.btnListMessages_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optString);
            this.groupBox1.Controls.Add(this.optBinary);
            this.groupBox1.Location = new System.Drawing.Point(554, 311);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(95, 65);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message";
            // 
            // optBinary
            // 
            this.optBinary.AutoSize = true;
            this.optBinary.Location = new System.Drawing.Point(7, 20);
            this.optBinary.Name = "optBinary";
            this.optBinary.Size = new System.Drawing.Size(54, 17);
            this.optBinary.TabIndex = 0;
            this.optBinary.TabStop = true;
            this.optBinary.Text = "Binary";
            this.optBinary.UseVisualStyleBackColor = true;
            // 
            // optString
            // 
            this.optString.AutoSize = true;
            this.optString.Location = new System.Drawing.Point(7, 42);
            this.optString.Name = "optString";
            this.optString.Size = new System.Drawing.Size(52, 17);
            this.optString.TabIndex = 1;
            this.optString.TabStop = true;
            this.optString.Text = "String";
            this.optString.UseVisualStyleBackColor = true;
            // 
            // FormDimensionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClearMessages);
            this.Controls.Add(this.btnListMessages);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnClearStatus);
            this.Controls.Add(this.btnListStatus);
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPw);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtParity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtStopBits);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBitLength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBaudRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPort);
            this.Name = "FormDimensionSettings";
            this.Text = "Dimension Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDimensionSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormDimensionSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.TextBox txtBitLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStopBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtParity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPw;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Button btnListStatus;
        private System.Windows.Forms.Button btnClearStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnClearMessages;
        private System.Windows.Forms.Button btnListMessages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optString;
        private System.Windows.Forms.RadioButton optBinary;
    }
}