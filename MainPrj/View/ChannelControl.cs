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

        private void tbxSearchCustomer_Enter(object sender, EventArgs e)
        {
            if (this.tbxSearchCustomer.Text.Equals(Properties.Resources.SearchString))
            {
                this.tbxSearchCustomer.Text = string.Empty;
                this.tbxSearchCustomer.ForeColor = Color.Black;
            }
        }

        private void tbxSearchCustomer_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbxSearchCustomer.Text))
            {
                this.tbxSearchCustomer.Text = Properties.Resources.SearchString;
                this.tbxSearchCustomer.ForeColor = SystemColors.GrayText;
            }
        }

        public void SearchCustomer()
        {
            if (this.tbxSearchCustomer.Focused && this.tbxSearchCustomer.Text.Length >= Properties.Settings.Default.StartSearchTextLength)
            {
                List<CustomerModel> list = CommonProcess.RequestCustomerByKeyword(this.tbxSearchCustomer.Text);
                if (CommonProcess.HasError)
                {
                    CommonProcess.HasError = false;
                    return;
                }
                List<SelectorModel> list2 = new List<SelectorModel>();
                foreach (CustomerModel current in list)
                {
                    list2.Add(new SelectorModel
                    {
                        Id = current.Id,
                        Name = current.Name,
                        Address = current.Address
                    });
                }
                SelectorView selectorView = new SelectorView();
                selectorView.ListData = list2;
                selectorView.Text = Properties.Resources.SelectorTitleCustomer;
                selectorView.Location = new Point(this.tbxSearchCustomer.Location.X, this.tbxSearchCustomer.Location.Y + this.tbxSearchCustomer.Bounds.Height);
                selectorView.ShowDialog();
                string selectedId = selectorView.SelectedId;
                if (!string.IsNullOrEmpty(selectedId))
                {
                    foreach (CustomerModel current2 in list)
                    {
                        if (selectedId.Equals(current2.Id))
                        {
                            this.data.Id = current2.Id;
                            this.data.Name = current2.Name;
                            this.data.Address = current2.Address;
                            this.data.PhoneList = current2.PhoneList;
                            this.data.AgencyName = current2.AgencyName;
                            this.data.CustomerType = current2.CustomerType;
                            this.data.Contact = current2.Contact;
                            CustomerModel expr_1DE = this.data;
                            expr_1DE.Contact_note += current2.Contact_note;
                            this.data.Sale_name = current2.Sale_name;
                            this.data.Sale_phone = current2.Sale_phone;
                            this.data.Sale_type = current2.Sale_type;
                            this.data.AgencyNearest = current2.AgencyNearest;
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
                            if (CommonProcess.IsValidPhone(this.GetPhone()) && !current2.PhoneList.Contains(this.GetPhone()))
                            {
                                if (string.IsNullOrEmpty(current2.PhoneList))
                                {
                                    text = this.GetPhone();
                                }
                                else
                                {
                                    text = string.Format("{0}{1}{2}", current2.PhoneList, Properties.Settings.Default.PhoneListToken, this.GetPhone());
                                }
                                CommonProcess.UpdateCustomerPhone(selectedId, text);
                                this.SetPhoneList(text);
                                break;
                            }
                            break;
                        }
                    }
                }
            }
        }
        public bool CanChangeTab()
        {
            return !this.tbxCustomerName.Focused && !this.tbxSearchCustomer.Focused && !this.tbxNote.Focused;
        }
    }
}
