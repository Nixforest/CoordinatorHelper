﻿using MainPrj.Util;
using MainPrj.View.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class OrderCoordinatorView : Form
    {
        private string note = string.Empty;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        public OrderCoordinatorView()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                note = coordinatorOrderView_v2.GetData();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        public CoordinatorOrderView_v2 getContent()
        {
            return coordinatorOrderView_v2;
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                note = coordinatorOrderView_v2.GetData();
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }

        }

        private bool ValidateData()
        {
            if (coordinatorOrderView_v2.isEmpty())
            {
                CommonProcess.ShowInformMessage("Bạn phải chọn vật tư trước.", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
    }
}
