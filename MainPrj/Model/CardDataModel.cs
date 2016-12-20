using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MainPrj
{
    public class CardDataModel
    {
        /// <summary>
        /// First field.
        /// </summary>
        private string first = "";

        public string First
        {
            get { return first; }
            set { first = value; }
        }
        /// <summary>
        /// Phone.
        /// </summary>
        private string phone = "";

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        /// <summary>
        /// Third field.
        /// </summary>
        private string third = "";

        public string Third
        {
            get { return third; }
            set { third = value; }
        }
        /// <summary>
        /// Fourth field.
        /// </summary>
        private int channel = -1;

        public int Channel
        {
            get { return channel; }
            set { channel = value; }
        }
        /// <summary>
        /// Fifth field.
        /// </summary>
        private int status = -1;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// Sixth field.
        /// </summary>
        private string sixth = "";

        public string Sixth
        {
            get { return sixth; }
            set { sixth = value; }
        }
        //++ BUG0091-SPJ (NguyenPT 20161216) Handle packet from Zibosoft record card
        private static string[] lastPhone = new string[] {
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty
        };
        public static string[][] lastRecord = new string[][] {
            new string[] { string.Empty, string.Empty, string.Empty },
            new string[] { string.Empty, string.Empty, string.Empty },
            new string[] { string.Empty, string.Empty, string.Empty },
            new string[] { string.Empty, string.Empty, string.Empty },
            new string[] { string.Empty, string.Empty, string.Empty },
            new string[] { string.Empty, string.Empty, string.Empty },
            new string[] { string.Empty, string.Empty, string.Empty },
            new string[] { string.Empty, string.Empty, string.Empty }
        };
        //-- BUG0091-SPJ (NguyenPT 20161216) Handle packet from Zibosoft record card

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">String data</param>
        public CardDataModel(string data)
        {
            int n;
            if (data != null)
            {
                if (data.StartsWith("txIP"))
                {
                    string[] arrDataBuf = data.Split(',');
                    if (arrDataBuf.Length == (int)CardDataType.CARDDATA_NUM)
                    {
                        first = arrDataBuf[(int)CardDataType.CARDDATA_TYPE1];
                        phone = arrDataBuf[(int)CardDataType.CARDDATA_PHONE];
                        third = arrDataBuf[(int)CardDataType.CARDDATA_TYPE3];
                        string channelStr = arrDataBuf[(int)CardDataType.CARDDATA_CHANNEL];
                        if (!String.IsNullOrEmpty(channelStr))
                        {
                            if (int.TryParse(channelStr, out n))
                            {
                                channel = n - 1;
                            }
                        }
                        string statusStr = arrDataBuf[(int)CardDataType.CARDDATA_STATUS];
                        if (!String.IsNullOrEmpty(statusStr))
                        {
                            if (int.TryParse(statusStr, out n))
                            {
                                status = n - 1;
                            }
                        }
                        sixth = arrDataBuf[(int)CardDataType.CARDDATA_TYPE6];
                    }
                    //++ BUG0091-SPJ (NguyenPT 20161216) Handle packet from Zibosoft record card
                    // Reset last phone value
                    lastPhone[channel]  = String.Empty;
                    lastRecord[channel] = new string[] { string.Empty, string.Empty, string.Empty };
                    //-- BUG0091-SPJ (NguyenPT 20161216) Handle packet from Zibosoft record card
                }
                else
                {
                    //++ BUG0091-SPJ (NguyenPT 20161216) Handle packet from Zibosoft record card
                    string logData = string.Empty;
                    if (data.StartsWith("<CRMV"))
                    {
                        // <CRMV1               0002     2016-08-02 16:15:00                               0939331371                    >                                          172.16.1.64                                       {RAWCID:[0939331371]}{DETAILDES:[]}
                        Regex regData = new Regex(@"^\<CRMV1\s*?(?<channel>.*)\s+(?<time>\d*)\-(?<time1>\d*)\-(?<time2>\d*)\s(?<time3>\d*):(?<time4>\d*):(?<time5>\d*)\s*?(?<phone>.*)\s*\>\s*?(?<sourceIP>.*)\s*\{RAWCID:.*?\}",
                            RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Multiline);

                        // FROM
                        Match m = regData.Match(data);
                        if (m.Success)
                        {
                            phone = m.Groups["phone"].Value.ToString().Trim();
                            string channelStr = m.Groups["channel"].Value.ToString().Trim();
                            if (!String.IsNullOrEmpty(channelStr))
                            {
                                if (int.TryParse(channelStr, out n))
                                {
                                    channel = n - 1;
                                }
                            }
                            //++ BUG0085-SPJ (NguyenPT 20161117) Fix bug
                            //status = (int)CardDataStatus.CARDDATA_HANDLING;
                            status = (int)CardDataStatus.CARDDATA_RINGING;
                            //-- BUG0085-SPJ (NguyenPT 20161117) Fix bug
                            // Reset last phone value
                            lastPhone[channel]   = phone;
                            logData = String.Format("Gọi đến: {0}-{1}",channelStr, 
                                String.Format("{0}{1}{2} {3}{4}{5}",
                                m.Groups["time"].Value.ToString(),
                                m.Groups["time1"].Value.ToString(),
                                m.Groups["time2"].Value.ToString(),
                                m.Groups["time3"].Value.ToString(),
                                m.Groups["time4"].Value.ToString(),
                                m.Groups["time5"].Value.ToString()));
                            lastRecord[channel] = new string[] { string.Empty, string.Empty, string.Empty };
                        }
                    }
                    else
                    {
                        // CHANNELSTATUS {{{STATUS:[HANGUP]  CHANNEL:[000] {DATA:[]}}}
                        // CHANNELSTATUS {{{STATUS:[DIAL]    CHANNEL:[000] {DATA:[*]}}}
                        // CHANNELSTATUS {{{STATUS:[OFFHOOK] CHANNEL:[000] {DATA:[]}}}
                        Regex regData = new Regex(@"^CHANNELSTATUS\s*?\{\{\{STATUS\:\[(?<calltype>.*)\]\s*?CHANNEL\:\[(?<channel>.*)\]\s*?\{DATA\:\[.*?\]\}\}\}",
                            RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Multiline);

                        DateTime now = System.DateTime.Now;
                        Match m = regData.Match(data);
                        if (m.Success)
                        {
                            String callType   = m.Groups["calltype"].Value.ToString();
                            string channelStr = m.Groups["channel"].Value.ToString().Trim();
                            if (!String.IsNullOrEmpty(channelStr))
                            {
                                if (int.TryParse(channelStr, out n))
                                {
                                    channel = n;
                                }
                            }
                            phone             = lastPhone[channel];
                            switch (callType)
                            {
                                case "OFFHOOK":
                                    status = (int)CardDataStatus.CARDDATA_HANDLING;
                                    logData = String.Format("Nhấc máy: {0}-{1}", (channel + 1).ToString("D4"), now.ToString("yyyyMMdd HHmmss"));
                                    lastRecord[channel][0] = String.Format("{0}{1}{2}1N.VC2",
                                        now.ToString("yyyyMMddHHmmss"),
                                        (channel + 1).ToString("D4"),
                                        phone);
                                    lastRecord[channel][1] = String.Format("{0}{1}{2}{3}1N.VC2",
                                        now.ToString("yyyyMMddHHmm"),
                                        (now.AddSeconds(-1)).Second.ToString("D2"),
                                        (channel + 1).ToString("D4"),
                                        phone);
                                    lastRecord[channel][2] = String.Format("{0}{1}{2}{3}1N.VC2",
                                        now.ToString("yyyyMMddHHmm"),
                                        (now.AddSeconds(1)).Second.ToString("D2"),
                                        (channel + 1).ToString("D4"),
                                        phone);
                                    //lastRecord[channel][3] = String.Format("{0}{1}{2}{3}1N.VC2",
                                    //    now.ToString("yyyyMMddHHmm"),
                                    //    (now.AddSeconds(1)).ToString("D2"),
                                    //    (channel + 1).ToString("D3"),
                                    //    phone);
                                    //lastRecord[channel][4] = String.Format("{0}{1}{2}{3}1N.VC2",
                                    //    now.ToString("yyyyMMddHHmm"),
                                    //    (now.AddSeconds(2)).ToString("D2"),
                                    //    (channel + 1).ToString("D3"),
                                    //    phone);
                                    break;
                                case "DIAL":
                                    status = (int)CardDataStatus.CARDDATA_HANDLING;
                                    break;
                                case "HANGUP":
                                    logData = String.Format("Cúp máy: {0}-{1}", (channel + 1).ToString("D4"), now.ToString("yyyyMMdd HHmmss"));
                                    status = (int)CardDataStatus.CARDDATA_HANGUP;
                                    break;
                                default:
                                    break;
                            }
                            if (status.Equals((int)CardDataStatus.CARDDATA_HANGUP))
                            {
                                string filepath = Properties.Resources.ZIBOSOFT_RECORD_FILEPATH_DEFAULT;
                                filepath += @"\" + now.ToString(Properties.Resources.RecordDateTimeFormat);
                                string result = string.Empty;
                                foreach (var item in lastRecord[channel])
                                {
                                    if (File.Exists(String.Format(@"{0}\{1}", filepath, item)))
                                    {
                                        result = item;
                                        break;
                                    }
                                }
                                lastRecord[channel] = new string[] { String.Format(@"{0}\{1}", filepath, result), string.Empty, string.Empty };
                                // Reset last value
                                lastPhone[channel] = string.Empty;
                            }
                        }
                    }
                    //-- BUG0091-SPJ (NguyenPT 20161216) Handle packet from Zibosoft record card

                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        LogUtility.Log(logData, w);
                    }
                }
            }
        }
    }
}
