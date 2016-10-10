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
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows.Forms;

namespace MainPrj.Util
{
    /// <summary>
    /// Common process class.
    /// </summary>
    public static class CommonProcess
    {
        #region Constant
        //++ BUG0045-SPJ (NguyenPT 20160823) Define constants
        public const string INI_KEY_AGENTID        = "AgentId";
        public const string INI_SECTION_GENERAL = "General";
        //-- BUG0045-SPJ (NguyenPT 20160823) Define constants
        //++ BUG0046-SPJ (NguyenPT 20160824) Login automatically
        public const string INI_KEY_USERNAME = "Username";
        public const string INI_KEY_PASSWORD = "Password";
        //-- BUG0046-SPJ (NguyenPT 20160824) Login automatically
        //++ BUG0055-SPJ (NguyenPT 20160826) Save brand information in setting.ini
        public const string INI_KEY_BRAND = "Brand";
        //-- BUG0055-SPJ (NguyenPT 20160826) Save brand information in setting.ini
        //++ BUG0008-SPJ (NguyenPT 20160830) Order history
        public const string API_ORDER_HISTORY = "/api/default/windowGetCustomerHistory";
        //-- BUG0008-SPJ (NguyenPT 20160830) Order history
        //++ BUG0074-SPJ (NguyenPT 20160913) Handle turn on/off SIP thread
        public const string INI_KEY_PACKET_UDP = "PacketUDP";
        public const string INI_KEY_PACKET_SIP = "PacketSIP";
        //-- BUG0074-SPJ (NguyenPT 20160913) Handle turn on/off SIP thread
        //++ BUG0083-SPJ (NguyenPT 20160928) Add Uphold phone setting
        public const string INI_KEY_UPHOLD_PHONE = "UpholdPhone";
        public const string UPHOLD_PHONE_HCM     = "0838 408 408";
        //-- BUG0083-SPJ (NguyenPT 20160928) Add Uphold phone setting
        ////++ BUG0082-SPJ (NguyenPT 20160928) Handle save Setting data path on Setting
        //public static string INI_KEY_SETTING_DIRECTORY = "SettingDirectory";
        ////-- BUG0082-SPJ (NguyenPT 20160928) Handle save Setting data path on Setting
        /// <summary>
        /// API: inform received notification.
        /// </summary>
        public const string API_NOTIFY_RECEIVED = @"http://spj.daukhimiennam.com/api/socket/notifyReceived";
        #endregion
        #region Static variables
        public static SoundPlayer NotificationSound = new SoundPlayer(Properties.Resources.notifySound3);
        public static List<string> AGENT_LIST_ZIBO = new List<string>
        {
            "1311",		    // Cửa hàng 1
            "1312",		    // Cửa hàng 2
            "1313",		    // Cửa hàng 3
            "125798",		// Đại lý Trạm Vĩnh Long 1
            "30753",		// Cửa hàng Cần Thơ 1
            "138544",		// Cửa hàng Cần Thơ 2
            "262526",		// Cửa Hàng Ô Môn
            "118",		    // Đại lý An Thạnh
            "116",		    // Đại lý Bình Đa
            "122",		    // Đại lý Bình Tân
            "106",		    // Đại lý Bình Thạnh 1
            "115",		    // Đại lý Dĩ An
            "108",		    // Đại lý Hóc Môn
            "109",		    // Đại lý Lái Thiêu
            "114",		    // Đại lý Long Bình Tân
            "121",		    // Đại lý Ngã Ba Trị An
            "100",		    // Đại lý Quận 2
            "113",		    // Đại lý Quận 3
            "101",		    // Đại lý Quận 4
            "102",		    // Đại lý Quận 7
            "119",			// Đại lý Tân Định
            "126",		    // Đại lý Tân Phú
            "120",		    // Đại lý Tân Sơn
            "110",		    // Đại lý Thủ Dầu Một
            "112",		    // Đại lý Thủ Đức 1
            "123"		    // Đại lý Trảng Dài
        };
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
        /// Flag check if has error in processing.
        /// </summary>
        public static bool HasError = false;
        ///// <summary>
        ///// Setting directory.
        ///// </summary>
        //public static string SettingDirectory = String.Empty;

        public static string FACEBOOK_COLOR = "3B5998";
        //public static string FACEBOOK_NEW_ITEM_COLOR = "EDF2FA";
        public static string FACEBOOK_NEW_ITEM_COLOR = "0080FF";
        public static string FACEBOOK_ITEM_HOVER_COLOR = "F6F7F9";
        /// <summary>
        /// Minximum time to reconnect with web socket.
        /// </summary>
        public const int RECONNECT_WEBSOCKET_MIN_TIME = 10;
        /// <summary>
        /// Maximum time to reconnect with web socket.
        /// </summary>
        public const int RECONNECT_WEBSOCKET_MAX_TIME = 20;
        #endregion

