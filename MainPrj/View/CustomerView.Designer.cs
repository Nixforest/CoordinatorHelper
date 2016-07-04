namespace MainPrj.View
{
    partial class CustomerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerView));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateCustomer = new System.Windows.Forms.Button();
            this.channelControl = new MainPrj.View.ChannelControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(773, 501);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 37);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateCustomer
            // 
            this.btnCreateCustomer.Location = new System.Drawing.Point(585, 501);
            this.btnCreateCustomer.Name = "btnCreateCustomer";
            this.btnCreateCustomer.Size = new System.Drawing.Size(182, 37);
            this.btnCreateCustomer.TabIndex = 2;
            this.btnCreateCustomer.Text = "Tạo Khách Hàng";
            this.btnCreateCustomer.UseVisualStyleBackColor = true;
            this.btnCreateCustomer.Click += new System.EventHandler(this.btnCreateCustomer_Click);
            // 
            // channelControl
            // 
            customerModel1.ActivePhone = "";
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
            this.channelControl.Data = customerModel1;
            this.channelControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControl.Location = new System.Drawing.Point(17, 28);
            this.channelControl.Margin = new System.Windows.Forms.Padding(11);
            this.channelControl.Name = "channelControl";
            this.channelControl.Size = new System.Drawing.Size(849, 474);
            this.channelControl.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(873, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // CustomerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(873, 567);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCreateCustomer);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.channelControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật thông tin Khách hàng";
            this.Load += new System.EventHandler(this.CustomerView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerView_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChannelControl channelControl;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateCustomer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}