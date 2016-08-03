using System;
using System.Collections.Generic;
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
                }
                else
                {
                    // <CRMV1               0002     2016-08-02 16:15:00                               0939331371                    >                                          172.16.1.64                                       {RAWCID:[0939331371]}{DETAILDES:[]}
                    Regex regData = new Regex(@"^\<CRMV1\s*?(?<channel>.*)\s+\d*\-\d*\-\d*\s\d*:\d*:\d*\s*?(?<phone>.*)\s*\>\s*?(?<sourceIP>.*)\s*\{RAWCID:.*?\}",
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
                        status = (int)CardDataStatus.CARDDATA_HANDLING;
                    }
                }
            }
        }
    }
}
