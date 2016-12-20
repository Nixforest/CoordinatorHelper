using MainPrj.Model;
using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class SelectCallTypeView : Form
    {
        /// <summary>
        /// List reason.
        /// </summary>
        private List<SelectorModel> _listReason = new List<SelectorModel>();

        /// <summary>
        /// Call type.
        /// </summary>
        private String _callType = String.Empty;

        public String CallType
        {
            get { return _callType; }
            set { _callType = value; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public SelectCallTypeView(CallModel data, string currentValue)
        {
            InitializeComponent();
            this.selectCallTypeControl.UpdateData(data, currentValue);
            //this.CallType = currentValue;
            //// Get list current type call
            //string[] listCurrentValue = currentValue.Split(Properties.Resources.SPLITER_STR[0]);
            //this._listReason = DataPure.Instance.GetListCallType();
            //int offset = 12;
            //int margin = 12;
            //int width = this.Size.Width - 4 * margin;
            //int height = 50;
            //foreach (BaseModel model in this._listReason)
            //{
            //    CheckBox cbx                = new CheckBox();
            //    cbx.Appearance              = System.Windows.Forms.Appearance.Button;
            //    cbx.AutoSize                = false;
            //    cbx.Location                = new System.Drawing.Point(margin, offset);
            //    cbx.Name                    = model.Id;
            //    cbx.Size                    = new System.Drawing.Size(width, height);
            //    cbx.TabIndex                = 0;
            //    cbx.Text                    = model.Name;
            //    cbx.UseVisualStyleBackColor = true;
            //    cbx.BackColor               = CommonProcess.ConvertColorFromString(Properties.Resources.COLOR_BUTTON_NORMAL);
            //    cbx.ForeColor               = Color.White;
            //    cbx.TextAlign               = ContentAlignment.MiddleCenter;
            //    cbx.Anchor                  = AnchorStyles.Left | AnchorStyles.Right;
            //    offset                     += height + margin;
            //    cbx.CheckedChanged         += cbx_CheckedChanged;
            //    if (listCurrentValue.Contains(model.Id))
            //    {
            //        cbx.Checked = true;
            //    }
            //    this.Controls.Add(cbx);
            //}

        }

        /// <summary>
        /// Handle check changed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        void cbx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = sender as CheckBox;
            if (cbx.Checked)
            {
                cbx.BackColor = CommonProcess.ConvertColorFromString(Properties.Resources.COLOR_BUTTON_SELECTED);
            }
            else
            {
                cbx.BackColor = CommonProcess.ConvertColorFromString(Properties.Resources.COLOR_BUTTON_NORMAL);
            }
        }

        /// <summary>
        /// Handle OK button press.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //this.CallType = string.Empty;
            //// Get all type call by checkbox status
            //foreach (Control control in this.Controls)
            //{
            //    if (control is CheckBox)
            //    {
            //        if ((control as CheckBox).Checked)
            //        {
            //            this.CallType += control.Name + Properties.Resources.SPLITER_STR;
            //        }
            //    }
            //}
            //// Remove last spliter
            //if (!string.IsNullOrEmpty(this.CallType))
            //{
            //    this.CallType = this.CallType.Remove(this.CallType.Length - 1);
            //}
            this.Close();
        }
    }
}
