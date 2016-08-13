using MainPrj.Util;
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
            //note = coordinatorOrderView.GetData();
            note = coordinatorOrderView_v2.GetData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
