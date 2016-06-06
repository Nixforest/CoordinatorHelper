﻿namespace MainPrj
{
    partial class MainForm
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
            MainPrj.Model.CustomerModel customerModel1 = new MainPrj.Model.CustomerModel();
            MainPrj.Model.CustomerModel customerModel2 = new MainPrj.Model.CustomerModel();
            MainPrj.Model.CustomerModel customerModel3 = new MainPrj.Model.CustomerModel();
            MainPrj.Model.CustomerModel customerModel4 = new MainPrj.Model.CustomerModel();
            MainPrj.Model.CustomerModel customerModel5 = new MainPrj.Model.CustomerModel();
            MainPrj.Model.CustomerModel customerModel6 = new MainPrj.Model.CustomerModel();
            MainPrj.Model.CustomerModel customerModel7 = new MainPrj.Model.CustomerModel();
            MainPrj.Model.CustomerModel customerModel8 = new MainPrj.Model.CustomerModel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemLoginLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGuideline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxLog = new System.Windows.Forms.TextBox();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.channelControlLine1 = new MainPrj.View.ChannelControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.channelControlLine2 = new MainPrj.View.ChannelControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.channelControlLine3 = new MainPrj.View.ChannelControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.channelControlLine4 = new MainPrj.View.ChannelControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.channelControlLine5 = new MainPrj.View.ChannelControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.channelControlLine6 = new MainPrj.View.ChannelControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.channelControlLine7 = new MainPrj.View.ChannelControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.channelControlLine8 = new MainPrj.View.ChannelControl();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chbListenFromCard = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.chbUpdatePhone = new System.Windows.Forms.CheckBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.pbxAvatar = new System.Windows.Forms.PictureBox();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnTransferToSale = new System.Windows.Forms.Button();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLoginLogout,
            this.toolStripMenuItemConfig,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1596, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemLoginLogout
            // 
            this.toolStripMenuItemLoginLogout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLogin,
            this.toolStripMenuItemLogout});
            this.toolStripMenuItemLoginLogout.Name = "toolStripMenuItemLoginLogout";
            this.toolStripMenuItemLoginLogout.Size = new System.Drawing.Size(77, 20);
            this.toolStripMenuItemLoginLogout.Text = "Đăng nhập";
            // 
            // toolStripMenuItemLogin
            // 
            this.toolStripMenuItemLogin.Image = global::MainPrj.Properties.Resources.done_small;
            this.toolStripMenuItemLogin.Name = "toolStripMenuItemLogin";
            this.toolStripMenuItemLogin.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItemLogin.Text = "Đăng nhập";
            this.toolStripMenuItemLogin.Click += new System.EventHandler(this.toolStripMenuItemLogin_Click);
            // 
            // toolStripMenuItemLogout
            // 
            this.toolStripMenuItemLogout.Enabled = false;
            this.toolStripMenuItemLogout.Image = global::MainPrj.Properties.Resources.cancel1;
            this.toolStripMenuItemLogout.Name = "toolStripMenuItemLogout";
            this.toolStripMenuItemLogout.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItemLogout.Text = "Đăng xuất";
            this.toolStripMenuItemLogout.Click += new System.EventHandler(this.toolStripMenuItemLogout_Click);
            // 
            // toolStripMenuItemConfig
            // 
            this.toolStripMenuItemConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSetting});
            this.toolStripMenuItemConfig.Name = "toolStripMenuItemConfig";
            this.toolStripMenuItemConfig.Size = new System.Drawing.Size(56, 20);
            this.toolStripMenuItemConfig.Text = "Cài đặt";
            // 
            // toolStripMenuItemSetting
            // 
            this.toolStripMenuItemSetting.Name = "toolStripMenuItemSetting";
            this.toolStripMenuItemSetting.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemSetting.Text = "Cài đặt chung";
            this.toolStripMenuItemSetting.Click += new System.EventHandler(this.toolStripMenuItemSetting_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemGuideline,
            this.toolStripSeparator1,
            this.toolStripMenuItemSupport});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // toolStripMenuItemGuideline
            // 
            this.toolStripMenuItemGuideline.Name = "toolStripMenuItemGuideline";
            this.toolStripMenuItemGuideline.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemGuideline.Text = "Hướng dẫn sử dụng";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItemSupport
            // 
            this.toolStripMenuItemSupport.Name = "toolStripMenuItemSupport";
            this.toolStripMenuItemSupport.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemSupport.Text = "Hỗ trợ";
            this.toolStripMenuItemSupport.Click += new System.EventHandler(this.toolStripMenuItemSupport_Click);
            // 
            // tbxLog
            // 
            this.tbxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLog.Location = new System.Drawing.Point(1340, 27);
            this.tbxLog.Multiline = true;
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxLog.Size = new System.Drawing.Size(318, 517);
            this.tbxLog.TabIndex = 2;
            this.tbxLog.Visible = false;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPage1);
            this.mainTabControl.Controls.Add(this.tabPage2);
            this.mainTabControl.Controls.Add(this.tabPage3);
            this.mainTabControl.Controls.Add(this.tabPage4);
            this.mainTabControl.Controls.Add(this.tabPage5);
            this.mainTabControl.Controls.Add(this.tabPage6);
            this.mainTabControl.Controls.Add(this.tabPage7);
            this.mainTabControl.Controls.Add(this.tabPage8);
            this.mainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTabControl.Location = new System.Drawing.Point(11, 26);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1316, 516);
            this.mainTabControl.TabIndex = 3;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.channelControlLine1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1308, 478);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1 :";
            // 
            // channelControlLine1
            // 
            customerModel1.Address = "";
            customerModel1.AgencyName = "";
            customerModel1.AgencyNearest = "";
            customerModel1.Contact = "";
            customerModel1.Contact_note = "";
            customerModel1.CustomerType = "";
            customerModel1.Id = "";
            customerModel1.Name = "";
            customerModel1.PhoneList = "";
            customerModel1.Sale_name = "";
            customerModel1.Sale_phone = "";
            customerModel1.Sale_type = "";
            this.channelControlLine1.Data = customerModel1;
            this.channelControlLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine1.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine1.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine1.Name = "channelControlLine1";
            this.channelControlLine1.Size = new System.Drawing.Size(1316, 482);
            this.channelControlLine1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.channelControlLine2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1308, 478);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2 :";
            // 
            // channelControlLine2
            // 
            customerModel2.Address = "";
            customerModel2.AgencyName = "";
            customerModel2.AgencyNearest = "";
            customerModel2.Contact = "";
            customerModel2.Contact_note = "";
            customerModel2.CustomerType = "";
            customerModel2.Id = "";
            customerModel2.Name = "";
            customerModel2.PhoneList = "";
            customerModel2.Sale_name = "";
            customerModel2.Sale_phone = "";
            customerModel2.Sale_type = "";
            this.channelControlLine2.Data = customerModel2;
            this.channelControlLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine2.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine2.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine2.Name = "channelControlLine2";
            this.channelControlLine2.Size = new System.Drawing.Size(1316, 482);
            this.channelControlLine2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.channelControlLine3);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1308, 478);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3 :";
            // 
            // channelControlLine3
            // 
            customerModel3.Address = "";
            customerModel3.AgencyName = "";
            customerModel3.AgencyNearest = "";
            customerModel3.Contact = "";
            customerModel3.Contact_note = "";
            customerModel3.CustomerType = "";
            customerModel3.Id = "";
            customerModel3.Name = "";
            customerModel3.PhoneList = "";
            customerModel3.Sale_name = "";
            customerModel3.Sale_phone = "";
            customerModel3.Sale_type = "";
            this.channelControlLine3.Data = customerModel3;
            this.channelControlLine3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine3.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine3.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine3.Name = "channelControlLine3";
            this.channelControlLine3.Size = new System.Drawing.Size(1316, 482);
            this.channelControlLine3.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.channelControlLine4);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1308, 478);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "4 :";
            // 
            // channelControlLine4
            // 
            customerModel4.Address = "";
            customerModel4.AgencyName = "";
            customerModel4.AgencyNearest = "";
            customerModel4.Contact = "";
            customerModel4.Contact_note = "";
            customerModel4.CustomerType = "";
            customerModel4.Id = "";
            customerModel4.Name = "";
            customerModel4.PhoneList = "";
            customerModel4.Sale_name = "";
            customerModel4.Sale_phone = "";
            customerModel4.Sale_type = "";
            this.channelControlLine4.Data = customerModel4;
            this.channelControlLine4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine4.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine4.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine4.Name = "channelControlLine4";
            this.channelControlLine4.Size = new System.Drawing.Size(1316, 482);
            this.channelControlLine4.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.channelControlLine5);
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1308, 478);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "5 :";
            // 
            // channelControlLine5
            // 
            customerModel5.Address = "";
            customerModel5.AgencyName = "";
            customerModel5.AgencyNearest = "";
            customerModel5.Contact = "";
            customerModel5.Contact_note = "";
            customerModel5.CustomerType = "";
            customerModel5.Id = "";
            customerModel5.Name = "";
            customerModel5.PhoneList = "";
            customerModel5.Sale_name = "";
            customerModel5.Sale_phone = "";
            customerModel5.Sale_type = "";
            this.channelControlLine5.Data = customerModel5;
            this.channelControlLine5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine5.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine5.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine5.Name = "channelControlLine5";
            this.channelControlLine5.Size = new System.Drawing.Size(1316, 482);
            this.channelControlLine5.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.channelControlLine6);
            this.tabPage6.Location = new System.Drawing.Point(4, 34);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1308, 478);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "6 :";
            // 
            // channelControlLine6
            // 
            customerModel6.Address = "";
            customerModel6.AgencyName = "";
            customerModel6.AgencyNearest = "";
            customerModel6.Contact = "";
            customerModel6.Contact_note = "";
            customerModel6.CustomerType = "";
            customerModel6.Id = "";
            customerModel6.Name = "";
            customerModel6.PhoneList = "";
            customerModel6.Sale_name = "";
            customerModel6.Sale_phone = "";
            customerModel6.Sale_type = "";
            this.channelControlLine6.Data = customerModel6;
            this.channelControlLine6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine6.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine6.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine6.Name = "channelControlLine6";
            this.channelControlLine6.Size = new System.Drawing.Size(1316, 482);
            this.channelControlLine6.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage7.Controls.Add(this.channelControlLine7);
            this.tabPage7.Location = new System.Drawing.Point(4, 34);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1308, 478);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "7 :";
            // 
            // channelControlLine7
            // 
            customerModel7.Address = "";
            customerModel7.AgencyName = "";
            customerModel7.AgencyNearest = "";
            customerModel7.Contact = "";
            customerModel7.Contact_note = "";
            customerModel7.CustomerType = "";
            customerModel7.Id = "";
            customerModel7.Name = "";
            customerModel7.PhoneList = "";
            customerModel7.Sale_name = "";
            customerModel7.Sale_phone = "";
            customerModel7.Sale_type = "";
            this.channelControlLine7.Data = customerModel7;
            this.channelControlLine7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine7.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine7.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine7.Name = "channelControlLine7";
            this.channelControlLine7.Size = new System.Drawing.Size(1316, 482);
            this.channelControlLine7.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage8.Controls.Add(this.channelControlLine8);
            this.tabPage8.Location = new System.Drawing.Point(4, 34);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1308, 478);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "8 :";
            // 
            // channelControlLine8
            // 
            customerModel8.Address = "";
            customerModel8.AgencyName = "";
            customerModel8.AgencyNearest = "";
            customerModel8.Contact = "";
            customerModel8.Contact_note = "";
            customerModel8.CustomerType = "";
            customerModel8.Id = "";
            customerModel8.Name = "";
            customerModel8.PhoneList = "";
            customerModel8.Sale_name = "";
            customerModel8.Sale_phone = "";
            customerModel8.Sale_type = "";
            this.channelControlLine8.Data = customerModel8;
            this.channelControlLine8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine8.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine8.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine8.Name = "channelControlLine8";
            this.channelControlLine8.Size = new System.Drawing.Size(1316, 482);
            this.channelControlLine8.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(974, 554);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 34);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Test";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chbListenFromCard
            // 
            this.chbListenFromCard.AutoSize = true;
            this.chbListenFromCard.Location = new System.Drawing.Point(974, 594);
            this.chbListenFromCard.Name = "chbListenFromCard";
            this.chbListenFromCard.Size = new System.Drawing.Size(172, 28);
            this.chbListenFromCard.TabIndex = 13;
            this.chbListenFromCard.Text = "Listen from card?";
            this.chbListenFromCard.UseVisualStyleBackColor = true;
            this.chbListenFromCard.CheckedChanged += new System.EventHandler(this.chbListenFromCard_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 851);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1596, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // chbUpdatePhone
            // 
            this.chbUpdatePhone.AutoSize = true;
            this.chbUpdatePhone.Location = new System.Drawing.Point(1074, 557);
            this.chbUpdatePhone.Name = "chbUpdatePhone";
            this.chbUpdatePhone.Size = new System.Drawing.Size(236, 28);
            this.chbUpdatePhone.TabIndex = 13;
            this.chbUpdatePhone.Text = "Update phone to server?";
            this.chbUpdatePhone.UseVisualStyleBackColor = true;
            this.chbUpdatePhone.CheckedChanged += new System.EventHandler(this.chbUpdatePhone_CheckedChanged);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.Blue;
            this.lblUsername.Location = new System.Drawing.Point(773, 557);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUsername.Size = new System.Drawing.Size(90, 24);
            this.lblUsername.TabIndex = 16;
            this.lblUsername.Text = "Họ và tên";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.Red;
            this.lblRole.Location = new System.Drawing.Point(782, 581);
            this.lblRole.Name = "lblRole";
            this.lblRole.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRole.Size = new System.Drawing.Size(81, 24);
            this.lblRole.TabIndex = 16;
            this.lblRole.Text = "Bộ phận";
            // 
            // pbxAvatar
            // 
            this.pbxAvatar.BackColor = System.Drawing.Color.Black;
            this.pbxAvatar.Location = new System.Drawing.Point(869, 548);
            this.pbxAvatar.Name = "pbxAvatar";
            this.pbxAvatar.Size = new System.Drawing.Size(64, 64);
            this.pbxAvatar.TabIndex = 15;
            this.pbxAvatar.TabStop = false;
            // 
            // btnOrderList
            // 
            this.btnOrderList.Enabled = false;
            this.btnOrderList.Image = global::MainPrj.Properties.Resources.list;
            this.btnOrderList.Location = new System.Drawing.Point(382, 618);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(204, 64);
            this.btnOrderList.TabIndex = 6;
            this.btnOrderList.Text = "Danh sách đơn hàng (F6)";
            this.btnOrderList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrderList.UseVisualStyleBackColor = true;
            this.btnOrderList.Click += new System.EventHandler(this.btnOrderList_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Image = global::MainPrj.Properties.Resources.history;
            this.btnHistory.Location = new System.Drawing.Point(196, 618);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(180, 64);
            this.btnHistory.TabIndex = 6;
            this.btnHistory.Text = "Lịch sử cuộc gọi (F5)";
            this.btnHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnTransferToSale
            // 
            this.btnTransferToSale.Enabled = false;
            this.btnTransferToSale.Image = global::MainPrj.Properties.Resources.transfer;
            this.btnTransferToSale.Location = new System.Drawing.Point(10, 618);
            this.btnTransferToSale.Name = "btnTransferToSale";
            this.btnTransferToSale.Size = new System.Drawing.Size(180, 64);
            this.btnTransferToSale.TabIndex = 5;
            this.btnTransferToSale.Text = "Chuyển cho Sale (F4)";
            this.btnTransferToSale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransferToSale.UseVisualStyleBackColor = true;
            this.btnTransferToSale.Click += new System.EventHandler(this.btnTransferToSale_Click);
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Image = global::MainPrj.Properties.Resources.update;
            this.btnUpdateCustomer.Location = new System.Drawing.Point(382, 548);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(204, 64);
            this.btnUpdateCustomer.TabIndex = 4;
            this.btnUpdateCustomer.Text = "Cập nhật Khách Hàng (F3)";
            this.btnUpdateCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Enabled = false;
            this.btnSaveData.Image = global::MainPrj.Properties.Resources.ordertruck;
            this.btnSaveData.Location = new System.Drawing.Point(196, 548);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(180, 64);
            this.btnSaveData.TabIndex = 3;
            this.btnSaveData.Text = "Đặt hàng sau (F2)";
            this.btnSaveData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Enabled = false;
            this.btnCreateOrder.Image = global::MainPrj.Properties.Resources.ordernow;
            this.btnCreateOrder.Location = new System.Drawing.Point(10, 548);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(180, 64);
            this.btnCreateOrder.TabIndex = 2;
            this.btnCreateOrder.Text = "Đặt hàng ngay (F1)";
            this.btnCreateOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1596, 873);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.pbxAvatar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.chbUpdatePhone);
            this.Controls.Add(this.chbListenFromCard);
            this.Controls.Add(this.btnOrderList);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnTransferToSale);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.btnUpdateCustomer);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.tbxLog);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hỗ trợ Điều phối - Kế toán";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSetting;
        private System.Windows.Forms.TextBox tbxLog;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private View.ChannelControl channelControlLine1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private View.ChannelControl channelControlLine2;
        private View.ChannelControl channelControlLine3;
        private View.ChannelControl channelControlLine4;
        private View.ChannelControl channelControlLine5;
        private View.ChannelControl channelControlLine6;
        private View.ChannelControl channelControlLine7;
        private System.Windows.Forms.TabPage tabPage8;
        private View.ChannelControl channelControlLine8;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnTransferToSale;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.CheckBox chbListenFromCard;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.CheckBox chbUpdatePhone;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoginLogout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLogin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLogout;
        private System.Windows.Forms.PictureBox pbxAvatar;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGuideline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSupport;
    }
}

