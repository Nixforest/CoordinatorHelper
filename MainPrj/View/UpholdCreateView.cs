using MainPrj.Model;
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
    public partial class UpholdCreateView : Form
    {
        private CustomerModel _customer;
        /// <summary>
        /// Customer information
        /// </summary>
        public CustomerModel CustomerInfo
        {
            get { return _customer; }
            set { _customer = value; }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="customer">Customer model</param>
        public UpholdCreateView(CustomerModel customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            tbxOther.Enabled = radioButton6.Checked;
        }
        /// <summary>
        /// Handle click button Create.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CreateUphold())
            {
                BillPrintUpholdModel printModel = new BillPrintUpholdModel();

                //printModel.Brand = Properties.Settings.Default.BillBrand;
                printModel.Phone = DataPure.Instance.Agent.Phone;
                printModel.CustomerName = CustomerInfo != null ?
                    String.Format("{0}-{1}", CustomerInfo.ActivePhone,
                    CustomerInfo.Name) : String.Empty;
                printModel.CustomerAddress = CustomerInfo != null ? CustomerInfo.Address : String.Empty;
                printModel.AgentAddress = DataPure.Instance.Agent.Address;
                printModel.Reason = radioButton1.Checked ? radioButton1.Text :
                    radioButton2.Checked ? radioButton2.Text :
                    radioButton3.Checked ? radioButton3.Text :
                    radioButton4.Checked ? radioButton4.Text :
                    radioButton5.Checked ? radioButton5.Text :
                    tbxOther.Text;
                printModel.Print();
                this.Close();
            }
        }
        /// <summary>
        /// Create uphold
        /// </summary>
        /// <returns>True if create is success, False otherwise</returns>
        private bool CreateUphold()
        {
            return true;
        }
    }
}
