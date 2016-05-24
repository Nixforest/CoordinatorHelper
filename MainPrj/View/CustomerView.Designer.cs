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
            this.channelControl = new MainPrj.View.ChannelControl();
            this.SuspendLayout();
            // 
            // channelControl
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
            this.channelControl.Data = customerModel1;
            this.channelControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelControl.Location = new System.Drawing.Point(17, 28);
            this.channelControl.Margin = new System.Windows.Forms.Padding(11, 11, 11, 11);
            this.channelControl.Name = "channelControl";
            this.channelControl.Size = new System.Drawing.Size(849, 474);
            this.channelControl.TabIndex = 0;
            // 
            // CustomerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 499);
            this.Controls.Add(this.channelControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CustomerView";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerView_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private ChannelControl channelControl;
    }
}