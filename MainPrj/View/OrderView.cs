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
    public partial class OrderView : Form
    {
        public OrderView()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPromote_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrderView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = CommonProcess.ShowInformMessage(Properties.Resources.AreYouSureToClose,
                MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.No))
            {
                e.Cancel = true;
            }
        }
    }
}
