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
    /// <summary>
    /// User control Channel.
    /// </summary>
    public partial class ChannelControl : UserControl
    {
        /// <summary>
        /// Current data.
        /// </summary>
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
        public void SetIncommingPhone(string phone)
        {
            this.tbxIncommingNumber.Text = phone;
        }
        /// <summary>
        /// Get phone number.
        /// </summary>
        /// <returns>Incomming number</returns>
        public string GetIncommingPhone()
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
            if (phone == null)
            {
                return;
            }
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
                        listPhoneControl.ElementAt(i).BackColor = SystemColors.ButtonFace;
                        listPhoneControl.ElementAt(i).ForeColor = SystemColors.Highlight;
                    }
                    else
                    {
                        listPhoneControl.ElementAt(i).BackColor = SystemColors.ButtonFace;
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
        /// Set agency nearest.
        /// </summary>
        /// <param name="agency">Agency value</param>
        public void SetAgencyNearest(string agency)
        {
            this.tbxAgencyNearest.Text = agency;
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
            //data.Name = tbxCustomerName.Text.Trim();
        }
        /// <summary>
        /// Handle when after load control.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ChannelControl_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Handle when change text of note.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxNote_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void SaveNote()
        {
            data.Contact_note = tbxNote.Text.Trim();
            tbxIncommingNumber.Focus();
        }
        /// <summary>
        /// Handle when focus on Search textbox
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxSearchCustomer_Enter(object sender, EventArgs e)
        {
            if (this.tbxSearchCustomer.Text.Equals(Properties.Resources.SearchString))
            {
                this.tbxSearchCustomer.Text = string.Empty;
                this.tbxSearchCustomer.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Handle when lost focus on Search textbox
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxSearchCustomer_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbxSearchCustomer.Text.Trim()))
            {
                this.tbxSearchCustomer.Text = Properties.Resources.SearchString;
                this.tbxSearchCustomer.ForeColor = SystemColors.GrayText;
            }
        }
        /// <summary>
        /// Search customer.
        /// </summary>
        public void SearchCustomer()
        {
            if (this.tbxSearchCustomer.Focused
                && this.tbxSearchCustomer.Text.Length >= Properties.Settings.Default.StartSearchTextLength)
            {
                List<CustomerModel> listResult = CommonProcess.RequestCustomerByKeyword(this.tbxSearchCustomer.Text.Trim());
                if (CommonProcess.HasError)
                {
                    CommonProcess.HasError = false;
                    return;
                }
                List<SelectorModel> listSelector = new List<SelectorModel>();
                foreach (CustomerModel customer in listResult)
                {
                    listSelector.Add(new SelectorModel
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        Address = customer.Address
                    });
                }
                SelectorView selectorView = SelectorView.GetInstance();
                selectorView.ListData = listSelector;
                selectorView.Text = Properties.Resources.SelectorTitleCustomer;
                //selectorView.ShowDialog();
                selectorView.Show();
                string selectedId = selectorView.SelectedId;
                if (!string.IsNullOrEmpty(selectedId))
                {
                    foreach (CustomerModel customer in listResult)
                    {
                        if (selectedId.Equals(customer.Id))
                        {
                            // Update data
                            this.data.Id = customer.Id;
                            this.data.Name = customer.Name;
                            this.data.Address = customer.Address;
                            this.data.PhoneList = customer.PhoneList;
                            this.data.AgencyName = customer.AgencyName;
                            this.data.AgencyNearest = customer.AgencyNearest;
                            this.data.Contact = customer.Contact;
                            this.data.CustomerType = customer.CustomerType;
                            this.data.Contact_note += customer.Contact_note;
                            this.data.Sale_name = customer.Sale_name;
                            this.data.Sale_phone = customer.Sale_phone;
                            this.data.Sale_type = customer.Sale_type;

                            this.SetCustomerName(this.data.Name);
                            this.SetAddress(this.data.Address);
                            this.SetPhoneList(this.data.PhoneList);
                            this.SetAgency(this.data.AgencyName);
                            this.SetAgencyNearest(this.data.AgencyNearest);
                            this.SetContact(this.data.Contact);
                            this.SetCustomerType(this.data.CustomerType);
                            this.SetNote(this.data.Contact_note);
                            this.SetSaleInfor(this.data.Sale_name, this.data.Sale_phone);
                            string text = string.Empty;
                            if (CommonProcess.IsValidPhone(this.GetIncommingPhone()))
                            {
                                // Update phone
                                if (string.IsNullOrEmpty(customer.PhoneList))
                                {
                                    text = this.GetIncommingPhone();
                                }
                                else
                                {
                                    if (!customer.PhoneList.Contains(this.GetIncommingPhone()))
                                    {
                                        text = string.Format("{0}{1}{2}", customer.PhoneList,
                                        Properties.Settings.Default.PhoneListToken, this.GetIncommingPhone());
                                    }
                                }
                                if (!String.IsNullOrEmpty(text))
                                {
                                    CommonProcess.UpdateCustomerPhone(selectedId, text);
                                    this.SetPhoneList(text);
                                }
                                break;
                            }
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        ///  Check can change tab.
        /// </summary>
        /// <returns></returns>
        public bool CanChangeTab()
        {
            return !this.tbxSearchCustomer.Focused && !this.tbxNote.Focused;
        }
    }
}
