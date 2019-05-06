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
            this.SuspendLayout();
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(779, 80);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(129, 28);
            this.BtnClear.TabIndex = 26;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClearStatus_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(20, 174);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(708, 457);
            this.txtOutput.TabIndex = 36;
            this.txtOutput.Text = "";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(737, 174);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(681, 472);
            this.txtStatus.TabIndex = 39;
            this.txtStatus.Text = "";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(157, 75);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(593, 22);
            this.txtPassword.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 45;
            this.label4.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(157, 43);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(593, 22);
            this.txtUsername.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "Username";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(157, 11);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(593, 22);
            this.txtUrl.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 17);
            this.label9.TabIndex = 41;
            this.label9.Text = "LIMS Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "Sysmex Port";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(779, 46);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(129, 28);
            this.BtnClose.TabIndex = 49;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(779, 11);
            this.BtnOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(129, 28);
            this.BtnOpen.TabIndex = 48;
            this.BtnOpen.Text = "Open";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // cmbSysMexPort
            // 
            this.cmbSysMexPort.FormattingEnabled = true;
            this.cmbSysMexPort.Location = new System.Drawing.Point(182, 107);
            this.cmbSysMexPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSysMexPort.Name = "cmbSysMexPort";
            this.cmbSysMexPort.Size = new System.Drawing.Size(568, 24);
            this.cmbSysMexPort.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 54;
            this.label2.Text = "Diamension Port";
            // 
            // cmbDimPort
            // 
            this.cmbDimPort.FormattingEnabled = true;
            this.cmbDimPort.Location = new System.Drawing.Point(182, 140);
            this.cmbDimPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDimPort.Name = "cmbDimPort";
            this.cmbDimPort.Size = new System.Drawing.Size(568, 24);
            this.cmbDimPort.TabIndex = 51;
            // 
            // chkSysmex
            // 
            this.chkSysmex.AutoSize = true;
            this.chkSysmex.Checked = true;
            this.chkSysmex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSysmex.Location = new System.Drawing.Point(157, 107);
            this.chkSysmex.Name = "chkSysmex";
            this.chkSysmex.Size = new System.Drawing.Size(18, 17);
            this.chkSysmex.TabIndex = 55;
            this.chkSysmex.UseVisualStyleBackColor = true;
            // 
            // chkDim
            // 
            this.chkDim.AutoSize = true;
            this.chkDim.Location = new System.Drawing.Point(157, 147);
            this.chkDim.Name = "chkDim";
            this.chkDim.Size = new System.Drawing.Size(18, 17);
            this.chkDim.TabIndex = 56;
            this.chkDim.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 646);
            this.Controls.Add(this.chkDim);
            this.Controls.Add(this.chkSysmex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDimPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.cmbSysMexPort);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.BtnClear);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "SSS Middleware";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDimensionSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormDimensionSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}