        #region Show message
        [DllImport("user32.dll")]
        private static extern int PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
        /// <summary>
        /// Show error message box.
        /// </summary>
        /// <param name="msg">Message content</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowErrorMessage(string msg, Form parent = null)
        {
            HandlerTimer();
            if (parent == null)
            {
                return MessageBox.Show(msg, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (parent.InvokeRequired)
                {
                    return (DialogResult)parent.Invoke((Action)delegate
                    {
                        MessageBox.Show(parent, msg, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
                else
                {
                    return MessageBox.Show(parent, msg, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Show inform message box.
        /// </summary>
        /// <param name="msg">Message content</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowInformMessage(string msg, Form parent = null)
        {
            if (parent == null)
            {
                return MessageBox.Show(msg, Properties.Resources.Inform, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else
            {
                if (parent.InvokeRequired)
                {
                    return (DialogResult)parent.Invoke((Action)delegate
                    {
                        MessageBox.Show(parent, msg, Properties.Resources.Inform, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    });
                }
                else
                {
                    return MessageBox.Show(parent, msg, Properties.Resources.Inform, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }
        /// <summary>
        /// Show inform message box.
        /// </summary>
        /// <param name="msg">Message content</param>
        /// <param name="buttons"></param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowInformMessage(string msg, MessageBoxButtons buttons, Form parent = null)
        {
            if (parent == null)
            {
                return MessageBox.Show(msg, Properties.Resources.Inform, buttons, MessageBoxIcon.Information);
            }
            else
            {
                if (parent.InvokeRequired)
                {
                    return (DialogResult)parent.Invoke((Action)delegate
                    {
                        MessageBox.Show(parent, msg, Properties.Resources.Inform, buttons, MessageBoxIcon.Information);
                    });
                }
                else
                {
                    return MessageBox.Show(parent, msg, Properties.Resources.Inform, buttons, MessageBoxIcon.Information);
                }
            }
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
        public static void HandlerTimer()
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
        }
        #endregion

        #region File handler
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
        //++ BUG0043-SPJ (NguyenPT 20160822) Write history when has a call
        /// <summary>
        /// Write history.
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>True if write success, false otherwise</returns>
        public static bool WriteHistory(CallModel model)
        {
            if (model != null)
            {
                string date = model.Id.Substring(0, 8);
                string filepath = String.Format("{0}\\{1}_{2}", Properties.Settings.Default.SettingFilePath,
                    date, Properties.Settings.Default.HistoryFileName);

                try
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        // Write file
                        sw.WriteLine(model.ToString());
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
        //-- BUG0043-SPJ (NguyenPT 20160822) Write history when has a call
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
        /// <summary>
        /// Read history by date.
        /// </summary>
        /// <param name="dateValue">Date value</param>
        /// <returns>List of call models</returns>
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
        //++ BUG0043-SPJ (NguyenPT 20160822) Write list order
        /// <summary>
        /// Read list orders by date.
        /// </summary>
        /// <param name="dateValue">Date value</param>
        /// <returns>List of call models</returns>
        public static List<OrderModel> ReadListOrdersByDate(DateTime dateValue)
        {
            List<OrderModel> result = new List<OrderModel>();
            string date = dateValue.ToString(Properties.Settings.Default.CallIdFormat).Substring(0, 8);
            //++ BUG0066-SPJ (NguyenPT 20160904) Increate List Order view performance
            //if (DataPure.Instance.ListOrderHistory.ContainsKey(date))
            //{
            //    return DataPure.Instance.ListOrderHistory[date];
            //}
            //-- BUG0066-SPJ (NguyenPT 20160904) Increate List Order view performance

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
                //++ BUG0066-SPJ (NguyenPT 20160904) Increate List Order view performance
                //DataPure.Instance.ListOrderHistory.Add(date, result);
                //-- BUG0066-SPJ (NguyenPT 20160904) Increate List Order view performance
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
        /// Write order on date.
        /// </summary>
        /// <param name="dateValue">Date value</param>
        /// <param name="model">Model</param>
        /// <returns>True if write success, false otherwise</returns>
        public static bool WriteOrderByDate(DateTime dateValue, OrderModel model)
        {
            if (model != null)
            {
                string date = dateValue.ToString("yyyyMMdd");

                string filepath = String.Format("{0}\\{1}_{2}", Properties.Settings.Default.SettingFilePath,
                    date, Properties.Settings.Default.OrdersFileName);
                try
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        // Write file
                        sw.WriteLine(model.ToString());
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
        /// Write list orders fle.
        /// </summary>
        public static bool WriteListOrdersByDate(DateTime dateValue, List<OrderModel> list)
        {
            if (list.Count > 0)
            {
                string date = dateValue.ToString("yyyyMMdd");

                string filepath = String.Format("{0}\\{1}_{2}", Properties.Settings.Default.SettingFilePath,
                    date, Properties.Settings.Default.OrdersFileName);
                try
                {
                    using (StreamWriter sw = new StreamWriter(File.Open(filepath, System.IO.FileMode.Create)))
                    {
                        // Write file
                        foreach (OrderModel item in list)
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
        /// Update order to file.
        /// </summary>
        /// <param name="model">Model</param>
        public static void UpdateOrderToFile(OrderModel model)
        {
            if (model == null)
	        {
                return;
            }
            //++ BUG0057-SPJ (NguyenPT 20160828) Fix bug convert datetime
            DateTime date = DateTime.ParseExact(
                model.Created_date,
                Properties.Resources.DefaultDateTimeFormat,
                System.Globalization.CultureInfo.InvariantCulture);
            //List<OrderModel> list = ReadListOrdersByDate(Convert.ToDateTime(model.Created_date));
            List<OrderModel> list = ReadListOrdersByDate(date);
            //-- BUG0057-SPJ (NguyenPT 20160828) Fix bug convert datetime
            for (int i = 0; i < list.Count; i++ )
            {
                if (list[i].Id.Equals(model.Id))
                {
                    list[i] = model;
                    break;
                }
            }
            //++ BUG0057-SPJ (NguyenPT 20160828) Fix bug convert datetime
            //WriteListOrdersByDate(Convert.ToDateTime(model.Created_date), list);
            WriteListOrdersByDate(date, list);
            //-- BUG0057-SPJ (NguyenPT 20160828) Fix bug convert datetime
        }
        //-- BUG0043-SPJ (NguyenPT 20160822) Write list order
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
        //++ BUG0045-SPJ (NguyenPT 20160823) Read/Write agent id to setting.ini file
        /// <summary>
        /// Write agent id to setting.ini file.
        /// </summary>
        /// <param name="agentId">Agent id</param>
        public static void WriteAgentIdToSetting(string agentId)
        {
            string filepath = String.Format("{0}\\setting.ini", Properties.Settings.Default.SettingFilePath);
            var iniFile = new INIHandle(filepath);
            iniFile.Write(INI_KEY_AGENTID, agentId, INI_SECTION_GENERAL);
        }
        /// <summary>
        /// Read agent id from setting file.
        /// </summary>
        /// <returns>Agent id</returns>
        public static string ReadAgentIdFromSetting()
        {
            return ReadSetting(INI_KEY_AGENTID, INI_SECTION_GENERAL);
        }
        //-- BUG0045-SPJ (NguyenPT 20160823) Read/Write agent id to setting.ini file
        /// <summary>
        /// Write login information to setting.ini file.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        public static void WriteLoginInfoToSetting(string username, string password)
        {
            string filepath = String.Format("{0}\\setting.ini", Properties.Settings.Default.SettingFilePath);
            var iniFile = new INIHandle(filepath);
            iniFile.Write(INI_KEY_USERNAME, username, INI_SECTION_GENERAL);
            iniFile.Write(INI_KEY_PASSWORD, password, INI_SECTION_GENERAL);
        }
        //++ BUG0046-SPJ (NguyenPT 20160824) Login automatically
        /// <summary>
        /// Read username from setting.ini file.
        /// </summary>
        /// <returns>Username</returns>
        public static string ReadUsernameFromSetting()
        {
            return ReadSetting(INI_KEY_USERNAME, INI_SECTION_GENERAL);
        }
        /// <summary>
        /// Read password from setting.ini file.
        /// </summary>
        /// <returns>Password</returns>
        public static string ReadPasswordFromSetting()
        {
            return ReadSetting(INI_KEY_PASSWORD, INI_SECTION_GENERAL);
        }
        /// <summary>
        /// Read a setting from setting.ini file.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="section">Section</param>
        /// <returns>Value of key</returns>
        public static string ReadSetting(string key, string section)
        {
            string filepath = String.Format("{0}\\setting.ini", Properties.Settings.Default.SettingFilePath);
            var iniFile = new INIHandle(filepath);
            return iniFile.Read(key, section);
        }
        //-- BUG0046-SPJ (NguyenPT 20160824) Login automatically

        //++ BUG0055-SPJ (NguyenPT 20160826) Save brand information in setting.ini
        /// <summary>
        /// Write brand information to setting.ini.
        /// </summary>
        /// <param name="brand">Brand</param>
        public static void WriteBrandToSetting(string brand)
        {
            string filepath = String.Format("{0}\\setting.ini", Properties.Settings.Default.SettingFilePath);
            var iniFile = new INIHandle(filepath);
            iniFile.Write(INI_KEY_BRAND, brand, INI_SECTION_GENERAL);
        }
        /// <summary>
        /// Read brand information from setting.
        /// </summary>
        /// <returns>Brand setting</returns>
        public static string ReadBrandFromSetting()
        {
            return ReadSetting(INI_KEY_BRAND, INI_SECTION_GENERAL);
        }
        //-- BUG0055-SPJ (NguyenPT 20160826) Save brand information in setting.ini
        //++ BUG0074-SPJ (NguyenPT 20160913) Handle turn on/off SIP thread
        /// <summary>
        /// Write Packet UDP flag.
        /// </summary>
        /// <param name="packetUDP">Packet UDP</param>
        public static void WritePacketUDPToSetting(bool packetUDP)
        {
            string filepath = String.Format("{0}\\setting.ini", Properties.Settings.Default.SettingFilePath);
            var iniFile = new INIHandle(filepath);
            iniFile.Write(INI_KEY_PACKET_UDP, packetUDP.ToString(), INI_SECTION_GENERAL);
        }
        /// <summary>
        /// Read packet UDP flag.
        /// </summary>
        /// <returns>Packet UDP flag</returns>
        public static string ReadPacketUDPFromSetting()
        {
            return ReadSetting(INI_KEY_PACKET_UDP, INI_SECTION_GENERAL);
        }
        /// <summary>
        /// Write Packet SIP flag.
        /// </summary>
        /// <param name="packetSIP">Packet SIP</param>
        public static void WritePacketSIPToSetting(bool packetSIP)
        {
            string filepath = String.Format("{0}\\setting.ini", Properties.Settings.Default.SettingFilePath);
            var iniFile = new INIHandle(filepath);
            iniFile.Write(INI_KEY_PACKET_SIP, packetSIP.ToString(), INI_SECTION_GENERAL);
        }
        /// <summary>
        /// Read packet SIP flag.
        /// </summary>
        /// <returns>Packet SIP flag</returns>
        public static string ReadPacketSIPFromSetting()
        {
            return ReadSetting(INI_KEY_PACKET_SIP, INI_SECTION_GENERAL);
        }
        //-- BUG0074-SPJ (NguyenPT 20160913) Handle turn on/off SIP thread
        ////++ BUG0082-SPJ (NguyenPT 20160928) Handle save Setting data path on Setting
        ///// <summary>
        ///// Write setting directory to setting.ini.
        ///// </summary>
        ///// <param name="path">Setting directory</param>
        //public static void WriteSettingDirectoryToSetting(string path)
        //{
        //    string filepath = String.Format("{0}\\setting.ini", Properties.Settings.Default.SettingFilePath);
        //    var iniFile = new INIHandle(filepath);
        //    iniFile.Write(INI_KEY_SETTING_DIRECTORY, path, INI_SECTION_GENERAL);
        //}
        ///// <summary>
        ///// Read setting directory from setting.ini.
        ///// </summary>
        ///// <returns>Setting directory</returns>
        //public static string ReadSettingDirectoryFromSetting()
        //{
        //    return ReadSetting(INI_KEY_SETTING_DIRECTORY, INI_SECTION_GENERAL);
        //}
        ////-- BUG0082-SPJ (NguyenPT 20160928) Handle save Setting data path on Setting
        //++ BUG0083-SPJ (NguyenPT 20160928) Add Uphold phone setting
        /// <summary>
        /// Write uphold phone to setting.ini.
        /// </summary>
        /// <param name="path">Uphold phone</param>
        public static void WriteUpholdPhoneToSetting(string phone)
        {
            string filepath = String.Format("{0}\\setting.ini", Properties.Settings.Default.SettingFilePath);
            var iniFile = new INIHandle(filepath);
            iniFile.Write(INI_KEY_UPHOLD_PHONE, phone, INI_SECTION_GENERAL);
        }
        /// <summary>
        /// Read uphold phone from setting.ini.
        /// </summary>
        /// <returns>Uphold phone</returns>
        public static string ReadUpholdPhoneFromSetting()
        {
            return ReadSetting(INI_KEY_UPHOLD_PHONE, INI_SECTION_GENERAL);
        }
        //-- BUG0083-SPJ (NguyenPT 20160928) Add Uphold phone setting
        #endregion

        #region Common methods
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
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
        public static string GetRoleString(string roleId)
        {
            if (CommonProcess.IsValidNumber(roleId))
            {
                return GetRoleString((RoleType)int.Parse(roleId));
            }
            return string.Empty;
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
                // Check if name of customer is empty, set "Không rõ"
                if (String.IsNullOrEmpty(customer.Name))
                {
                    channel.SetCustomerName(Properties.Resources.CustomerNameUnknown);
                }
                else
                {
                    channel.SetCustomerName(customer.Name);
                }
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
            return IsValidDouble(phone);
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
        /// <summary>
        /// Create avatar.
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="size">Size</param>
        /// <param name="color">Color</param>
        /// <param name="fontSize">Font size of text</param>
        /// <returns>Bitmap object</returns>
        public static Bitmap CreateAvatar(string text, int size, Color color, int fontSize = 24)
        {
            Bitmap retVal = new Bitmap(size, size);
            return CreateAvatar(retVal, text, size, color, fontSize);
        }
        /// <summary>
        /// Create avatar.
        /// </summary>
        /// <param name="bitmap">Bitmap object</param>
        /// <param name="text">Text</param>
        /// <param name="size">Size</param>
        /// <param name="color">Color</param>
        /// <param name="fontSize">Font size of text</param>
        /// <returns>Bitmap object</returns>
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
            //++ BUG0059-SPJ (NguyenPT 20160831) Can show negative money value
            //if (money < 0.0)
            //{
            //    money = 0.0;
            //}
            //-- BUG0059-SPJ (NguyenPT 20160831) Can show negative money value
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
        /// <summary>
        /// Make long method.
        /// </summary>
        /// <param name="lowPart">Low value</param>
        /// <param name="highPart">High value</param>
        /// <returns>Int value</returns>
        public static int MakeLong(short lowPart, short highPart)
        {
            return (int)(((ushort)lowPart) | (uint)(highPart << 16));
        }
        /// <summary>
        /// Set space for listview.
        /// </summary>
        /// <param name="listview">List view object</param>
        /// <param name="cx">X space</param>
        /// <param name="cy">Y space</param>
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
        /// <summary>
        /// Get FROM information from sip data.
        /// </summary>
        /// <param name="sipData">Data content</param>
        /// <returns>FROM number</returns>
        public static string GetFrom(string sipData)
        {
            string from = string.Empty;
            // From: "108" <sip:108@210.245.124.253>;tag=as1d09372a
            Regex regFrom = new Regex(@"^From:\s?(?<FromID>"".*""|.*)\<sip:\+?(?<FromTelephone>.*)@.*$",
                RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Multiline);
            // FROM
            Match m = regFrom.Match(sipData);
            if (m.Success)
            {
                from = ((string)m.Groups["FromID"].Value.ToString().Replace("\"", "").Trim());
            }
            return from;
        }
        /// <summary>
        /// Check if sip data is INVITE packet.
        /// </summary>
        /// <returns>True if SIP data is INVITE packet type, False otherwise</returns>
        public static bool IsRingingPacket(string sipData)
        {
            return sipData.StartsWith("INVITE");
        }
        /// <summary>
        /// Check if sip data is CANCEL packet.
        /// </summary>
        /// <returns>True if SIP data is CANCEL packet type, False otherwise</returns>
        public static bool IsMissPacket(string sipData)
        {
            return sipData.StartsWith("CANCEL");
        }
        /// <summary>
        /// Check if sip data is OK of INVITE packet.
        /// </summary>
        /// <returns>True if SIP data is OK of INVITE packet type, False otherwise</returns>
        public static bool IsHandlingPacket(string sipData)
        {
            return (sipData.StartsWith("SIP/2.0 200 OK") && sipData.Contains("CSeq: 102 INVITE"));
        }
        /// <summary>
        /// Check if sip data is BYE packet.
        /// </summary>
        /// <returns>True if SIP data is BYE packet type, False otherwise</returns>
        public static bool IsHangUpPacket(string sipData)
        {
            return (sipData.StartsWith("SIP/2.0 200 OK")
                && (sipData.Contains("CSeq: 103 BYE") || sipData.Contains("CSeq: 2 BYE")));
        }
        /// <summary>
        /// Check if sip data is BUSY packet.
        /// </summary>
        /// <returns>True if SIP data is BUSY packet type, False otherwise</returns>
        public static bool IsBusyPacket(string sipData)
        {
            return (sipData.StartsWith("SIP/2.0 486 Busy Here") && sipData.Contains("CSeq: 102 INVITE"));
        } 
        /// <summary>
        /// Update progress.
        /// </summary>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        /// <param name="status">Status string</param>
        /// <param name="bar">Progress bar</param>
        /// <param name="label">Status label</param>
        public static void UpdateProgress(UploadProgressChangedEventArgs e, string status,
            ToolStripProgressBar bar, ToolStripStatusLabel label)
        {
            if ((e.ProgressPercentage <= 50)
                && (e.ProgressPercentage >= 0))
            {
                bar.Value = e.ProgressPercentage * 2;
            }
            label.Text = status;
        }
        //++ BUG0045-SPJ (NguyenPT 20160823) Check if agent id is exist inside List agents
        /// <summary>
        /// Check if agent id id valid.
        /// </summary>
        /// <param name="agentId">Id of agent</param>
        /// <returns>True if agent id is exist inside List agents, False otherwise</returns>
        public static bool IsValidAgentId(string agentId)
        {
            foreach (SelectorModel item in DataPure.Instance.GetListAgents())
            {
                if (item.Id.Equals(agentId))
                {
                    return true;
                }
            }
            return false;
        }
        //-- BUG0045-SPJ (NguyenPT 20160823) Check if agent id is exist inside List agents
        public static string NormalizationStringJson(string data)
        {
            return data.Replace("\\", "/");
        }
        public static Color ConvertColorFromString(string color)
        {
            return (Color)new ColorConverter().ConvertFromString("#" + color);
        }
        ///// <summary>
        ///// Get setting directory.
        ///// </summary>
        ///// <returns>Setting directory</returns>
        //public static string GetSettingDirectory()
        //{
        //    // Read the first time
        //    if (String.IsNullOrEmpty(SettingDirectory))
        //    {
        //        // Read from
        //        string temp = ReadSettingDirectoryFromSetting();
        //        if (!string.IsNullOrEmpty(temp))
        //        {
        //            SettingDirectory = temp;
        //        }
        //        else
        //        {
        //            SettingDirectory = Properties.Settings.Default.SettingFilePath;
        //        }
        //    }
        //    return SettingDirectory;
        //}
        #endregion

        #region Request Server
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
        /// Request logout.
        /// </summary>
        /// <param name="progressChanged">Progress changed handler</param>
        /// <param name="completedHandler">Completed handler</param>
        public static void RequestLogout(UploadProgressChangedEventHandler progressChanged, UploadValuesCompletedEventHandler completedHandler)
        {
            UserLoginResponseModel data = new UserLoginResponseModel();
            using (WebClient client = new WebClient())
            {
                string respStr = String.Empty;
                client.UploadProgressChanged += new UploadProgressChangedEventHandler(progressChanged);
                client.UploadValuesCompleted += new UploadValuesCompletedEventHandler(completedHandler);
                try
                {
                    // Post keyword to server
                    string value = string.Empty;
                    value = String.Format("{{\"token\":\"{0}\"}}", Properties.Settings.Default.UserToken);
                    client.UploadValuesAsync(
                        new Uri(Properties.Settings.Default.ServerURL + Properties.Settings.Default.URLLogout),
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
                    //++ BUG0071-SPJ (NguyenPT 20160908) Add agent_id into message request server
                    //value = String.Format("{{\"token\":\"{0}\"}}",
                    //    Properties.Settings.Default.UserToken);
                    value = String.Format("{{\"token\":\"{0}\",\"agent_id\":\"{1}\"}}",
                        Properties.Settings.Default.UserToken, CommonProcess.ReadAgentIdFromSetting());
                    //-- BUG0071-SPJ (NguyenPT 20160908) Add agent_id into message request server
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
                            //++ BUG0052-SPJ (NguyenPT 20160823) Update CCS when change Agent
                            DataPure.Instance.TempData.Monitor_market_development = baseResp.Record.Monitor_market_development;
                            //-- BUG0052-SPJ (NguyenPT 20160823) Update CCS when change Agent
                            DataPure.Instance.TempData.Agent_phone = baseResp.Record.Agent_phone;
                            DataPure.Instance.TempData.Agent_address = baseResp.Record.Agent_address;
                            DataPure.Instance.TempData.Agent_province = baseResp.Record.Agent_province;
                            DataPure.Instance.TempData.Agent_district = baseResp.Record.Agent_district;
                            DataPure.Instance.TempData.Agent_cell_phone = baseResp.Record.Agent_cell_phone;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Request create new order by coordinator.
        /// </summary>
        /// <param name="agentId">Id of agent</param>
        /// <param name="customerId">Id of customer</param>
        /// <param name="note">Note of order</param>
        public static string RequestCreateOrderCoordinator(string agentId, string customerId, string note,
            UploadProgressChangedEventHandler progressChanged,
            UploadValuesCompletedEventHandler completedHandler)
        {
            string retVal = string.Empty;
            using (WebClient client = new WebClient())
            {
                client.UploadProgressChanged += new UploadProgressChangedEventHandler(progressChanged);
                client.UploadValuesCompleted += new UploadValuesCompletedEventHandler(completedHandler);
                string respStr = String.Empty;
                try
                {
                    // Post keyword to server
                    string value = string.Empty;
                    value = String.Format("{{\"token\":\"{0}\",\"customer_id\":\"{1}\",\"agent_id\":\"{2}\",\"note\":\"{3}\"}}",
                        Properties.Settings.Default.UserToken,
                        customerId, agentId, note);
                    client.UploadValuesAsync(
                        new Uri(Properties.Settings.Default.ServerURL + Properties.Settings.Default.URLCreateOrderCoordinator),
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

                //if (!String.IsNullOrEmpty(respStr))
                //{
                //    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(OrderResponseModel));
                //    byte[] encodingBytes = null;
                //    try
                //    {
                //        // Encoding response data
                //        encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(respStr);
                //    }
                //    catch (System.Text.EncoderFallbackException)
                //    {
                //        ShowErrorMessage(Properties.Resources.EncodingError);
                //        HasError = true;
                //    }
                //    if (encodingBytes != null)
                //    {
                //        MemoryStream msU = new MemoryStream(encodingBytes);
                //        OrderResponseModel baseResp = (OrderResponseModel)js.ReadObject(msU);
                //        if (baseResp != null && baseResp.Status.Equals("1"))
                //        {
                //            retVal = baseResp.Id;
                //        }
                //    }
                //}
            }
            return retVal;
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
        /// Update agent cell phone.
        /// </summary>
        /// <param name="agentId">Id of agent</param>
        /// <param name="cellPhone">Cell phone of agent</param>
        /// <param name="progressChanged">Progress changed handler</param>
        /// <param name="completedHandler">Completed handler</param>
        public static void UpdateAgentCellPhone(string agentId, string cellPhone,
            UploadProgressChangedEventHandler progressChanged,
            UploadValuesCompletedEventHandler completedHandler)
        {
            // Declare result variable
            using (WebClient client = new WebClient())
            {
                client.UploadProgressChanged += new UploadProgressChangedEventHandler(progressChanged);
                client.UploadValuesCompleted += new UploadValuesCompletedEventHandler(completedHandler);
                try
                {
                    client.UploadValuesAsync(
                        new Uri(Properties.Settings.Default.ServerURL
                        + Properties.Settings.Default.URLUpdateCustomerPhone),
                        new NameValueCollection
					    {
						    {
							    Properties.Settings.Default.CustomerIdKey,
							    agentId
						    },
						    {
							    Properties.Settings.Default.PhoneKey,
							    cellPhone
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
                        updateModel.Token           = Properties.Settings.Default.UserToken;
                        updateModel.Id              = model.WebId;
                        updateModel.Note            = model.Note;
                        updateModel.Status          = (int)model.Status;
                        //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
                        updateModel.Created_date    = model.Created_date;
                        //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
                        //++ BUG0056-SPJ (NguyenPT 20160830) Handle order type
                        updateModel.Order_type  = model.Order_type;
                        updateModel.Type_amount = model.Type_amount;
                        //-- BUG0056-SPJ (NguyenPT 20160830) Handle order type
                        //++ BUG0058-SPJ (NguyenPT 20160830) Update Deliver and CCS
                        updateModel.Employee_maintain_id          = model.DeliverId;
                        updateModel.Monitor_market_development_id = model.CCSId;
                        //-- BUG0058-SPJ (NguyenPT 20160830) Update Deliver and CCS
                        //++ BUG0068-SPJ (NguyenPT 20160905) Change promote money
                        if (model.IsManualChangePromote)
                        {
                            //++ BUG0078-SPJ (NguyenPT 20160925) Check if user change promote money manual to 0
                            //updateModel.Amount_discount = model.PromoteMoney;
                            if (model.PromoteMoney != 0.0)
                            {
                                updateModel.Amount_discount = model.PromoteMoney;
                            }
                            else
                            {
                                // Push 1.0 to server
                                updateModel.Amount_discount = 1.0;
                            }
                            //-- BUG0078-SPJ (NguyenPT 20160925) Check if user change promote money manual to 0
                        }
                        else
                        {
                            updateModel.Amount_discount = 0.0;
                        }
                        //-- BUG0068-SPJ (NguyenPT 20160905) Change promote money
                        updateModel.Order_detail    = new List<OrderDetailModel>();
                        foreach (ProductModel product in model.Products)
                        {
                            OrderDetailModel orderDetail = new OrderDetailModel();
                            // Create data
                            orderDetail.Materials_id = product.Id;
                            orderDetail.Materials_type_id = product.TypeId;
                            orderDetail.Quantity = product.Quantity;
                            orderDetail.Price = product.Price.ToString();
                            orderDetail.TotalPay = (product.Price * product.Quantity).ToString();
                            orderDetail.Seri = string.Empty;

                            // Add to list order detail
                            updateModel.Order_detail.Add(orderDetail);
                        }
                        foreach (PromoteModel promote in model.Promotes)
                        {
                            OrderDetailModel orderDetail = new OrderDetailModel();
                            // Create data
                            orderDetail.Materials_id = promote.Id;
                            orderDetail.Materials_type_id = promote.TypeId;
                            orderDetail.Quantity = promote.Quantity;
                            orderDetail.Price = String.Empty;
                            orderDetail.TotalPay = String.Empty;
                            orderDetail.Seri = string.Empty;

                            // Add to list order detail
                            updateModel.Order_detail.Add(orderDetail);
                        }
                        foreach (CylinderModel cylinder in model.Cylinders)
                        {
                            OrderDetailModel orderDetail = new OrderDetailModel();
                            // Create data
                            orderDetail.Materials_id = cylinder.Id;
                            orderDetail.Materials_type_id = cylinder.TypeId;
                            orderDetail.Quantity = cylinder.Quantity;
                            orderDetail.Price = String.Empty;
                            orderDetail.TotalPay = String.Empty;
                            orderDetail.Seri = cylinder.Serial;

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
                        if (baseResp != null)
                        {
                            if (baseResp.Status == "1")
                            {
                                if (baseResp.Id != null)
                                {
                                    retVal = baseResp.Id;
                                }
                            }
                            else
                            {
                                ShowErrorMessage(baseResp.Message);
                            }
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
                        createModel.Token        = Properties.Settings.Default.UserToken;
                        createModel.Customer_id  = model.Customer.Id;
                        createModel.Note         = model.Note;
                        createModel.Status       = (int)model.Status;
                        //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
                        createModel.Created_date = model.Created_date;
                        //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
                        //++ BUG0056-SPJ (NguyenPT 20160830) Handle order type
                        createModel.Order_type       = model.Order_type;
                        createModel.Type_amount      = model.Type_amount;
                        //-- BUG0056-SPJ (NguyenPT 20160830) Handle order type
                        //++ BUG0068-SPJ (NguyenPT 20160905) Change promote money
                        if (model.IsManualChangePromote)
                        {
                            //++ BUG0078-SPJ (NguyenPT 20160925) Check if user change promote money manual to 0
                            //createModel.Amount_discount = model.PromoteMoney;
                            if (model.PromoteMoney != 0.0)
                            {
                                createModel.Amount_discount = model.PromoteMoney;
                            }
                            else
                            {
                                // Push 1.0 to server
                                createModel.Amount_discount = 1.0;
                            }
                            //-- BUG0078-SPJ (NguyenPT 20160925) Check if user change promote money manual to 0
                        }
                        else
                        {
                            createModel.Amount_discount = 0.0;
                        }
                        //-- BUG0068-SPJ (NguyenPT 20160905) Change promote money
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
                            orderDetail.Materials_id = product.Id;
                            orderDetail.Materials_type_id = product.TypeId;
                            orderDetail.Quantity = product.Quantity;
                            orderDetail.Price = product.Price.ToString();
                            orderDetail.TotalPay = (product.Price * product.Quantity).ToString();
                            orderDetail.Seri = string.Empty;

                            // Add to list order detail
                            createModel.Order_detail.Add(orderDetail);
                        }
                        foreach (PromoteModel promote in model.Promotes)
                        {
                            OrderDetailModel orderDetail = new OrderDetailModel();
                            // Create data
                            orderDetail.Materials_id = promote.Id;
                            orderDetail.Materials_type_id = promote.TypeId;
                            orderDetail.Quantity = promote.Quantity;
                            orderDetail.Price = String.Empty;
                            orderDetail.TotalPay = String.Empty;
                            orderDetail.Seri = string.Empty;

                            // Add to list order detail
                            createModel.Order_detail.Add(orderDetail);
                        }
                        foreach (CylinderModel cylinder in model.Cylinders)
                        {
                            OrderDetailModel orderDetail = new OrderDetailModel();
                            // Create data
                            orderDetail.Materials_id = cylinder.Id;
                            orderDetail.Materials_type_id = cylinder.TypeId;
                            orderDetail.Quantity = cylinder.Quantity;
                            orderDetail.Price = String.Empty;
                            orderDetail.TotalPay = String.Empty;
                            orderDetail.Seri = cylinder.Serial;

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
                        if (baseResp != null)
                        {
                            if (baseResp.Status == "1")
                            {
                                if (baseResp.Id != null)
                                {
                                    retVal = baseResp.Id;
                                }
                            }
                            else
                            {
                                ShowErrorMessage(baseResp.Message);
                            }
                        }
                    }
                }
            }
            return retVal;
        }
        /// <summary>
        /// Get agent ext.
        /// </summary>
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
        //++ BUG0008-SPJ (NguyenPT 20160830) Order history
        public static void RequestOrderHistory(string customerId, UploadProgressChangedEventHandler progressChanged,
            UploadValuesCompletedEventHandler completedHandler)
        {
            using (WebClient client = new WebClient())
            {
                client.UploadProgressChanged += new UploadProgressChangedEventHandler(progressChanged);
                client.UploadValuesCompleted += new UploadValuesCompletedEventHandler(completedHandler);
                string respStr = String.Empty;
                try
                {
                    // Post keyword to server
                    string value = string.Empty;
                    value = String.Format("{{\"token\":\"{0}\",\"customer_id\":\"{1}\"}}",
                        Properties.Settings.Default.UserToken, customerId);
                    client.UploadValuesAsync(
                        new Uri(Properties.Settings.Default.ServerURL + API_ORDER_HISTORY),
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
        //-- BUG0008-SPJ (NguyenPT 20160830) Order history
        public static void RequestNotifyReceived(string notifyId, string receiveId, string receivedName, string note)
        {
            using (WebClient client = new WebClient())
            {
                string respStr = String.Empty;
                try
                {
                    // Post keyword to server
                    string value = string.Empty;
                    value = String.Format("{{\"token\":\"{0}\", \"notify_id\":\"{1}\", \"received_id\":\"{2}\", \"received_name\":\"{3}\", \"note\":\"{4}\"}}",
                        Properties.Settings.Default.UserToken,
                        notifyId, receiveId, receivedName, note);
                    byte[] response = client.UploadValues(
                        API_NOTIFY_RECEIVED,
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
                        BaseResponseModel baseResp = null;
                        try
                        {
                            baseResp = (BaseResponseModel)js.ReadObject(msU);
                        }
                        catch (SerializationException e)
                        {
                            //ShowErrorMessage(Properties.Resources.ConvertJsonError, DataPure.Instance.MainForm);
                            HasError = true;
                        }
                        if (baseResp != null)
                        {
                            if (baseResp.Status == "1")
                            {
                                //ShowInformMessage("Đã xác nhận thành công", MessageBoxButtons.OK);
                                //ShowInformMessage("Đã xác nhận thành công", DataPure.Instance.MainForm);
                            }
                            else
                            {
                                //ShowErrorMessage(baseResp.Message, DataPure.Instance.MainForm);
                                HasError = true;
                            }
                        }
                    }
                }
            }
        }
        public static void HandleInformReceivedNotificationSuccess(string notifyId)
        {
            DataPure.Instance.MarkNotificationAsRead(notifyId);
            //if (DataPure.Instance.ListNotification.ContainsKey(notifyId))
            //{
            //    DataPure.Instance.ListNotification[notifyId].IsNew = false;
            //}
            ShowInformMessage(Properties.Resources.InformReceivedNotification, DataPure.Instance.MainForm);
            //int count = DataPure.Instance.GetNewNotificationCount();
            //if (count != 0)
            //{
            //    // Update notification label
            //    ((MainForm)DataPure.Instance.MainForm).SetNotificationLabel(count.ToString());
            //}
            //else
            //{
            //    // Update notification label
            //    ((MainForm)DataPure.Instance.MainForm).SetNotificationLabel(string.Empty);
            //}
            // Update notification label
            ((MainForm)DataPure.Instance.MainForm).SetNotificationLabel(DataPure.Instance.GetNewNotificationCount().ToString());
        }
        #endregion
    }
}
