using MainPrj.Model;
using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
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
        /// <summary>
        /// Handle create new customer.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(channelControl.Data.Name))
            {
                List<String> customerInfo = channelControl.GetNewCustomerInfo();
                CommonProcess.RequestCreateNewCustomer(customerInfo[0],
                    channelControl.GetIncommingPhone(),
                    customerInfo[1],
                    customerInfo[2],
                    customerInfo[3],
                    customerInfo[4],
                    customerInfo[5],
                    createCustomerProgressChanged,
                    createCustomerCompleted);
            }
        }
        // 
        private void createCustomerCompleted(object sender, System.Net.UploadValuesCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + "Hủy";
            }
            else if (e.Error != null)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + e.Error.Message;
            }
            else
            {
                byte[] response = e.Result;
                string respStr = String.Empty;
                respStr = System.Text.Encoding.UTF8.GetString(response);
                // Response string is not null
                if (!String.IsNullOrEmpty(respStr))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CustomerResponseModel));
                    byte[] encodingBytes = null;
                    try
                    {
                        // Encoding response data
                        encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(respStr);
                    }
                    catch (System.Text.EncoderFallbackException)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.EncodingError);
                    }
                    if (encodingBytes != null)
                    {
                        MemoryStream msU = new MemoryStream(encodingBytes);
                        CustomerResponseModel baseResp = (CustomerResponseModel)js.ReadObject(msU);
                        // Check status
                        if ((baseResp != null)
                            && (baseResp.Status.Equals("1")))
                        {
                            // Create customer is success.
                            toolStripStatusLabel.Text = Properties.Resources.CreateCustomerSuccess;
                            CommonProcess.ShowInformMessage(Properties.Resources.CreateCustomerSuccess,
                                MessageBoxButtons.OK);
                            if (baseResp.Record != null)
                            {
                                baseResp.Record[0].ActivePhone = channelControl.GetIncommingPhone();
                                CommonProcess.SetChannelInformation(channelControl, baseResp.Record[0]);
                            }
                        }
                        else
                        {
                            // Create customer is failed.
                            CommonProcess.ShowInformMessage(Properties.Resources.CreateCustomerFailed,
                                MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Handle when creating customer.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        private void createCustomerProgressChanged(object sender, System.Net.UploadProgressChangedEventArgs e)
        {
            //if ((e.ProgressPercentage <= 50)
            //    && (e.ProgressPercentage >= 0))
            //{
            //    toolStripProgressBar.Value = e.ProgressPercentage * 2;
            //}
            //toolStripStatusLabel.Text = Properties.Resources.RequestingCreateCustomer;
            CommonProcess.UpdateProgress(e, Properties.Resources.RequestingCreateCustomer,
                toolStripProgressBar, toolStripStatusLabel);
        }
        /// <summary>
        /// Handle when load form
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void CustomerView_Load(object sender, EventArgs e)
        {
            btnCreateCustomer.Enabled = DataPure.Instance.IsAccountingAgentRole();
            //string city = this.channelControl.GetCity();
            //string street = this.channelControl.GetStreet();
            //this.channelControl.SetCity(DataPure.Instance.TempData.List_province);
            //this.channelControl.SetCity(city);
            //this.channelControl.SetStreet(DataPure.Instance.TempData.List_street);
            //this.channelControl.SetStreet(street);
        }
    }
}
