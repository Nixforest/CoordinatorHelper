namespace MainPrj.View
{
    partial class ChannelControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxIncommingNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxCity = new System.Windows.Forms.ComboBox();
            this.cbxDistrict = new System.Windows.Forms.ComboBox();
            this.cbxWard = new System.Windows.Forms.ComboBox();
            this.cbxStreet = new System.Windows.Forms.ComboBox();
            this.tbxSearchCustomer = new System.Windows.Forms.TextBox();
            this.tbxCost = new System.Windows.Forms.TextBox();
            this.tbxCustomerTel4 = new System.Windows.Forms.TextBox();
            this.tbxCustomerTel2 = new System.Windows.Forms.TextBox();
            this.tbxCustomerTel5 = new System.Windows.Forms.TextBox();
            this.tbxCustomerTel3 = new System.Windows.Forms.TextBox();
            this.tbxCustomerTel1 = new System.Windows.Forms.TextBox();
            this.tbxSaleName = new System.Windows.Forms.TextBox();
            this.tbxCustomerType = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxContact = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxAgencyNearest = new System.Windows.Forms.TextBox();
            this.tbxNote = new System.Windows.Forms.TextBox();
            this.tbxAgency = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCustomerName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxIncommingNumber
            // 
            this.tbxIncommingNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIncommingNumber.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbxIncommingNumber.Location = new System.Drawing.Point(2, 2);
            this.tbxIncommingNumber.Margin = new System.Windows.Forms.Padding(2);
            this.tbxIncommingNumber.Name = "tbxIncommingNumber";
            this.tbxIncommingNumber.Size = new System.Drawing.Size(840, 35);
            this.tbxIncommingNumber.TabIndex = 1;
            this.tbxIncommingNumber.Text = "Số điện thoại";
            this.tbxIncommingNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxCity);
            this.groupBox1.Controls.Add(this.cbxDistrict);
            this.groupBox1.Controls.Add(this.cbxWard);
            this.groupBox1.Controls.Add(this.cbxStreet);
            this.groupBox1.Controls.Add(this.tbxSearchCustomer);
            this.groupBox1.Controls.Add(this.tbxCost);
            this.groupBox1.Controls.Add(this.tbxCustomerTel4);
            this.groupBox1.Controls.Add(this.tbxCustomerTel2);
            this.groupBox1.Controls.Add(this.tbxCustomerTel5);
            this.groupBox1.Controls.Add(this.tbxCustomerTel3);
            this.groupBox1.Controls.Add(this.tbxCustomerTel1);
            this.groupBox1.Controls.Add(this.tbxSaleName);
            this.groupBox1.Controls.Add(this.tbxCustomerType);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbxContact);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbxAgencyNearest);
            this.groupBox1.Controls.Add(this.tbxNote);
            this.groupBox1.Controls.Add(this.tbxAgency);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbxAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxCustomerName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(840, 428);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Khách Hàng";
            // 
            // cbxCity
            // 
            this.cbxCity.DisplayMember = "Text";
            this.cbxCity.FormattingEnabled = true;
            this.cbxCity.Location = new System.Drawing.Point(159, 94);
            this.cbxCity.Margin = new System.Windows.Forms.Padding(2);
            this.cbxCity.Name = "cbxCity";
            this.cbxCity.Size = new System.Drawing.Size(220, 32);
            this.cbxCity.TabIndex = 6;
            this.cbxCity.ValueMember = "Value";
            this.cbxCity.SelectedIndexChanged += new System.EventHandler(this.cbxCity_SelectedIndexChanged);
            // 
            // cbxDistrict
            // 
            this.cbxDistrict.DisplayMember = "Text";
            this.cbxDistrict.FormattingEnabled = true;
            this.cbxDistrict.Location = new System.Drawing.Point(384, 94);
            this.cbxDistrict.Margin = new System.Windows.Forms.Padding(2);
            this.cbxDistrict.Name = "cbxDistrict";
            this.cbxDistrict.Size = new System.Drawing.Size(220, 32);
            this.cbxDistrict.TabIndex = 7;
            this.cbxDistrict.ValueMember = "Value";
            this.cbxDistrict.SelectedIndexChanged += new System.EventHandler(this.cbxDistrict_SelectedIndexChanged);
            // 
            // cbxWard
            // 
            this.cbxWard.DisplayMember = "Text";
            this.cbxWard.FormattingEnabled = true;
            this.cbxWard.Location = new System.Drawing.Point(610, 94);
            this.cbxWard.Margin = new System.Windows.Forms.Padding(2);
            this.cbxWard.Name = "cbxWard";
            this.cbxWard.Size = new System.Drawing.Size(225, 32);
            this.cbxWard.TabIndex = 8;
            this.cbxWard.ValueMember = "Value";
            // 
            // cbxStreet
            // 
            this.cbxStreet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxStreet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxStreet.DisplayMember = "Text";
            this.cbxStreet.FormattingEnabled = true;
            this.cbxStreet.Location = new System.Drawing.Point(610, 60);
            this.cbxStreet.Margin = new System.Windows.Forms.Padding(2);
            this.cbxStreet.Name = "cbxStreet";
            this.cbxStreet.Size = new System.Drawing.Size(224, 32);
            this.cbxStreet.TabIndex = 5;
            this.cbxStreet.ValueMember = "Value";
            // 
            // tbxSearchCustomer
            // 
            this.tbxSearchCustomer.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbxSearchCustomer.Location = new System.Drawing.Point(610, 26);
            this.tbxSearchCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.tbxSearchCustomer.Name = "tbxSearchCustomer";
            this.tbxSearchCustomer.Size = new System.Drawing.Size(224, 29);
            this.tbxSearchCustomer.TabIndex = 3;
            this.tbxSearchCustomer.Text = "Tìm kiếm";
            this.tbxSearchCustomer.Enter += new System.EventHandler(this.tbxSearchCustomer_Enter);
            this.tbxSearchCustomer.Leave += new System.EventHandler(this.tbxSearchCustomer_Leave);
            // 
            // tbxCost
            // 
            this.tbxCost.Location = new System.Drawing.Point(662, 166);
            this.tbxCost.Margin = new System.Windows.Forms.Padding(2);
            this.tbxCost.Name = "tbxCost";
            this.tbxCost.ReadOnly = true;
            this.tbxCost.Size = new System.Drawing.Size(173, 29);
            this.tbxCost.TabIndex = 14;
            // 
            // tbxCustomerTel4
            // 
            this.tbxCustomerTel4.Location = new System.Drawing.Point(159, 166);
            this.tbxCustomerTel4.Margin = new System.Windows.Forms.Padding(2);
            this.tbxCustomerTel4.Name = "tbxCustomerTel4";
            this.tbxCustomerTel4.ReadOnly = true;
            this.tbxCustomerTel4.Size = new System.Drawing.Size(220, 29);
            this.tbxCustomerTel4.TabIndex = 12;
            // 
            // tbxCustomerTel2
            // 
            this.tbxCustomerTel2.Location = new System.Drawing.Point(384, 131);
            this.tbxCustomerTel2.Margin = new System.Windows.Forms.Padding(2);
            this.tbxCustomerTel2.Name = "tbxCustomerTel2";
            this.tbxCustomerTel2.ReadOnly = true;
            this.tbxCustomerTel2.Size = new System.Drawing.Size(220, 29);
            this.tbxCustomerTel2.TabIndex = 10;
            // 
            // tbxCustomerTel5
            // 
            this.tbxCustomerTel5.Location = new System.Drawing.Point(384, 166);
            this.tbxCustomerTel5.Margin = new System.Windows.Forms.Padding(2);
            this.tbxCustomerTel5.Name = "tbxCustomerTel5";
            this.tbxCustomerTel5.ReadOnly = true;
            this.tbxCustomerTel5.Size = new System.Drawing.Size(220, 29);
            this.tbxCustomerTel5.TabIndex = 13;
            // 
            // tbxCustomerTel3
            // 
            this.tbxCustomerTel3.Location = new System.Drawing.Point(610, 131);
            this.tbxCustomerTel3.Margin = new System.Windows.Forms.Padding(2);
            this.tbxCustomerTel3.Name = "tbxCustomerTel3";
            this.tbxCustomerTel3.ReadOnly = true;
            this.tbxCustomerTel3.Size = new System.Drawing.Size(225, 29);
            this.tbxCustomerTel3.TabIndex = 11;
            // 
            // tbxCustomerTel1
            // 
            this.tbxCustomerTel1.Location = new System.Drawing.Point(159, 131);
            this.tbxCustomerTel1.Margin = new System.Windows.Forms.Padding(2);
            this.tbxCustomerTel1.Name = "tbxCustomerTel1";
            this.tbxCustomerTel1.ReadOnly = true;
            this.tbxCustomerTel1.Size = new System.Drawing.Size(220, 29);
            this.tbxCustomerTel1.TabIndex = 9;
            // 
            // tbxSaleName
            // 
            this.tbxSaleName.Location = new System.Drawing.Point(159, 389);
            this.tbxSaleName.Margin = new System.Windows.Forms.Padding(2);
            this.tbxSaleName.Name = "tbxSaleName";
            this.tbxSaleName.ReadOnly = true;
            this.tbxSaleName.Size = new System.Drawing.Size(676, 29);
            this.tbxSaleName.TabIndex = 20;
            // 
            // tbxCustomerType
            // 
            this.tbxCustomerType.Location = new System.Drawing.Point(159, 312);
            this.tbxCustomerType.Margin = new System.Windows.Forms.Padding(2);
            this.tbxCustomerType.Name = "tbxCustomerType";
            this.tbxCustomerType.ReadOnly = true;
            this.tbxCustomerType.Size = new System.Drawing.Size(676, 29);
            this.tbxCustomerType.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 392);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "Sale:";
            // 
            // tbxContact
            // 
            this.tbxContact.Location = new System.Drawing.Point(159, 277);
            this.tbxContact.Margin = new System.Windows.Forms.Padding(2);
            this.tbxContact.Name = "tbxContact";
            this.tbxContact.ReadOnly = true;
            this.tbxContact.Size = new System.Drawing.Size(676, 29);
            this.tbxContact.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 314);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Loại Khách Hàng:";
            // 
            // tbxAgencyNearest
            // 
            this.tbxAgencyNearest.Location = new System.Drawing.Point(159, 236);
            this.tbxAgencyNearest.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAgencyNearest.Name = "tbxAgencyNearest";
            this.tbxAgencyNearest.ReadOnly = true;
            this.tbxAgencyNearest.Size = new System.Drawing.Size(676, 29);
            this.tbxAgencyNearest.TabIndex = 16;
            // 
            // tbxNote
            // 
            this.tbxNote.Location = new System.Drawing.Point(159, 347);
            this.tbxNote.Margin = new System.Windows.Forms.Padding(2);
            this.tbxNote.Multiline = true;
            this.tbxNote.Name = "tbxNote";
            this.tbxNote.Size = new System.Drawing.Size(676, 36);
            this.tbxNote.TabIndex = 19;
            this.tbxNote.TextChanged += new System.EventHandler(this.tbxNote_TextChanged);
            // 
            // tbxAgency
            // 
            this.tbxAgency.Location = new System.Drawing.Point(159, 200);
            this.tbxAgency.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAgency.Name = "tbxAgency";
            this.tbxAgency.ReadOnly = true;
            this.tbxAgency.Size = new System.Drawing.Size(676, 29);
            this.tbxAgency.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 280);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Người liên hệ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 239);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Đại Lý gần nhất:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 350);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ghi chú:";
            // 
            // tbxAddress
            // 
            this.tbxAddress.Location = new System.Drawing.Point(159, 60);
            this.tbxAddress.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(445, 29);
            this.tbxAddress.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 204);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Đại Lý:";
            // 
            // tbxCustomerName
            // 
            this.tbxCustomerName.AutoCompleteCustomSource.AddRange(new string[] {
            "a",
            "b",
            "c"});
            this.tbxCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbxCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbxCustomerName.Location = new System.Drawing.Point(159, 26);
            this.tbxCustomerName.Margin = new System.Windows.Forms.Padding(2);
            this.tbxCustomerName.Name = "tbxCustomerName";
            this.tbxCustomerName.Size = new System.Drawing.Size(445, 29);
            this.tbxCustomerName.TabIndex = 2;
            this.tbxCustomerName.TextChanged += new System.EventHandler(this.tbxCustomerName_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(610, 170);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "Giá:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Địa chỉ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số điện thoại:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Khách Hàng:";
            // 
            // ChannelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbxIncommingNumber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ChannelControl";
            this.Size = new System.Drawing.Size(846, 468);
            this.Load += new System.EventHandler(this.ChannelControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxIncommingNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxCost;
        private System.Windows.Forms.TextBox tbxCustomerTel4;
        private System.Windows.Forms.TextBox tbxCustomerTel2;
        private System.Windows.Forms.TextBox tbxCustomerTel5;
        private System.Windows.Forms.TextBox tbxCustomerTel3;
        private System.Windows.Forms.TextBox tbxCustomerTel1;
        private System.Windows.Forms.TextBox tbxCustomerType;
        private System.Windows.Forms.TextBox tbxContact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxAgencyNearest;
        private System.Windows.Forms.TextBox tbxNote;
        private System.Windows.Forms.TextBox tbxAgency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxCustomerName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSaleName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxSearchCustomer;
        private System.Windows.Forms.ComboBox cbxCity;
        private System.Windows.Forms.ComboBox cbxDistrict;
        private System.Windows.Forms.ComboBox cbxWard;
        private System.Windows.Forms.ComboBox cbxStreet;
    }
}
