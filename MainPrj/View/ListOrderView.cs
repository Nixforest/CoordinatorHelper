using MainPrj.Model;
using MainPrj.Model.Update;
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
        private List<OrderModel> listCurrentData = new List<OrderModel>();
        //++ BUG0044-SPJ (NguyenPT 20160822) Change quantity data type to double
        //private int totalGas      = 0;
        //private int totalGasStove = 0;
        //private int totalVan = 0;
        /// <summary>
        /// Total number of gas.
        /// </summary>
        private double totalGas      = 0.0;
        /// <summary>
        /// Total number of gas stove.
        /// </summary>
        private double totalGasStove = 0.0;
        /// <summary>
        /// Total number of Van.
        /// </summary>
        private double totalVan      = 0.0;
        //-- BUG0044-SPJ (NguyenPT 20160822) Change quantity data type to double
        /// <summary>
        /// Total money.
        /// </summary>
        private double totalPay   = 0.0;
        /// <summary>
        /// Total cylinder.
        /// </summary>
        private int totalCylinder = 0;
        //++ BUG0010-SPJ (NguyenPT 20160818) Add total promote money
        /// <summary>
        /// Total promote money.
        /// </summary>
        private double totalPromote = 0.0;
        //-- BUG0010-SPJ (NguyenPT 20160818) Add total promote money
        /// <summary>
        /// List items of Deliver combobox.
        /// </summary>
        private List<object> _listDeliverItems = new List<object>();
        //++ BUG0041-SPJ (NguyenPT 20160822) Filter Orders data by date
        private List<OrderModel> listTodayData = new List<OrderModel>();

        /// <summary>
        /// List of data.
        /// </summary>
        public List<OrderModel> ListTodayData
        {
            get { return listTodayData; }
            set { listTodayData = value; }
        }
        //-- BUG0041-SPJ (NguyenPT 20160822) Filter Orders data by date
        /// <summary>
        /// Constructor.
        /// </summary>
        public ListOrderView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Update total.
        /// </summary>
        private void UpdateTotal()
        {
            // Reset value
            totalGas      = 0;
            totalGasStove = 0;
            totalVan      = 0;
            totalPay      = 0.0;
            totalCylinder = 0;
            //++ BUG0010-SPJ (NguyenPT 20160818) Add total promote money
            totalPromote = 0.0;
            //-- BUG0010-SPJ (NguyenPT 20160818) Add total promote money
            // Re-calculate values from list current data
            foreach (OrderModel item in listCurrentData)
            {
                // Ignore Cancelled order
                if (item.Status.Equals(OrderStatus.ORDERSTATUS_CANCEL))
                {
                    continue;
                }
                // Total gas
                if (item.Products != null)
                {
                    foreach (ProductModel product in item.Products)
                    {
                        if (product.IsGas())
                        {
                            totalGas += product.Quantity;
                        }
                        else if (product.IsGasStove())
                        {
                            totalGasStove += product.Quantity;
                        }
                        else if (product.IsVan())
                        {
                            totalVan += product.Quantity;
                        }
                    }
                }

                // Total Cylinder
                if (item.Cylinders != null)
                {
                    foreach (CylinderModel cylinder in item.Cylinders)
                    {
                        if (!String.IsNullOrEmpty(cylinder.Id))
                        {
                            totalCylinder += cylinder.Quantity;
                        }
                    }
                }
                
                //++ BUG0010-SPJ (NguyenPT 20160818) Calculate total promote money
                totalPromote += item.PromoteMoney;
                //-- BUG0010-SPJ (NguyenPT 20160818) Calculate total promote money
                // Total pay
                totalPay += item.TotalPay;
            }
            lblTotalGas.Text = totalGas.ToString();
            lblGasStove.Text = totalGasStove.ToString();
            lblVan.Text      = totalVan.ToString();
            lblCylinder.Text = totalCylinder.ToString();
            lblTotalPay.Text = CommonProcess.FormatMoney(totalPay);
            //++ BUG0010-SPJ (NguyenPT 20160818) Show total promote money
            lblTotalPromote.Text = CommonProcess.FormatMoney(totalPromote);
            //-- BUG0010-SPJ (NguyenPT 20160818) Show total promote money
        }
        /// <summary>
        /// Update total.
        /// </summary>
        /// <param name="listOrder">List orders</param>
        private void UpdateTotal(List<OrderModel> listOrders)
        {
            // Reset value
            totalGas      = 0;
            totalGasStove = 0;
            totalVan      = 0;
            totalPay      = 0.0;
            totalCylinder = 0;
            totalPromote  = 0.0;

            // Re-calculate values from list orders
            foreach (OrderModel item in listOrders)
            {
                if (item.Status.Equals(OrderStatus.ORDERSTATUS_CANCEL))
                {
                    continue;
                }
                // Total gas
                if (item.Products != null)
                {
                    foreach (ProductModel product in item.Products)
                    {
                        if (product.IsGas())
                        {
                            totalGas += product.Quantity;
                        }
                        else if (product.IsGasStove())
                        {
                            totalGasStove += product.Quantity;
                        }
                        else if (product.IsVan())
                        {
                            totalVan += product.Quantity;
                        }
                    }
                }

                // Total Cylinder
                if (item.Cylinders != null)
                {
                    foreach (CylinderModel cylinder in item.Cylinders)
                    {
                        if (!String.IsNullOrEmpty(cylinder.Id))
                        {
                            totalCylinder += cylinder.Quantity;
                        }
                    }
                }
                // Total pay
                totalPromote += item.PromoteMoney;
                totalPay += item.TotalPay;
            }
            lblTotalGas.Text     = totalGas.ToString();
            lblGasStove.Text     = totalGasStove.ToString();
            lblVan.Text          = totalVan.ToString();
            lblCylinder.Text     = totalCylinder.ToString();
            lblTotalPay.Text     = CommonProcess.FormatMoney(totalPay);
            lblTotalPromote.Text = CommonProcess.FormatMoney(totalPromote);
        }
        /// <summary>
        /// Handle click button Clear.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Reset text in search textbox
            tbxSearch.Text      = Properties.Resources.SearchString;
            tbxSearch.ForeColor = SystemColors.GrayText;
            // Clear list current data
            this.listCurrentData.Clear();
            //LoadListView(DataPure.Instance.ListOrders);
            int dayNum = (dtpFilterTo.Value - dtpFilterFrom.Value).Days;
            DateTime from = dtpFilterFrom.Value;
            for (int i = 0; i <= dayNum; i++)
            {
                from = dtpFilterFrom.Value;
                this.listCurrentData.AddRange(CommonProcess.ReadListOrdersByDate(from.AddDays(i)));
            }
            ReloadListView(this.listCurrentData);
        }
        /// <summary>
        /// Load data to listview.
        /// </summary>
        /// <param name="listData">List of data</param>
        //private void LoadListView(List<OrderModel> listData)
        //{
        //    this.listViewListOrder.Items.Clear();
        //    for (int i = listData.Count - 1; i >= 0; i--)
        //    {
        //        if (!listData[i].Status.Equals(OrderStatus.ORDERSTATUS_CANCEL))
        //        {
        //            this.listViewListOrder.Items.Add(
        //            CreateListViewItem(listData[i], listData.Count - i));

        //            for (int j = 1; j < listData[i].Cylinders.Count; j++)
        //            {
        //                OrderModel subModel = new OrderModel();
        //                if (j < listData[i].Products.Count)
        //                {
        //                    subModel.Products.Add(listData[i].Products[j]);
        //                }
        //                else
        //                {
        //                    subModel.Products.Add(new ProductModel());
        //                }
        //                subModel.Cylinders.Add(listData[i].Cylinders[j]);
        //                this.listViewListOrder.Items.Add(CreateListViewSubItem(subModel));
        //            }
        //        }
        //    }
        //}

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
                    else if (listViewListOrder.Focused)
                    {
                        HandleFinishOrder();
                    }
                    break;
                default: break;
            }
        }
        /// <summary>
        /// Handle finish order.
        /// </summary>
        private void HandleFinishOrder()
        {
            if (listViewListOrder.SelectedItems.Count > 0)
            {
                string id = listViewListOrder.SelectedItems[0].Tag.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    foreach (OrderModel item in this.listCurrentData)
                    {
                        if (item.Id.Equals(id))
                        {
                            FinishOrderView view = new FinishOrderView(item);
                            view.ShowDialog();
                            ReloadListView(this.listCurrentData);
                            UpdateTotal();
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Search keyword in listview.
        /// </summary>
        /// <param name="keyword">Keyword</param>
        private void SearchByKeyword(string keyword)
        {
            this.listCurrentData.Clear();
            keyword = CommonProcess.NormalizationString(keyword).ToLower();
            //if (!String.IsNullOrEmpty(keyword))
            //{
            //    foreach (OrderModel item in DataPure.Instance.ListOrders)
            //    {
            //        if (item.IsContainString(keyword))
            //        {
            //            this.listDataSearch.Add(item);
            //        }
            //    }
            //}
            //LoadListView(this.listDataSearch);
            // Result when search with keyword
            List<OrderModel> listResult = new List<OrderModel>();
            // Get number of days
            int dayNum = (dtpFilterTo.Value - dtpFilterFrom.Value).Days;
            // Get From value
            DateTime from = dtpFilterFrom.Value;
            // Loop for all dates
            for (int i = 0; i <= dayNum; i++)
            {
                from = dtpFilterFrom.Value.AddDays(i);
                DateTime today = System.DateTime.Now;
                if ((from.Year == today.Year)
                    && (from.Month == today.Month)
                    && (from.Day == today.Day))
                {
                    if (!String.IsNullOrEmpty(keyword))
                    {
                        foreach (OrderModel item in this.listTodayData)
                        {
                            if (item.IsContainString(keyword))
                            {
                                listResult.Add(item);
                            }
                        }
                    }
                    else
                    {
                        listResult.AddRange(this.listTodayData);
                    }
                }
                else
                {
                    listResult.AddRange(CommonProcess.ReadListOrdersByDate(from));
                }
            }
            if (!String.IsNullOrEmpty(keyword))
            {
                foreach (OrderModel item in listResult)
                {
                    if (item.IsContainString(keyword))
                    {
                        this.listCurrentData.Add(item);
                    }
                }
            }
            else
            {
                this.listCurrentData.AddRange(listResult);
            }
            ReloadListView(listCurrentData);
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
        /// Add an item into Deliver combobox
        /// </summary>
        /// <param name="model"></param>
        private void AddDeliverToCombobox(OrderModel model)
        {
            if (model != null)
            {
                string id = !String.IsNullOrEmpty(model.DeliverId) ? model.DeliverId : model.CCSId;
                object item = new { Text = DataPure.Instance.GetDeliverNameInOrder(model), Value = id };
                if (!_listDeliverItems.Contains(item))
                {
                    _listDeliverItems.Add(item);
                }
            }
        }
        /// <summary>
        /// Reload listview.
        /// </summary>
        /// <param name="list">List data</param>
        private void ReloadListView(List<OrderModel> list, bool isFilter = true)
        {
            list.Sort();
            if (isFilter)
            {
                // Add deliver filter
                _listDeliverItems = new List<object>();
                _listDeliverItems.Add(new { Text = string.Empty, Value = string.Empty });
            }
            //++ BUG0066-SPJ (NguyenPT 20160903) Handle FLICKERING on ListView
            this.listViewListOrder.BeginUpdate();
            //-- BUG0066-SPJ (NguyenPT 20160903) Handle FLICKERING on ListView
            this.listViewListOrder.Items.Clear();

            // Loop through all orders
            int idx = 0;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (!list[i].Status.Equals(OrderStatus.ORDERSTATUS_CANCEL))
                {
                    this.listViewListOrder.Items.Add(
                        CreateListViewItem(list[i], ++idx));

                    for (int j = 1; j < list[i].Cylinders.Count; j++)
                    {
                        OrderModel subModel = new OrderModel();
                        if (j < list[i].Products.Count)
                        {
                            subModel.Products.Add(list[i].Products[j]);
                        }
                        else
                        {
                            subModel.Products.Add(new ProductModel());
                        }
                        subModel.Cylinders.Add(list[i].Cylinders[j]);
                        this.listViewListOrder.Items.Add(CreateListViewSubItem(subModel));
                    }
                    // Add deliver filter
                    AddDeliverToCombobox(list[i]);

                    if (isFilter)
                    {
                        cbxDeliver.DataSource = _listDeliverItems;
                        cbxDeliver.SelectedIndex = 0;
                    }
                }
            }
            //++ BUG0066-SPJ (NguyenPT 20160903) Handle FLICKERING on ListView
            this.listViewListOrder.EndUpdate();
            //-- BUG0066-SPJ (NguyenPT 20160903) Handle FLICKERING on ListView
        }
        /// <summary>
        /// Handle load form.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ListOrderView_Load(object sender, EventArgs e)
        {
            SetTitle(System.DateTime.Now.ToString(Properties.Resources.DateTimeFormat));

            this.listCurrentData.AddRange(this.listTodayData);
            ReloadListView(this.listCurrentData);
            //// Loop through all orders
            //for (int i = DataPure.Instance.ListOrders.Count - 1; i >= 0; i--)
            //{
            //    this.listViewListOrder.Items.Add(
            //        CreateListViewItem(DataPure.Instance.ListOrders[i], DataPure.Instance.ListOrders.Count - i));

            //    for (int j = 1; j < DataPure.Instance.ListOrders[i].Cylinders.Count; j++)
            //    {
            //        OrderModel subModel = new OrderModel();
            //        if (j < DataPure.Instance.ListOrders[i].Products.Count)
            //        {
            //            subModel.Products.Add(DataPure.Instance.ListOrders[i].Products[j]);
            //        }
            //        subModel.Cylinders.Add(DataPure.Instance.ListOrders[i].Cylinders[j]);
            //        this.listViewListOrder.Items.Add(CreateListViewSubItem(subModel));
            //    }
            //    // Add deliver filter
            //    AddDeliverToCombobox(DataPure.Instance.ListOrders[i]);
            //}
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
                //typeof(ComboBox),   // Cylinder
                //typeof(ComboBox),   // Cylinder quantity
                //typeof(TextBox),    // Cylinder seri
                null,
                null,
                null,
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
            //++ BUG0059-SPJ (NguyenPT 20160831) Handle show record without product
            ProductModel product = new ProductModel();
            if (model.Products.Count > 0)
            {
                product = model.Products[0];
            }
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_PRODUCTS] = product.Name;
            if (product.Quantity != 0)
            {
                arr[(int)ListOrderColumns.LISTORDER_COLUMN_PRODUCTS_QUANTITY] = product.Quantity.ToString();
            }
            else
            {
                arr[(int)ListOrderColumns.LISTORDER_COLUMN_PRODUCTS_QUANTITY] = String.Empty;
            }
            //-- BUG0059-SPJ (NguyenPT 20160831) Handle show record without product
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
            if (model.Status.Equals(OrderStatus.ORDERSTATUS_PAID))
            {
                arr[(int)ListOrderColumns.LISTORDER_COLUMN_TOTALPAY] = CommonProcess.FormatMoney(model.TotalPay);
            }
            else if (model.Status.Equals(OrderStatus.ORDERSTATUS_CANCEL))
            {
                arr[(int)ListOrderColumns.LISTORDER_COLUMN_TOTALPAY] = Properties.Resources.Cancel;
            }
            else
            {
                arr[(int)ListOrderColumns.LISTORDER_COLUMN_TOTALPAY] = String.Empty;
            }
            string deliverStr = DataPure.Instance.GetDeliverNameInOrder(model);

            #region Del
            //if (!String.IsNullOrEmpty(model.DeliverId))
            //{
            //    if ((DataPure.Instance.TempData != null)
            //        && (DataPure.Instance.TempData.Employee_maintain != null))
            //    {
            //        foreach (SelectorModel deliver in DataPure.Instance.TempData.Employee_maintain)
            //        {
            //            if (model.DeliverId.Equals(deliver.Id))
            //            {
            //                deliverStr = deliver.Name;
            //                break;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    if ((DataPure.Instance.TempData != null)
            //        && (DataPure.Instance.TempData.Monitor_market_development != null))
            //    {
            //        foreach (SelectorModel deliver in DataPure.Instance.TempData.Monitor_market_development)
            //        {
            //            if (model.CCSId.Equals(deliver.Id))
            //            {
            //                deliverStr = deliver.Name;
            //                break;
            //            }
            //        }
            //    }
            //} 
            #endregion
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_DELIVER]           = deliverStr;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER]          = model.Cylinders[0].Name;
            if (model.Cylinders[0].Quantity != 0)
            {
                arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER_QUANTITY] = model.Cylinders[0].Quantity.ToString();
            }
            else
            {

                arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER_QUANTITY] = String.Empty;
            }
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER_SERI]     = model.Cylinders[0].Serial;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_NOTE]              = model.Note;
            item = new ListViewItem(arr);
            if (!model.IsUpdateToServer)
            {
                item.Font = new Font(this.listViewListOrder.Font, FontStyle.Bold);
            }
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
            if (model.Products[0].Quantity != 0)
            {
                arr[(int)ListOrderColumns.LISTORDER_COLUMN_PRODUCTS_QUANTITY] = model.Products[0].Quantity.ToString();
            }
            else
            {
                arr[(int)ListOrderColumns.LISTORDER_COLUMN_PRODUCTS_QUANTITY] = String.Empty;
            }
            
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_PROMOTE]           = String.Empty;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_TOTALPAY]          = String.Empty;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_DELIVER]           = String.Empty;
            arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER]          = model.Cylinders[0].Name;
            if (model.Cylinders[0].Quantity != 0)
            {
                arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER_QUANTITY] = model.Cylinders[0].Quantity.ToString();
            }
            else
            {
                arr[(int)ListOrderColumns.LISTORDER_COLUMN_CYLINDER_QUANTITY] = String.Empty;
            }
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
                        int index = 0;
                        if (mainIdx != -1)
                        {
                            index = idx - mainIdx;
                        }
                        foreach (OrderModel item in this.listCurrentData)
                        {
                            if (item.Id.Equals(id))
                            {
                                if (DataPure.Instance.TempData != null)
                                {
                                    if (DataPure.Instance.TempData.Material_vo != null)
                                    {
                                        if (!String.IsNullOrEmpty(e.DisplayText))
                                        {
                                            foreach (MaterialModel material in DataPure.Instance.TempData.Material_vo)
                                            {
                                                if (material.Name.Equals(e.DisplayText))
                                                {
                                                    item.Cylinders[index].Id     = material.Id;
                                                    item.Cylinders[index].TypeId = material.Materials_type_id;
                                                    item.Cylinders[index].Name   = material.Name;
                                                    item.IsUpdateToServer        = false;
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            item.Cylinders[index].Id           = string.Empty;
                                            item.Cylinders[index].TypeId       = string.Empty;
                                            item.Cylinders[index].Name         = string.Empty;
                                            item.Cylinders[index].Materials_no = string.Empty;
                                            item.Cylinders[index].Quantity     = 0;
                                            item.Cylinders[index].Serial       = string.Empty;
                                            item.IsUpdateToServer        = false;
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
                        foreach (OrderModel item in this.listCurrentData)
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
                                    item.IsUpdateToServer = false;
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
                        foreach (OrderModel item in this.listCurrentData)
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
                                item.IsUpdateToServer = false;
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
                            foreach (OrderModel item in this.listCurrentData)
                            {
                                if (item.Id.Equals(id))
                                {
                                    if (!item.Note.Equals(e.DisplayText.Trim()))
                                    {
                                        item.Note = e.DisplayText;
                                        string retId = CommonProcess.UpdateOrderToServer(item);
                                        if (!String.IsNullOrEmpty(retId))
                                        {
                                            item.IsUpdateToServer = true;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        
                    }
                    break;
                default:
                    break;
            }
            //LoadListView(DataPure.Instance.ListOrders);
            ReloadListView(this.listCurrentData);
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
            HandleFinishOrder();
        }
        /// <summary>
        /// Handle update data to server.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            //foreach (ListViewItem lvItem in this.listViewListOrder.Items)
            //{
            //    if (!String.IsNullOrEmpty(lvItem.Tag.ToString()))
            //    {
            //        string id = lvItem.Tag.ToString();
            //        foreach (OrderModel item in DataPure.Instance.ListOrders)
            //        {
            //            if (item.Id.Equals(id) && !item.IsUpdateToServer)
            //            {
            //                string retId = CommonProcess.UpdateOrderToServer(item);
            //                if (!String.IsNullOrEmpty(retId))
            //                {
            //                    item.IsUpdateToServer = true;
            //                    //CommonProcess.ShowInformMessage(Properties.Resources.UpdateOrderSuccess, MessageBoxButtons.OK);
            //                }
            //            }
            //        }
            //    }
            //}
            //CommonProcess.ShowInformMessage(Properties.Resources.UpdateOrderSuccess, MessageBoxButtons.OK);
            //LoadListView(DataPure.Instance.ListOrders);
            if (listViewListOrder.SelectedItems.Count > 0)
            {
                string id = listViewListOrder.SelectedItems[0].Tag.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    foreach (OrderModel item in this.listCurrentData)
                    {
                        if (item.Id.Equals(id))
                        {
                            //++ BUG0059-SPJ (NguyenPT 20160831) Handle show record without product
                            if (!item.Order_type.Equals((int)OrderType.ORDERTYPE_THUVO))
                            {
                                OrderView order = new OrderView(item.Customer, true);
                                order.SetData(item);
                                order.ShowDialog();
                                //++ BUG0010-SPJ (NguyenPT 20160818) Show total promote money
                                UpdateTotal();
                                //-- BUG0010-SPJ (NguyenPT 20160818) Show total promote money
                                //LoadListView(DataPure.Instance.ListOrders);
                                ReloadListView(this.listCurrentData);
                                return;
                            }
                            else
                            {
                                CommonProcess.ShowInformMessage(Properties.Resources.CanNotUpdateOrder, MessageBoxButtons.OK);
                            }
                            //-- BUG0059-SPJ (NguyenPT 20160831) Handle show record without product
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handle when click Export Report button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            OrderReport report = new OrderReport();
            Dictionary<string, OrderDetailModel> listData = new Dictionary<string, OrderDetailModel>();
            foreach (OrderModel item in this.listCurrentData)
            {
                if (item.Status.Equals(OrderStatus.ORDERSTATUS_CANCEL))
                {
                    continue;
                }
                foreach (ProductModel product in item.Products)
                {
                    if (listData.Keys.Contains(product.Materials_no))
                    {
                        listData[product.Materials_no].Quantity += product.Quantity;
                    }
                    else
                    {
                        listData.Add(product.Materials_no,
                           new OrderDetailModel()
                           {
                               Materials_id      = product.Materials_no,
                               Materials_type_id = product.TypeId,
                               Quantity          = product.Quantity,
                               Price             = string.Empty,
                               TotalPay          = string.Empty,
                               Seri              = product.Name,
                           });
                    }
                }
                foreach (PromoteModel promote in item.Promotes)
                {
                    if (listData.Keys.Contains(promote.Materials_no))
                    {
                        listData[promote.Materials_no].Quantity += promote.Quantity;
                    }
                    else
                    {
                        listData.Add(promote.Materials_no,
                           new OrderDetailModel()
                           {
                               Materials_id      = promote.Materials_no,
                               Materials_type_id = promote.TypeId,
                               Quantity          = promote.Quantity,
                               Price             = string.Empty,
                               TotalPay          = string.Empty,
                               Seri              = promote.Name,
                           });
                    }
                }
                foreach (CylinderModel cylinder in item.Cylinders)
                {
                    if (!string.IsNullOrEmpty(cylinder.Id))
                    {
                        if (listData.Keys.Contains(cylinder.Materials_no))
                        {
                            listData[cylinder.Materials_no].Quantity += cylinder.Quantity;
                        }
                        else
                        {
                            listData.Add(cylinder.Materials_no,
                               new OrderDetailModel()
                               {
                                   Materials_id      = cylinder.Materials_no,
                                   Materials_type_id = cylinder.TypeId,
                                   Quantity          = cylinder.Quantity,
                                   Price             = string.Empty,
                                   TotalPay          = string.Empty,
                                   Seri              = cylinder.Name,
                               });
                        }
                    }
                }
            }
            report.ListData = listData;
            report.ShowDialog();
        }
        /// <summary>
        /// Handle when click Cancel Order button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (listViewListOrder.SelectedItems.Count > 0)
            {
                string id = listViewListOrder.SelectedItems[0].Tag.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    foreach (OrderModel item in this.listCurrentData)
                    {
                        if (item.Id.Equals(id))
                        {
                            //CancelOrderView view = new CancelOrderView(id);
                            CancelOrderView view = new CancelOrderView(item);
                            view.ShowDialog();
                            //LoadListView(DataPure.Instance.ListOrders);
                            ReloadListView(this.listCurrentData);
                            UpdateTotal();
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Handle double click on item in listview.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void listViewListOrder_DoubleClick(object sender, EventArgs e)
        {
            HandleFinishOrder();
        }
        /// <summary>
        /// Handle change selection in Deliver combobox.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void cbxDeliver_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDeliver.SelectedIndex == 0)
            {
                //LoadListView(DataPure.Instance.ListOrders);
                ReloadListView(this.listCurrentData);
                UpdateTotal();
            }
            else
            {
                //this.listCurrentData.Clear();
                List<OrderModel> list = new List<OrderModel>();
                foreach (OrderModel model in this.listCurrentData)
                {
                    string id = !String.IsNullOrEmpty(model.DeliverId) ? model.DeliverId : model.CCSId;
                    if (id.Equals(cbxDeliver.SelectedValue))
                    {
                        list.Add(model);
                    }
                }
                //LoadListView(this.listCurrentData);
                ReloadListView(list, false);
                UpdateTotal(list);
            }
        }
        /// <summary>
        /// Handle when click print order.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if ((this.listViewListOrder.SelectedItems.Count > 0)
                && (!String.IsNullOrEmpty(this.listViewListOrder.SelectedItems[0].Tag.ToString())))
            {
                string id = this.listViewListOrder.SelectedItems[0].Tag.ToString();
                foreach (OrderModel item in this.listCurrentData)
                {
                    if (item.Id.Equals(id))
                    {
                        // Print
                        //++ BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
                        //BillPrintModel printModel = new BillPrintModel();
                        BillPrintOrderModel printModel = new BillPrintOrderModel();
                        //-- BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
                        //printModel.Brand = Properties.Settings.Default.BillBrand;
                        printModel.Phone = DataPure.Instance.Agent.Phone;
                        printModel.CustomerName = item.Customer != null ?
                            String.Format("{0}-{1}", item.Customer.ActivePhone,
                            item.Customer.Name) : String.Empty;
                        printModel.CustomerAddress = item.Customer != null ? item.Customer.Address : String.Empty;
                        printModel.AgentAddress = DataPure.Instance.Agent.Address;
                        printModel.Products.AddRange(item.Products);
                        printModel.Promotes.AddRange(item.Promotes);
                        printModel.TotalMoney = item.TotalMoney;

                        double totalPromote = 0.0;
                        foreach (ProductModel product in item.Products)
                        {
                            if (product.IsGas())
                            {
                                totalPromote += Properties.Settings.Default.PromoteMoney * product.Quantity;
                            }
                        }
                        if (item.Promotes.Count != 0)
                        {
                            totalPromote = 0.0;
                        }
                        printModel.TotalPromote = totalPromote;
                        printModel.TotalPay     = item.TotalPay;
                        //++ BUG0056-SPJ (NguyenPT 20160830) Handle order type
                        printModel.OrderType    = (OrderType)item.Order_type;
                        printModel.OtherMoney   = item.Type_amount;
                        //-- BUG0056-SPJ (NguyenPT 20160830) Handle order type
                        printModel.Print();
                        break;
                    }
                }
            }
        }

        private void dtpFilterFrom_ValueChanged(object sender, EventArgs e)
        {
            // Check if From value is greater than To value
            if (dtpFilterFrom.Value > dtpFilterTo.Value)
            {
                dtpFilterTo.Value = dtpFilterFrom.Value;
            }
            string keyword = this.tbxSearch.Text.Trim();
            if (this.tbxSearch.Text.Equals(Properties.Resources.SearchString))
            {
                keyword = string.Empty;
            }
            this.SearchByKeyword(keyword);
        }

        private void dtpFilterTo_ValueChanged(object sender, EventArgs e)
        {
            // Check if From value is greater than To value
            if (dtpFilterFrom.Value > dtpFilterTo.Value)
            {
                dtpFilterFrom.Value = dtpFilterTo.Value;
            }
            string keyword = this.tbxSearch.Text.Trim();
            if (this.tbxSearch.Text.Equals(Properties.Resources.SearchString))
            {
                keyword = string.Empty;
            }
            this.SearchByKeyword(keyword);
        }
    }
}
