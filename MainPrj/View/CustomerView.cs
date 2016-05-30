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
    public partial class CustomerView : Form
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public CustomerView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Get Channel
        /// </summary>
        /// <returns></returns>
		public ChannelControl GetChannel()
		{
			return this.channelControl;
		}
        /// <summary>
        /// Handle keydown.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">KeyEventArgs</param>
		private void CustomerView_KeyDown(object sender, KeyEventArgs e)
		{
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ChannelControl channelControl = this.channelControl;
			        if (channelControl != null)
			        {
				        channelControl.SearchCustomer();
			        }
                    break;
                case Keys.F3:
                    this.channelControl.SaveNote();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Handle click close button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!this.channelControl.GetNote().Equals(this.channelControl.Data.Contact_note))
            {
                DialogResult result = CommonProcess.ShowInformMessage(Properties.Resources.DataNotSaveYet, MessageBoxButtons.YesNoCancel);
                if (result.Equals(DialogResult.Yes))
                {
                    this.channelControl.SaveNote();
                    this.Close();
                }
                else if (result.Equals(DialogResult.No))
                {
                    this.Close();
                }
            }
        }
    }
}
