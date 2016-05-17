using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinatorHelper.Model
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
        private string channel = "";

        public string Channel
        {
            get { return channel; }
            set { channel = value; }
        }
        /// <summary>
        /// Fifth field.
        /// </summary>
        private string fifth = "";

        public string Fifth
        {
            get { return fifth; }
            set { fifth = value; }
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
            if (data != null)
            {
                string[] arrDataBuf = data.Split(',');
                if (arrDataBuf.Length == (int)CardDataType.CARDDATA_NUM)
                {
                    first = arrDataBuf[(int)CardDataType.CARDDATA_TYPE1];
                    phone = arrDataBuf[(int)CardDataType.CARDDATA_PHONE];
                    third = arrDataBuf[(int)CardDataType.CARDDATA_TYPE3];
                    channel = arrDataBuf[(int)CardDataType.CARDDATA_CHANNEL];
                    fifth = arrDataBuf[(int)CardDataType.CARDDATA_TYPE5];
                    sixth = arrDataBuf[(int)CardDataType.CARDDATA_TYPE6];
                }
            }
        }
    }
}
