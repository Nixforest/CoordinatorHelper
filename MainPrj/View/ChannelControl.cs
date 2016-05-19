using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MainPrj.Util;
using MainPrj.Model;

namespace MainPrj.View
{
    public partial class ChannelControl : UserControl
    {
        private AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
        private CustomerModel data = new CustomerModel();

        public CustomerModel Data
        {
            get { return data; }
            set { data = value; }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public ChannelControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Set phone number.
        /// </summary>
        /// <param name="phone"></param>
        public void SetPhone(string phone)
        {
            this.tbxIncommingNumber.Text = phone;
        }
        /// <summary>
        /// Get phone number.
        /// </summary>
        /// <returns>Incomming number</returns>
        public string GetPhone()
        {
            return this.tbxIncommingNumber.Text;
        }
        /// <summary>
        /// Set customer name.
        /// </summary>
        /// <param name="customerName">Customer name</param>
        public void SetCustomerName(string customerName)
        {
            this.tbxCustomerName.Text = customerName;
        }
        /// <summary>
        /// Set address.
        /// </summary>
        /// <param name="address">Address</param>
        public void SetAddress(string address)
        {
            this.tbxAddress.Text = address;
        }
        /// <summary>
        /// Set list of phone number
        /// </summary>
        /// <param name="phone">Phone string</param>
        public void SetPhoneList(string phone)
        {
            string[] listPhone = phone.Split(Properties.Settings.Default.PhoneListToken.ToCharArray());
            List<TextBox> listPhoneControl = new List<TextBox>();
            listPhoneControl.Add(this.tbxCustomerTel1);
            listPhoneControl.Add(this.tbxCustomerTel2);
            listPhoneControl.Add(this.tbxCustomerTel3);
            listPhoneControl.Add(this.tbxCustomerTel4);
            listPhoneControl.Add(this.tbxCustomerTel5);
            try
            {
                for (int i = 0; i < Math.Min(listPhone.Length, listPhoneControl.Count); i++)
                {
                    listPhoneControl.ElementAt(i).Text = listPhone[i];
                    if (tbxIncommingNumber.Text.Equals(listPhone[i]))
                    {
                        listPhoneControl.ElementAt(i).ForeColor = SystemColors.Highlight;
                    }
                    else
                    {
                        listPhoneControl.ElementAt(i).ForeColor = Color.Black;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
            }
        }
        /// <summary>
        /// Set agency.
        /// </summary>
        /// <param name="agency">Agency value</param>
        public void SetAgency(string agency)
        {
            this.tbxAgency.Text = agency;
        }
        /// <summary>
        /// Set contact.
        /// </summary>
        /// <param name="contact">Contact</param>
        public void SetContact(string contact)
        {
            this.tbxContact.Text = contact;
        }
        /// <summary>
        /// Set customer type.
        /// </summary>
        /// <param name="customerType">Type of customer</param>
        public void SetCustomerType(string customerType)
        {
            this.tbxCustomerType.Text = customerType;
        }
        /// <summary>
        /// Set note.
        /// </summary>
        /// <param name="note">Note</param>
        public void SetNote(string note)
        {
            this.tbxNote.Text = note;
        }
        /// <summary>
        /// Set Sale information.
        /// </summary>
        /// <param name="saleName">Name of sale</param>
        /// <param name="salePhone">Phone of sale</param>
        public void SetSaleInfor(string saleName, string salePhone)
        {
            this.tbxSaleName.Text = String.Format("{0} - {1}", saleName, salePhone);
        }
        /// <summary>
        /// Clear previous data in channel.
        /// </summary>
        public void ClearData()
        {
            this.tbxCustomerName.Text = String.Empty;
            this.tbxAddress.Text = String.Empty;
            this.tbxCustomerTel1.Text = String.Empty;
            this.tbxCustomerTel2.Text = String.Empty;
            this.tbxCustomerTel3.Text = String.Empty;
            this.tbxCustomerTel4.Text = String.Empty;
            this.tbxCustomerTel5.Text = String.Empty;
            this.tbxCost.Text = String.Empty;
            this.tbxAgency.Text = String.Empty;
            this.tbxAgencyNearest.Text = String.Empty;
            this.tbxContact.Text = String.Empty;
            this.tbxCustomerType.Text = String.Empty;
            this.tbxNote.Text = String.Empty;
            this.tbxSaleName.Text = String.Empty;
        }
        /// <summary>
        /// Handle when change text value.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxCustomerName_TextChanged(object sender, EventArgs e)
        {
            //if (tbxCustomerName.Focused)
            //{
            //    //List<CustomerModel> listCustomer = CommonProcess.RequestCustomerByKeyword(tbxCustomerName.Text);
            //    List<CustomerModel> listCustomer = CommonProcess.RequestCustomerByPhone(tbxCustomerName.Text);
            //    // Check if has error when handle common process
            //    if (CommonProcess.HasError)
            //    {
            //        // Reset flag
            //        CommonProcess.HasError = false;
            //        // Stop
            //        return;
            //    }
            //    foreach (CustomerModel item in listCustomer)
            //    {
            //        autoComplete.Add(item.Name + item.Address);
            //    }
            //}
            data.Name = tbxCustomerName.Text.Trim();
        }
        /// <summary>
        /// Handle when after load control.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ChannelControl_Load(object sender, EventArgs e)
        {
            tbxCustomerName.AutoCompleteCustomSource = autoComplete;
        }
        /// <summary>
        /// Handle when change text of note.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxNote_TextChanged(object sender, EventArgs e)
        {
            data.Contact_note = tbxNote.Text.Trim();
        }
    }
}
