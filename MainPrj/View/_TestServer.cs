using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class _TestServer : Form
    {
        public _TestServer()
        {
            InitializeComponent();
        }

        private void btnSendReq_Click(object sender, EventArgs e)
        {
            CommonProcess.RequestLogin("chuongtq", "chuong1992");
        }
    }
}
