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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingView));
            this.label1 = new System.Windows.Forms.Label();
            this.nUDMainPort = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
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
            this.label14 = new System.Windows.Forms.Label();
            this.btnMissCallTextColor = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnFinishCallColor = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnFinishCallTextColor = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btnFinishCallBackColor = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.nUDTimeAutoCloseMsgBox = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.btnTabActiveBackgroundColor = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.btnTabIncommingTextColor = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.btnTabHandleCallTextColor = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.btnTabFinishCallTextColor = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label23 = new System.Windows.Forms.Label();
            this.nUDPhoneCutLen = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btnSearchResult = new System.Windows.Forms.Button();
            this.btnSearchResultText = new System.Windows.Forms.Button();
            this.btnSearchResultBackground = new System.Windows.Forms.Button();
            this.btnPrinterSetting = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.tbxBrand = new System.Windows.Forms.TextBox();
            this.cbxTabColorChanged = new System.Windows.Forms.CheckBox();
            this.btnAccess = new System.Windows.Forms.Button();
            this.btnInputExcel = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbSIP = new System.Windows.Forms.CheckBox();
            this.chbUDP = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label28 = new System.Windows.Forms.Label();
            this.tbxUpholdPhone = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.btnNewNotifyColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMainPort)).BeginInit();
            this.groupBoxServer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeAutoCloseMsgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPhoneCutLen)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 554);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application Port:";
            // 
            // nUDMainPort
            // 
            this.nUDMainPort.Enabled = false;
            this.nUDMainPort.Location = new System.Drawing.Point(95, 552);
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
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(824, 600);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(743, 600);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.tbxPhoneSeparator);
            this.groupBoxServer.Controls.Add(this.label5);
            this.groupBoxServer.Controls.Add(this.groupBox2);
            this.groupBoxServer.Controls.Add(this.tbxURLUpdateCustomerPhone);
            this.groupBoxServer.Controls.Add(this.label8);
            this.groupBoxServer.Controls.Add(this.tbxURLGetCustomerByKeyword);
            this.groupBoxServer.Controls.Add(this.label6);
            this.groupBoxServer.Controls.Add(this.tbxURLGetCustomerByPhone);
            this.groupBoxServer.Controls.Add(this.label3);
            this.groupBoxServer.Controls.Add(this.tbxServerURL);
            this.groupBoxServer.Controls.Add(this.label2);
            this.groupBoxServer.Location = new System.Drawing.Point(385, 9);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(514, 585);
            this.groupBoxServer.TabIndex = 5;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "Máy chủ";
            this.groupBoxServer.Visible = false;
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
            this.label10.Location = new System.Drawing.Point(10, 581);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Local IP:";
            // 
            // tbxIP
            // 
            this.tbxIP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIP.Location = new System.Drawing.Point(95, 578);
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.ReadOnly = true;
            this.tbxIP.Size = new System.Drawing.Size(284, 20);
            this.tbxIP.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "History filepath:";
            // 
            // tbxHistoryFilepath
            // 
            this.tbxHistoryFilepath.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxHistoryFilepath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHistoryFilepath.Location = new System.Drawing.Point(95, 12);
            this.tbxHistoryFilepath.Name = "tbxHistoryFilepath";
            this.tbxHistoryFilepath.ReadOnly = true;
            this.tbxHistoryFilepath.Size = new System.Drawing.Size(250, 20);
            this.tbxHistoryFilepath.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(351, 10);
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
            this.label12.Location = new System.Drawing.Point(10, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "History filename:";
            // 
            // tbxHistoryFilename
            // 
            this.tbxHistoryFilename.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxHistoryFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHistoryFilename.Location = new System.Drawing.Point(95, 38);
            this.tbxHistoryFilename.Name = "tbxHistoryFilename";
            this.tbxHistoryFilename.Size = new System.Drawing.Size(284, 20);
            this.tbxHistoryFilename.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Call Id format:";
            // 
            // tbxCallIdFormat
            // 
            this.tbxCallIdFormat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxCallIdFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCallIdFormat.Location = new System.Drawing.Point(95, 64);
            this.tbxCallIdFormat.Name = "tbxCallIdFormat";
            this.tbxCallIdFormat.Size = new System.Drawing.Size(284, 20);
            this.tbxCallIdFormat.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Màu chữ cuộc gọi Nhỡ:";
            // 
            // btnMissCallTextColor
            // 
            this.btnMissCallTextColor.Location = new System.Drawing.Point(150, 88);
            this.btnMissCallTextColor.Name = "btnMissCallTextColor";
            this.btnMissCallTextColor.Size = new System.Drawing.Size(23, 23);
            this.btnMissCallTextColor.TabIndex = 7;
            this.btnMissCallTextColor.UseVisualStyleBackColor = true;
            this.btnMissCallTextColor.Click += new System.EventHandler(this.btnMissCallTextColor_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(134, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Màu cuộc gọi Hoàn thành:";
            // 
            // btnFinishCallColor
            // 
            this.btnFinishCallColor.Location = new System.Drawing.Point(150, 117);
            this.btnFinishCallColor.Name = "btnFinishCallColor";
            this.btnFinishCallColor.Size = new System.Drawing.Size(68, 23);
            this.btnFinishCallColor.TabIndex = 7;
            this.btnFinishCallColor.Text = "AABBBCCC";
            this.btnFinishCallColor.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(92, 151);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Màu chữ:";
            // 
            // btnFinishCallTextColor
            // 
            this.btnFinishCallTextColor.Location = new System.Drawing.Point(150, 146);
            this.btnFinishCallTextColor.Name = "btnFinishCallTextColor";
            this.btnFinishCallTextColor.Size = new System.Drawing.Size(23, 23);
            this.btnFinishCallTextColor.TabIndex = 7;
            this.btnFinishCallTextColor.UseVisualStyleBackColor = true;
            this.btnFinishCallTextColor.Click += new System.EventHandler(this.btnFinishCallTextColor_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(199, 151);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Màu nền:";
            // 
            // btnFinishCallBackColor
            // 
            this.btnFinishCallBackColor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFinishCallBackColor.Location = new System.Drawing.Point(257, 146);
            this.btnFinishCallBackColor.Name = "btnFinishCallBackColor";
            this.btnFinishCallBackColor.Size = new System.Drawing.Size(23, 23);
            this.btnFinishCallBackColor.TabIndex = 7;
            this.btnFinishCallBackColor.UseVisualStyleBackColor = true;
            this.btnFinishCallBackColor.Click += new System.EventHandler(this.btnFinishCallBackColor_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 177);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(168, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Thời gian tự động đóng Message:";
            // 
            // nUDTimeAutoCloseMsgBox
            // 
            this.nUDTimeAutoCloseMsgBox.Location = new System.Drawing.Point(184, 175);
            this.nUDTimeAutoCloseMsgBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nUDTimeAutoCloseMsgBox.Name = "nUDTimeAutoCloseMsgBox";
            this.nUDTimeAutoCloseMsgBox.Size = new System.Drawing.Size(114, 20);
            this.nUDTimeAutoCloseMsgBox.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 207);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Màu nền tab đang active:";
            // 
            // btnTabActiveBackgroundColor
            // 
            this.btnTabActiveBackgroundColor.Location = new System.Drawing.Point(150, 202);
            this.btnTabActiveBackgroundColor.Name = "btnTabActiveBackgroundColor";
            this.btnTabActiveBackgroundColor.Size = new System.Drawing.Size(23, 23);
            this.btnTabActiveBackgroundColor.TabIndex = 7;
            this.btnTabActiveBackgroundColor.UseVisualStyleBackColor = true;
            this.btnTabActiveBackgroundColor.Click += new System.EventHandler(this.btnTabActiveBackground_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 236);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(111, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Màu chữ tab Gọi đến:";
            // 
            // btnTabIncommingTextColor
            // 
            this.btnTabIncommingTextColor.Location = new System.Drawing.Point(150, 231);
            this.btnTabIncommingTextColor.Name = "btnTabIncommingTextColor";
            this.btnTabIncommingTextColor.Size = new System.Drawing.Size(23, 23);
            this.btnTabIncommingTextColor.TabIndex = 7;
            this.btnTabIncommingTextColor.UseVisualStyleBackColor = true;
            this.btnTabIncommingTextColor.Click += new System.EventHandler(this.btnIncommingTextColor_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 265);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(123, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Màu chữ tab Đang xử lý:";
            // 
            // btnTabHandleCallTextColor
            // 
            this.btnTabHandleCallTextColor.Location = new System.Drawing.Point(150, 260);
            this.btnTabHandleCallTextColor.Name = "btnTabHandleCallTextColor";
            this.btnTabHandleCallTextColor.Size = new System.Drawing.Size(23, 23);
            this.btnTabHandleCallTextColor.TabIndex = 7;
            this.btnTabHandleCallTextColor.UseVisualStyleBackColor = true;
            this.btnTabHandleCallTextColor.Click += new System.EventHandler(this.btnTabHandleCallTextColor_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 294);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(122, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "Màu chữ tab Xử lý xong:";
            // 
            // btnTabFinishCallTextColor
            // 
            this.btnTabFinishCallTextColor.Location = new System.Drawing.Point(150, 289);
            this.btnTabFinishCallTextColor.Name = "btnTabFinishCallTextColor";
            this.btnTabFinishCallTextColor.Size = new System.Drawing.Size(23, 23);
            this.btnTabFinishCallTextColor.TabIndex = 7;
            this.btnTabFinishCallTextColor.UseVisualStyleBackColor = true;
            this.btnTabFinishCallTextColor.Click += new System.EventHandler(this.btnTabFinishCallTextColor_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(10, 322);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(150, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Độ dài phone hiển thị trên tab:";
            // 
            // nUDPhoneCutLen
            // 
            this.nUDPhoneCutLen.Location = new System.Drawing.Point(184, 320);
            this.nUDPhoneCutLen.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nUDPhoneCutLen.Name = "nUDPhoneCutLen";
            this.nUDPhoneCutLen.Size = new System.Drawing.Size(114, 20);
            this.nUDPhoneCutLen.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 352);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(111, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "Màu kết quả tìm kiếm:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(92, 381);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(52, 13);
            this.label25.TabIndex = 0;
            this.label25.Text = "Màu chữ:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(199, 381);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 13);
            this.label26.TabIndex = 0;
            this.label26.Text = "Màu nền:";
            // 
            // btnSearchResult
            // 
            this.btnSearchResult.Location = new System.Drawing.Point(150, 347);
            this.btnSearchResult.Name = "btnSearchResult";
            this.btnSearchResult.Size = new System.Drawing.Size(68, 23);
            this.btnSearchResult.TabIndex = 7;
            this.btnSearchResult.Text = "AABBBCCC";
            this.btnSearchResult.UseVisualStyleBackColor = true;
            // 
            // btnSearchResultText
            // 
            this.btnSearchResultText.Location = new System.Drawing.Point(150, 376);
            this.btnSearchResultText.Name = "btnSearchResultText";
            this.btnSearchResultText.Size = new System.Drawing.Size(23, 23);
            this.btnSearchResultText.TabIndex = 7;
            this.btnSearchResultText.UseVisualStyleBackColor = true;
            this.btnSearchResultText.Click += new System.EventHandler(this.btnSearchResultText_Click);
            // 
            // btnSearchResultBackground
            // 
            this.btnSearchResultBackground.Location = new System.Drawing.Point(257, 376);
            this.btnSearchResultBackground.Name = "btnSearchResultBackground";
            this.btnSearchResultBackground.Size = new System.Drawing.Size(23, 23);
            this.btnSearchResultBackground.TabIndex = 7;
            this.btnSearchResultBackground.UseVisualStyleBackColor = true;
            this.btnSearchResultBackground.Click += new System.EventHandler(this.btnSearchResultBackground_Click);
            // 
            // btnPrinterSetting
            // 
            this.btnPrinterSetting.Location = new System.Drawing.Point(12, 514);
            this.btnPrinterSetting.Name = "btnPrinterSetting";
            this.btnPrinterSetting.Size = new System.Drawing.Size(75, 23);
            this.btnPrinterSetting.TabIndex = 2;
            this.btnPrinterSetting.Text = "Máy in";
            this.btnPrinterSetting.UseVisualStyleBackColor = true;
            this.btnPrinterSetting.Click += new System.EventHandler(this.btnPrinterSetting_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(10, 412);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(124, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "Thương hiệu in hóa đơn:";
            // 
            // tbxBrand
            // 
            this.tbxBrand.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxBrand.Location = new System.Drawing.Point(150, 409);
            this.tbxBrand.Name = "tbxBrand";
            this.tbxBrand.Size = new System.Drawing.Size(229, 20);
            this.tbxBrand.TabIndex = 1;
            // 
            // cbxTabColorChanged
            // 
            this.cbxTabColorChanged.AutoSize = true;
            this.cbxTabColorChanged.Location = new System.Drawing.Point(202, 92);
            this.cbxTabColorChanged.Name = "cbxTabColorChanged";
            this.cbxTabColorChanged.Size = new System.Drawing.Size(115, 17);
            this.cbxTabColorChanged.TabIndex = 6;
            this.cbxTabColorChanged.Text = "Thay đổi màu tab?";
            this.cbxTabColorChanged.UseVisualStyleBackColor = true;
            // 
            // btnAccess
            // 
            this.btnAccess.Location = new System.Drawing.Point(662, 600);
            this.btnAccess.Name = "btnAccess";
            this.btnAccess.Size = new System.Drawing.Size(75, 23);
            this.btnAccess.TabIndex = 8;
            this.btnAccess.Text = "Nâng cao";
            this.btnAccess.UseVisualStyleBackColor = true;
            this.btnAccess.Click += new System.EventHandler(this.btnAccess_Click);
            // 
            // btnInputExcel
            // 
            this.btnInputExcel.Location = new System.Drawing.Point(596, 600);
            this.btnInputExcel.Name = "btnInputExcel";
            this.btnInputExcel.Size = new System.Drawing.Size(60, 23);
            this.btnInputExcel.TabIndex = 9;
            this.btnInputExcel.Text = "Nhập excel";
            this.btnInputExcel.UseVisualStyleBackColor = true;
            this.btnInputExcel.Visible = false;
            this.btnInputExcel.Click += new System.EventHandler(this.btnInputExcel_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(385, 600);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(205, 23);
            this.progressBar.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbSIP);
            this.groupBox1.Controls.Add(this.chbUDP);
            this.groupBox1.Location = new System.Drawing.Point(12, 460);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 48);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Các loại gói tin";
            // 
            // chbSIP
            // 
            this.chbSIP.AutoSize = true;
            this.chbSIP.Location = new System.Drawing.Point(138, 19);
            this.chbSIP.Name = "chbSIP";
            this.chbSIP.Size = new System.Drawing.Size(43, 17);
            this.chbSIP.TabIndex = 0;
            this.chbSIP.Text = "SIP";
            this.toolTip.SetToolTip(this.chbSIP, "Chạy thread xử lý gói tin SIP (VoIP) nhận từ mạng.");
            this.chbSIP.UseVisualStyleBackColor = true;
            // 
            // chbUDP
            // 
            this.chbUDP.AutoSize = true;
            this.chbUDP.Checked = true;
            this.chbUDP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbUDP.Location = new System.Drawing.Point(7, 20);
            this.chbUDP.Name = "chbUDP";
            this.chbUDP.Size = new System.Drawing.Size(49, 17);
            this.chbUDP.TabIndex = 0;
            this.chbUDP.Text = "UDP";
            this.toolTip.SetToolTip(this.chbUDP, "Chạy thread đọc xử lý gói tin UDP nhận từ card ghi âm.");
            this.chbUDP.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(10, 434);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(105, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Số điện thoại CSKH:";
            // 
            // tbxUpholdPhone
            // 
            this.tbxUpholdPhone.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxUpholdPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUpholdPhone.Location = new System.Drawing.Point(150, 431);
            this.tbxUpholdPhone.Name = "tbxUpholdPhone";
            this.tbxUpholdPhone.Size = new System.Drawing.Size(229, 20);
            this.tbxUpholdPhone.TabIndex = 1;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(187, 207);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(122, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Màu nền thông báo mới:";
            // 
            // btnNewNotifyColor
            // 
            this.btnNewNotifyColor.Location = new System.Drawing.Point(315, 202);
            this.btnNewNotifyColor.Name = "btnNewNotifyColor";
            this.btnNewNotifyColor.Size = new System.Drawing.Size(23, 23);
            this.btnNewNotifyColor.TabIndex = 7;
            this.btnNewNotifyColor.UseVisualStyleBackColor = true;
            this.btnNewNotifyColor.Click += new System.EventHandler(this.btnNewNotifyColor_Click);
            // 
            // SettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 635);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnInputExcel);
            this.Controls.Add(this.btnAccess);
            this.Controls.Add(this.btnSearchResultBackground);
            this.Controls.Add(this.btnSearchResultText);
            this.Controls.Add(this.btnFinishCallBackColor);
            this.Controls.Add(this.btnSearchResult);
            this.Controls.Add(this.btnFinishCallTextColor);
            this.Controls.Add(this.btnFinishCallColor);
            this.Controls.Add(this.btnTabFinishCallTextColor);
            this.Controls.Add(this.btnTabHandleCallTextColor);
            this.Controls.Add(this.btnTabIncommingTextColor);
            this.Controls.Add(this.btnNewNotifyColor);
            this.Controls.Add(this.btnTabActiveBackgroundColor);
            this.Controls.Add(this.btnMissCallTextColor);
            this.Controls.Add(this.cbxTabColorChanged);
            this.Controls.Add(this.chbTestingMode);
            this.Controls.Add(this.groupBoxServer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.btnPrinterSetting);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.nUDPhoneCutLen);
            this.Controls.Add(this.nUDTimeAutoCloseMsgBox);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.nUDMainPort);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbxUpholdPhone);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.tbxBrand);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.tbxCallIdFormat);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbxHistoryFilename);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbxHistoryFilepath);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxIP);
            this.Controls.Add(this.label10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cài đặt chung";
            this.Load += new System.EventHandler(this.SettingView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUDMainPort)).EndInit();
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxServer.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeAutoCloseMsgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPhoneCutLen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDMainPort;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBoxServer;
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
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnMissCallTextColor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnFinishCallColor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnFinishCallTextColor;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnFinishCallBackColor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown nUDTimeAutoCloseMsgBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnTabActiveBackgroundColor;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnTabIncommingTextColor;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnTabHandleCallTextColor;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnTabFinishCallTextColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown nUDPhoneCutLen;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnSearchResult;
        private System.Windows.Forms.Button btnSearchResultText;
        private System.Windows.Forms.Button btnSearchResultBackground;
        private System.Windows.Forms.Button btnPrinterSetting;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbxBrand;
        private System.Windows.Forms.CheckBox cbxTabColorChanged;
        private System.Windows.Forms.Button btnAccess;
        private System.Windows.Forms.Button btnInputExcel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbSIP;
        private System.Windows.Forms.CheckBox chbUDP;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbxUpholdPhone;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnNewNotifyColor;
    }
}