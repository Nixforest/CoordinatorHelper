using MainPrj.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
            return RequestCustomer(Properties.Settings.Default.URLGetCustomerByPhone, Properties.Settings.Default.PhoneKey, phone);
        }
        /// <summary>
        /// Request customer information from server by keyword.
        /// </summary>
        /// <param name="keyword">Keyword value</param>
        /// <returns>List of customer</returns>
        public static List<CustomerModel> RequestCustomerByKeyword(string keyword)
        {
            return RequestCustomer(Properties.Settings.Default.URLGetCustomerByKeyword, Properties.Settings.Default.KeywordKey, keyword);
        }

        /// <summary>
        /// Request customer information from server by keyword.
        /// </summary>
        /// <param name="url">Request url</param>
        /// <param name="keyword">Keyword value</param>
        /// <returns>List of customer</returns>
        public static List<CustomerModel> RequestCustomer(string url, string key, string keyword)
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
                        { key, keyword }
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
        /// Get local IP address.
        /// </summary>
        /// <returns>IP Address</returns>
        public static string GetLocalIPAddress()
        {
            // Check network is available
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return Properties.Resources.InternetConnectionError;
            }
            string hostName = String.Empty;                                 // Host name
            try
            {
                hostName = Dns.GetHostName();                               // Get computer host name
            }
            catch (SocketException)
            {
                ShowErrorMessage(Properties.Resources.SocketException);
                return String.Empty;
            }
            if (!String.IsNullOrEmpty(hostName))                            // Host name is valid
            {
                try
                {
                    IPAddress[] host = Dns.GetHostAddresses(hostName);      // Get IP Addresses
                    foreach (IPAddress item in host)
                    {
                        if (item.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return item.ToString();
                        }
                    }
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    ShowErrorMessage(Properties.Resources.ErrorLengthOfHostName);
                    return String.Empty;
                }
                catch (SocketException)
                {
                    ShowErrorMessage(Properties.Resources.SocketException);
                    return String.Empty;
                }
                catch (ArgumentException)
                {
                    ShowErrorMessage(Properties.Resources.ErrorIPAddressInvalid);
                    return String.Empty;
                }
            }
            return String.Empty;
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
        /// <summary>
        /// Get status string from status id.
        /// </summary>
        /// <param name="status">Status id</param>
        /// <returns>
        /// 0: Gọi đến
        /// 1: Gọi đi
        /// 2: Đang xử lý
        /// 3: Xong
        /// 4: Nhỡ
        /// 5: Xong
        /// </returns>
        public static string GetStatusString(int status)
        {
            string retVal = String.Empty;
            switch (status)
            {
                case (int)CardDataStatus.CARDDATA_RINGING:
                    retVal = Properties.Resources.CardDataStatus1;
                    break;
                case (int)CardDataStatus.CARDDATA_CALLING:
                    retVal = Properties.Resources.CardDataStatus2;
                    break;
                case (int)CardDataStatus.CARDDATA_HANDLING:
                    retVal = Properties.Resources.CardDataStatus3;
                    break;
                case (int)CardDataStatus.CARDDATA_HANGUP:
                    retVal = Properties.Resources.CardDataStatus4;
                    break;
                case (int)CardDataStatus.CARDDATA_MISS:
                    retVal = Properties.Resources.CardDataStatus5;
                    break;
                case (int)CardDataStatus.CARDDATA_RECORD:
                    retVal = Properties.Resources.CardDataStatus6;
                    break;
                default:
                    break;
            }
            return retVal;
        }
        /// <summary>
        /// Get call type string.
        /// </summary>
        /// <param name="type">Type of call</param>
        /// <returns>Đặt hàng ngay/Đặt hàng sau/Bảo trì</returns>
        public static string GetCallTypeString(CallType type)
        {
            string retVal = String.Empty;
            switch (type)
            {
                case CallType.CALLTYPE_ORDER:
                    retVal = Properties.Resources.CallType1;
                    break;
                case CallType.CALLTYPE_ORDER_SAVE:
                    retVal = Properties.Resources.CallType2;
                    break;
                case CallType.CALLTYPE_UPHOLD:
                    retVal = Properties.Resources.CallType3;
                    break;
                default:
                    break;
            }
            return retVal;
        }
        /// <summary>
        /// Handle write file.
        /// </summary>
        /// <param name="listData">List of data</param>
        public static void WriteHistory(List<CallModel> listData)
        {
            if (listData.Count > 0)
            {
                string date = listData[0].Id.Substring(0, 8);
                string filepath = String.Format("{0}\\{1}_{2}", Properties.Settings.Default.HistoryFilePath,
                    date, Properties.Settings.Default.HistoryFileName);

                try
                {
                    using (StreamWriter sw = new StreamWriter(File.Open(filepath, System.IO.FileMode.Append)))
                    {
                        // Write file
                        foreach (CallModel item in listData)
                        {
                            sw.WriteLine(item.ToString());
                        }
                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                }
                
            }
        }
    }
}
