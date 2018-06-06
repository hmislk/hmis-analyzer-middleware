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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReceive = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.txtBitLength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStopBits = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtParity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefreshAna = new System.Windows.Forms.Button();
            this.btnSendNoRequest = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPw = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLimsRequest = new System.Windows.Forms.Button();
            this.btnRefreshLims = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(101, 17);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(254, 21);
            this.cmbPort.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReceive);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.txtReceive);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSend);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Location = new System.Drawing.Point(563, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 286);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Port";
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(367, 175);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(75, 23);
            this.btnReceive.TabIndex = 11;
            this.btnReceive.Text = "Receive";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(368, 55);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(97, 175);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(264, 105);
            this.txtReceive.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Received Text";
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(97, 55);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(264, 105);
            this.txtSend.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "To Send Text";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(189, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(97, 19);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
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
            // btnRefreshAna
            // 
            this.btnRefreshAna.Location = new System.Drawing.Point(850, 307);
            this.btnRefreshAna.Name = "btnRefreshAna";
            this.btnRefreshAna.Size = new System.Drawing.Size(155, 23);
            this.btnRefreshAna.TabIndex = 12;
            this.btnRefreshAna.Text = "Refresh Analyzer";
            this.btnRefreshAna.UseVisualStyleBackColor = true;
            this.btnRefreshAna.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSendNoRequest
            // 
            this.btnSendNoRequest.Location = new System.Drawing.Point(660, 307);
            this.btnSendNoRequest.Name = "btnSendNoRequest";
            this.btnSendNoRequest.Size = new System.Drawing.Size(184, 23);
            this.btnSendNoRequest.TabIndex = 13;
            this.btnSendNoRequest.Text = "Send No Request Message";
            this.btnSendNoRequest.UseVisualStyleBackColor = true;
            this.btnSendNoRequest.Click += new System.EventHandler(this.btnSendNoRequest_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(264, 230);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(154, 20);
            this.txtUsername.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(264, 261);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(154, 20);
            this.txtPassword.TabIndex = 17;
            // 
            // lblPw
            // 
            this.lblPw.AutoSize = true;
            this.lblPw.Location = new System.Drawing.Point(175, 268);
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
            // btnLimsRequest
            // 
            this.btnLimsRequest.Location = new System.Drawing.Point(660, 336);
            this.btnLimsRequest.Name = "btnLimsRequest";
            this.btnLimsRequest.Size = new System.Drawing.Size(184, 23);
            this.btnLimsRequest.TabIndex = 20;
            this.btnLimsRequest.Text = "Send Request to LIMS";
            this.btnLimsRequest.UseVisualStyleBackColor = true;
            this.btnLimsRequest.Click += new System.EventHandler(this.btnLimsRequest_Click);
            // 
            // btnRefreshLims
            // 
            this.btnRefreshLims.Location = new System.Drawing.Point(850, 336);
            this.btnRefreshLims.Name = "btnRefreshLims";
            this.btnRefreshLims.Size = new System.Drawing.Size(155, 23);
            this.btnRefreshLims.TabIndex = 21;
            this.btnRefreshLims.Text = "Refresh LIMS";
            this.btnRefreshLims.UseVisualStyleBackColor = true;
            this.btnRefreshLims.Click += new System.EventHandler(this.btnRefreshLims_Click);
            // 
            // FormDimensionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 450);
            this.Controls.Add(this.btnRefreshLims);
            this.Controls.Add(this.btnRefreshAna);
            this.Controls.Add(this.btnLimsRequest);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPw);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSendNoRequest);
            this.Controls.Add(this.txtParity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtStopBits);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBitLength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBaudRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.label1);
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.TextBox txtBitLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStopBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtParity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRefreshAna;
        private System.Windows.Forms.Button btnSendNoRequest;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPw;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnLimsRequest;
        private System.Windows.Forms.Button btnRefreshLims;
    }
}