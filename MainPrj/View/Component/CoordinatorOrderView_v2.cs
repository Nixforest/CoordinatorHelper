using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View.Component
{
    public partial class CoordinatorOrderView_v2 : UserControl
    {
        public CoordinatorOrderView_v2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Get data.
        /// </summary>
        /// <returns>Data string</returns>
        internal string GetData()
        {
            string retVal  = string.Empty;
            string b50 = string.Empty;
            string b45 = string.Empty;
            string b12 = string.Empty;
            string b6 = string.Empty;
            string spliter = ", ";
            if (nUDQuantityB50.Value != 0)
            {
                b50 = String.Format("{0} bình 50kg", nUDQuantityB50.Value);
            }
            if (nUDQuantityB45.Value != 0)
            {
                b45 = String.Format("{0} bình 45kg", nUDQuantityB45.Value);
            }
            if (nUDQuantityB12.Value != 0)
            {
                b12 = String.Format("{0} bình 12kg", nUDQuantityB12.Value);
            }
            if (nUDQuantityB6.Value != 0)
            {
                //++ BUG0064-SPJ (NguyenPT 20160831) Get 6kg value
                //b6 = String.Format("{0} bình 6kg", nUDQuantityB12.Value);
                b6 = String.Format("{0} bình 6kg", nUDQuantityB6.Value);
                //-- BUG0064-SPJ (NguyenPT 20160831) Get 6kg value
            }
            if (!String.IsNullOrEmpty(b50))
            {
                retVal = b50;
            }
            if (!String.IsNullOrEmpty(b45))
            {
                if (!String.IsNullOrEmpty(retVal))
                {
                    retVal += spliter + b45;
                }
                else
                {
                    retVal = b45;
                }
            }
            if (!String.IsNullOrEmpty(b12))
            {
                if (!String.IsNullOrEmpty(retVal))
                {
                    retVal += spliter + b12;
                }
                else
                {
                    retVal = b12;
                }
            }
            if (!String.IsNullOrEmpty(b6))
            {
                if (!String.IsNullOrEmpty(retVal))
                {
                    retVal += spliter + b6;
                }
                else
                {
                    retVal = b6;
                }
            }
            if (String.IsNullOrEmpty(retVal))
            {
                return retVal;
            }

            string formatStr = "{0}: {1}";
            if (String.IsNullOrEmpty(tbxNote.Text))
            {
                formatStr = "{0}{1}";
            }
            retVal = String.Format(formatStr,
                retVal,
                tbxNote.Text);

            return retVal;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbxNote_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
