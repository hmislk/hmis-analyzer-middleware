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
            this.cmbPort3 = new System.Windows.Forms.ComboBox();
            this.cmbPort4 = new System.Windows.Forms.ComboBox();
            this.cmbPort5 = new System.Windows.Forms.ComboBox();
            this.cmbPort6 = new System.Windows.Forms.ComboBox();
            this.txtAnalyzer1 = new System.Windows.Forms.TextBox();
            this.txtAnalyzer2 = new System.Windows.Forms.TextBox();
            this.txtAnalyzer3 = new System.Windows.Forms.TextBox();
            this.txtAnalyzer4 = new System.Windows.Forms.TextBox();
            this.txtAnalyzer5 = new System.Windows.Forms.TextBox();
            this.txtAnalyzer6 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPortStatus = new System.Windows.Forms.RichTextBox();
            this.btnEnq1 = new System.Windows.Forms.Button();
            this.btnEnq2 = new System.Windows.Forms.Button();
            this.btnEnq3 = new System.Windows.Forms.Button();
            this.btnEnq4 = new System.Windows.Forms.Button();
            this.btnEnq5 = new System.Windows.Forms.Button();
            this.btnEnq6 = new System.Windows.Forms.Button();
            this.txtCmd1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(584, 65);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(97, 23);
            this.BtnClear.TabIndex = 26;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClearStatus_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(688, 133);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(229, 330);
            this.txtOutput.TabIndex = 36;
            this.txtOutput.Text = "";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(923, 133);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(268, 438);
            this.txtStatus.TabIndex = 39;
            this.txtStatus.Text = "";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(118, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(446, 20);
            this.txtPassword.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(118, 35);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(446, 20);
            this.txtUsername.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Username";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(118, 9);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(446, 20);
            this.txtUrl.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "LIMS Address";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(584, 37);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(97, 23);
            this.BtnClose.TabIndex = 49;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(584, 9);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(97, 23);
            this.BtnOpen.TabIndex = 48;
            this.BtnOpen.Text = "Open";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // cmbPort1
            // 
            this.cmbPort1.FormattingEnabled = true;
            this.cmbPort1.Location = new System.Drawing.Point(18, 141);
            this.cmbPort1.Name = "cmbPort1";
            this.cmbPort1.Size = new System.Drawing.Size(170, 21);
            this.cmbPort1.TabIndex = 47;
            // 
            // cmbPort2
            // 
            this.cmbPort2.FormattingEnabled = true;
            this.cmbPort2.Location = new System.Drawing.Point(18, 167);
            this.cmbPort2.Name = "cmbPort2";
            this.cmbPort2.Size = new System.Drawing.Size(170, 21);
            this.cmbPort2.TabIndex = 51;
            // 
            // cmbPort3
            // 
            this.cmbPort3.FormattingEnabled = true;
            this.cmbPort3.Location = new System.Drawing.Point(18, 193);
            this.cmbPort3.Name = "cmbPort3";
            this.cmbPort3.Size = new System.Drawing.Size(170, 21);
            this.cmbPort3.TabIndex = 57;
            // 
            // cmbPort4
            // 
            this.cmbPort4.FormattingEnabled = true;
            this.cmbPort4.Location = new System.Drawing.Point(18, 219);
            this.cmbPort4.Name = "cmbPort4";
            this.cmbPort4.Size = new System.Drawing.Size(170, 21);
            this.cmbPort4.TabIndex = 58;
            // 
            // cmbPort5
            // 
            this.cmbPort5.FormattingEnabled = true;
            this.cmbPort5.Location = new System.Drawing.Point(18, 245);
            this.cmbPort5.Name = "cmbPort5";
            this.cmbPort5.Size = new System.Drawing.Size(170, 21);
            this.cmbPort5.TabIndex = 59;
            // 
            // cmbPort6
            // 
            this.cmbPort6.FormattingEnabled = true;
            this.cmbPort6.Location = new System.Drawing.Point(18, 271);
            this.cmbPort6.Name = "cmbPort6";
            this.cmbPort6.Size = new System.Drawing.Size(170, 21);
            this.cmbPort6.TabIndex = 60;
            // 
            // txtAnalyzer1
            // 
            this.txtAnalyzer1.Location = new System.Drawing.Point(204, 141);
            this.txtAnalyzer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAnalyzer1.Name = "txtAnalyzer1";
            this.txtAnalyzer1.Size = new System.Drawing.Size(198, 20);
            this.txtAnalyzer1.TabIndex = 65;
            // 
            // txtAnalyzer2
            // 
            this.txtAnalyzer2.Location = new System.Drawing.Point(204, 167);
            this.txtAnalyzer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAnalyzer2.Name = "txtAnalyzer2";
            this.txtAnalyzer2.Size = new System.Drawing.Size(198, 20);
            this.txtAnalyzer2.TabIndex = 66;
            // 
            // txtAnalyzer3
            // 
            this.txtAnalyzer3.Location = new System.Drawing.Point(204, 195);
            this.txtAnalyzer3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAnalyzer3.Name = "txtAnalyzer3";
            this.txtAnalyzer3.Size = new System.Drawing.Size(198, 20);
            this.txtAnalyzer3.TabIndex = 67;
            // 
            // txtAnalyzer4
            // 
            this.txtAnalyzer4.Location = new System.Drawing.Point(204, 223);
            this.txtAnalyzer4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAnalyzer4.Name = "txtAnalyzer4";
            this.txtAnalyzer4.Size = new System.Drawing.Size(198, 20);
            this.txtAnalyzer4.TabIndex = 68;
            // 
            // txtAnalyzer5
            // 
            this.txtAnalyzer5.Location = new System.Drawing.Point(204, 249);
            this.txtAnalyzer5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAnalyzer5.Name = "txtAnalyzer5";
            this.txtAnalyzer5.Size = new System.Drawing.Size(198, 20);
            this.txtAnalyzer5.TabIndex = 69;
            // 
            // txtAnalyzer6
            // 
            this.txtAnalyzer6.Location = new System.Drawing.Point(204, 275);
            this.txtAnalyzer6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAnalyzer6.Name = "txtAnalyzer6";
            this.txtAnalyzer6.Size = new System.Drawing.Size(198, 20);
            this.txtAnalyzer6.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "Analyzer";
            // 
            // txtPortStatus
            // 
            this.txtPortStatus.Location = new System.Drawing.Point(789, 8);
            this.txtPortStatus.Name = "txtPortStatus";
            this.txtPortStatus.Size = new System.Drawing.Size(128, 119);
            this.txtPortStatus.TabIndex = 73;
            this.txtPortStatus.Text = "";
            // 
            // btnEnq1
            // 
            this.btnEnq1.Location = new System.Drawing.Point(569, 141);
            this.btnEnq1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnq1.Name = "btnEnq1";
            this.btnEnq1.Size = new System.Drawing.Size(102, 19);
            this.btnEnq1.TabIndex = 74;
            this.btnEnq1.Text = "Send ENQ";
            this.btnEnq1.UseVisualStyleBackColor = true;
            this.btnEnq1.Click += new System.EventHandler(this.btnEnq1_Click);
            // 
            // btnEnq2
            // 
            this.btnEnq2.Location = new System.Drawing.Point(569, 169);
            this.btnEnq2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnq2.Name = "btnEnq2";
            this.btnEnq2.Size = new System.Drawing.Size(102, 19);
            this.btnEnq2.TabIndex = 75;
            this.btnEnq2.Text = "Send ENQ";
            this.btnEnq2.UseVisualStyleBackColor = true;
            this.btnEnq2.Click += new System.EventHandler(this.btnEnq2_Click);
            // 
            // btnEnq3
            // 
            this.btnEnq3.Location = new System.Drawing.Point(569, 196);
            this.btnEnq3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnq3.Name = "btnEnq3";
            this.btnEnq3.Size = new System.Drawing.Size(102, 19);
            this.btnEnq3.TabIndex = 76;
            this.btnEnq3.Text = "Send ENQ";
            this.btnEnq3.UseVisualStyleBackColor = true;
            this.btnEnq3.Click += new System.EventHandler(this.btnEnq3_Click);
            // 
            // btnEnq4
            // 
            this.btnEnq4.Location = new System.Drawing.Point(569, 224);
            this.btnEnq4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnq4.Name = "btnEnq4";
            this.btnEnq4.Size = new System.Drawing.Size(102, 19);
            this.btnEnq4.TabIndex = 77;
            this.btnEnq4.Text = "Send ENQ";
            this.btnEnq4.UseVisualStyleBackColor = true;
            this.btnEnq4.Click += new System.EventHandler(this.btnEnq4_Click);
            // 
            // btnEnq5
            // 
            this.btnEnq5.Location = new System.Drawing.Point(569, 250);
            this.btnEnq5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnq5.Name = "btnEnq5";
            this.btnEnq5.Size = new System.Drawing.Size(102, 19);
            this.btnEnq5.TabIndex = 78;
            this.btnEnq5.Text = "Send ENQ";
            this.btnEnq5.UseVisualStyleBackColor = true;
            this.btnEnq5.Click += new System.EventHandler(this.btnEnq5_Click);
            // 
            // btnEnq6
            // 
            this.btnEnq6.Location = new System.Drawing.Point(569, 276);
            this.btnEnq6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnq6.Name = "btnEnq6";
            this.btnEnq6.Size = new System.Drawing.Size(102, 19);
            this.btnEnq6.TabIndex = 79;
            this.btnEnq6.Text = "Send ENQ";
            this.btnEnq6.UseVisualStyleBackColor = true;
            this.btnEnq6.Click += new System.EventHandler(this.btnEnq6_Click);
            // 
            // txtCmd1
            // 
            this.txtCmd1.Location = new System.Drawing.Point(406, 140);
            this.txtCmd1.Margin = new System.Windows.Forms.Padding(2);
            this.txtCmd1.Name = "txtCmd1";
            this.txtCmd1.Size = new System.Drawing.Size(159, 20);
            this.txtCmd1.TabIndex = 80;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 525);
            this.Controls.Add(this.txtCmd1);
            this.Controls.Add(this.btnEnq6);
            this.Controls.Add(this.btnEnq5);
            this.Controls.Add(this.btnEnq4);
            this.Controls.Add(this.btnEnq3);
            this.Controls.Add(this.btnEnq2);
            this.Controls.Add(this.btnEnq1);
            this.Controls.Add(this.txtPortStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAnalyzer6);
            this.Controls.Add(this.txtAnalyzer5);
            this.Controls.Add(this.txtAnalyzer4);
            this.Controls.Add(this.txtAnalyzer3);
            this.Controls.Add(this.txtAnalyzer2);
            this.Controls.Add(this.txtAnalyzer1);
            this.Controls.Add(this.cmbPort6);
            this.Controls.Add(this.cmbPort5);
            this.Controls.Add(this.cmbPort4);
            this.Controls.Add(this.cmbPort3);
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
        private System.Windows.Forms.ComboBox cmbPort3;
        private System.Windows.Forms.ComboBox cmbPort4;
        private System.Windows.Forms.ComboBox cmbPort5;
        private System.Windows.Forms.ComboBox cmbPort6;
        private System.Windows.Forms.TextBox txtAnalyzer1;
        private System.Windows.Forms.TextBox txtAnalyzer2;
        private System.Windows.Forms.TextBox txtAnalyzer3;
        private System.Windows.Forms.TextBox txtAnalyzer4;
        private System.Windows.Forms.TextBox txtAnalyzer5;
        private System.Windows.Forms.TextBox txtAnalyzer6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtPortStatus;
        private System.Windows.Forms.Button btnEnq1;
        private System.Windows.Forms.Button btnEnq2;
        private System.Windows.Forms.Button btnEnq3;
        private System.Windows.Forms.Button btnEnq4;
        private System.Windows.Forms.Button btnEnq5;
        private System.Windows.Forms.Button btnEnq6;
        private System.Windows.Forms.TextBox txtCmd1;
    }
}