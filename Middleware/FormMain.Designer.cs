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
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.cmbPort1 = new System.Windows.Forms.ComboBox();
            this.cmbPort2 = new System.Windows.Forms.ComboBox();
            this.chkPort1 = new System.Windows.Forms.CheckBox();
            this.chkPort2 = new System.Windows.Forms.CheckBox();
            this.cmbPort3 = new System.Windows.Forms.ComboBox();
            this.cmbPort4 = new System.Windows.Forms.ComboBox();
            this.cmbPort5 = new System.Windows.Forms.ComboBox();
            this.cmbPort6 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.txtAnalyzer1 = new System.Windows.Forms.TextBox();
            this.txtAnalyzer2 = new System.Windows.Forms.TextBox();
            this.txtAnalyzer3 = new System.Windows.Forms.TextBox();
            this.txtAnalyzer4 = new System.Windows.Forms.TextBox();
            this.txtAnalyzer5 = new System.Windows.Forms.TextBox();
            this.txtAnalyzer6 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(779, 80);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(4);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(129, 28);
            this.BtnClear.TabIndex = 26;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClearStatus_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(779, 140);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(304, 438);
            this.txtOutput.TabIndex = 36;
            this.txtOutput.Text = "";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(737, 174);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(681, 472);
            this.txtStatus.TabIndex = 39;
            this.txtStatus.Text = "";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(157, 75);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
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
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
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
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4);
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
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(779, 46);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(4);
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
            this.BtnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(129, 28);
            this.BtnOpen.TabIndex = 48;
            this.BtnOpen.Text = "Open";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // cmbPort1
            // 
            this.cmbPort1.FormattingEnabled = true;
            this.cmbPort1.Location = new System.Drawing.Point(70, 149);
            this.cmbPort1.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPort1.Name = "cmbPort1";
            this.cmbPort1.Size = new System.Drawing.Size(226, 24);
            this.cmbPort1.TabIndex = 47;
            // 
            // cmbPort2
            // 
            this.cmbPort2.FormattingEnabled = true;
            this.cmbPort2.Location = new System.Drawing.Point(70, 181);
            this.cmbPort2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPort2.Name = "cmbPort2";
            this.cmbPort2.Size = new System.Drawing.Size(226, 24);
            this.cmbPort2.TabIndex = 51;
            // 
            // chkPort1
            // 
            this.chkPort1.AutoSize = true;
            this.chkPort1.Checked = true;
            this.chkPort1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPort1.Location = new System.Drawing.Point(24, 153);
            this.chkPort1.Name = "chkPort1";
            this.chkPort1.Size = new System.Drawing.Size(18, 17);
            this.chkPort1.TabIndex = 55;
            this.chkPort1.UseVisualStyleBackColor = true;
            // 
            // chkPort2
            // 
            this.chkPort2.AutoSize = true;
            this.chkPort2.Location = new System.Drawing.Point(24, 185);
            this.chkPort2.Name = "chkPort2";
            this.chkPort2.Size = new System.Drawing.Size(18, 17);
            this.chkPort2.TabIndex = 56;
            this.chkPort2.UseVisualStyleBackColor = true;
            // 
            // cmbPort3
            // 
            this.cmbPort3.FormattingEnabled = true;
            this.cmbPort3.Location = new System.Drawing.Point(70, 213);
            this.cmbPort3.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPort3.Name = "cmbPort3";
            this.cmbPort3.Size = new System.Drawing.Size(226, 24);
            this.cmbPort3.TabIndex = 57;
            // 
            // cmbPort4
            // 
            this.cmbPort4.FormattingEnabled = true;
            this.cmbPort4.Location = new System.Drawing.Point(70, 245);
            this.cmbPort4.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPort4.Name = "cmbPort4";
            this.cmbPort4.Size = new System.Drawing.Size(226, 24);
            this.cmbPort4.TabIndex = 58;
            // 
            // cmbPort5
            // 
            this.cmbPort5.FormattingEnabled = true;
            this.cmbPort5.Location = new System.Drawing.Point(70, 277);
            this.cmbPort5.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPort5.Name = "cmbPort5";
            this.cmbPort5.Size = new System.Drawing.Size(226, 24);
            this.cmbPort5.TabIndex = 59;
            // 
            // cmbPort6
            // 
            this.cmbPort6.FormattingEnabled = true;
            this.cmbPort6.Location = new System.Drawing.Point(70, 309);
            this.cmbPort6.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPort6.Name = "cmbPort6";
            this.cmbPort6.Size = new System.Drawing.Size(226, 24);
            this.cmbPort6.TabIndex = 60;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(24, 217);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 61;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(24, 249);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 62;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(24, 281);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(18, 17);
            this.checkBox3.TabIndex = 63;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(24, 313);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(18, 17);
            this.checkBox4.TabIndex = 64;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // txtAnalyzer1
            // 
            this.txtAnalyzer1.Location = new System.Drawing.Point(318, 149);
            this.txtAnalyzer1.Name = "txtAnalyzer1";
            this.txtAnalyzer1.Size = new System.Drawing.Size(263, 22);
            this.txtAnalyzer1.TabIndex = 65;
            // 
            // txtAnalyzer2
            // 
            this.txtAnalyzer2.Location = new System.Drawing.Point(318, 185);
            this.txtAnalyzer2.Name = "txtAnalyzer2";
            this.txtAnalyzer2.Size = new System.Drawing.Size(263, 22);
            this.txtAnalyzer2.TabIndex = 66;
            // 
            // txtAnalyzer3
            // 
            this.txtAnalyzer3.Location = new System.Drawing.Point(318, 215);
            this.txtAnalyzer3.Name = "txtAnalyzer3";
            this.txtAnalyzer3.Size = new System.Drawing.Size(263, 22);
            this.txtAnalyzer3.TabIndex = 67;
            // 
            // txtAnalyzer4
            // 
            this.txtAnalyzer4.Location = new System.Drawing.Point(318, 249);
            this.txtAnalyzer4.Name = "txtAnalyzer4";
            this.txtAnalyzer4.Size = new System.Drawing.Size(263, 22);
            this.txtAnalyzer4.TabIndex = 68;
            // 
            // txtAnalyzer5
            // 
            this.txtAnalyzer5.Location = new System.Drawing.Point(318, 281);
            this.txtAnalyzer5.Name = "txtAnalyzer5";
            this.txtAnalyzer5.Size = new System.Drawing.Size(263, 22);
            this.txtAnalyzer5.TabIndex = 69;
            // 
            // txtAnalyzer6
            // 
            this.txtAnalyzer6.Location = new System.Drawing.Point(318, 313);
            this.txtAnalyzer6.Name = "txtAnalyzer6";
            this.txtAnalyzer6.Size = new System.Drawing.Size(263, 22);
            this.txtAnalyzer6.TabIndex = 70;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 646);
            this.Controls.Add(this.txtAnalyzer6);
            this.Controls.Add(this.txtAnalyzer5);
            this.Controls.Add(this.txtAnalyzer4);
            this.Controls.Add(this.txtAnalyzer3);
            this.Controls.Add(this.txtAnalyzer2);
            this.Controls.Add(this.txtAnalyzer1);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cmbPort6);
            this.Controls.Add(this.cmbPort5);
            this.Controls.Add(this.cmbPort4);
            this.Controls.Add(this.cmbPort3);
            this.Controls.Add(this.chkPort2);
            this.Controls.Add(this.chkPort1);
            this.Controls.Add(this.cmbPort2);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.cmbPort1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.BtnClear);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.ComboBox cmbPort1;
        private System.Windows.Forms.ComboBox cmbPort2;
        private System.Windows.Forms.CheckBox chkPort1;
        private System.Windows.Forms.CheckBox chkPort2;
        private System.Windows.Forms.ComboBox cmbPort3;
        private System.Windows.Forms.ComboBox cmbPort4;
        private System.Windows.Forms.ComboBox cmbPort5;
        private System.Windows.Forms.ComboBox cmbPort6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox txtAnalyzer1;
        private System.Windows.Forms.TextBox txtAnalyzer2;
        private System.Windows.Forms.TextBox txtAnalyzer3;
        private System.Windows.Forms.TextBox txtAnalyzer4;
        private System.Windows.Forms.TextBox txtAnalyzer5;
        private System.Windows.Forms.TextBox txtAnalyzer6;
    }
}