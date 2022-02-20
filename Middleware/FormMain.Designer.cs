namespace Middleware
{
    partial class FormMain
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
            this.BtnClear = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.txtStatus = new System.Windows.Forms.RichTextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.cmbSysMexPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDimPort = new System.Windows.Forms.ComboBox();
            this.chkSysmex = new System.Windows.Forms.CheckBox();
            this.chkDim = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Sysmex = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkMaglumi800 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMaglumi800Port = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkBA400 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.Sysmex.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(466, 85);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(97, 23);
            this.BtnClear.TabIndex = 26;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClearStatus_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(15, 252);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(532, 261);
            this.txtOutput.TabIndex = 36;
            this.txtOutput.Text = "";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(553, 252);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(512, 273);
            this.txtStatus.TabIndex = 39;
            this.txtStatus.Text = "";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(85, 93);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(324, 20);
            this.txtPassword.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(85, 60);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(324, 20);
            this.txtUsername.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Username";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(85, 25);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(324, 20);
            this.txtUrl.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "LIMS Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Port";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(466, 56);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(97, 23);
            this.BtnClose.TabIndex = 49;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(466, 27);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(97, 23);
            this.BtnOpen.TabIndex = 48;
            this.BtnOpen.Text = "Open";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // cmbSysMexPort
            // 
            this.cmbSysMexPort.FormattingEnabled = true;
            this.cmbSysMexPort.Location = new System.Drawing.Point(64, 53);
            this.cmbSysMexPort.Name = "cmbSysMexPort";
            this.cmbSysMexPort.Size = new System.Drawing.Size(94, 21);
            this.cmbSysMexPort.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Port";
            // 
            // cmbDimPort
            // 
            this.cmbDimPort.FormattingEnabled = true;
            this.cmbDimPort.Location = new System.Drawing.Point(64, 54);
            this.cmbDimPort.Name = "cmbDimPort";
            this.cmbDimPort.Size = new System.Drawing.Size(94, 21);
            this.cmbDimPort.TabIndex = 51;
            // 
            // chkSysmex
            // 
            this.chkSysmex.AutoSize = true;
            this.chkSysmex.Checked = true;
            this.chkSysmex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSysmex.Location = new System.Drawing.Point(22, 26);
            this.chkSysmex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkSysmex.Name = "chkSysmex";
            this.chkSysmex.Size = new System.Drawing.Size(59, 17);
            this.chkSysmex.TabIndex = 55;
            this.chkSysmex.Text = "Enable";
            this.chkSysmex.UseVisualStyleBackColor = true;
            // 
            // chkDim
            // 
            this.chkDim.AutoSize = true;
            this.chkDim.Location = new System.Drawing.Point(22, 29);
            this.chkDim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkDim.Name = "chkDim";
            this.chkDim.Size = new System.Drawing.Size(65, 17);
            this.chkDim.TabIndex = 56;
            this.chkDim.Text = "Enabled";
            this.chkDim.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 125);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LIMS";
            // 
            // Sysmex
            // 
            this.Sysmex.Controls.Add(this.chkSysmex);
            this.Sysmex.Controls.Add(this.label1);
            this.Sysmex.Controls.Add(this.cmbSysMexPort);
            this.Sysmex.Location = new System.Drawing.Point(194, 143);
            this.Sysmex.Name = "Sysmex";
            this.Sysmex.Size = new System.Drawing.Size(169, 92);
            this.Sysmex.TabIndex = 58;
            this.Sysmex.TabStop = false;
            this.Sysmex.Text = "Sysmex";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDim);
            this.groupBox2.Controls.Add(this.cmbDimPort);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(19, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 92);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dimension";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbMaglumi800Port);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.chkMaglumi800);
            this.groupBox3.Location = new System.Drawing.Point(378, 143);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 89);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MAGLUMI 800";
            // 
            // chkMaglumi800
            // 
            this.chkMaglumi800.AutoSize = true;
            this.chkMaglumi800.Location = new System.Drawing.Point(19, 26);
            this.chkMaglumi800.Name = "chkMaglumi800";
            this.chkMaglumi800.Size = new System.Drawing.Size(65, 17);
            this.chkMaglumi800.TabIndex = 0;
            this.chkMaglumi800.Text = "Enabled";
            this.chkMaglumi800.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Port";
            // 
            // cmbMaglumi800Port
            // 
            this.cmbMaglumi800Port.FormattingEnabled = true;
            this.cmbMaglumi800Port.Location = new System.Drawing.Point(48, 56);
            this.cmbMaglumi800Port.Name = "cmbMaglumi800Port";
            this.cmbMaglumi800Port.Size = new System.Drawing.Size(101, 21);
            this.cmbMaglumi800Port.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkBA400);
            this.groupBox4.Location = new System.Drawing.Point(565, 143);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(193, 86);
            this.groupBox4.TabIndex = 61;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "BA 400";
            // 
            // chkBA400
            // 
            this.chkBA400.AutoSize = true;
            this.chkBA400.Location = new System.Drawing.Point(21, 26);
            this.chkBA400.Name = "chkBA400";
            this.chkBA400.Size = new System.Drawing.Size(65, 17);
            this.chkBA400.TabIndex = 0;
            this.chkBA400.Text = "Enabled";
            this.chkBA400.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 525);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Sysmex);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.BtnClear);
            this.Name = "FormMain";
            this.Text = "SSS Middleware";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDimensionSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormDimensionSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Sysmex.ResumeLayout(false);
            this.Sysmex.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.RichTextBox txtStatus;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.ComboBox cmbSysMexPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDimPort;
        private System.Windows.Forms.CheckBox chkSysmex;
        private System.Windows.Forms.CheckBox chkDim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Sysmex;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbMaglumi800Port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkMaglumi800;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkBA400;
    }
}