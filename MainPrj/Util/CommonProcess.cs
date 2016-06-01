using MainPrj.Model;
using MainPrj.View;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace MainPrj.Util
{
    /// <summary>
    /// Common process class.
    /// </summary>
    public static class CommonProcess
    {
        private static List<string> AVATAR_BACKCOLOR = new List<string>
        {
            "3C79B2", "FF8F88", "6FB9FF", "C0CC44", "AFB28C" 
        };
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
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CustomerResponseModel));
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
                        CustomerResponseModel baseResp = (CustomerResponseModel)js.ReadObject(msU);
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
        /// Request logout
        /// </summary>
        public static void RequestLogout()
        {
            UserLoginResponseModel data = new UserLoginResponseModel();
            using (WebClient client = new WebClient())
            {
                string respStr = String.Empty;
                try
                {
                    // Post keyword to server
                    string value = string.Empty;
                    value = String.Format("{{\"token\":\"{0}\"}}", Properties.Settings.Default.UserToken);
                    byte[] response = client.UploadValues(
                        Properties.Settings.Default.ServerURL + Properties.Settings.Default.URLLogout,
                        new System.Collections.Specialized.NameValueCollection()
                    {
                        { "q", value}
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
                        if (baseResp != null)
                        {
                            
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Request login
        /// </summary>
        /// <param name="url">Server url</param>
        /// <param name="username">Username</param>
        /// <param name="password">password</param>
        /// <returns>UserLoginResponseModel</returns>
        public static UserLoginResponseModel RequestLogin(string username, string password)
        {
            // Declare result variable
            UserLoginResponseModel data = new UserLoginResponseModel();
            using (WebClient client = new WebClient())
            {
                string respStr = String.Empty;
                try
                {
                    // Post keyword to server
                    string value = string.Empty;
                    value = String.Format("{{\"username\":\"{0}\",\"password\":\"{1}\",\"gcm_device_token\":\"{2}\",\"apns_device_token\":\"{3}\",\"type\":\"2\"}}",
                        username, password, "1", "1");
                    byte[] response = client.UploadValues(
                        Properties.Settings.Default.ServerURL + Properties.Settings.Default.URLLogin,
                        new System.Collections.Specialized.NameValueCollection()
                    {
                        { "q", value}
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
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(UserLoginResponseModel));
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
                        UserLoginResponseModel baseResp = (UserLoginResponseModel)js.ReadObject(msU);
                        if (baseResp != null)
                        {
                            data = baseResp;
                        }
                        if (!String.IsNullOrEmpty(baseResp.Token))
                        {
                            Properties.Settings.Default.UserToken = baseResp.Token;
                            Properties.Settings.Default.Save();
                        }
                    }
                }
            }
            return data;
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
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern int PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
        /// <summary>
        /// Show error message box.
        /// </summary>
        /// <param name="msg">Message content</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowErrorMessage(string msg)
        {
            System.Timers.Timer timer = new System.Timers.Timer(Properties.Settings.Default.TimeAutoCloseMsgBox)
            {
                AutoReset = false
            };
            timer.Elapsed += delegate(object param0, ElapsedEventArgs param1)
            {
                IntPtr hWnd = CommonProcess.FindWindowByCaption(IntPtr.Zero, Properties.Resources.Error);
                if (hWnd.ToInt32() != 0)
                {
                    CommonProcess.PostMessage(hWnd, 16u, 0, 0);
                }
            };
            timer.Enabled = true;
            return MessageBox.Show(msg, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Show inform message box.
        /// </summary>
        /// <param name="msg">Message content</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowInformMessage(string msg)
        {
            return MessageBox.Show(msg, Properties.Resources.Inform, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// Show inform message box.
        /// </summary>
        /// <param name="msg">Message content</param>
        /// <param name="buttons"></param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowInformMessage(string msg, MessageBoxButtons buttons)
        {
            return MessageBox.Show(msg, Properties.Resources.Inform, buttons, MessageBoxIcon.Warning);
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
        public static string GetRoleString(RoleType type)
        {
            string retVal = string.Empty;
            switch (type)
            {
                case RoleType.ROLE_MANAGER:
                    retVal = "Quản lý";
                    break;
                case RoleType.ROLE_ADMIN:
                    retVal = "Quản lý";
                    break;
                case RoleType.ROLE_SALE:
                    retVal = "Bán hàng";
                    break;
                case RoleType.ROLE_CUSTOMER:
                    retVal = "Khách hàng";
                    break;
                case RoleType.ROLE_AGENT:
                    retVal = "Đại lý";
                    break;
                case RoleType.ROLE_MEMBER:
                    retVal = "Thành viên";
                    break;
                case RoleType.ROLE_EMPLOYEE_MAINTAIN:
                    retVal = "Giao nhận";
                    break;
                case RoleType.ROLE_CHECK_MAINTAIN:
                    break;
                case RoleType.ROLE_ACCOUNTING_AGENT:
                    retVal = "Kế Toán Bán Hàng";
                    break;
                case RoleType.ROLE_ACCOUNTING_AGENT_PRIMARY:
                    retVal = "Kế Toán Đại Lý";
                    break;
                case RoleType.ROLE_ACCOUNTING_ZONE:
                    retVal = "Kế Toán Khu Vực";
                    break;
                case RoleType.ROLE_MONITORING:
                    break;
                case RoleType.ROLE_MONITORING_MAINTAIN:
                    break;
                case RoleType.ROLE_MONITORING_MARKET_DEVELOPMENT:
                    retVal = "Chuyên Viên CCS";
                    break;
                case RoleType.ROLE_EMPLOYEE_MARKET_DEVELOPMENT:
                    break;
                case RoleType.ROLE_MONITORING_STORE_CARD:
                    break;
                case RoleType.ROLE_DIEU_PHOI:
                    retVal = "Điều Phối";
                    break;
                case RoleType.ROLE_SCHEDULE_CAR:
                    break;
                case RoleType.ROLE_DIRECTOR:
                    break;
                case RoleType.ROLE_SUB_USER_AGENT:
                    break;
                case RoleType.ROLE_DRIVER:
                    break;
                case RoleType.ROLE_ACCOUNT_RECEIVABLE:
                    break;
                case RoleType.ROLE_HEAD_GAS_BO:
                    break;
                case RoleType.ROLE_HEAD_GAS_MOI:
                    break;
                case RoleType.ROLE_DIRECTOR_BUSSINESS:
                    break;
                case RoleType.ROLE_RECEPTION:
                    break;
                case RoleType.ROLE_CHIEF_ACCOUNTANT:
                    break;
                case RoleType.ROLE_CHIEF_MONITOR:
                    break;
                case RoleType.ROLE_MONITOR_AGENT:
                    break;
                case RoleType.ROLE_SECRETARY_OF_THE_MEETING:
                    break;
                case RoleType.ROLE_HEAD_OF_LEGAL:
                    break;
                case RoleType.ROLE_EMPLOYEE_OF_LEGAL:
                    break;
                case RoleType.ROLE_ACCOUNTING:
                    break;
                case RoleType.ROLE_DEBT_COLLECTION:
                    break;
                case RoleType.ROLE_HEAD_TECHNICAL:
                    break;
                case RoleType.ROLE_HEAD_OF_MAINTAIN:
                    break;
                case RoleType.ROLE_E_MAINTAIN:
                    break;
                case RoleType.ROLE_SECURITY_SYSTEM:
                    break;
                case RoleType.ROLE_BUSINESS_PROJECT:
                    break;
                case RoleType.ROLE_HEAD_OF_BUSINESS:
                    break;
                case RoleType.ROLE_WORKER:
                    break;
                case RoleType.ROLE_SECURITY:
                    break;
                case RoleType.ROLE_MANAGING_DIRECTOR:
                    break;
                case RoleType.ROLE_CRAFT_WAREHOUSE:
                    break;
                case RoleType.ROLE_HEAD_GAS_FAMILY:
                    break;
                case RoleType.ROLE_TEST_CALL_CENTER:
                    break;
                case RoleType.ROLE_CHIET_NAP:
                    break;
                case RoleType.ROLE_PHU_XE:
                    break;
                case RoleType.ROLE_SUB_DIRECTOR:
                    break;
                case RoleType.ROLE_ITEMS:
                    break;
                case RoleType.ROLE_CASHIER:
                    break;
                case RoleType.ROLE_MECHANIC:
                    break;
                case RoleType.ROLE_TECHNICAL:
                    break;
                case RoleType.ROLE_AUDIT:
                    break;
                case RoleType.ROLE_SALE_ADMIN:
                    break;
                case RoleType.ROLE_IT:
                    break;
                case RoleType.ROLE_IT_EMPLOYEE:
                    break;
                case RoleType.ROLE_BRANCH_DIRECTOR:
                    break;
                case RoleType.ROLE_CLEANER:
                    break;
                case RoleType.ROLE_MANAGER_DRIVER:
                    break;
                case RoleType.ROLETYPE_NUM:
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
        /// <summary>
        /// Set data to channel tab.
        /// </summary>
        /// <param name="channel">Channel control</param>
        /// <param name="customer">Customer information</param>
        public static void SetChannelInformation(ChannelControl channel, CustomerModel customer)
        {
            if ((channel != null) && (customer != null))
            {
                channel.ClearData();
                channel.SetCustomerName(customer.Name);
                channel.SetAddress(customer.Address);
                channel.SetPhoneList(customer.PhoneList);
                channel.SetAgency(customer.AgencyName);
                channel.SetAgencyNearest(customer.AgencyNearest);
                channel.SetContact(customer.Contact);
                channel.SetCustomerType(customer.CustomerType);
                channel.SetNote(customer.Contact_note);
                channel.SetSaleInfor(customer.Sale_name, customer.Sale_phone);
                channel.Data = customer;
            }
        }
        /// <summary>
        /// Check if phone is valid
        /// </summary>
        /// <param name="phone">Phone string to check</param>
        /// <returns>True if phone is valid, False otherwise</returns>
        public static bool IsValidPhone(string phone)
        {
            return IsValidNumber(phone);
        }
        /// <summary>
        /// Check if string is valid number
        /// </summary>
        /// <param name="str">String to check</param>
        /// <returns>True if string is valid number, False otherwise</returns>
        public static bool IsValidNumber(string str)
        {
            bool result = false;
            int num;
            if (!string.IsNullOrEmpty(str) && int.TryParse(str, out num))
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// Update customer phone
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <param name="phone">Phone to update</param>
        public static void UpdateCustomerPhone(string customerId, string phone)
        {
            if (Properties.Settings.Default.UpdatePhone)
            {
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        byte[] bytes = webClient.UploadValues(Properties.Settings.Default.ServerURL
                            + Properties.Settings.Default.URLUpdateCustomerPhone, new NameValueCollection
					{
						{
							Properties.Settings.Default.CustomerIdKey,
							customerId
						},
						{
							Properties.Settings.Default.PhoneKey,
							phone
						}
					});
                    }
                    catch (WebException)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.InternetConnectionError);
                        CommonProcess.HasError = true;
                    }
                }
            }
        }
        /// <summary>
        /// Vietnamese strings sign.
        /// </summary>
        private static readonly string[] UnicodeSigns = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };
        /// <summary>
        /// Remove sign for Vietnamese string.
        /// </summary>
        /// <param name="str">String to format</param>
        /// <returns>String after format</returns>
        public static string NormalizationString(string str)
        {
            for (int i = 1; i < UnicodeSigns.Length; i++)
            {
                for (int j = 0; j < UnicodeSigns[i].Length; j++)
                {
                    str = str.Replace(UnicodeSigns[i][j], UnicodeSigns[0][i - 1]);
                }
            }
            return str;
        }
        /// <summary>
        /// Create avatar.
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="size">size of avatar</param>
        /// <returns>Bitmap object</returns>
        public static Bitmap CreateAvatar(string text, int size)
        {
            Bitmap retVal = new Bitmap(size, size);
            if (AVATAR_BACKCOLOR.Count == 0)
            {
                return retVal;
            }
            var randomIdx = new Random().Next(0, AVATAR_BACKCOLOR.Count - 1);
            var bgColor = AVATAR_BACKCOLOR[randomIdx];
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            var font = new Font("Calibri", 24, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(retVal);

            graphics.Clear((Color)new ColorConverter().ConvertFromString("#" + bgColor));
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.DrawString(text, font, new SolidBrush(Color.WhiteSmoke),
                new RectangleF(0, 0, size, size), sf);
            graphics.Flush();
            return retVal;
        }
    }
}
