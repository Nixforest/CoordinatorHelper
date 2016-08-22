﻿using MainPrj.Model;
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
    public partial class FinishOrderView : Form
    {
        //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        //private string id = string.Empty;
        private OrderModel _data = null;
        //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        private string deliverId = string.Empty;
        /// <summary>
        /// Deliver id.
        /// </summary>
        public string DeliverId
        {
            get { return deliverId; }
            set { deliverId = value; }
        }

        //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        ///// <summary>
        ///// Order's id.
        ///// </summary>
        //public string Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}
        //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        private List<CylinderModel> cylinders = new List<CylinderModel>();
        /// <summary>
        /// Constructor.
        /// </summary>
        //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        //public FinishOrderView(string id)
        public FinishOrderView(OrderModel data)
        //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        {
            InitializeComponent();
            //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
            //this.Id = id;
            _data = data;
            //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        }
        /// <summary>
        /// Handle when click Finish button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
            //if (!string.IsNullOrEmpty(id))
            //{
            //    foreach (OrderModel item in DataPure.Instance.ListOrders)
            //    {
            //        if (item.Id.Equals(id))
            //        {
            //            item.Cylinders.Clear();
            //            item.Cylinders.AddRange(cylinders);
            //            if (cylinders.Count < item.Products.Count)
            //            {
            //                for (int i = 0; i < (item.Products.Count - cylinders.Count); i++)
            //                {
            //                    item.Cylinders.Add(new CylinderModel());
            //                }
            //            }
            //            item.Status           = OrderStatus.ORDERSTATUS_PAID;
            //            item.IsUpdateToServer = false;
            //            if (cbxDeliver.SelectedValue != null)
            //            {
            //                item.DeliverId = cbxDeliver.SelectedValue.ToString();
            //            }
            //            // Update to server
            //            string retId = CommonProcess.UpdateOrderToServer(item);
            //            if (!String.IsNullOrEmpty(retId))
            //            {
            //                item.IsUpdateToServer = true;
            //            }
            //            if (chbPromote.Checked)
            //            {
            //                item.Promotes.Clear();
            //                item.PromoteMoney = Properties.Settings.Default.PromoteMoney;
            //                item.TotalPay -= item.PromoteMoney;
            //            }
            //            break;
            //        }
            //    }

            //    this.Close();
            //}
            if (_data != null)
            {
                _data.Cylinders.Clear();
                _data.Cylinders.AddRange(cylinders);
                if (cylinders.Count < _data.Products.Count)
                {
                    for (int i = 0; i < (_data.Products.Count - cylinders.Count); i++)
                    {
                        _data.Cylinders.Add(new CylinderModel());
                    }
                }
                _data.Status           = OrderStatus.ORDERSTATUS_PAID;
                _data.IsUpdateToServer = false;
                if (cbxDeliver.SelectedValue != null)
                {
                    _data.DeliverId = cbxDeliver.SelectedValue.ToString();
                }
                if (chbPromote.Checked)
                {
                    _data.Promotes.Clear();
                    _data.PromoteMoney = Properties.Settings.Default.PromoteMoney;
                    _data.TotalPay -= _data.PromoteMoney;
                }
                // Update to server
                string retId = CommonProcess.UpdateOrderToServer(_data);
                if (!String.IsNullOrEmpty(retId))
                {
                    _data.IsUpdateToServer = true;
                    CommonProcess.UpdateOrderToFile(_data);
                }
            }
            this.Close();
            //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        }
        /// <summary>
        /// Handle when open form
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void FinishOrderView_Load(object sender, EventArgs e)
        {
            //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
            //if (!string.IsNullOrEmpty(id))
            //{
            //    foreach (OrderModel item in DataPure.Instance.ListOrders)
            //    {
            //        if (item.Id.Equals(id))
            //        {
            //            foreach (CylinderModel cylinder in item.Cylinders)
            //            {
            //                if (!String.IsNullOrEmpty(cylinder.Id))
            //                {
            //                    cylinders.Add(cylinder);
            //                }
            //            }
            //            lblTotalPay.Text = CommonProcess.FormatMoney(item.TotalPay);
            //            this.deliverId = !String.IsNullOrEmpty(item.DeliverId) ? item.DeliverId : item.CCSId;
            //            //cylinders.AddRange(item.Cylinders);
            //            if (item.Promotes.Count == 0)
            //            {
            //                chbPromote.Enabled = false;
            //            }
            //            break;
            //        }
            //    }
            //}
            if (_data != null)
            {
                foreach (CylinderModel cylinder in _data.Cylinders)
                {
                    if (!String.IsNullOrEmpty(cylinder.Id))
                    {
                        cylinders.Add(cylinder);
                    }
                }
                lblTotalPay.Text = CommonProcess.FormatMoney(_data.TotalPay);
                this.deliverId = !String.IsNullOrEmpty(_data.DeliverId) ? _data.DeliverId : _data.CCSId;
                if (_data.Promotes.Count == 0)
                {
                    chbPromote.Enabled = false;
                }
            }
            //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
            int index = 0;
            foreach (CylinderModel item in cylinders)
            {
                if (!String.IsNullOrEmpty(item.Id))
                {
                    this.listViewCylinder.Items.Add(CreateListViewItem(item, ++index));
                }
            }
            this.listViewCylinder.ColumnTypes = new List<Type>
            {
                null,
                null,
                null,
                typeof(ComboBox),
                typeof(TextBox)
            };
            List<object> itemsQuantity = new List<object>();
            itemsQuantity.Add(new { Text = string.Empty, Value = string.Empty });
            for (int i = 0; i < 50; i++)
            {
                itemsQuantity.Add(new { Text = i + 1, Value = i + 1 });
            }
            this.listViewCylinder.Combobox.Items.Clear();
            this.listViewCylinder.Combobox.Items.AddRange(itemsQuantity.ToArray());
            this.listViewCylinder.SubItemEndEditing += new SubItemEndEditingEventHandler(listViewCylinder_SubItemEndEditing);

            // Check null object
            if (DataPure.Instance.User != null)
            {
                // Check null object
                if (DataPure.Instance.TempData != null)
                {
                    // Deliver
                    List<object> items = new List<object>();
                    foreach (SelectorModel item in DataPure.Instance.GetListDelivers())
                    {
                        items.Add(new { Text = item.Name, Value = item.Id });
                    }
                    foreach (SelectorModel item in DataPure.Instance.GetListCCSs())
                    {
                        items.Add(new { Text = item.Name + Properties.Resources.CCSSuffix, Value = item.Id });
                    }
                    cbxDeliver.DataSource = items;
                    cbxDeliver.SelectedValue = this.DeliverId;
                }
            }
        }
        /// <summary>
        /// Create listview item.
        /// </summary>
        /// <param name="model">Cylinder Model</param>
        /// <param name="index">Index</param>
        /// <returns>ListViewItem</returns>
        private ListViewItem CreateListViewItem(CylinderModel model, int index)
        {
            // Create array data
            string[] arr = new string[(int)CylinderColumns.CYLINDER_COLUMN_NUM];
            // No column
            arr[(int)CylinderColumns.CYLINDER_COLUMN_NO] = String.Format("{0}", index);
            // Id column
            arr[(int)CylinderColumns.CYLINDER_COLUMN_ID] = model.Materials_no;
            // Name column
            arr[(int)CylinderColumns.CYLINDER_COLUMN_NAME] = model.Name;
            // Quantity column
            if (model.Quantity != 0)
            {
                arr[(int)CylinderColumns.CYLINDER_COLUMN_QUANTITY] = String.Format("{0}", model.Quantity);
            }
            else
            {
                arr[(int)CylinderColumns.CYLINDER_COLUMN_QUANTITY] = String.Empty;
            }
            // Serial column
            arr[(int)CylinderColumns.CYLINDER_COLUMN_SERIAL] = model.Serial;
            // Create listview item object
            ListViewItem item = new ListViewItem(arr);
            // Set tag value
            item.Tag = model.Id;

            return item;
        }
        /// <summary>
        /// Handle when lost focus from search textbox.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbxSearch.Text.Trim()))
            {
                this.tbxSearch.Text      = Properties.Resources.SearchString;
                this.tbxSearch.ForeColor = SystemColors.GrayText;
            }
        }
        /// <summary>
        /// Handle when focus into search textbox.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxSearch_Enter(object sender, EventArgs e)
        {
            if (this.tbxSearch.Text.Equals(Properties.Resources.SearchString))
            {
                this.tbxSearch.Text      = string.Empty;
                this.tbxSearch.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// Handle when Keydown event is fired.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">KeyEventArgs</param>
        private void FinishOrderView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (tbxSearch.Focused)
                    {
                        HandleAddCylinder();
                    }
                    break;
                case Keys.Delete:
                    if (listViewCylinder.Focused)
                    {
                        HandleDeleteCylinders();
                    }
                    break;
                default: break;
            }
        }
        /// <summary>
        /// Handle delete cylinders row.
        /// </summary>
        private void HandleDeleteCylinders()
        {
            if (this.listViewCylinder.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listViewCylinder.SelectedItems)
                {
                    string id = item.Tag.ToString();
                    foreach (CylinderModel model in cylinders)
                    {
                        if (model.Id.Equals(id))
                        {
                            cylinders.Remove(model);
                            break;
                        }
                    }
                }
                ReloadListCylinders();
            }
        }
        /// <summary>
        /// Handle add cylinders.
        /// </summary>
        private void HandleAddCylinder()
        {
            List<SelectorModel> listSelector = new List<SelectorModel>();
            List<MaterialModel> searchResult = new List<MaterialModel>();
            if (DataPure.Instance.TempData != null)
            {
                if (DataPure.Instance.TempData.Material_vo != null)
                {
                    searchResult = CommonProcess.SearchMaterial(tbxSearch.Text.Trim(),
                        DataPure.Instance.TempData.Material_vo.ToList());
                }
            }
            // Create list selector from search result
            foreach (MaterialModel item in searchResult)
            {
                listSelector.Add(new SelectorModel
                {
                    Id     = item.Materials_no,
                    Name   = item.Name,
                    Detail = item.Label
                });
            }
            // Create SelectorView
            SelectorView selectorView = new SelectorView();
            selectorView.ListData     = listSelector;
            selectorView.Text         = Properties.Resources.SelectorTitleCylinder;
            // Change header
            selectorView.SetHeaderText(SelectorColumns.SELECTOR_COLUMN_ADDRESS, Properties.Resources.Detail);
            selectorView.ShowDialog();
            // Get selected id
            string selectedId = selectorView.SelectedId;
            if (!string.IsNullOrEmpty(selectedId))
            {
                foreach (MaterialModel item in searchResult)
                {
                    if (selectedId.Equals(item.Materials_no))
                    {
                        CylinderModel model = new CylinderModel
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Quantity = 1,
                            Serial = String.Empty,
                            TypeId = item.Materials_type_id,
                            Materials_no = item.Materials_no
                        };
                        foreach (CylinderModel cylinder in cylinders)
                        {
                            if (cylinder.Id.Equals(model.Id))
                            {
                                cylinder.Quantity += 1;
                                model = null;
                                break;
                            }
                        }
                        if (model != null)
                        {
                            cylinders.Add(model);
                        }
                        ReloadListCylinders();
                        this.btnFinish.Focus();
                        break;
                    }
                }
            }
        }
        private void ReloadListCylinders()
        {
            listViewCylinder.Items.Clear();
            int index = 0;
            foreach (CylinderModel item in cylinders)
            {
                if (!String.IsNullOrEmpty(item.Id))
                {
                    listViewCylinder.Items.Add(CreateListViewItem(item, ++index));
                }
            }
        }

        private void listViewCylinder_SubItemEndEditing(object sender, SubItemEndEditingEventArgs e)
        {
            CylinderColumns column = (CylinderColumns)e.SubItem;
            switch (column)
            {
                case CylinderColumns.CYLINDER_COLUMN_NO:
                    break;
                case CylinderColumns.CYLINDER_COLUMN_ID:
                    break;
                case CylinderColumns.CYLINDER_COLUMN_NAME:
                    break;
                case CylinderColumns.CYLINDER_COLUMN_QUANTITY:
                    if (this.listViewCylinder.SelectedItems.Count > 0)
                    {
                        // Get tag value
                        string id = this.listViewCylinder.SelectedItems[0].Tag.ToString();
                        if (!String.IsNullOrEmpty(id))
                        {
                            foreach (CylinderModel item in cylinders)
                            {
                                if (item.Id.Equals(id))
                                {
                                    string quantityStr = e.DisplayText;
                                    int quantity = item.Quantity;
                                    // Check editing value is valid or not
                                    if (int.TryParse(quantityStr, out quantity))
                                    {
                                        // Update data
                                        item.Quantity = quantity;
                                    }
                                    else
                                    {
                                        // Reset display
                                        e.DisplayText = item.Quantity.ToString();
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case CylinderColumns.CYLINDER_COLUMN_SERIAL:
                    if (this.listViewCylinder.SelectedItems.Count > 0)
                    {
                        // Get tag value
                        string id = this.listViewCylinder.SelectedItems[0].Tag.ToString();
                        if (!String.IsNullOrEmpty(id))
                        {
                            foreach (CylinderModel item in cylinders)
                            {
                                if (item.Id.Equals(id))
                                {
                                    item.Serial = e.DisplayText;
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case CylinderColumns.CYLINDER_COLUMN_NUM:
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// Cylinder columns
    /// </summary>
    public enum CylinderColumns
    {
        CYLINDER_COLUMN_NO,
        CYLINDER_COLUMN_ID,
        CYLINDER_COLUMN_NAME,
        CYLINDER_COLUMN_QUANTITY,
        CYLINDER_COLUMN_SERIAL,
        CYLINDER_COLUMN_NUM
    }
}
