using MainPrj.Model;
using MainPrj.Model.Update;
using MainPrj.View;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
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
        /// <summary>
        /// Material color.
        /// </summary>
        public static Dictionary<string, Color> MATERIAL_COLOR = new Dictionary<string, Color>()
        {
            { "xám", Color.Gray },
            { "đỏ", Color.Red },
            { "xanh", Color.Blue },
            { "vàng", Color.YellowGreen },
            { "ngọc", Color.Purple },
            { "cam", Color.Orange },
            { "đậm", Color.PaleGreen },
        };
        /// <summary>
        /// Background color for avatar image.
        /// </summary>
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
                    string type = "1";
                    if (DataPure.Instance.User != null)
                    {
                        if (DataPure.Instance.IsAccountingAgentRole())
                        {
                            type = "2";
                        }
                    }
                    // Post keyword to server
                    byte[] response = client.UploadValues(
                        Properties.Settings.Default.ServerURL + url,
                        new System.Collections.Specialized.NameValueCollection()
                    {
                        { key, keyword },
                        { "window_customer_type", type }
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
        /// Request login.
        /// </summary>
        /// <param name="url">Server url</param>
        /// <param name="username">Username</param>
        /// <param name="password">password</param>
        /// <param name="progressChanged">Event handler when progress changed</param>
        /// <param name="completedHandler">Event handler when finish upload</param>
        /// <returns>UserLoginResponseModel</returns>
        public static UserLoginResponseModel RequestLogin(string username, string password,
            UploadProgressChangedEventHandler progressChanged, UploadValuesCompletedEventHandler completedHandler)
        {
            // Declare result variable
            UserLoginResponseModel data = new UserLoginResponseModel();
            using (WebClient client = new WebClient())
            {
                client.UploadProgressChanged += new UploadProgressChangedEventHandler(progressChanged);
                client.UploadValuesCompleted += new UploadValuesCompletedEventHandler(completedHandler);
                string respStr = String.Empty;
                try
                {
                    // Post keyword to server
                    string value = string.Empty;
                    value = String.Format("{{\"username\":\"{0}\",\"password\":\"{1}\",\"gcm_device_token\":\"{2}\",\"apns_device_token\":\"{3}\",\"type\":\"2\"}}",
                        username, password, "1", "1");
                    client.UploadValuesAsync(
                        new Uri(Properties.Settings.Default.ServerURL + Properties.Settings.Default.URLLogin),
                        new System.Collections.Specialized.NameValueCollection()
                    {
                        { "q", value}
                    });
                    // Get response
                    //respStr = System.Text.Encoding.UTF8.GetString(response);
                }
                catch (System.Net.WebException)
                {
                    ShowErrorMessage(Properties.Resources.InternetConnectionError);
                    HasError = true;
                }
            }
            return data;
        }
        /// <summary>
        /// Request temp data.
        /// </summary>
        /// <param name="progressChanged">Event handler when progress changed</param>
        /// <param name="completedHandler">Event handler when finish upload</param>
        /// <param name="isNotFirstTime"></param>
        public static void RequestTempData(UploadProgressChangedEventHandler progressChanged,
            UploadValuesCompletedEventHandler completedHandler)
        {
            // Declare result variable
            using (WebClient client = new WebClient())
            {
                client.UploadProgressChanged += new UploadProgressChangedEventHandler(progressChanged);
                client.UploadValuesCompleted += new UploadValuesCompletedEventHandler(completedHandler);
                string respStr = String.Empty;
                try
                {
                    // Post keyword to server
                    string value = string.Empty;
                    value = String.Format("{{\"token\":\"{0}\"}}",
                        Properties.Settings.Default.UserToken);
                    client.UploadValuesAsync(
                        new Uri(Properties.Settings.Default.ServerURL + Properties.Settings.Default.URLGetConfig),
                        new System.Collections.Specialized.NameValueCollection()
                    {
                        { "q", value}
                    });
                    // Get response
                    //respStr = System.Text.Encoding.UTF8.GetString(response);
                }
                catch (System.Net.WebException)
                {
                    ShowErrorMessage(Properties.Resources.InternetConnectionError);
                    HasError = true;
                }
            }
        }
        /// <summary>
        /// Request create new customer.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="phone">Phone</param>
        /// <param name="cityId">Id of city</param>
        /// <param name="districtId">Id of district</param>
        /// <param name="wardId">Id of ward</param>
        /// <param name="streetId">Id of street</param>
        /// <param name="addressDetail">Detail of address</param>
        /// <param name="progressChanged">Event handler when progress changed</param>
        /// <param name="completedHandler">Event handler when finish upload</param>
        public static void RequestCreateNewCustomer(string name, string phone, string cityId, string districtId,
            string wardId, string streetId, string addressDetail, UploadProgressChangedEventHandler progressChanged,
            UploadValuesCompletedEventHandler completedHandler)
        {
            using (WebClient client = new WebClient())
            {
                client.UploadProgressChanged += new UploadProgressChangedEventHandler(progressChanged);
                client.UploadValuesCompleted += new UploadValuesCompletedEventHandler(completedHandler);
                try
                {
                    // Post keyword to server
                    string value = string.Empty;
                    value = String.Format("{{\"token\":\"{0}\", \"agent_id\":\"{1}\", \"first_name\":\"{2}\", \"phone\":\"{3}\", \"province_id\":\"{4}\", \"district_id\":\"{5}\", \"ward_id\":\"{6}\", \"street_id\":\"{7}\", \"house_numbers\":\"{8}\"}}",
                        Properties.Settings.Default.UserToken,
                        DataPure.Instance.Agent.Id,
                        name, phone, cityId, districtId, wardId, streetId, addressDetail);
                    client.UploadValuesAsync(
                        new Uri(Properties.Settings.Default.ServerURL + Properties.Settings.Default.URLCreateCustomer),
                        new System.Collections.Specialized.NameValueCollection()
                    {
                        { "q", value}
                    });
                }
                catch (System.Net.WebException)
                {
                    ShowErrorMessage(Properties.Resources.InternetConnectionError);
                    HasError = true;
                }
            }
        }
        /// <summary>
        /// Request agent information from server.
        /// </summary>
        /// <param name="agentId">Agent Id</param>
        public static void RequestAgentInformation(string agentId)
        {
            using (WebClient client = new WebClient())
            {
                string respStr = String.Empty;
                try
                {
                    // Post keyword to server
                    string value = string.Empty;
                    value = String.Format("{{\"token\":\"{0}\",\"agent_id\":\"{1}\"}}",
                        Properties.Settings.Default.UserToken,
                        agentId);
                    byte[] response = client.UploadValues(
                        Properties.Settings.Default.ServerURL + Properties.Settings.Default.URLGetAgentInfo,
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
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(TempDataResponseModel));
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
                        TempDataResponseModel baseResp = (TempDataResponseModel)js.ReadObject(msU);
                        if ((baseResp != null)
                            && (baseResp.Record != null))
                        {
                            DataPure.Instance.TempData.Employee_maintain = baseResp.Record.Employee_maintain;
                            DataPure.Instance.TempData.Agent_phone       = baseResp.Record.Agent_phone;
                            DataPure.Instance.TempData.Agent_address     = baseResp.Record.Agent_address;
                            DataPure.Instance.TempData.Agent_province    = baseResp.Record.Agent_province;
                            DataPure.Instance.TempData.Agent_district    = baseResp.Record.Agent_district;
                        }
                    }
                }
            }
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
                    if (host != null)
                    {
                        foreach (IPAddress item in host)
                        {
                            if (item.AddressFamily == AddressFamily.InterNetwork)
                            {
                                return item.ToString();
                            }
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
        /// <summary>
        /// Get role string.
        /// </summary>
        /// <param name="type">Role type</param>
        /// <returns>Role string</returns>
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
        public static bool WriteHistory(List<CallModel> listData)
        {
            if ((listData != null) && (listData.Count > 0))
            {
                string date = listData[0].Id.Substring(0, 8);
                string filepath = String.Format("{0}\\{1}_{2}", Properties.Settings.Default.SettingFilePath,
                    date, Properties.Settings.Default.HistoryFileName);

                try
                {
                    using (StreamWriter sw = new StreamWriter(File.Open(filepath, System.IO.FileMode.Create)))
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
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Read history.
        /// </summary>
        public static void ReadHistory()
        {
            string date = System.DateTime.Now.ToString(Properties.Settings.Default.CallIdFormat).Substring(0, 8);

            string filepath = String.Format("{0}\\{1}_{2}", Properties.Settings.Default.SettingFilePath,
                date, Properties.Settings.Default.HistoryFileName);
            try
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CallModel));
                string line = string.Empty;
                byte[] encodingBytes = null;
                using (StreamReader sr = new StreamReader(File.Open(filepath, System.IO.FileMode.OpenOrCreate)))
                {
                    while (true)
                    {
                        line = sr.ReadLine();
                        if (!String.IsNullOrEmpty(line))
                        {
                            try
                            {
                                // Encoding response data
                                encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(line);
                            }
                            catch (System.Text.EncoderFallbackException)
                            {
                                ShowErrorMessage(Properties.Resources.EncodingError);
                                HasError = true;
                            }
                            if (encodingBytes != null)
                            {
                                MemoryStream msU = new MemoryStream(encodingBytes);
                                CallModel model = (CallModel)js.ReadObject(msU);
                                if (model != null)
                                {
                                    DataPure.Instance.ListCalls.Add(model);
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                HasError = false;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                HasError = true;
            }
        }
        public static List<CallModel> ReadHistoryByDate(DateTime dateValue)
        {
            List<CallModel> result = new List<CallModel>();
            string date = dateValue.ToString(Properties.Settings.Default.CallIdFormat).Substring(0, 8);

            string filepath = String.Format("{0}\\{1}_{2}", Properties.Settings.Default.SettingFilePath,
                date, Properties.Settings.Default.HistoryFileName);
            try
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CallModel));
                string line = string.Empty;
                byte[] encodingBytes = null;
                using (StreamReader sr = new StreamReader(File.Open(filepath, System.IO.FileMode.OpenOrCreate)))
                {
                    while (true)
                    {
                        line = sr.ReadLine();
                        if (!String.IsNullOrEmpty(line))
                        {
                            try
                            {
                                // Encoding response data
                                encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(line);
                            }
                            catch (System.Text.EncoderFallbackException)
                            {
                                ShowErrorMessage(Properties.Resources.EncodingError);
                                HasError = true;
                            }
                            if (encodingBytes != null)
                            {
                                MemoryStream msU = new MemoryStream(encodingBytes);
                                CallModel model = (CallModel)js.ReadObject(msU);
                                if (model != null)
                                {
                                    result.Add(model);
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                HasError = false;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                HasError = true;
            }
            return result;
        }
        /// <summary>
        /// Write list orders fle.
        /// </summary>
        public static bool WriteListOrders()
        {
            if (DataPure.Instance.ListOrders.Count > 0)
            {
                string date = DataPure.Instance.ListOrders[0].Id.Substring(0, 8);

                string filepath = String.Format("{0}\\{1}_{2}", Properties.Settings.Default.SettingFilePath,
                    date, Properties.Settings.Default.OrdersFileName);
                try
                {
                    using (StreamWriter sw = new StreamWriter(File.Open(filepath, System.IO.FileMode.Create)))
                    {
                        // Write file
                        foreach (OrderModel item in DataPure.Instance.ListOrders)
                        {
                            sw.WriteLine(item.ToString());
                        }
                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Read data list orders
        /// </summary>
        public static void ReadListOrders()
        {
            string date = System.DateTime.Now.ToString(Properties.Settings.Default.CallIdFormat).Substring(0, 8);

            string filepath = String.Format("{0}\\{1}_{2}", Properties.Settings.Default.SettingFilePath,
                date, Properties.Settings.Default.OrdersFileName);
            try
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(OrderModel));
                string line = string.Empty;
                byte[] encodingBytes = null;
                using (StreamReader sr = new StreamReader(File.Open(filepath, System.IO.FileMode.OpenOrCreate)))
                {
                    while (true)
                    {
                        line = sr.ReadLine();
                        if (!String.IsNullOrEmpty(line))
                        {
                            try
                            {
                                // Encoding response data
                                encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(line);
                            }
                            catch (System.Text.EncoderFallbackException)
                            {
                                ShowErrorMessage(Properties.Resources.EncodingError);
                                HasError = true;
                            }
                            if (encodingBytes != null)
                            {
                                MemoryStream msU = new MemoryStream(encodingBytes);
                                OrderModel model = (OrderModel)js.ReadObject(msU);
                                if (model != null)
                                {
                                    DataPure.Instance.ListOrders.Add(model);
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                HasError = false;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                HasError = true;
            }
        }
        /// <summary>
        /// Write setting.
        /// </summary>
        public static bool WriteSetting()
        {
            // Recent material
            if (DataPure.Instance.ListRecentProductsImg.Count > 0)
            {
                string filepath = String.Format("{0}\\{1}", Properties.Settings.Default.SettingFilePath,
                    Properties.Settings.Default.SettingProductFileName);
                try
                {
                    using (StreamWriter sw = new StreamWriter(File.Open(filepath, System.IO.FileMode.Create)))
                    {
                        // Write file
                        foreach (MaterialBitmap item in DataPure.Instance.ListRecentProductsImg.Values)
                        {
                            sw.WriteLine(item.ToString());
                        }
                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Read setting.
        /// </summary>
        public static void ReadSetting()
        {
            // Recent material
            string filepath = String.Format("{0}\\{1}", Properties.Settings.Default.SettingFilePath,
                Properties.Settings.Default.SettingProductFileName);
            try
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(MaterialBitmap));
                string line = string.Empty;
                byte[] encodingBytes = null;
                using (StreamReader sr = new StreamReader(File.Open(filepath, System.IO.FileMode.OpenOrCreate)))
                {
                    while (true)
                    {
                        line = sr.ReadLine();
                        if (!String.IsNullOrEmpty(line))
                        {
                            try
                            {
                                // Encoding response data
                                encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(line);
                            }
                            catch (System.Text.EncoderFallbackException)
                            {
                                ShowErrorMessage(Properties.Resources.EncodingError);
                                HasError = true;
                            }
                            if (encodingBytes != null)
                            {
                                MemoryStream msU = new MemoryStream(encodingBytes);
                                MaterialBitmap model = (MaterialBitmap)js.ReadObject(msU);
                                if (model != null)
                                {
                                    model.Bitmap = CreateAvatar(model.Text, Properties.Settings.Default.ImageSize,
                                        model.Color, Properties.Settings.Default.ImageFontSize);
                                    DataPure.Instance.ListRecentProductsImg.Add(model.Model.Materials_no, model);
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                HasError = false;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                HasError = true;
            }
        }
        /// <summary>
        /// Write setting.
        /// </summary>
        public static bool WriteSettingPromote()
        {
            // Recent material
            if (DataPure.Instance.ListRecentPromotesImg.Count > 0)
            {
                string filepath = String.Format("{0}\\{1}", Properties.Settings.Default.SettingFilePath,
                    Properties.Settings.Default.SettingPromoteFileName);
                try
                {
                    using (StreamWriter sw = new StreamWriter(File.Open(filepath, System.IO.FileMode.Create)))
                    {
                        // Write file
                        foreach (MaterialBitmap item in DataPure.Instance.ListRecentPromotesImg.Values)
                        {
                            sw.WriteLine(item.ToString());
                        }
                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Read setting.
        /// </summary>
        public static void ReadSettingPromote()
        {
            // Recent material
            string filepath = String.Format("{0}\\{1}", Properties.Settings.Default.SettingFilePath,
                Properties.Settings.Default.SettingPromoteFileName);
            try
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(MaterialBitmap));
                string line = string.Empty;
                byte[] encodingBytes = null;
                using (StreamReader sr = new StreamReader(File.Open(filepath, System.IO.FileMode.OpenOrCreate)))
                {
                    while (true)
                    {
                        line = sr.ReadLine();
                        if (!String.IsNullOrEmpty(line))
                        {
                            try
                            {
                                // Encoding response data
                                encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(line);
                            }
                            catch (System.Text.EncoderFallbackException)
                            {
                                ShowErrorMessage(Properties.Resources.EncodingError);
                                HasError = true;
                            }
                            if (encodingBytes != null)
                            {
                                MemoryStream msU = new MemoryStream(encodingBytes);
                                MaterialBitmap model = (MaterialBitmap)js.ReadObject(msU);
                                if (model != null)
                                {
                                    model.Bitmap = CreateAvatar(model.Text, Properties.Settings.Default.ImageSize,
                                        model.Color, Properties.Settings.Default.ImageFontSize);
                                    DataPure.Instance.ListRecentPromotesImg.Add(model.Model.Materials_no, model);
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                HasError = false;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                HasError = true;
            }
        }
        //public static void 
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
        /// Check if string is valid double.
        /// </summary>
        /// <param name="str">String to check</param>
        /// <returns>True if string is valid double, False otherwise</returns>
        public static bool IsValidDouble(string str)
        {
            bool result = false;
            double num;
            if (!string.IsNullOrEmpty(str) && double.TryParse(str, out num))
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// Update customer phone.
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
        /// Update customer to server.
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Order id</returns>
        public static string UpdateOrderToServer(OrderModel model)
        {
            string retVal = string.Empty;
            if (!String.IsNullOrEmpty(Properties.Settings.Default.UserToken))
            {
                string respStr = String.Empty;
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        UpdateOrderModel updateModel = new UpdateOrderModel();
                        // Create data
                        updateModel.Token        = Properties.Settings.Default.UserToken;
                        updateModel.Id           = model.WebId;
                        updateModel.Note         = model.Note;
                        updateModel.Status       = (int)model.Status;
                        updateModel.Order_detail = new List<OrderDetailModel>();
                        foreach (ProductModel product in model.Products)
                        {
                            OrderDetailModel orderDetail = new OrderDetailModel();
                            // Create data
                            orderDetail.Materials_id      = product.Id;
                            orderDetail.Materials_type_id = product.TypeId;
                            orderDetail.Quantity          = product.Quantity;
                            orderDetail.Price             = product.Price.ToString();
                            orderDetail.TotalPay          = (product.Price * product.Quantity).ToString();
                            orderDetail.Seri              = string.Empty;

                            // Add to list order detail
                            updateModel.Order_detail.Add(orderDetail);
                        }
                        foreach (PromoteModel promote in model.Promotes)
                        {
                            OrderDetailModel orderDetail = new OrderDetailModel();
                            // Create data
                            orderDetail.Materials_id      = promote.Id;
                            orderDetail.Materials_type_id = promote.TypeId;
                            orderDetail.Quantity          = promote.Quantity;
                            orderDetail.Price             = String.Empty;
                            orderDetail.TotalPay          = String.Empty;
                            orderDetail.Seri              = string.Empty;

                            // Add to list order detail
                            updateModel.Order_detail.Add(orderDetail);
                        }
                        foreach (CylinderModel cylinder in model.Cylinders)
                        {
                            OrderDetailModel orderDetail = new OrderDetailModel();
                            // Create data
                            orderDetail.Materials_id      = cylinder.Id;
                            orderDetail.Materials_type_id = cylinder.TypeId;
                            orderDetail.Quantity          = cylinder.Quantity;
                            orderDetail.Price             = String.Empty;
                            orderDetail.TotalPay          = String.Empty;
                            orderDetail.Seri              = cylinder.Serial;

                            // Add to list order detail
                            updateModel.Order_detail.Add(orderDetail);
                        }

                        // Post keyword to server
                        string value = string.Empty;
                        value = updateModel.ToString();
                        byte[] response = webClient.UploadValues(
                            Properties.Settings.Default.ServerURL + Properties.Settings.Default.URLUpdateOrder,
                            new System.Collections.Specialized.NameValueCollection()
                        {
                            { "q", value}
                        });
                        // Get response
                        respStr = System.Text.Encoding.UTF8.GetString(response);
                    }
                    catch (WebException)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.InternetConnectionError);
                        CommonProcess.HasError = true;
                    }
                }
                if (!String.IsNullOrEmpty(respStr))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(OrderResponseModel));
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
                        OrderResponseModel baseResp = (OrderResponseModel)js.ReadObject(msU);
                        if ((baseResp != null)
                            && (baseResp.Id != null))
                        {
                            retVal = baseResp.Id;
                        }
                    }
                }
            }
            return retVal;
        }
        /// <summary>
        /// Create order to server.
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Order id</returns>
        public static string CreateOrderToServer(OrderModel model)
        {
            string retVal = string.Empty;
            if (!String.IsNullOrEmpty(Properties.Settings.Default.UserToken))
            {
                string respStr = String.Empty;
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        CreateOrderModel createModel = new CreateOrderModel();
                        // Create data
                        createModel.Token       = Properties.Settings.Default.UserToken;
                        createModel.Customer_id = model.Customer.Id;
                        createModel.Note        = model.Note;
                        createModel.Status      = (int)model.Status;
                        if (DataPure.Instance.Agent != null)
                        {
                            createModel.Agent_id = DataPure.Instance.Agent.Id;
                        }
                        else
                        {
                            CommonProcess.ShowErrorMessage(Properties.Resources.YouMustSelectAnAgent);
                            CommonProcess.HasError = true;
                            return string.Empty;
                        }
                        createModel.Employee_maintain_id = model.DeliverId;
                        createModel.Monitor_market_development_id = model.CCSId;
                        createModel.Order_detail = new List<OrderDetailModel>();
                        foreach (ProductModel product in model.Products)
                        {
                            OrderDetailModel orderDetail = new OrderDetailModel();
                            // Create data
                            orderDetail.Materials_id      = product.Id;
                            orderDetail.Materials_type_id = product.TypeId;
                            orderDetail.Quantity          = product.Quantity;
                            orderDetail.Price             = product.Price.ToString();
                            orderDetail.TotalPay          = (product.Price * product.Quantity).ToString();
                            orderDetail.Seri              = string.Empty;

                            // Add to list order detail
                            createModel.Order_detail.Add(orderDetail);
                        }
                        foreach (PromoteModel promote in model.Promotes)
                        {
                            OrderDetailModel orderDetail = new OrderDetailModel();
                            // Create data
                            orderDetail.Materials_id      = promote.Id;
                            orderDetail.Materials_type_id = promote.TypeId;
                            orderDetail.Quantity          = promote.Quantity;
                            orderDetail.Price             = String.Empty;
                            orderDetail.TotalPay          = String.Empty;
                            orderDetail.Seri              = string.Empty;

                            // Add to list order detail
                            createModel.Order_detail.Add(orderDetail);
                        }
                        foreach (CylinderModel cylinder in model.Cylinders)
                        {
                            OrderDetailModel orderDetail = new OrderDetailModel();
                            // Create data
                            orderDetail.Materials_id      = cylinder.Id;
                            orderDetail.Materials_type_id = cylinder.TypeId;
                            orderDetail.Quantity          = cylinder.Quantity;
                            orderDetail.Price             = String.Empty;
                            orderDetail.TotalPay          = String.Empty;
                            orderDetail.Seri              = cylinder.Serial;

                            // Add to list order detail
                            createModel.Order_detail.Add(orderDetail);
                        }

                        // Post keyword to server
                        string value = string.Empty;
                        value = createModel.ToString();
                        byte[] response = webClient.UploadValues(
                            Properties.Settings.Default.ServerURL + Properties.Settings.Default.URLCreateOrder,
                            new System.Collections.Specialized.NameValueCollection()
                        {
                            { "q", value}
                        });
                        // Get response
                        respStr = System.Text.Encoding.UTF8.GetString(response);
                    }
                    catch (WebException)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.InternetConnectionError);
                        CommonProcess.HasError = true;
                    }
                }
                if (!String.IsNullOrEmpty(respStr))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(OrderResponseModel));
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
                        OrderResponseModel baseResp = (OrderResponseModel)js.ReadObject(msU);
                        if ((baseResp != null)
                            && (baseResp.Id != null))
                        {
                            retVal = baseResp.Id;
                        }
                    }
                }
            }
            return retVal;
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
        public static Bitmap CreateAvatar(string text, int size, int fontSize = 24)
        {
            Bitmap retVal = new Bitmap(size, size);
            if (AVATAR_BACKCOLOR.Count == 0)
            {
                return retVal;
            }
            var randomIdx = new Random().Next(0, AVATAR_BACKCOLOR.Count - 1);
            var bgColor = AVATAR_BACKCOLOR[randomIdx];
            return CreateAvatar(retVal, text, size,
                (Color)new ColorConverter().ConvertFromString("#" + bgColor), fontSize);
        }
        public static Bitmap CreateAvatar(string text, int size, Color color, int fontSize = 24)
        {
            Bitmap retVal = new Bitmap(size, size);
            return CreateAvatar(retVal, text, size, color, fontSize);
        }
        public static Bitmap CreateAvatar(Bitmap bitmap, string text, int size, Color color, int fontSize = 24)
        {
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            var font = new Font("Calibri", fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(bitmap);

            graphics.Clear(color);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.DrawString(text, font, new SolidBrush(Color.WhiteSmoke),
                new RectangleF(0, 0, size, size), sf);
            graphics.Flush();
            return bitmap;
        }
        /// <summary>
        /// Search material.
        /// </summary>
        /// <param name="keyword">Keyword</param>
        /// <returns>List of material</returns>
        public static List<MaterialModel> SearchMaterial(string keyword, List<MaterialModel> source)
        {
            List<MaterialModel> result = new List<MaterialModel>();
            if (source != null)
            {
                foreach (MaterialModel item in source)
                {
                    if (item.IsContainString(keyword))
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Search promote.
        /// </summary>
        /// <param name="keyword">Keyword</param>
        /// <returns>List of material</returns>
        public static List<MaterialModel> SearchPromote(string keyword)
        {
            List<MaterialModel> result = new List<MaterialModel>();
            // Check null object
            if (DataPure.Instance.TempData != null)
            {
                // Check null object
                if (DataPure.Instance.TempData.Material_promotion != null)
                {
                    foreach (MaterialModel item in DataPure.Instance.TempData.Material_promotion)
                    {
                        if (item.IsContainString(keyword))
                        {
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Format money.
        /// </summary>
        /// <param name="money">Money value</param>
        /// <returns>String after format</returns>
        public static string FormatMoney(double money)
        {
            if (money < 0.0)
            {
                money = 0.0;
            }
            string retVal = String.Empty;
            NumberFormatInfo nfi = new CultureInfo("vi-VN", false).NumberFormat;
            nfi.CurrencyDecimalDigits = 0;
            retVal = money.ToString("C", nfi);
            return retVal;
        }
        /// <summary>
        /// Clone Dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="original"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> CloneDictionary<TKey, TValue>(
            Dictionary<TKey, TValue> original) where TValue : ICloneable
        {
            Dictionary<TKey, TValue> ret = new Dictionary<TKey, TValue>(original.Count, original.Comparer);
            foreach (KeyValuePair<TKey, TValue> entry in original)
            {
                ret.Add(entry.Key, (TValue)entry.Value.Clone());
            }
            return ret;
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static int MakeLong(short lowPart, short highPart)
        {
            return (int)(((ushort)lowPart) | (uint)(highPart << 16));
        }

        public static void ListView_SetSpacing(ListView listview, short cx, short cy)
        {
            const int LVM_FIRST = 0x1000;
            const int LVM_SETICONSPACING = LVM_FIRST + 53;
            // http://msdn.microsoft.com/en-us/library/bb761176(VS.85).aspx
            // minimum spacing = 4
            SendMessage(listview.Handle, LVM_SETICONSPACING,
            IntPtr.Zero, (IntPtr)MakeLong(cx, cy));

            // http://msdn.microsoft.com/en-us/library/bb775085(VS.85).aspx
            // DOESN'T WORK!
            // can't find ListView_SetIconSpacing in dll comctl32.dll
            //ListView_SetIconSpacing(listView.Handle, 5, 5);
        }
        public static void GetAgentExt()
        {
            using (WebClient client = new WebClient())
            {
                string respStr = String.Empty;
                try
                {
                    // Post keyword to server
                    byte[] response = client.UploadValues(
                        Properties.Settings.Default.ServerURL + "/api/spj/getAgent",
                        new System.Collections.Specialized.NameValueCollection()
                    {
                        { "key", "dc36cc6fb2db91e515372db1821b6275" },
                        { "phone", "01684331552" }
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
                    Console.WriteLine(respStr);
                }
            }
        }
    }
}
