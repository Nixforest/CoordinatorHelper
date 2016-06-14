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
    public partial class ListOrderView : Form
    {
        /// <summary>
        /// List of data which search result.
        /// </summary>
        private List<OrderModel> listDataSearch = new List<OrderModel>();
        private int totalGas      = 0;
        private int totalGasStove = 0;
        private int totalVan      = 0;
        private double totalPay   = 0.0;
        private int totalCylinder = 0;
        /// <summary>
        /// Constructor.
        /// </summary>
        public ListOrderView()
        {
            InitializeComponent();
        }
        private void UpdateTotal()
        {
            totalGas      = 0;
            totalGasStove = 0;
            totalVan      = 0;
            totalPay   = 0.0;
            totalCylinder = 0;

            foreach (OrderModel item in DataPure.Instance.ListOrders)
            {
                // Total gas
                foreach (ProductModel product in item.Products)
                {
                    if (product.IsGas())
                    {
                        totalGas += product.Quantity;
                    }
                }

                // Total Cylinder
                foreach (CylinderModel cylinder in item.Cylinders)
                {
                    if (!String.IsNullOrEmpty(cylinder.Id))
                    {
                        totalCylinder += cylinder.Quantity;
                    }
                }
                // Total pay
                totalPay += item.TotalPay;
            }
            lblTotalGas.Text = totalGas.ToString();
            lblGasStove.Text = totalGasStove.ToString();
            lblVan.Text      = totalVan.ToString();
            lblCylinder.Text = totalCylinder.ToString();
            lblTotalPay.Text = CommonProcess.FormatMoney(totalPay);
        }
        /// <summary>
        /// Handle click button Clear.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxSearch.Text      = Properties.Resources.SearchString;
            tbxSearch.ForeColor = SystemColors.GrayText;
            this.listDataSearch.Clear();
            LoadListView(DataPure.Instance.ListOrders);
        }
        /// <summary>
        /// Load data to listview.
        /// </summary>
        /// <param name="listData">List of data</param>
        private void LoadListView(List<OrderModel> listData)
        {
            this.listViewListOrder.Items.Clear();
            for (int i = listData.Count - 1; i >= 0; i--)
            {
                this.listViewListOrder.Items.Add(
                    CreateListViewItem(listData[i], listData.Count - i));

                for (int j = 1; j < listData[i].Cylinders.Count; j++)
                {
                    OrderModel subModel = new OrderModel();
                    if (j < listData[i].Products.Count)
                    {
                        subModel.Products.Add(listData[i].Products[j]);
                    }
                    subModel.Cylinders.Add(listData[i].Cylinders[j]);
                    this.listViewListOrder.Items.Add(CreateListViewSubItem(subModel));
                }
            }
        }

        /// <summary>
        /// Handle when lost focus on Search textbox.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbxSearch.Text.Trim()))
            {
                this.tbxSearch.Text = Properties.Resources.SearchString;
                this.tbxSearch.ForeColor = SystemColors.GrayText;
            }
        }

        /// <summary>
        /// Handle when enter focus on Search textbox.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxSearch_Enter(object sender, EventArgs e)
        {
            if (this.tbxSearch.Text.Equals(Properties.Resources.SearchString))
            {
                this.tbxSearch.Text = string.Empty;
                this.tbxSearch.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// Handle when press keydown.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">KeyEventArgs</param>
        private void ListOrderView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    this.Close();
                    break;
                case Keys.Enter:
                    if (tbxSearch.Focused)
                    {
                        this.SearchByKeyword(this.tbxSearch.Text.Trim());
                    }
                    break;
                default: break;
            }
        }
        /// <summary>
        /// Search keyword in listview.
        /// </summary>
        /// <param name="keyword">Keyword</param>
        private void SearchByKeyword(string keyword)
        {
            this.listDataSearch.Clear();
            keyword = CommonProcess.NormalizationString(keyword).ToLower();
            if (!String.IsNullOrEmpty(keyword))
            {
                foreach (OrderModel item in DataPure.Instance.ListOrders)
                {
                    if (item.IsContainString(keyword))
                    {
                        this.listDataSearch.Add(item);
                    }
                }
            }
            LoadListView(this.listDataSearch);
        }
        /// <summary>
        /// Set title.
        /// </summary>
        /// <param name="title">Title value</param>
        private void SetTitle(string title)
        {
            this.Text = String.Format("{0} {1}",
                Properties.Resources.ListOrder, title);
        }
        /// <summary>
        /// Handle load form.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ListOrderView_Load(object sender, EventArgs e)
        {
            SetTitle(System.DateTime.Now.ToString(Properties.Resources.DateTimeFormat));
            for (int i = DataPure.Instance.ListOrders.Count - 1; i >= 0; i--)
            {
                this.listViewListOrder.Items.Add(
                    CreateListViewItem(DataPure.Instance.ListOrders[i], DataPure.Instance.ListOrders.Count - i));

                for (int j = 1; j < DataPure.Instance.ListOrders[i].Cylinders.Count; j++)
                {
                    OrderModel subModel = new OrderModel();
                    if (j < DataPure.Instance.ListOrders[i].Products.Count)
                    {
                        subModel.Products.Add(DataPure.Instance.ListOrders[i].Products[j]);
                    }
                    subModel.Cylinders.Add(DataPure.Instance.ListOrders[i].Cylinders[j]);
                    this.listViewListOrder.Items.Add(CreateListViewSubItem(subModel));
                }
            }
            // ListView columns type
            this.listViewListOrder.ColumnTypes = new List<Type>()
            { 
                null,               // STT
                null,               // Name
                null,               // Phone
                null,               // Address
                null,               // Products
                null,               // Product quantity
                null,               // Promotes
                null,               // Total pay
                //typeof(TextBox),    
                null,               // Deliver
                typeof(ComboBox),   // Cylinder
                typeof(ComboBox),   // Cylinder quantity
                typeof(TextBox),    // Cylinder seri
                typeof(TextBox),    // Note
            };
            this.listViewListOrder.SubItemBeginEditing += new SubItemEventHandler(listViewListOrder_BeginEditing);
            UpdateTotal();
        }
        /// <summary>
        /// Handle begin editing in listview.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">SubItemEventArgs</param>
        private void listViewListOrder_BeginEditing(object sender, SubItemEventArgs e)
        {
            ListOrderColumns column = (ListOrderColumns)e.SubItem;
            switch (column)
            {
                case ListOrderColumns.LISTORDER_COLUMN_NO:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_NAME:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_PHONE:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_ADDRESS:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_PRODUCTS:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_PRODUCTS_QUANTITY:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_PROMOTE:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_TOTALPAY:
                    if (String.IsNullOrEmpty(this.listViewListOrder.SelectedItems[0].Tag.ToString()))
                    {
                        this.listViewListOrder.EndEditing(false);
                    }
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_DELIVER:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_CYLINDER:
                    List<object> items = new List<object>();
                    items.Add(new { Text = string.Empty, Value = string.Empty });
                    if (DataPure.Instance.TempData != null)
                    {
                        if (DataPure.Instance.TempData.Material_vo != null)
                        {
                            foreach (MaterialModel item in DataPure.Instance.TempData.Material_vo)
                            {
                                items.Add(new { Text = item.Name, Value = item.Id });
                            }
                        }
                    }
                    this.listViewListOrder.Combobox.Items.Clear();
                    this.listViewListOrder.Combobox.Items.AddRange(items.ToArray());
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_CYLINDER_QUANTITY:
                    List<object> itemsQuantity = new List<object>();
                    itemsQuantity.Add(new { Text = string.Empty, Value = string.Empty });
                    for (int i = 0; i < 50; i++)
                    {
                        itemsQuantity.Add(new { Text = i + 1, Value = i + 1 });
                    }
                    this.listViewListOrder.Combobox.Items.Clear();
                    this.listViewListOrder.Combobox.Items.AddRange(itemsQuantity.ToArray());
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_CYLINDER_SERI:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_NOTE:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_NUM:
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Create listview item.
        /// </summary>
        /// <param name="model">Order object</param>
        /// <param name="index">Index</param>
        /// <returns>ListViewItem</returns>
        private ListViewItem CreateListViewItem(OrderModel model, int index)
        {
            ListViewItem item;
            string[] arr = new string[(int)ListOrderColumns.LISTORDER_COLUMN_NUM];
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_NO]                = String.Format("{0}", index);
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_NAME]              = model.Customer.Name;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_PHONE]             = model.Customer.ActivePhone;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_ADDRESS]           = model.Customer.Address;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_PRODUCTS]          = model.Products[0].Name;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_PRODUCTS_QUANTITY] = model.Products[0].Quantity.ToString();
            string promoteStr = string.Empty;
            if (model.Promotes.Count != 0)
            {
                promoteStr = model.Promotes[0].Name;
                for (int i = 1; i < model.Promotes.Count; i++)
                {
                    promoteStr += " - " + model.Promotes[i].Name;
                }
            }
            else
            {
                promoteStr = CommonProcess.FormatMoney(model.PromoteMoney);
            }
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_PROMOTE]       = promoteStr;
            
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_TOTALPAY]      = CommonProcess.FormatMoney(model.TotalPay);
            string deliverStr = string.Empty;
            if (!String.IsNullOrEmpty(model.DeliverId))
            {
                if ((DataPure.Instance.TempData != null)
                    && (DataPure.Instance.TempData.Employee_maintain != null))
                {
                    foreach (SelectorModel deliver in DataPure.Instance.TempData.Employee_maintain)
                    {
                        if (model.DeliverId.Equals(deliver.Id))
                        {
                            deliverStr = deliver.Name;
                            break;
                        }
                    }
                }
            }
            else
            {
                if ((DataPure.Instance.TempData != null)
                    && (DataPure.Instance.TempData.Monitor_market_development != null))
                {
                    foreach (SelectorModel deliver in DataPure.Instance.TempData.Monitor_market_development)
                    {
                        if (model.CCSId.Equals(deliver.Id))
                        {
                            deliverStr = deliver.Name;
                            break;
                        }
                    }
                }
            }
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_DELIVER]           = deliverStr;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER]          = model.Cylinders[0].Name;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER_QUANTITY] = model.Cylinders[0].Quantity.ToString();
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER_SERI]     = model.Cylinders[0].Serial;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_NOTE]              = model.Note;
            item = new ListViewItem(arr);
            // Set tag value
            item.Tag = model.Id;
            return item;
        }
        /// <summary>
        /// Create listview sub item.
        /// </summary>
        /// <param name="model">Order object</param>
        /// <returns>ListViewItem</returns>
        private ListViewItem CreateListViewSubItem(OrderModel model)
        {
            ListViewItem item;
            string[] arr = new string[(int)ListOrderColumns.LISTORDER_COLUMN_NUM];
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_NO]                = String.Empty;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_NAME]              = String.Empty;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_PHONE]             = String.Empty;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_ADDRESS]           = String.Empty;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_PRODUCTS]          = model.Products[0].Name;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_PRODUCTS_QUANTITY] = model.Products[0].Quantity.ToString();
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_PROMOTE]           = String.Empty;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_TOTALPAY]          = String.Empty;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_DELIVER]           = String.Empty;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER]          = model.Cylinders[0].Name;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER_QUANTITY] = model.Cylinders[0].Quantity.ToString();
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER_SERI]     = model.Cylinders[0].Serial;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_NOTE]              = String.Empty;
            item = new ListViewItem(arr);
            // Set tag value
            item.Tag = model.Id;
            return item;
        }
        /// <summary>
        /// Handle finish editing item event on listview
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">SubItemEndEditingEventArgs</param>
        private void listViewListOrder_SubItemEndEditing(object sender, SubItemEndEditingEventArgs e)
        {
            ListOrderColumns column = (ListOrderColumns)e.SubItem;
            switch (column)
            {
                case ListOrderColumns.LISTORDER_COLUMN_NO:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_NAME:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_PHONE:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_ADDRESS:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_PRODUCTS:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_PRODUCTS_QUANTITY:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_PROMOTE:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_TOTALPAY:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_DELIVER:
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_CYLINDER:
                    if (this.listViewListOrder.SelectedItems.Count > 0)
                    {
                        // Get tag value
                        string id = this.listViewListOrder.SelectedItems[0].Tag.ToString();
                        // Get current index
                        int idx = this.listViewListOrder.SelectedIndices[0];
                        int mainIdx = -1;
                        // Check if this row is sub row
                        if (String.IsNullOrEmpty(id))
                        {
                            for (int i = idx; i >= 0; i--)
                            {
                                /// Reverse find main row
                                if (!String.IsNullOrEmpty(this.listViewListOrder.Items[i].Tag.ToString()))
                                {
                                    id = this.listViewListOrder.Items[i].Tag.ToString();
                                    mainIdx = i;
                                    break;
                                }
                            }
                        }
                        foreach (OrderModel item in DataPure.Instance.ListOrders)
                        {
                            if (item.Id.Equals(id))
                            {
                                if (DataPure.Instance.TempData != null)
                                {
                                    if (DataPure.Instance.TempData.Material_vo != null)
                                    {
                                        foreach (MaterialModel material in DataPure.Instance.TempData.Material_vo)
                                        {
                                            if (material.Name.Equals(e.DisplayText))
                                            {
                                                if (mainIdx != -1)
                                                {
                                                    item.Cylinders[idx - mainIdx].Id     = material.Id;
                                                    item.Cylinders[idx - mainIdx].TypeId = material.Materials_type_id;
                                                    item.Cylinders[idx - mainIdx].Name   = material.Name;
                                                }
                                                else
                                                {
                                                    item.Cylinders[0].Id     = material.Id;
                                                    item.Cylinders[0].TypeId = material.Materials_type_id;
                                                    item.Cylinders[0].Name   = material.Name;
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_CYLINDER_QUANTITY:
                    if (this.listViewListOrder.SelectedItems.Count > 0)
                    {
                        // Get tag value
                        string id = this.listViewListOrder.SelectedItems[0].Tag.ToString();
                        // Get current index
                        int idx = this.listViewListOrder.SelectedIndices[0];
                        int mainIdx = -1;
                        // Check if this row is sub row
                        if (String.IsNullOrEmpty(id))
                        {
                            for (int i = idx; i >= 0; i--)
                            {
                                /// Reverse find main row
                                if (!String.IsNullOrEmpty(this.listViewListOrder.Items[i].Tag.ToString()))
                                {
                                    id = this.listViewListOrder.Items[i].Tag.ToString();
                                    mainIdx = i;
                                    break;
                                }
                            }
                        }
                        foreach (OrderModel item in DataPure.Instance.ListOrders)
                        {
                            if (item.Id.Equals(id))
                            {
                                string quantityStr = e.DisplayText;
                                int itemIdx = 0;
                                if (mainIdx != -1)
                                {
                                    itemIdx = idx - mainIdx;
                                }
                                else
                                {
                                    itemIdx = 0;
                                }
                                int quantity = item.Cylinders[itemIdx].Quantity;
                                // Check editing value is valid or not
                                if (int.TryParse(quantityStr, out quantity))
                                {
                                    // Update data
                                    item.Cylinders[itemIdx].Quantity = quantity;
                                }
                                else
                                {
                                    // Reset display
                                    e.DisplayText = item.Cylinders[itemIdx].Quantity.ToString();
                                }
                                break;
                            }
                        }
                    }
                    UpdateTotal();
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_CYLINDER_SERI:
                    if (this.listViewListOrder.SelectedItems.Count > 0)
                    {
                        // Get tag value
                        string id = this.listViewListOrder.SelectedItems[0].Tag.ToString();
                        // Get current index
                        int idx = this.listViewListOrder.SelectedIndices[0];
                        int mainIdx = -1;
                        // Check if this row is sub row
                        if (String.IsNullOrEmpty(id))
                        {
                            for (int i = idx; i >= 0; i--)
                            {
                                /// Reverse find main row
                                if (!String.IsNullOrEmpty(this.listViewListOrder.Items[i].Tag.ToString()))
                                {
                                    id = this.listViewListOrder.Items[i].Tag.ToString();
                                    mainIdx = i;
                                    break;
                                }
                            }
                        }
                        foreach (OrderModel item in DataPure.Instance.ListOrders)
                        {
                            if (item.Id.Equals(id))
                            {
                                int itemIdx = 0;
                                if (mainIdx != -1)
                                {
                                    itemIdx = idx - mainIdx;
                                }
                                else
                                {
                                    itemIdx = 0;
                                }
                                item.Cylinders[itemIdx].Serial = e.DisplayText;
                                break;
                            }
                        }
                    }
                    break;
                case ListOrderColumns.LISTORDER_COLUMN_NOTE:
                    if (this.listViewListOrder.SelectedItems.Count > 0)
                    {
                        // Get tag value
                        string id = this.listViewListOrder.SelectedItems[0].Tag.ToString();
                        // Check if this row is sub row
                        if (!String.IsNullOrEmpty(id))
                        {
                            foreach (OrderModel item in DataPure.Instance.ListOrders)
                            {
                                if (item.Id.Equals(id))
                                {
                                    item.Note = e.DisplayText;
                                    break;
                                }
                            }
                        }
                        
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Handle click Close button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Handle click add cylinder button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnAddCylinder_Click(object sender, EventArgs e)
        {
            CommonProcess.ShowInformMessageProcessing();
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            if ((this.listViewListOrder.SelectedItems.Count > 0)
                && (!String.IsNullOrEmpty(this.listViewListOrder.SelectedItems[0].Tag.ToString())))
            {
                string id = this.listViewListOrder.SelectedItems[0].Tag.ToString();
                foreach (OrderModel item in DataPure.Instance.ListOrders)
                {
                    if (item.Id.Equals(id))
                    {
                        CommonProcess.UpdateOrderToServer(item);
                        break;
                    }
                }
            }
        }
    }
}
