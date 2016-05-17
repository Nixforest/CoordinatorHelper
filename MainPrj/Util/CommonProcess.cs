using MainPrj.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.Util
{
    /// <summary>
    /// Common process class.
    /// </summary>
    public static class CommonProcess
    {
        /// <summary>
        /// Flag check if has error in processing.
        /// </summary>
        public static bool HasError = false;

        /// <summary>
        /// Request customer information from server by phone number.
        /// </summary>
        /// <param name="phone">Phone number value</param>
        /// <returns>List of customer</returns>
        public static List<CustomerModel> RequestCustomerByPhone(string phone)
        {
            return RequestCustomer(Properties.Settings.Default.URLGetCustomerByPhone, phone);
        }
        /// <summary>
        /// Request customer information from server by keyword.
        /// </summary>
        /// <param name="keyword">Keyword value</param>
        /// <returns>List of customer</returns>
        public static List<CustomerModel> RequestCustomerByKeyword(string keyword)
        {
            return RequestCustomer(Properties.Settings.Default.URLGetCustomerByKeyword, keyword);
        }

        /// <summary>
        /// Request customer information from server by keyword.
        /// </summary>
        /// <param name="url">Request url</param>
        /// <param name="keyword">Keyword value</param>
        /// <returns>List of customer</returns>
        public static List<CustomerModel> RequestCustomer(string url, string keyword)
        {
            // Declare result variable
            List<CustomerModel> result = new List<CustomerModel>();
            using (WebClient client = new WebClient())
            {
                string respStr = String.Empty;
                try
                {
                    // Post keyword to server
                    byte[] response = client.UploadValues(
                        Properties.Settings.Default.ServerURL + url,
                        new System.Collections.Specialized.NameValueCollection()
                    {
                        { Properties.Settings.Default.PhoneKey, keyword }
                    });
                    // Get response
                    respStr = System.Text.Encoding.UTF8.GetString(response);
                }
                catch (System.Net.WebException)
                {
                    ShowErrorMessage(Properties.Resources.InternetConnectionError);
                    HasError = true;
                }

                if (!String.IsNullOrEmpty(respStr))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(BaseResponseModel));
                    byte[] encodingBytes = null;
                    try
                    {
                        // Encoding response data
                        //encodingBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(respStr);
                        encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(respStr);
                    }
                    catch (System.Text.EncoderFallbackException)
                    {
                        ShowErrorMessage(Properties.Resources.EncodingError);
                        HasError = true;
                    }
                    if (encodingBytes != null)
                    {
                        MemoryStream msU = new MemoryStream(encodingBytes);
                        BaseResponseModel baseResp = (BaseResponseModel)js.ReadObject(msU);
                        if (baseResp.Record != null)
                        {
                            foreach (CustomerModel item in baseResp.Record)
                            {
                                result.Add(item);
                            }
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Show error message box.
        /// </summary>
        /// <param name="msg">Message content</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowErrorMessage(string msg)
        {
            return MessageBox.Show(msg, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Show inform message box.
        /// </summary>
        /// <param name="msg">Message content</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowInformMessage(string msg)
        {
            return MessageBox.Show(msg, Properties.Resources.Inform, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Show inform message box.
        /// </summary>
        /// <param name="msg">Message content</param>
        /// <param name="buttons"></param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowInformMessage(string msg, MessageBoxButtons buttons)
        {
            return MessageBox.Show(msg, Properties.Resources.Inform, buttons, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Show message box inform about function processing.
        /// </summary>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowInformMessageProcessing()
        {
            return MessageBox.Show(Properties.Resources.FunctionProcessing, Properties.Resources.Inform,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
