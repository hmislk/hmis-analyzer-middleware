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
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSysMexClose = new System.Windows.Forms.Button();
            this.BtnOpenSysMex = new System.Windows.Forms.Button();
            this.cmbSysMexPort = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDimClose = new System.Windows.Forms.Button();
            this.btnDimOpen = new System.Windows.Forms.Button();
            this.cmbDimPort = new System.Windows.Forms.ComboBox();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(855, 126);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(97, 23);
            this.BtnClear.TabIndex = 26;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClearStatus_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(15, 159);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(532, 354);
            this.txtOutput.TabIndex = 36;
            this.txtOutput.Text = "";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(553, 159);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(512, 366);
            this.txtStatus.TabIndex = 39;
            this.txtStatus.Text = "";
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Controls.Add(this.tabPage3);
            this.tab.Location = new System.Drawing.Point(12, 12);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(837, 141);
            this.tab.TabIndex = 40;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtUrl);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(829, 115);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "LIMS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(97, 6);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(446, 20);
            this.txtUrl.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "LIMS Address";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.BtnSysMexClose);
            this.tabPage2.Controls.Add(this.BtnOpenSysMex);
            this.tabPage2.Controls.Add(this.cmbSysMexPort);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(829, 115);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SysMex";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Port";
            // 
            // BtnSysMexClose
            // 
            this.BtnSysMexClose.Location = new System.Drawing.Point(157, 33);
            this.BtnSysMexClose.Name = "BtnSysMexClose";
            this.BtnSysMexClose.Size = new System.Drawing.Size(75, 23);
            this.BtnSysMexClose.TabIndex = 36;
            this.BtnSysMexClose.Text = "Close";
            this.BtnSysMexClose.UseVisualStyleBackColor = true;
            this.BtnSysMexClose.Click += new System.EventHandler(this.BtnSysMexClose_Click);
            // 
            // BtnOpenSysMex
            // 
            this.BtnOpenSysMex.Location = new System.Drawing.Point(76, 33);
            this.BtnOpenSysMex.Name = "BtnOpenSysMex";
            this.BtnOpenSysMex.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenSysMex.TabIndex = 35;
            this.BtnOpenSysMex.Text = "Open";
            this.BtnOpenSysMex.UseVisualStyleBackColor = true;
            this.BtnOpenSysMex.Click += new System.EventHandler(this.BtnOpenSysMex_Click);
            // 
            // cmbSysMexPort
            // 
            this.cmbSysMexPort.FormattingEnabled = true;
            this.cmbSysMexPort.Location = new System.Drawing.Point(36, 6);
            this.cmbSysMexPort.Name = "cmbSysMexPort";
            this.cmbSysMexPort.Size = new System.Drawing.Size(198, 21);
            this.cmbSysMexPort.TabIndex = 34;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.btnDimClose);
            this.tabPage3.Controls.Add(this.btnDimOpen);
            this.tabPage3.Controls.Add(this.cmbDimPort);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(829, 115);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dimension";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Port";
            // 
            // btnDimClose
            // 
            this.btnDimClose.Location = new System.Drawing.Point(158, 30);
            this.btnDimClose.Name = "btnDimClose";
            this.btnDimClose.Size = new System.Drawing.Size(75, 23);
            this.btnDimClose.TabIndex = 40;
            this.btnDimClose.Text = "Close";
            this.btnDimClose.UseVisualStyleBackColor = true;
            this.btnDimClose.Click += new System.EventHandler(this.BtnDimClose_Click);
            // 
            // btnDimOpen
            // 
            this.btnDimOpen.Location = new System.Drawing.Point(77, 30);
            this.btnDimOpen.Name = "btnDimOpen";
            this.btnDimOpen.Size = new System.Drawing.Size(75, 23);
            this.btnDimOpen.TabIndex = 39;
            this.btnDimOpen.Text = "Open";
            this.btnDimOpen.UseVisualStyleBackColor = true;
            this.btnDimOpen.Click += new System.EventHandler(this.BtnDimOpen_Click);
            // 
            // cmbDimPort
            // 
            this.cmbDimPort.FormattingEnabled = true;
            this.cmbDimPort.Location = new System.Drawing.Point(37, 3);
            this.cmbDimPort.Name = "cmbDimPort";
            this.cmbDimPort.Size = new System.Drawing.Size(198, 21);
            this.cmbDimPort.TabIndex = 38;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 525);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.BtnClear);
            this.Name = "FormMain";
            this.Text = "SSS Middleware";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDimensionSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormDimensionSettings_Load);
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.RichTextBox txtStatus;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSysMexClose;
        private System.Windows.Forms.Button BtnOpenSysMex;
        private System.Windows.Forms.ComboBox cmbSysMexPort;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDimClose;
        private System.Windows.Forms.Button btnDimOpen;
        private System.Windows.Forms.ComboBox cmbDimPort;
    }
}