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
    public partial class CoordinatorOrderView : UserControl
    {
        public CoordinatorOrderView()
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
            string gasType = string.Empty;
            string color   = string.Empty;
            gasType = rbtnSmall.Checked ? rbtnSmall.Text            // Small
                : (rbtnLarge.Checked ? rbtnLarge.Text               // Large
                    : rbtnLarge50.Text);                            // Large 50kg
            color = rbtnNoColor.Checked ? string.Empty              // No color
                : (rbtnRed.Checked ? rbtnRed.Text                   // Red
                    : (rbtnBlue.Checked ? rbtnBlue.Text             // Blue
                        : (rbtnYellow.Checked ? rbtnYellow.Text     // Yellow
                            : (rbtnGrey.Checked ? rbtnGrey.Text     // Grey
                                : rbtnOrange.Text))));              // Orange
            string formatStr = "{0} bình {1} {2}: {3}";
            if (String.IsNullOrEmpty(tbxNote.Text))
            {
                formatStr = "{0} bình {1} {2}{3}";
            }
            retVal = String.Format(formatStr,
                nUDQuantity.Value,
                gasType,
                color,
                tbxNote.Text);

            return retVal;
        }
    }
}
