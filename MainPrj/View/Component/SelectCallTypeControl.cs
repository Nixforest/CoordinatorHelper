using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MainPrj.Model;
using MainPrj.Util;

namespace MainPrj.View.Component
{
    public partial class SelectCallTypeControl : UserControl
    {
        /// <summary>
        /// List reason.
        /// </summary>
        private List<SelectorModel> _listReason = new List<SelectorModel>();
        /// <summary>
        /// Data model.
        /// </summary>
        private CallModel _data = null;

        /// <summary>
        /// Call type.
        /// </summary>
        private String _callType = String.Empty;

        public String CallType
        {
            get { return _callType; }
            set { _callType = value; }
        }
        //public SelectCallTypeControl(string currentValue)
        //{
        //    InitializeComponent();
        //    this.CallType = currentValue;
        //    // Get list current type call
        //    string[] listCurrentValue = currentValue.Split(GlobalConst.SPLITER_CHR);
        //    this._listReason = DataPure.Instance.GetListCallType();
        //    int offset = 12;
        //    int margin = 12;
        //    int width = this.flowLayoutPanel.Width - 2 * margin;
        //    int height = 50;
        //    foreach (BaseModel model in this._listReason)
        //    {
        //        CheckBox cbx                = new CheckBox();
        //        cbx.Appearance              = System.Windows.Forms.Appearance.Button;
        //        cbx.AutoSize                = false;
        //        cbx.Location                = new System.Drawing.Point(margin, offset);
        //        cbx.Name                    = model.Id;
        //        cbx.Size                    = new System.Drawing.Size(width, height);
        //        cbx.TabIndex                = 0;
        //        cbx.Text                    = model.Name;
        //        cbx.UseVisualStyleBackColor = true;
        //        cbx.BackColor               = CommonProcess.ConvertColorFromString(GlobalConst.COLOR_BUTTON_NORMAL);
        //        cbx.ForeColor               = Color.White;
        //        cbx.TextAlign               = ContentAlignment.MiddleCenter;
        //        cbx.Anchor                  = AnchorStyles.Left | AnchorStyles.Right;
        //        offset                     += height + margin;
        //        cbx.CheckedChanged         += cbx_CheckedChanged;
        //        if (listCurrentValue.Contains(model.Id))
        //        {
        //            cbx.Checked = true;
        //        }
        //        this.flowLayoutPanel.Controls.Add(cbx);
        //    }
        //}
        /// <summary>
        /// Update data for control
        /// </summary>
        /// <param name="data"></param>
        /// <param name="currentValue"></param>
        public void UpdateData(CallModel data, string currentValue = "")
        {
            this.CallType = currentValue;
            // Get list current type call
            string[] listCurrentValue = currentValue.Split(GlobalConst.SPLITER_CHR);
            // Get list current type call
            this._listReason = DataPure.Instance.GetListCallType();
            int offset = 12;
            int margin = 4;
            int width = this.flowLayoutPanel.Size.Width - 2 * margin;
            int height = 50;
            this.flowLayoutPanel.Controls.Clear();
            foreach (BaseModel model in this._listReason)
            {
                CheckBox cbx                = new CheckBox();
                cbx.Appearance              = System.Windows.Forms.Appearance.Button;
                cbx.AutoSize                = false;
                cbx.Location                = new System.Drawing.Point(margin, offset);
                cbx.Name                    = model.Id;
                cbx.Size                    = new System.Drawing.Size(width, height);
                cbx.TabIndex                = 0;
                cbx.Text                    = model.Name;
                cbx.UseVisualStyleBackColor = true;
                cbx.BackColor               = CommonProcess.ConvertColorFromString(GlobalConst.COLOR_BUTTON_NORMAL);
                cbx.ForeColor               = Color.White;
                cbx.TextAlign               = ContentAlignment.MiddleCenter;
                cbx.Anchor                  = AnchorStyles.Left | AnchorStyles.Right;
                offset                     += height + margin;
                cbx.CheckedChanged += cbx_CheckedChanged;
                if (listCurrentValue.Contains(model.Id))
                {
                    cbx.Checked = true;
                }
                //this.Controls.Add(cbx);
                this.flowLayoutPanel.Controls.Add(cbx);
            }
            this.flowLayoutPanel.Update();
            if (data != null)
            {
                this._data = data;
            }
        }
        public SelectCallTypeControl()
        {
            InitializeComponent();
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
                cbx.BackColor = CommonProcess.ConvertColorFromString(GlobalConst.COLOR_BUTTON_SELECTED);
            }
            else
            {
                cbx.BackColor = CommonProcess.ConvertColorFromString(GlobalConst.COLOR_BUTTON_NORMAL);
            }
            this.CallType = string.Empty;
            // Get all type call by checkbox status
            foreach (Control control in this.flowLayoutPanel.Controls)
            {
                if (control is CheckBox)
                {
                    if ((control as CheckBox).Checked)
                    {
                        this.CallType += control.Name + GlobalConst.SPLITER_STR;
                    }
                }
            }
            // Remove last spliter
            if (!string.IsNullOrEmpty(this.CallType))
            {
                this.CallType = this.CallType.Remove(this.CallType.Length - 1);
            }
            if (this._data != null)
            {
                this._data.Type_call = this.CallType;
            }
            //++ BUG0006-SPJ (NguyenPT 20161118) Call history
            // Mark this call is not updated to server yet
            this._data.IsUpdateToServer = false;
            //-- BUG0006-SPJ (NguyenPT 20161118) Call history
        }
    }
}
