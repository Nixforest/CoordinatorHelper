namespace MainPrj.View
{
    partial class SettingView
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
            this.nUDMainPort = new System.Windows.Forms.NumericUpDown();
            this.btnAdvance = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxPhoneSeparator = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxKeyCustomerId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxKeyKeyword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxKeyIncommingPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxURLUpdateCustomerPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxURLGetCustomerByKeyword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxURLGetCustomerByPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxServerURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbTestingMode = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxIP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxHistoryFilepath = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxHistoryFilename = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxCallIdFormat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMainPort)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application Port:";
            // 
            // nUDMainPort
            // 
            this.nUDMainPort.Enabled = false;
            this.nUDMainPort.Location = new System.Drawing.Point(95, 11);
            this.nUDMainPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nUDMainPort.Name = "nUDMainPort";
            this.nUDMainPort.ReadOnly = true;
            this.nUDMainPort.Size = new System.Drawing.Size(203, 20);
            this.nUDMainPort.TabIndex = 1;
            // 
            // btnAdvance
            // 
            this.btnAdvance.Location = new System.Drawing.Point(304, 8);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(75, 23);
            this.btnAdvance.TabIndex = 2;
            this.btnAdvance.Text = "Nâng cao";
            this.btnAdvance.UseVisualStyleBackColor = true;
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(694, 600);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(613, 600);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxPhoneSeparator);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tbxURLUpdateCustomerPhone);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbxURLGetCustomerByKeyword);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbxURLGetCustomerByPhone);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxServerURL);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(385, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 585);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Máy chủ";
            // 
            // tbxPhoneSeparator
            // 
            this.tbxPhoneSeparator.Location = new System.Drawing.Point(101, 128);
            this.tbxPhoneSeparator.Name = "tbxPhoneSeparator";
            this.tbxPhoneSeparator.Size = new System.Drawing.Size(81, 20);
            this.tbxPhoneSeparator.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Phone separator:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxKeyCustomerId);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbxKeyKeyword);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbxKeyIncommingPhone);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(10, 355);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 224);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Json keys";
            // 
            // tbxKeyCustomerId
            // 
            this.tbxKeyCustomerId.Location = new System.Drawing.Point(103, 71);
            this.tbxKeyCustomerId.Name = "tbxKeyCustomerId";
            this.tbxKeyCustomerId.Size = new System.Drawing.Size(81, 20);
            this.tbxKeyCustomerId.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Customer Id:";
            // 
            // tbxKeyKeyword
            // 
            this.tbxKeyKeyword.Location = new System.Drawing.Point(103, 45);
            this.tbxKeyKeyword.Name = "tbxKeyKeyword";
            this.tbxKeyKeyword.Size = new System.Drawing.Size(81, 20);
            this.tbxKeyKeyword.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Keyword:";
            // 
            // tbxKeyIncommingPhone
            // 
            this.tbxKeyIncommingPhone.Location = new System.Drawing.Point(103, 19);
            this.tbxKeyIncommingPhone.Name = "tbxKeyIncommingPhone";
            this.tbxKeyIncommingPhone.Size = new System.Drawing.Size(81, 20);
            this.tbxKeyIncommingPhone.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Incomming phone:";
            // 
            // tbxURLUpdateCustomerPhone
            // 
            this.tbxURLUpdateCustomerPhone.Location = new System.Drawing.Point(231, 95);
            this.tbxURLUpdateCustomerPhone.Name = "tbxURLUpdateCustomerPhone";
            this.tbxURLUpdateCustomerPhone.Size = new System.Drawing.Size(276, 20);
            this.tbxURLUpdateCustomerPhone.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Link update thông tin KH:";
            // 
            // tbxURLGetCustomerByKeyword
            // 
            this.tbxURLGetCustomerByKeyword.Location = new System.Drawing.Point(231, 69);
            this.tbxURLGetCustomerByKeyword.Name = "tbxURLGetCustomerByKeyword";
            this.tbxURLGetCustomerByKeyword.Size = new System.Drawing.Size(276, 20);
            this.tbxURLGetCustomerByKeyword.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Link request thông tin KH (keyword):";
            // 
            // tbxURLGetCustomerByPhone
            // 
            this.tbxURLGetCustomerByPhone.Location = new System.Drawing.Point(231, 43);
            this.tbxURLGetCustomerByPhone.Name = "tbxURLGetCustomerByPhone";
            this.tbxURLGetCustomerByPhone.Size = new System.Drawing.Size(276, 20);
            this.tbxURLGetCustomerByPhone.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Link request thông tin KH (phone):";
            // 
            // tbxServerURL
            // 
            this.tbxServerURL.Location = new System.Drawing.Point(76, 17);
            this.tbxServerURL.Name = "tbxServerURL";
            this.tbxServerURL.Size = new System.Drawing.Size(431, 20);
            this.tbxServerURL.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đường dẫn:";
            // 
            // chbTestingMode
            // 
            this.chbTestingMode.AutoSize = true;
            this.chbTestingMode.Location = new System.Drawing.Point(13, 606);
            this.chbTestingMode.Name = "chbTestingMode";
            this.chbTestingMode.Size = new System.Drawing.Size(91, 17);
            this.chbTestingMode.TabIndex = 6;
            this.chbTestingMode.Text = "Testing Mode";
            this.chbTestingMode.UseVisualStyleBackColor = true;
            this.chbTestingMode.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Local IP:";
            // 
            // tbxIP
            // 
            this.tbxIP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIP.Location = new System.Drawing.Point(95, 37);
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.ReadOnly = true;
            this.tbxIP.Size = new System.Drawing.Size(284, 20);
            this.tbxIP.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "History filepath:";
            // 
            // tbxHistoryFilepath
            // 
            this.tbxHistoryFilepath.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxHistoryFilepath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHistoryFilepath.Location = new System.Drawing.Point(95, 63);
            this.tbxHistoryFilepath.Name = "tbxHistoryFilepath";
            this.tbxHistoryFilepath.ReadOnly = true;
            this.tbxHistoryFilepath.Size = new System.Drawing.Size(250, 20);
            this.tbxHistoryFilepath.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(351, 61);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(28, 23);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "History filename:";
            // 
            // tbxHistoryFilename
            // 
            this.tbxHistoryFilename.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxHistoryFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHistoryFilename.Location = new System.Drawing.Point(95, 89);
            this.tbxHistoryFilename.Name = "tbxHistoryFilename";
            this.tbxHistoryFilename.Size = new System.Drawing.Size(284, 20);
            this.tbxHistoryFilename.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Call Id format:";
            // 
            // tbxCallIdFormat
            // 
            this.tbxCallIdFormat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxCallIdFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCallIdFormat.Location = new System.Drawing.Point(95, 115);
            this.tbxCallIdFormat.Name = "tbxCallIdFormat";
            this.tbxCallIdFormat.Size = new System.Drawing.Size(284, 20);
            this.tbxCallIdFormat.TabIndex = 1;
            // 
            // SettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 635);
            this.Controls.Add(this.chbTestingMode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnAdvance);
            this.Controls.Add(this.nUDMainPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxCallIdFormat);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbxHistoryFilename);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbxHistoryFilepath);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxIP);
            this.Controls.Add(this.label10);
            this.Name = "SettingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cài đặt chung";
            this.Load += new System.EventHandler(this.SettingView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUDMainPort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDMainPort;
        private System.Windows.Forms.Button btnAdvance;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxServerURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxURLGetCustomerByPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxKeyIncommingPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbxPhoneSeparator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbTestingMode;
        private System.Windows.Forms.TextBox tbxURLGetCustomerByKeyword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxKeyKeyword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxURLUpdateCustomerPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxKeyCustomerId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxIP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxHistoryFilepath;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbxHistoryFilename;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxCallIdFormat;
    }
}