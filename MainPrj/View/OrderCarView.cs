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
    public partial class OrderCarView : Form
    {
        public OrderCarView()
        {
            InitializeComponent();
        }

        private void OrderCarView_Load(object sender, EventArgs e)
        {
            //webBrowser.Navigate("http://spj.daukhimiennam.com/admin/gasOrders/create");
            webBrowser.Navigate("https://docs.google.com/spreadsheets/d/1LdQLXMPeUGBXnKKegBwupGi25wbria9Xr8qul0N--Ow/edit?usp=sharing");
        }
    }
}
