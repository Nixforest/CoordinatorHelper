using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoordinatorHelper.View
{
    public partial class Setting : Form
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Setting()
        {
            InitializeComponent();
            numericUpDownMainPort.Value = Properties.Settings.Default.UdpMainPort;
            //numericUpDownMainPort.Value = 1691;
        }

        /// <summary>
        /// Handle when click on Save button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UdpMainPort = (int)numericUpDownMainPort.Value;
            // Save setting
            Properties.Settings.Default.Save();
            // Close form
            this.Close();
        }

        /// <summary>
        /// Handle when click close button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close form
            this.Close();
        }
        /// <summary>
        /// Handle when click Advance button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnAdvance_Click(object sender, EventArgs e)
        {
            // Turn on control
            numericUpDownMainPort.ReadOnly = false;
        }
    }
}
