﻿using MainPrj.View.Component;
namespace MainPrj.View
{
    partial class ListOrderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListOrderView));
            this.btnClear = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdateData = new System.Windows.Forms.Button();
            this.btnAddCylinder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalGas = new System.Windows.Forms.Label();
            this.lblGasStove = new System.Windows.Forms.Label();
            this.lblVan = new System.Windows.Forms.Label();
            this.lblCylinder = new System.Windows.Forms.Label();
            this.lblTotalPay = new System.Windows.Forms.Label();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.listViewListOrder = new MainPrj.View.EditableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1213, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 39);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Hủy";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbxSearch.Location = new System.Drawing.Point(819, 10);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(388, 29);
            this.tbxSearch.TabIndex = 3;
            this.tbxSearch.Text = "Tìm kiếm";
            this.tbxSearch.Enter += new System.EventHandler(this.tbxSearch_Enter);
            this.tbxSearch.Leave += new System.EventHandler(this.tbxSearch_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(721, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tìm kiếm:";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1190, 597);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 36);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Image = global::MainPrj.Properties.Resources.upload_tray;
            this.btnUpdateData.Location = new System.Drawing.Point(16, 6);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(124, 39);
            this.btnUpdateData.TabIndex = 0;
            this.btnUpdateData.Text = "Cập nhật";
            this.btnUpdateData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateData.UseVisualStyleBackColor = true;
            this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
            // 
            // btnAddCylinder
            // 
            this.btnAddCylinder.Image = global::MainPrj.Properties.Resources.money_icon_gray;
            this.btnAddCylinder.Location = new System.Drawing.Point(146, 6);
            this.btnAddCylinder.Name = "btnAddCylinder";
            this.btnAddCylinder.Size = new System.Drawing.Size(121, 39);
            this.btnAddCylinder.TabIndex = 1;
            this.btnAddCylinder.Text = "Thu tiền";
            this.btnAddCylinder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddCylinder.UseVisualStyleBackColor = true;
            this.btnAddCylinder.Click += new System.EventHandler(this.btnAddCylinder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 603);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tổng bình xuất:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 603);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tổng bếp xuất:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 603);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tổng van xuất:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(691, 603);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tổng vỏ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(876, 603);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tổng tiền:";
            // 
            // lblTotalGas
            // 
            this.lblTotalGas.AutoSize = true;
            this.lblTotalGas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGas.ForeColor = System.Drawing.Color.Red;
            this.lblTotalGas.Location = new System.Drawing.Point(160, 599);
            this.lblTotalGas.Name = "lblTotalGas";
            this.lblTotalGas.Size = new System.Drawing.Size(29, 31);
            this.lblTotalGas.TabIndex = 11;
            this.lblTotalGas.Text = "0";
            // 
            // lblGasStove
            // 
            this.lblGasStove.AutoSize = true;
            this.lblGasStove.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGasStove.ForeColor = System.Drawing.Color.Blue;
            this.lblGasStove.Location = new System.Drawing.Point(387, 599);
            this.lblGasStove.Name = "lblGasStove";
            this.lblGasStove.Size = new System.Drawing.Size(29, 31);
            this.lblGasStove.TabIndex = 11;
            this.lblGasStove.Text = "0";
            // 
            // lblVan
            // 
            this.lblVan.AutoSize = true;
            this.lblVan.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVan.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblVan.Location = new System.Drawing.Point(602, 599);
            this.lblVan.Name = "lblVan";
            this.lblVan.Size = new System.Drawing.Size(29, 31);
            this.lblVan.TabIndex = 11;
            this.lblVan.Text = "0";
            // 
            // lblCylinder
            // 
            this.lblCylinder.AutoSize = true;
            this.lblCylinder.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCylinder.ForeColor = System.Drawing.Color.Red;
            this.lblCylinder.Location = new System.Drawing.Point(782, 599);
            this.lblCylinder.Name = "lblCylinder";
            this.lblCylinder.Size = new System.Drawing.Size(29, 31);
            this.lblCylinder.TabIndex = 11;
            this.lblCylinder.Text = "0";
            // 
            // lblTotalPay
            // 
            this.lblTotalPay.AutoSize = true;
            this.lblTotalPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPay.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalPay.Location = new System.Drawing.Point(977, 599);
            this.lblTotalPay.Name = "lblTotalPay";
            this.lblTotalPay.Size = new System.Drawing.Size(29, 31);
            this.lblTotalPay.TabIndex = 11;
            this.lblTotalPay.Text = "0";
            // 
            // btnExportReport
            // 
            this.btnExportReport.Image = global::MainPrj.Properties.Resources.report;
            this.btnExportReport.Location = new System.Drawing.Point(273, 6);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(166, 39);
            this.btnExportReport.TabIndex = 2;
            this.btnExportReport.Text = "Xuất báo cáo";
            this.btnExportReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // listViewListOrder
            // 
            this.listViewListOrder.AllowColumnReorder = true;
            this.listViewListOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.listViewListOrder.ColumnTypes = ((System.Collections.Generic.List<System.Type>)(resources.GetObject("listViewListOrder.ColumnTypes")));
            this.listViewListOrder.DoubleClickActivation = true;
            this.listViewListOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewListOrder.FullRowSelect = true;
            this.listViewListOrder.GridLines = true;
            this.listViewListOrder.HideSelection = false;
            this.listViewListOrder.Location = new System.Drawing.Point(16, 51);
            this.listViewListOrder.MultiSelect = false;
            this.listViewListOrder.Name = "listViewListOrder";
            this.listViewListOrder.ShowItemToolTips = true;
            this.listViewListOrder.Size = new System.Drawing.Size(1290, 532);
            this.listViewListOrder.TabIndex = 5;
            this.listViewListOrder.UseCompatibleStateImageBehavior = false;
            this.listViewListOrder.View = System.Windows.Forms.View.Details;
            this.listViewListOrder.SubItemEndEditing += new MainPrj.View.SubItemEndEditingEventHandler(this.listViewListOrder_SubItemEndEditing);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "TÊN KH";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SỐ ĐT";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ĐỊA CHỈ";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "X.BÁN";
            this.columnHeader5.Width = 170;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "SL";
            this.columnHeader6.Width = 40;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Q.TẶNG";
            this.columnHeader7.Width = 110;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "THU TIỀN";
            this.columnHeader9.Width = 80;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "NVGH";
            this.columnHeader10.Width = 130;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "VỎ";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "SL";
            this.columnHeader12.Width = 40;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "SERI";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "GHI CHÚ";
            this.columnHeader14.Width = 90;
            // 
            // ListOrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 639);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalPay);
            this.Controls.Add(this.lblCylinder);
            this.Controls.Add(this.lblVan);
            this.Controls.Add(this.lblGasStove);
            this.Controls.Add(this.lblTotalGas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExportReport);
            this.Controls.Add(this.btnAddCylinder);
            this.Controls.Add(this.btnUpdateData);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewListOrder);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ListOrderView";
            this.Text = "Danh sách đơn hàng";
            this.Load += new System.EventHandler(this.ListOrderView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListOrderView_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label label1;
        private EditableListView listViewListOrder;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Button btnUpdateData;
        private System.Windows.Forms.Button btnAddCylinder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalGas;
        private System.Windows.Forms.Label lblGasStove;
        private System.Windows.Forms.Label lblVan;
        private System.Windows.Forms.Label lblCylinder;
        private System.Windows.Forms.Label lblTotalPay;
        private System.Windows.Forms.Button btnExportReport;
    }
}