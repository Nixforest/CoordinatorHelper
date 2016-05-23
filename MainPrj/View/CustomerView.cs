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
    public partial class CustomerView : Form
    {
        public CustomerView()
        {
            InitializeComponent();
        }

		public ChannelControl GetChannel()
		{
			return this.channelControl;
		}

		private void CustomerView_KeyDown(object sender, KeyEventArgs e)
		{
			Keys keyCode = e.KeyCode;
			if (keyCode != Keys.Return)
			{
				return;
			}
			ChannelControl channelControl = this.channelControl;
			if (channelControl != null)
			{
				channelControl.SearchCustomer();
			}

        }
    }
}
