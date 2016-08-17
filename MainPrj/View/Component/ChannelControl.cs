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
using MainPrj.Model.Address;

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
            //this.SetCity(DataPure.Instance.GetListCities());
            //this.SetStreet(DataPure.Instance.GetListStreets());
            //this.tbxAddress.Text = address;
            string[] listAddress = address.Split(',');
            if (listAddress.Count() == 5)
            {
                if (!String.IsNullOrEmpty(listAddress[4]))
                {
                    cbxCity.Text = listAddress[4];
                }
                if (!String.IsNullOrEmpty(listAddress[3]))
                {
                    cbxDistrict.Text = listAddress[3];
                }
                cbxWard.Text         = listAddress[2];
                cbxStreet.Text       = listAddress[1];
                tbxAddress.Text      = listAddress[0];
            }
            else if (listAddress.Count() == 4)
            {
                if (!String.IsNullOrEmpty(listAddress[3]))
                {
                    cbxCity.Text = listAddress[3];
                }
                if (!String.IsNullOrEmpty(listAddress[2]))
                {
                    cbxDistrict.Text = listAddress[2];
                }
                cbxWard.Text = listAddress[1];
                cbxStreet.Text = listAddress[0];
            }
        }
        /// <summary>
        /// Set data for City combobox.
        /// </summary>
        /// <param name="cities">List of cities</param>
        public void SetCity(List<CityModel> cities)
        {
            if (cities != null)
            {
                List<object> items = new List<object>();
                items.Add(new { Text = string.Empty, Value = string.Empty });
                foreach (CityModel item in cities)
                {
                    items.Add(new { Text = item.Name, Value = item.Id });
                }
                cbxCity.DataSource = items;
                cbxCity.SelectedIndex = 0;
                if (DataPure.Instance.Agent != null)
                {
                    if (!String.IsNullOrEmpty(DataPure.Instance.Agent.Agent_province))
                    {
                        cbxCity.SelectedValue = DataPure.Instance.Agent.Agent_province;
                    }
                    if (!String.IsNullOrEmpty(DataPure.Instance.Agent.Agent_district))
                    {
                        cbxDistrict.SelectedValue = DataPure.Instance.Agent.Agent_district;
                    }
                }
            }
        }
        public void SetCity(string city)
        {
            cbxCity.SelectedText = city;
        }
        /// <summary>
        /// Get city string.
        /// </summary>
        /// <returns>Return city</returns>
        public string GetCity()
        {
            return cbxCity.SelectedText != null ? cbxCity.SelectedText : string.Empty;
        }
        /// <summary>
        /// Set data for Street combobox.
        /// </summary>
        /// <param name="streets">List of streets</param>
        public void SetStreet(List<StreetModel> streets)
        {
            if (streets != null)
            {
                List<object> items = new List<object>();
                items.Add(new { Text = string.Empty, Value = string.Empty });
                foreach (StreetModel item in streets)
                {
                    string removeSign = CommonProcess.NormalizationString(item.Name);
                    items.Add(new { Text = String.Format("{0} - {1}", removeSign, item.Name), Value = item.Id });
                }
                cbxStreet.DataSource = items;
                cbxStreet.SelectedIndex = 0;
            }
        }
        public void SetStreet(string street)
        {
            cbxStreet.SelectedText = street;
        }
        /// <summary>
        /// Get street string.
        /// </summary>
        /// <returns>Return street</returns>
        public string GetStreet()
        {
            return cbxStreet.SelectedText != null ? cbxStreet.SelectedText : string.Empty;
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
        /// Get note
        /// </summary>
        /// <returns>Note value</returns>
        public string GetNote()
        {
            return this.tbxNote.Text.Trim();
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
            this.tbxCustomerName.Text  = String.Empty;
            this.tbxAddress.Text       = String.Empty;
            //this.cbxCity.Text          = String.Empty;
            //this.cbxDistrict.Text      = String.Empty;
            this.cbxWard.Text          = String.Empty;
            this.cbxStreet.Text        = String.Empty;
            this.tbxCustomerTel1.Text  = String.Empty;
            this.tbxCustomerTel2.Text  = String.Empty;
            this.tbxCustomerTel3.Text  = String.Empty;
            this.tbxCustomerTel4.Text  = String.Empty;
            this.tbxCustomerTel5.Text  = String.Empty;
            this.tbxCost.Text          = String.Empty;
            this.tbxAgency.Text        = String.Empty;
            this.tbxAgencyNearest.Text = String.Empty;
            this.tbxContact.Text       = String.Empty;
            this.tbxCustomerType.Text  = String.Empty;
            this.tbxNote.Text          = String.Empty;
            this.tbxSaleName.Text      = String.Empty;
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
        /// Gets a value indicating whether the Search textbox has input focus.
        /// </summary>
        /// <returns>True if Search textbox has input focus, False otherwise</returns>
        public bool IsSearchTextBoxFocused()
        {
            return this.tbxSearchCustomer.Focused;
        }
        /// <summary>
        /// Gets a value indicating whether the Street combobox has input focus.
        /// </summary>
        /// <returns>True if Street combobox has input focus, False otherwise</returns>
        public bool IsStreetComboBoxFocused()
        {
            return this.cbxStreet.Focused;
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
                        Id     = customer.Id,
                        Name   = customer.Name,
                        Detail = customer.Address
                    });
                }
                SelectorView selectorView = new SelectorView();
                selectorView.ListData = listSelector;
                selectorView.Text = Properties.Resources.SelectorTitleCustomer;
                selectorView.ShowDialog();
                string selectedId = selectorView.SelectedId;
                if (!string.IsNullOrEmpty(selectedId))
                {
                    foreach (CustomerModel customer in listResult)
                    {
                        if (selectedId.Equals(customer.Id))
                        {
                            // Update data
                            this.data.Id            = customer.Id;
                            this.data.Name          = customer.Name;
                            this.data.Address       = customer.Address;
                            this.data.PhoneList     = customer.PhoneList;
                            this.data.AgencyName    = customer.AgencyName;
                            this.data.AgencyNearest = customer.AgencyNearest;
                            this.data.Contact       = customer.Contact;
                            this.data.CustomerType  = customer.CustomerType;
                            this.data.Contact_note += customer.Contact_note;
                            this.data.Sale_name     = customer.Sale_name;
                            this.data.Sale_phone    = customer.Sale_phone;
                            this.data.Sale_type     = customer.Sale_type;

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
                    this.SaveNote();
                }
            }
        }
        /// <summary>
        ///  Check can change tab.
        /// </summary>
        /// <returns>True if can change tab, False otherwise</returns>
        public bool CanChangeTab()
        {
            return !this.tbxSearchCustomer.Focused && !this.tbxNote.Focused;
        }
        /// <summary>
        /// Set data for channel.
        /// </summary>
        /// <param name="customer">Customer information</param>
        public void SetChannelInformation(CustomerModel customer)
        {
            //this.data.Id            = customer.Id;
            //this.data.Name          = customer.Name;
            //this.data.Address       = customer.Address;
            //this.data.PhoneList     = customer.PhoneList;
            //this.data.AgencyName    = customer.AgencyName;
            //this.data.AgencyNearest = customer.AgencyNearest;
            //this.data.Contact       = customer.Contact;
            //this.data.CustomerType  = customer.CustomerType;
            //this.data.Contact_note += customer.Contact_note;
            //this.data.Sale_name     = customer.Sale_name;
            //this.data.Sale_phone    = customer.Sale_phone;
            //this.data.Sale_type     = customer.Sale_type;
            this.data = customer;

            this.SetCustomerName(this.data.Name);
            this.SetAddress(this.data.Address);
            this.SetPhoneList(this.data.PhoneList);
            this.SetAgency(this.data.AgencyName);
            this.SetAgencyNearest(this.data.AgencyNearest);
            this.SetContact(this.data.Contact);
            this.SetCustomerType(this.data.CustomerType);
            this.SetNote(this.data.Contact_note);
            this.SetSaleInfor(this.data.Sale_name, this.data.Sale_phone);
        }
        /// <summary>
        /// Handle when change city.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void cbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DataPure.Instance.TempData != null)
                && (DataPure.Instance.TempData.List_province != null))
            {
                foreach (CityModel item in DataPure.Instance.TempData.List_province)
                {
                    if (cbxCity.SelectedValue.ToString().Equals(item.Id))
                    {
                        if (item.Data != null)
                        {
                            List<object> items = new List<object>();
                            items.Add(new { Text = string.Empty, Value = string.Empty });
                            foreach (DistrictModel district in item.Data)
                            {
                                items.Add(new { Text = district.Name, Value = district.Id });
                            }
                            cbxDistrict.DataSource = items;
                        }

                        break;
                    }
                }
            }
            if (cbxDistrict.Items.Count > 0)
            {
                cbxDistrict.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Get customer information to create new.
        /// </summary>
        /// <returns>
        /// List of data:
        /// - Customer name
        /// - Detail address
        /// - City Id
        /// - District Id
        /// - Ward Id
        /// - Street Id
        /// </returns>
        public List<String> GetNewCustomerInfo()
        {
            List<String> retVal = new List<string>();
            retVal.Add(tbxCustomerName.Text.Trim());
            string defaultVal = "0";
            if (cbxCity.SelectedValue != null)
            {
                retVal.Add(cbxCity.SelectedValue.ToString());
            }
            else
            {
                retVal.Add(defaultVal);
            }
            if (cbxDistrict.SelectedValue != null)
            {
                retVal.Add(cbxDistrict.SelectedValue.ToString());
            }
            else
            {
                retVal.Add(defaultVal);
            }
            if (cbxWard.SelectedValue != null)
            {
                retVal.Add(cbxWard.SelectedValue.ToString());
            }
            else
            {
                retVal.Add(defaultVal);
            }
            if (cbxStreet.SelectedValue != null)
            {
                retVal.Add(cbxStreet.SelectedValue.ToString());
            }
            else
            {
                retVal.Add(defaultVal);
            }
            retVal.Add(tbxAddress.Text.Trim());
            return retVal;
        }

        /// <summary>
        /// Handle when change district.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void cbxDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DataPure.Instance.TempData != null)
                && (DataPure.Instance.TempData.List_province != null))
            {
                foreach (CityModel item in DataPure.Instance.TempData.List_province)
                {
                    if (cbxCity.SelectedValue.ToString().Equals(item.Id))
                    {
                        if (item.Data != null)
                        {
                            foreach (DistrictModel district in item.Data)
                            {
                                if (cbxDistrict.SelectedValue.ToString().Equals(district.Id))
                                {
                                    if (district.Data != null)
                                    {
                                        List<object> items = new List<object>();
                                        items.Add(new { Text = string.Empty, Value = string.Empty });
                                        foreach (WardModel ward in district.Data)
                                        {
                                            items.Add(new { Text = ward.Name, Value = ward.Id });
                                        }
                                        cbxWard.DataSource = items;
                                    }
                                    break;
                                }
                            }
                        }

                        break;
                    }
                }
            }
            if (cbxWard.Items.Count > 0)
            {
                cbxWard.SelectedIndex = 0;
            }
        }
    }
}
