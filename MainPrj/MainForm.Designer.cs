namespace MainPrj
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxLog = new System.Windows.Forms.TextBox();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.btnTransferToSale = new System.Windows.Forms.Button();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.channelControlLine1 = new MainPrj.View.ChannelControl();
            this.channelControlLine2 = new MainPrj.View.ChannelControl();
            this.channelControlLine3 = new MainPrj.View.ChannelControl();
            this.channelControlLine4 = new MainPrj.View.ChannelControl();
            this.channelControlLine5 = new MainPrj.View.ChannelControl();
            this.channelControlLine6 = new MainPrj.View.ChannelControl();
            this.channelControlLine7 = new MainPrj.View.ChannelControl();
            this.channelControlLine8 = new MainPrj.View.ChannelControl();
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
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1916, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSetting});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(56, 20);
            this.toolStripMenuItem1.Text = "Cài đặt";
            // 
            // toolStripMenuItemSetting
            // 
            this.toolStripMenuItemSetting.Name = "toolStripMenuItemSetting";
            this.toolStripMenuItemSetting.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItemSetting.Text = "Cài đặt chung";
            this.toolStripMenuItemSetting.Click += new System.EventHandler(this.toolStripMenuItemSetting_Click);
            // 
            // tbxLog
            // 
            this.tbxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLog.Location = new System.Drawing.Point(1558, 27);
            this.tbxLog.Multiline = true;
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxLog.Size = new System.Drawing.Size(346, 538);
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
            this.mainTabControl.Location = new System.Drawing.Point(12, 27);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(954, 538);
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
            this.tabPage1.Size = new System.Drawing.Size(946, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Line 1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.channelControlLine2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(946, 500);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Line 2";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.channelControlLine3);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(946, 500);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Line 3";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.channelControlLine4);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(946, 500);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Line 4";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.channelControlLine5);
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(946, 500);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Line 5";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.channelControlLine6);
            this.tabPage6.Location = new System.Drawing.Point(4, 34);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(946, 500);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Line 6";
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage7.Controls.Add(this.channelControlLine7);
            this.tabPage7.Location = new System.Drawing.Point(4, 34);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(946, 500);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Line 7";
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage8.Controls.Add(this.channelControlLine8);
            this.tabPage8.Location = new System.Drawing.Point(4, 34);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(946, 500);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Line 8";
            // 
            // btnTransferToSale
            // 
            this.btnTransferToSale.Location = new System.Drawing.Point(400, 571);
            this.btnTransferToSale.Name = "btnTransferToSale";
            this.btnTransferToSale.Size = new System.Drawing.Size(143, 67);
            this.btnTransferToSale.TabIndex = 9;
            this.btnTransferToSale.Text = "(F4) Chuyển cho Sale";
            this.btnTransferToSale.UseVisualStyleBackColor = true;
            this.btnTransferToSale.Click += new System.EventHandler(this.btnTransferToSale_Click);
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Location = new System.Drawing.Point(251, 571);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(143, 67);
            this.btnUpdateCustomer.TabIndex = 10;
            this.btnUpdateCustomer.Text = "(F3) Cập nhật Khách Hàng";
            this.btnUpdateCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(131, 571);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(114, 67);
            this.btnSaveData.TabIndex = 11;
            this.btnSaveData.Text = "(F2) Đặt hàng sau";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(11, 571);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(114, 67);
            this.btnCreateOrder.TabIndex = 12;
            this.btnCreateOrder.Text = "(F1) Đặt hàng ngay";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(972, 61);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 35);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Test";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // channelControlLine1
            // 
            this.channelControlLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine1.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine1.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine1.Name = "channelControlLine1";
            this.channelControlLine1.Size = new System.Drawing.Size(1740, 979);
            this.channelControlLine1.TabIndex = 0;
            // 
            // channelControlLine2
            // 
            this.channelControlLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine2.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine2.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine2.Name = "channelControlLine2";
            this.channelControlLine2.Size = new System.Drawing.Size(1740, 1279);
            this.channelControlLine2.TabIndex = 0;
            // 
            // channelControlLine3
            // 
            this.channelControlLine3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine3.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine3.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine3.Name = "channelControlLine3";
            this.channelControlLine3.Size = new System.Drawing.Size(1740, 1279);
            this.channelControlLine3.TabIndex = 0;
            // 
            // channelControlLine4
            // 
            this.channelControlLine4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine4.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine4.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine4.Name = "channelControlLine4";
            this.channelControlLine4.Size = new System.Drawing.Size(1740, 1279);
            this.channelControlLine4.TabIndex = 0;
            // 
            // channelControlLine5
            // 
            this.channelControlLine5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine5.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine5.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine5.Name = "channelControlLine5";
            this.channelControlLine5.Size = new System.Drawing.Size(1740, 1279);
            this.channelControlLine5.TabIndex = 0;
            // 
            // channelControlLine6
            // 
            this.channelControlLine6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine6.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine6.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine6.Name = "channelControlLine6";
            this.channelControlLine6.Size = new System.Drawing.Size(1740, 1279);
            this.channelControlLine6.TabIndex = 0;
            // 
            // channelControlLine7
            // 
            this.channelControlLine7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine7.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine7.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine7.Name = "channelControlLine7";
            this.channelControlLine7.Size = new System.Drawing.Size(1740, 1279);
            this.channelControlLine7.TabIndex = 0;
            // 
            // channelControlLine8
            // 
            this.channelControlLine8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControlLine8.Location = new System.Drawing.Point(0, 0);
            this.channelControlLine8.Margin = new System.Windows.Forms.Padding(6);
            this.channelControlLine8.Name = "channelControlLine8";
            this.channelControlLine8.Size = new System.Drawing.Size(1740, 1279);
            this.channelControlLine8.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 1053);
            this.Controls.Add(this.btnTransferToSale);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.btnUpdateCustomer);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.tbxLog);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.btnSearch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hỗ trợ điều phối";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
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
    }
}

