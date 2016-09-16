using MainPrj.Model;
using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class OrderView : Form
    {
        /// <summary>
        /// List data products.
        /// </summary>
        private List<ProductModel> products = new List<ProductModel>();
        /// <summary>
        /// List data promotes.
        /// </summary>
        private List<PromoteModel> promotes = new List<PromoteModel>();
        /// <summary>
        /// Total pay money.
        /// </summary>
        private double totalPay            = 0.0;
        double total                       = 0.0;
        double totalPromote                = 0.0;
        private SerialPort port            = new SerialPort();
        private ImageList _listProductImg  = new ImageList();
        private ImageList _listPromoteImg  = new ImageList();
        private CustomerModel customerInfo = null;
        private bool _isUpdateMode         = false;
        private OrderModel _data           = null;
        //++ BUG0056-SPJ (NguyenPT 20160830) Handle order type
        private double otherMoney          = 0.0;
        private OrderType _orderType       = OrderType.ORDERTYPE_NORMAL;
        //-- BUG0056-SPJ (NguyenPT 20160830) Handle order type
        //++ BUG0068-SPJ (NguyenPT 20160905) Change promote money
        /// <summary>
        /// Flag is manual change promote money.
        /// </summary>
        private bool _isManualChangePromoteMoney = false;
        //-- BUG0068-SPJ (NguyenPT 20160905) Change promote money
        //++ BUG0075-SPJ (NguyenPT 20160915) Use backup object instead
        private OrderModel _bkData = null;
        //-- BUG0075-SPJ (NguyenPT 20160915) Use backup object instead
        /// <summary>
        /// Is in update mode.
        /// </summary>
        public bool IsUpdateMode
        {
            get { return _isUpdateMode; }
            set { _isUpdateMode = value; }
        }
        /// <summary>
        /// Customer information.
        /// </summary>
        public CustomerModel CustomerInfo
        {
            get { return customerInfo; }
            set { customerInfo = value; }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public OrderView(CustomerModel customer, bool isUpdateMode = false)
        {
            InitializeComponent();
            customerInfo                  = customer;
            _isUpdateMode                 = isUpdateMode;
            listViewRecentProduct.Enabled = !_isUpdateMode;
            listViewProduct.Enabled       = !_isUpdateMode;
            tbxItem.Enabled               = !_isUpdateMode;
            btnCreateOrder.Visible        = !_isUpdateMode;
            btnCreatePrint.Visible        = !_isUpdateMode;
            dtpDate.Enabled               = !_isUpdateMode;
            btnUpdate.Visible             = _isUpdateMode;
        }
        /// <summary>
        /// Handle click Cancel button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this._isUpdateMode)
            {
                // Reset data value
                _data.DeliverId    = _bkData.DeliverId;
                _data.CCSId        = _bkData.CCSId;
                _data.TotalPay     = _bkData.TotalPay;
                _data.TotalMoney   = _bkData.TotalMoney;
                _data.PromoteMoney = _bkData.PromoteMoney;
                _data.Order_type   = _bkData.Order_type;
                _data.Type_amount  = _bkData.Type_amount;
                _data.Promotes     = _bkData.Promotes;
            }
            this.Close();
        }

        private void OrderView_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = CommonProcess.ShowInformMessage(Properties.Resources.AreYouSureToClose,
            //    MessageBoxButtons.YesNo);
            //if (result.Equals(DialogResult.No))
            //{
            //    e.Cancel = true;
            //}
        }
        /// <summary>
        /// Load data.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void OrderView_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            //++ BUG0002-SPJ (NguyenPT 20160824) If active phone is empty, take from Phone list
            string phone = CustomerInfo != null ? CustomerInfo.ActivePhone : String.Empty;
            if (string.IsNullOrEmpty(phone))
            {
                string[] phoneList = CustomerInfo.PhoneList.Split(Properties.Settings.Default.PhoneListToken.ToCharArray());
                if ((phoneList != null) && (phoneList.Length > 0))
                {
                    phone = phoneList[0];
                }
            }
            //-- BUG0002-SPJ (NguyenPT 20160824) If active phone is empty, take from Phone list

            // Customer information
            tbxCustomer.Text = String.Format("{0} - {1}\r\n{2}",
                CustomerInfo != null ? CustomerInfo.Name : String.Empty,
                //++ BUG0002-SPJ (NguyenPT 20160824) If active phone is empty, take from Phone list
                //CustomerInfo != null ? CustomerInfo.ActivePhone : String.Empty,
                phone,
                //-- BUG0002-SPJ (NguyenPT 20160824) If active phone is empty, take from Phone list
                CustomerInfo != null ? CustomerInfo.Address : String.Empty);

            lblPromote.Text = CommonProcess.FormatMoney(Properties.Settings.Default.PromoteMoney);
            // Check null object
            if (DataPure.Instance.User != null)
            {
                // Creator
                lblCreator.Text = DataPure.Instance.User.First_name;
                // Check null object
                if (DataPure.Instance.TempData != null)
                {
                    // Deliver
                    List<object> items = new List<object>();
                    items.Add(new { Text = Properties.Resources.NoneSelect, Value = string.Empty });
                    // Check null object
                    if (DataPure.Instance.TempData.Employee_maintain != null)
                    {
                        foreach (SelectorModel item in DataPure.Instance.TempData.Employee_maintain)
                        {
                            items.Add(new { Text = item.Name, Value = item.Id });
                        }
                    }
                    cbxDeliver.DataSource = items;

                    // CCS
                    List<object> itemsCCS = new List<object>();
                    itemsCCS.Add(new { Text = Properties.Resources.NoneSelect, Value = string.Empty });
                    // Check null object
                    if (DataPure.Instance.TempData.Monitor_market_development != null)
                    {
                        foreach (SelectorModel item in DataPure.Instance.TempData.Monitor_market_development)
                        {
                            itemsCCS.Add(new { Text = item.Name, Value = item.Id });
                        }
                    }
                    cbxCCS.DataSource = itemsCCS;
                }
            }
            // Listview
            // Set column types for List products
            this.listViewProduct.ColumnTypes = new List<Type>()
            {
                null,
                null,
                null,
                typeof(ComboBox),
                typeof(TextBox),
                null,
            };
            this.listViewProduct.SubItemEndEditing += new SubItemEndEditingEventHandler(listViewProduct_SubItemEndEditing);
            // Set column types for List promotes
            this.listViewPromote.ColumnTypes = new List<Type>()
            {
                null,
                null,
                null,
                typeof(ComboBox),
            };
            this.listViewPromote.SubItemEndEditing += new SubItemEndEditingEventHandler(listViewPromote_SubItemEndEditing);
            // Set data for Quantity combobox
            for (int i = 1; i <= 50; i++)
            {
                this.listViewProduct.Combobox.Items.Add(i);
                this.listViewPromote.Combobox.Items.Add(i);
            }
            int size = Properties.Settings.Default.ImageSize;
            this._listProductImg.ImageSize = new Size(size, size);
            this._listProductImg.ColorDepth = ColorDepth.Depth24Bit;
            CommonProcess.ListView_SetSpacing(this.listViewRecentProduct, (short)(size + 12), (short)(size + 12));
            this.listViewRecentProduct.LargeImageList = this._listProductImg;
            foreach (string item in DataPure.Instance.ListRecentProductsImg.Keys)
            {
                AddProductSelected(DataPure.Instance.ListRecentProductsImg[item]);
            }

            this._listPromoteImg.ImageSize = new Size(size, size);
            this._listPromoteImg.ColorDepth = ColorDepth.Depth24Bit;
            CommonProcess.ListView_SetSpacing(this.listViewRecentPromote, (short)(size + 12), (short)(size + 12));
            this.listViewRecentPromote.LargeImageList = this._listPromoteImg;
            foreach (string item in DataPure.Instance.ListRecentPromotesImg.Keys)
            {
                AddPromoteSelected(DataPure.Instance.ListRecentPromotesImg[item]);
            }
            this.Text = Properties.Resources.CreateOrderTitle;
            //++ BUG0068-SPJ (NguyenPT 20160905) Change promote money
            this._isManualChangePromoteMoney = false;
            //-- BUG0068-SPJ (NguyenPT 20160905) Change promote money
            // Update data
            if (_isUpdateMode && (_data != null))
            {
                this.Text = Properties.Resources.UpdateOrderTitle;
                // Set deliver
                if (!String.IsNullOrEmpty(_data.DeliverId))
                {
                    cbxDeliver.SelectedValue = _data.DeliverId;
                }
                // Set CCS
                if (!String.IsNullOrEmpty(_data.CCSId))
                {
                    cbxCCS.SelectedValue = _data.CCSId;
                }
                products = _data.Products;
                ReloadListProduct();
                promotes = _data.Promotes;
                ReloadListPromotes();
                if (_data.Created_date != null)
                {
                    //++ BUG0057-SPJ (NguyenPT 20160828) Fix bug convert datetime
                    //dtpDate.Value = Convert.ToDateTime(_data.Created_date);
                    dtpDate.Value = Convert.ToDateTime(DateTime.ParseExact(
                        _data.Created_date,
                        Properties.Resources.DefaultDateTimeFormat,
                        System.Globalization.CultureInfo.InvariantCulture));
                    //-- BUG0057-SPJ (NguyenPT 20160828) Fix bug convert datetime
                }
                else
                {
                    dtpDate.Value = DateTime.Now;
                }
                //++ BUG0056-SPJ (NguyenPT 20160830) Handle order type
                this._orderType = (OrderType)_data.Order_type;
                this.otherMoney = _data.Type_amount;
                switch (this._orderType)
                {
                    case OrderType.ORDERTYPE_NORMAL:
                        rbOrderTypeNormal.Checked = true;
                        break;
                    case OrderType.ORDERTYPE_SELLVO:
                        rbOrderTypeSellvo.Checked = true;
                        break;
                    case OrderType.ORDERTYPE_THECHAN:
                        rbOrderTypeTheChan.Checked = true;
                        break;
                    //++ BUG0059-SPJ (NguyenPT 20160831) Return cylinder
                    case OrderType.ORDERTYPE_THUVO:
                        rbReturnCylinder.Checked = true;
                        break;
                    //-- BUG0059-SPJ (NguyenPT 20160831) Return cylinder
                    default:
                        break;
                }
                //-- BUG0056-SPJ (NguyenPT 20160830) Handle order type
                //++ BUG0068-SPJ (NguyenPT 20160905) Change promote money
                //UpdateMoney();
                this._isManualChangePromoteMoney = _data.IsManualChangePromote;
                UpdateMoney(this._isManualChangePromoteMoney);
                //-- BUG0068-SPJ (NguyenPT 20160905) Change promote money
            }
            //++ BUG0068-SPJ (NguyenPT 20160904) Can change promote money
            totalPromote = Properties.Settings.Default.PromoteMoney;
            //-- BUG0068-SPJ (NguyenPT 20160904) Can change promote money
        }

        /// <summary>
        /// Add promote to listview.
        /// </summary>
        /// <param name="model">Model</param>
        private void AddPromoteSelected(MaterialBitmap model)
        {
            if (model != null)
            {
                MaterialBitmap bitmap = DataPure.Instance.ListRecentPromotesImg[model.Model.Materials_no];
                if (bitmap.Bitmap == null)
                {
                    bitmap.Bitmap = CommonProcess.CreateAvatar(bitmap.Text,
                        Properties.Settings.Default.ImageSize, model.Color, Properties.Settings.Default.ImageFontSize);
                    bitmap.Color = model.Color;
                }
                this._listPromoteImg.Images.Add(bitmap.Bitmap);
                ListViewItem lvi = new ListViewItem(string.Empty);
                lvi.ImageIndex = this._listPromoteImg.Images.Count - 1;
                lvi.Tag = bitmap;
                this.listViewRecentPromote.Items.Add(lvi);
            }
        }

        /// <summary>
        /// Add products to listview.
        /// </summary>
        /// <param name="model">Model</param>
        private void AddProductSelected(MaterialBitmap model)
        {
            if (model != null)
            {
                MaterialBitmap bitmap = DataPure.Instance.ListRecentProductsImg[model.Model.Materials_no];
                if (bitmap.Bitmap == null)
                {
                    bitmap.Bitmap = CommonProcess.CreateAvatar(bitmap.Text,
                        Properties.Settings.Default.ImageSize, model.Color, Properties.Settings.Default.ImageFontSize);
                    bitmap.Color = model.Color;
                }
                this._listProductImg.Images.Add(bitmap.Bitmap);
                ListViewItem lvi = new ListViewItem(string.Empty);
                lvi.ImageIndex = this._listProductImg.Images.Count - 1;
                lvi.Tag = bitmap;
                this.listViewRecentProduct.Items.Add(lvi);
            }
        }
        /// <summary>
        /// Handle finish editing item event on List promotes.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">SubItemEndEditingEventArgs</param>
        private void listViewPromote_SubItemEndEditing(object sender, SubItemEndEditingEventArgs e)
        {
            // Get column
            PromoteColumns column = (PromoteColumns)e.SubItem;
            switch (column)
            {
                case PromoteColumns.PROMOTE_TABLE_COLUMN_NO:
                    break;
                case PromoteColumns.PROMOTE_TABLE_COLUMN_ID:
                    break;
                case PromoteColumns.PROMOTE_TABLE_COLUMN_NAME:
                    break;
                case PromoteColumns.PROMOTE_TABLE_COLUMN_QUANTITY:                  // Quantity column
                    if (this.listViewPromote.SelectedItems.Count > 0)
                    {
                        // Get tag value
                        string id = this.listViewPromote.SelectedItems[0].Tag.ToString();
                        foreach (PromoteModel item in this.promotes)
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
                    break;
                case PromoteColumns.PROMOTE_TABLE_COLUMN_NUM:
                    break;
                default:
                    break;
            }
            UpdateMoney();
        }

        /// <summary>
        /// Handle finish editing item event on List products.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">SubItemEndEditingEventArgs</param>
        void listViewProduct_SubItemEndEditing(object sender, SubItemEndEditingEventArgs e)
        {
            ProductColumns column = (ProductColumns)e.SubItem;
            switch (column)
            {
                case ProductColumns.PRODUCT_TABLE_COLUMN_NO:
                    break;
                case ProductColumns.PRODUCT_TABLE_COLUMN_ID:
                    break;
                case ProductColumns.PRODUCT_TABLE_COLUMN_NAME:
                    break;
                case ProductColumns.PRODUCT_TABLE_COLUMN_QUANTITY:                  // Quantity column
                    if (this.listViewProduct.SelectedItems.Count > 0)
                    {
                        // Get tag value
                        string id = this.listViewProduct.SelectedItems[0].Tag.ToString();
                        foreach (ProductModel item in this.products)
                        {
                            if (item.Id.Equals(id))
                            {
                                string quantityStr = e.DisplayText;
                                //int quantity = item.Quantity;
                                double quantity = item.Quantity;
                                // Check editing value is valid or not
                                //if (int.TryParse(quantityStr, out quantity))
                                if (double.TryParse(quantityStr, out quantity))
                                {
                                    // Update data
                                    item.Quantity = quantity;
                                    item.Money = item.Quantity * item.Price;
                                    this.listViewProduct.SelectedItems[0].SubItems[(int)ProductColumns.PRODUCT_TABLE_COLUMN_MONEY].Text = CommonProcess.FormatMoney(item.Money);
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
                    break;
                case ProductColumns.PRODUCT_TABLE_COLUMN_PRICE:                     // Price column
                    if (this.listViewProduct.SelectedItems.Count > 0)
                    {
                        // Get tag value
                        string id = this.listViewProduct.SelectedItems[0].Tag.ToString();
                        foreach (ProductModel item in this.products)
                        {
                            if (item.Id.Equals(id))
                            {
                                string priceStr = e.DisplayText;
                                double price = item.Price;
                                // Check editing value is valid or not
                                if (double.TryParse(priceStr, out price))
                                {
                                    // Update data
                                    item.Price = price;
                                    item.Money = item.Quantity * item.Price;
                                    this.listViewProduct.SelectedItems[0].SubItems[(int)ProductColumns.PRODUCT_TABLE_COLUMN_MONEY].Text = CommonProcess.FormatMoney(item.Money);
                                }
                                else
                                {
                                    // Reset display
                                    e.DisplayText = item.Price.ToString();
                                }
                                break;
                            }
                        }
                    }
                    break;
                case ProductColumns.PRODUCT_TABLE_COLUMN_MONEY:
                    break;
                case ProductColumns.PRODUCT_TABLE_COLUMN_NUM:
                    break;
                default:
                    break;
            }
            UpdateMoney();
        }
        /// <summary>
        /// Handle when selected index changed in Deliver combobox
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void cbxDeliver_SelectedIndexChanged(object sender, EventArgs e)
        {
            //++ BUG0042-SPJ (NguyenPT 20160818) Check selected value is not null
            //lblDeliver.Text = String.Format(Properties.Resources.IdIs, cbxDeliver.SelectedValue.ToString());
            if (cbxDeliver.SelectedValue != null)
            {
                lblDeliver.Text = String.Format(Properties.Resources.IdIs, cbxDeliver.SelectedValue.ToString());
            }
            //-- BUG0042-SPJ (NguyenPT 20160818) Check selected value is not null
        }

        /// <summary>
        /// Handle when selected index changed in CCS combobox
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void cbxCCS_SelectedIndexChanged(object sender, EventArgs e)
        {
            //++ BUG0042-SPJ (NguyenPT 20160818) Check selected value is not null
            //lblCCS.Text = String.Format(Properties.Resources.IdIs, cbxCCS.SelectedValue.ToString());
            if (cbxCCS.SelectedValue != null)
            {
                lblCCS.Text = String.Format(Properties.Resources.IdIs, cbxCCS.SelectedValue.ToString());
            }
            //-- BUG0042-SPJ (NguyenPT 20160818) Check selected value is not null
        }
        /// <summary>
        /// Handle keydown event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">KeyEventArgs</param>
        private void OrderView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:                        // Hit enter
                    if (tbxItem.Focused)
                    {
                        HandleAddProduct();
                    }
                    else if (tbxPromote.Focused)
                    {
                        HandleAddPromote();
                    }
                    //++ BUG0068-SPJ (NguyenPT 20160904) Can change promote money
                    else if (tbxPromoteMoney.Focused)
                    {
                        btnCreatePrint.Focus();
                    }
                    //-- BUG0068-SPJ (NguyenPT 20160904) Can change promote money
                    break;
                case Keys.Delete:                       // Hit delete
                    if (listViewProduct.Focused)
                    {
                        HandleDeleteProducts();
                    }
                    else if (listViewPromote.Focused)
                    {
                        HandleDeletePromotes();
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Handle delete item in List products.
        /// </summary>
        private void HandleDeleteProducts()
        {
            if (listViewProduct.SelectedItems.Count != 0)
            {
                foreach (ListViewItem item in listViewProduct.SelectedItems)
                {
                    string id = item.Tag.ToString();
                    foreach (ProductModel model in products)
                    {
                        if (model.Id.Equals(id))
                        {
                            products.Remove(model);
                            break;
                        }
                    }
                }
                ReloadListProduct();
                UpdateMoney();
            }
        }
        /// <summary>
        /// Handle delete item in List promotes.
        /// </summary>
        private void HandleDeletePromotes()
        {
            if (listViewPromote.SelectedItems.Count != 0)
            {
                foreach (ListViewItem item in listViewPromote.SelectedItems)
                {
                    string id = item.Tag.ToString();
                    foreach (PromoteModel model in promotes)
                    {
                        if (model.Id.Equals(id))
                        {
                            promotes.Remove(model);
                            break;
                        }
                    }
                }
                ReloadListPromotes();
                UpdateMoney();
            }
        }
        /// <summary>
        /// Handle add a promote to List promotes.
        /// </summary>
        private void HandleAddPromote()
        {
            List<SelectorModel> listSelector = new List<SelectorModel>();
            List<MaterialModel> searchResult = new List<MaterialModel>();
            if (DataPure.Instance.TempData != null)
            {
                if (DataPure.Instance.TempData.Material_promotion != null)
                {
                    searchResult = CommonProcess.SearchMaterial(tbxPromote.Text.Trim(),
                        DataPure.Instance.TempData.Material_promotion.ToList());
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
            selectorView.ListData = listSelector;
            selectorView.Text = Properties.Resources.SelectPromotes;
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
                        PromoteModel model = new PromoteModel
                        {
                            Id           = item.Id,
                            Name         = item.Name,
                            Quantity     = 1,
                            Materials_no = item.Materials_no,
                            TypeId       = item.Materials_type_id,
                        };
                        foreach (PromoteModel promote in promotes)
                        {
                            if (promote.Id.Equals(model.Id))
                            {
                                promote.Quantity += 1;
                                model = null;
                                break;
                            }
                        }
                        if (model != null)
                        {
                            promotes.Add(model);
                        }
                        ReloadListPromotes();
                        break;
                    }
                }
                UpdateMoney();
            }
        }
        /// <summary>
        /// Reload list products.
        /// </summary>
        private void ReloadListProduct()
        {
            listViewProduct.Items.Clear();
            int index = 0;
            foreach (ProductModel product in products)
            {
                product.Money = product.Quantity * product.Price;
                listViewProduct.Items.Add(listViewProduct.CreateListViewItem(product, ++index));
            }
        }
        /// <summary>
        /// Reload list promotes.
        /// </summary>
        private void ReloadListPromotes()
        {
            listViewPromote.Items.Clear();
            int index = 0;
            foreach (PromoteModel promote in promotes)
            {
                listViewPromote.Items.Add(listViewPromote.CreateListViewItem(promote, ++index));
            }
        }

        /// <summary>
        /// Handle add a promote to List products.
        /// </summary>
        private void HandleAddProduct()
        {
            List<SelectorModel> listSelector = new List<SelectorModel>();
            List<MaterialModel> searchResult = new List<MaterialModel>();
            if (DataPure.Instance.TempData != null)
            {
                if (DataPure.Instance.TempData.Material_gas != null)
                {
                    searchResult = CommonProcess.SearchMaterial(tbxItem.Text.Trim(),
                        DataPure.Instance.TempData.Material_gas.ToList());
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
            selectorView.ListData = listSelector;
            selectorView.Text = Properties.Resources.SelectItems;
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
                        double price = 0.0;
                        if (CommonProcess.IsValidDouble(item.Price))
                        {
                            price = double.Parse(item.Price);
                        }
                        ProductModel model = new ProductModel
                        {
                            Id           = item.Id,
                            Name         = item.Name,
                            Quantity     = 1,
                            Price        = price,
                            Money        = price,
                            Materials_no = item.Materials_no,
                            TypeId       = item.Materials_type_id,
                        };
                        foreach (ProductModel product in products)
                        {
                            if (product.Id.Equals(model.Id))
                            {
                                product.Quantity += 1;
                                model = null;
                                break;
                            }
                        }
                        if (model != null)
                        {
                            products.Add(model);
                        }
                        ReloadListProduct();
                        break;
                    }
                }
                UpdateMoney();
            }
        }
        /// <summary>
        /// Handle click Create order button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            CreateOrder();
        }
        /// <summary>
        /// Create order.
        /// </summary>
        /// <returns>True if create order is success, False otherwise</returns>
        private bool CreateOrder()
        {
            if (ValidateData())
            {
                OrderModel model = new OrderModel();
                model.CreatorId = DataPure.Instance.User.User_id;
                if (cbxDeliver.SelectedValue != null)
                {
                    model.DeliverId = cbxDeliver.SelectedValue.ToString();
                }
                if (cbxCCS.SelectedValue != null)
                {
                    model.CCSId = cbxCCS.SelectedValue.ToString();
                }
                model.Customer = new CustomerModel(CustomerInfo);
                model.Products.AddRange(products);
                //++ BUG0059-SPJ (NguyenPT 20160831) Return cylinder
                if (model.Products[0].IsCylinder())
                {
                    CylinderModel cylinder = new CylinderModel();
                    cylinder.Id = model.Products[0].Id;
                    cylinder.Name = model.Products[0].Name;
                    cylinder.Materials_no = model.Products[0].Materials_no;
                    cylinder.Quantity = (int)model.Products[0].Quantity;
                    cylinder.TypeId = model.Products[0].TypeId;
                    model.Cylinders.Insert(0, cylinder);
                    model.Products.RemoveAt(0);
                }
                //foreach (ProductModel item in products)
                foreach (ProductModel item in model.Products)
                //-- BUG0059-SPJ (NguyenPT 20160831) Return cylinder
                {
                    model.Cylinders.Add(new CylinderModel());
                }
                model.Promotes.AddRange(promotes);
                model.TotalPay              = totalPay;
                model.TotalMoney            = total;
                model.PromoteMoney          = totalPromote;
                //++ BUG0068-SPJ (NguyenPT 20160905) Change promote money
                model.IsManualChangePromote = this._isManualChangePromoteMoney;
                //-- BUG0068-SPJ (NguyenPT 20160905) Change promote money
                model.Order_type            = (int)this._orderType;
                model.Type_amount           = this.otherMoney;
                model.Created_date          = dtpDate.Value.ToString(Properties.Resources.DefaultDateTimeFormat);
                //model.Id                  = System.DateTime.Now.ToString(Properties.Settings.Default.CallIdFormat);
                model.Id                    = dtpDate.Value.ToString(Properties.Settings.Default.CallIdFormat);
                string ret                  = CommonProcess.CreateOrderToServer(model);
                if (CommonProcess.HasError)
                {
                    CommonProcess.HasError = false;
                    CommonProcess.ShowErrorMessage(Properties.Resources.CreateOrderServerError);
                    return false;
                }
                else
                {
                    if (!String.IsNullOrEmpty(ret))
                    {
                        // Create order success
                        CommonProcess.ShowInformMessage(Properties.Resources.CreateOrderSuccess, MessageBoxButtons.OK);
                    }
                }
                model.WebId = ret;
                
                //DataPure.Instance.ListOrders.Add(model);
                if ((dtpDate.Value.Day == System.DateTime.Now.Day)
                    && (dtpDate.Value.Month == System.DateTime.Now.Month)
                    && (dtpDate.Value.Year == System.DateTime.Now.Year))
                {
                    DataPure.Instance.ListOrders.Add(model);
                }
                //else
                //{
                //    if (!DataPure.Instance.ListOrderHistory.ContainsKey(model.Created_date))
                //    {
                //        DataPure.Instance.ListOrderHistory.Add(model.Created_date, new List<OrderModel>());
                //    }
                //    DataPure.Instance.ListOrderHistory[model.Created_date].Add(model);
                //}
                // Write order to file
                CommonProcess.WriteOrderByDate(dtpDate.Value, model);
                
                this.Close();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Validate inputted data.
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            bool retVal = true;
            // Check user is login
            if (DataPure.Instance.User == null)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.NotLoginYet);
                return false;
            }
            // Check customer infor is not null
            if ((CustomerInfo == null)
                || (String.IsNullOrEmpty(CustomerInfo.Id)))
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.NotSelectCustomer);
                return false;
            }
            // Not select deliver or CCS
            if ((cbxDeliver.SelectedIndex <= 0)
                    && (cbxCCS.SelectedIndex <= 0))
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.NotSelectDeliverCCS);
                return false;
            }
            // Not select products.
            if (products.Count == 0)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.NotSelectProducts);
                return false;
            }
            // Check if not input price
            double total = 0.0;
            foreach (ProductModel product in products)
            {
                total += product.Price;
            }
            if (total == 0)
            {
                //++ BUG0059-SPJ (NguyenPT 20160831) Return cylinder
                //CommonProcess.ShowErrorMessage(Properties.Resources.NotInputProductPrice);
                DialogResult result = CommonProcess.ShowInformMessage(Properties.Resources.NotInputProductPrice, MessageBoxButtons.OKCancel);
                if (result.Equals(DialogResult.Cancel))
                {
                    return false;
                }
                //-- BUG0059-SPJ (NguyenPT 20160831) Return cylinder
            }
            return retVal;
        }
        /// <summary>
        /// Update money field.
        /// </summary>
        //++ BUG0068-SPJ (NguyenPT 20160904) Can change promote money
        //private void UpdateMoney()
        private void UpdateMoney(bool isManualChangePromote = false)
        //-- BUG0068-SPJ (NguyenPT 20160904) Can change promote money
        {
            total = 0.0;
            //++ BUG0068-SPJ (NguyenPT 20160904) Can change promote money
            //totalPromote = 0.0;
            this._isManualChangePromoteMoney = isManualChangePromote;
            if (!isManualChangePromote)
            {
                totalPromote = 0.0;
            }
            //-- BUG0068-SPJ (NguyenPT 20160904) Can change promote money
            totalPay     = 0.0;
            foreach (ProductModel item in products)
            {
                total += item.Money;
                if (item.IsGas())
                {
                    //++ BUG0068-SPJ (NguyenPT 20160904) Can change promote money
                    //totalPromote += Properties.Settings.Default.PromoteMoney * item.Quantity;
                    if (!isManualChangePromote)
                    {
                        totalPromote += Properties.Settings.Default.PromoteMoney * item.Quantity;
                    }
                    //-- BUG0068-SPJ (NguyenPT 20160904) Can change promote money
                }
            }
            if (promotes.Count != 0)
            {
                //++ BUG0068-SPJ (NguyenPT 20160904) Can change promote money
                //totalPromote = 0.0;
                if (!isManualChangePromote)
                {
                    totalPromote = 0.0;
                }
                //-- BUG0068-SPJ (NguyenPT 20160904) Can change promote money
            }
            //++ BUG0059-SPJ (NguyenPT 20160831) Return cylinder
            //totalPay = total - totalPromote;
            if (this._orderType.Equals(OrderType.ORDERTYPE_THUVO))
            {
                totalPay = total - totalPromote - otherMoney;
            }
            else
            {
                totalPay = total - totalPromote + otherMoney;
            }
            //-- BUG0059-SPJ (NguyenPT 20160831) Return cylinder

            // Update UI
            lblTotal.Text    = CommonProcess.FormatMoney(total);
            lblPromote.Text  = CommonProcess.FormatMoney(totalPromote);
            lblTotalPay.Text = CommonProcess.FormatMoney(totalPay);
        }
        /// <summary>
        /// Handle leave Item textbox event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxItem_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.tbxItem.Text))
            {
                this.tbxItem.Text      = Properties.Resources.SearchString;
                this.tbxItem.ForeColor = SystemColors.GrayText;
            }
        }
        /// <summary>
        /// Handle enter Item textbox event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxItem_Enter(object sender, EventArgs e)
        {
            if (this.tbxItem.Text.Equals(Properties.Resources.SearchString))
            {
                this.tbxItem.Text      = string.Empty;
                this.tbxItem.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Handle leave Promote textbox event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxPromote_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.tbxPromote.Text))
            {
                this.tbxPromote.Text      = Properties.Resources.SearchString;
                this.tbxPromote.ForeColor = SystemColors.GrayText;
            }
        }

        /// <summary>
        /// Handle enter Promote textbox event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxPromote_Enter(object sender, EventArgs e)
        {
            if (this.tbxPromote.Text.Equals(Properties.Resources.SearchString))
            {
                this.tbxPromote.Text      = string.Empty;
                this.tbxPromote.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// Handle when click Create order and Print.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCreatePrint_Click(object sender, EventArgs e)
        {
            if (CreateOrder())
            {
                // Print
                //++ BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
                //BillPrintModel printModel = new BillPrintModel();
                BillPrintOrderModel printModel = new BillPrintOrderModel();
                //-- BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
                //printModel.Brand = Properties.Settings.Default.BillBrand;
                printModel.Phone = DataPure.Instance.Agent.Phone;
                printModel.CustomerName = CustomerInfo != null ?
                    String.Format("{0}-{1}", CustomerInfo.ActivePhone,
                    CustomerInfo.Name) : String.Empty;
                printModel.CustomerAddress = CustomerInfo != null ? CustomerInfo.Address : String.Empty;
                printModel.AgentAddress    = DataPure.Instance.Agent.Address;
                printModel.Products.AddRange(products);
                printModel.Promotes.AddRange(promotes);
                printModel.TotalMoney   = this.total;
                printModel.TotalPromote = this.totalPromote;
                printModel.TotalPay     = this.totalPay;
                printModel.OrderType = this._orderType;
                printModel.OtherMoney = this.otherMoney;
                printModel.Print();
            }
        }
        /// <summary>
        /// Double click on listview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewRecentProduct_DoubleClick(object sender, EventArgs e)
        {
            if (this.listViewRecentProduct.SelectedItems.Count > 0)
            {
                MaterialBitmap item = (MaterialBitmap) this.listViewRecentProduct.SelectedItems[0].Tag;
                if (DataPure.Instance.GetListMaterialGas().ContainsKey(item.Model.Materials_no))
                {
                    AddProduct(DataPure.Instance.GetListMaterialGas()[item.Model.Materials_no]);
                }

                UpdateMoney();
            }
        }
        private void AddProduct(MaterialModel item)
        {
            double price = 0.0;
            if (CommonProcess.IsValidDouble(item.Price))
            {
                price = double.Parse(item.Price);
            }
            ProductModel model = new ProductModel
            {
                Id = item.Id,
                Name = item.Name,
                Quantity = 1,
                Price = price,
                Money = price,
                Materials_no = item.Materials_no,
                TypeId = item.Materials_type_id,
            };
            foreach (ProductModel product in products)
            {
                if (product.Id.Equals(model.Id))
                {
                    product.Quantity += 1;
                    model = null;
                    break;
                }
            }
            if (model != null)
            {
                products.Add(model);
            }
            ReloadListProduct();
        }
        private void AddPromote(MaterialModel item)
        {
            PromoteModel model = new PromoteModel
            {
                Id           = item.Id,
                Name         = item.Name,
                Quantity     = 1,
                Materials_no = item.Materials_no,
                TypeId       = item.Materials_type_id,
            };
            foreach (PromoteModel promote in promotes)
            {
                if (promote.Id.Equals(model.Id))
                {
                    promote.Quantity += 1;
                    model = null;
                    break;
                }
            }
            if (model != null)
            {
                promotes.Add(model);
            }
            ReloadListPromotes();
        }

        private void listViewRecentPromote_DoubleClick(object sender, EventArgs e)
        {
            if (this.listViewRecentPromote.SelectedItems.Count > 0)
            {
                MaterialBitmap item = (MaterialBitmap)this.listViewRecentPromote.SelectedItems[0].Tag;
                if (DataPure.Instance.GetListMaterialPromote().ContainsKey(item.Model.Materials_no))
                {
                    AddPromote(DataPure.Instance.GetListMaterialPromote()[item.Model.Materials_no]);
                }
                //AddPromote(item.Model);

                UpdateMoney();
            }
        }
        public void SetData(OrderModel model)
        {
            if (model == null)
            {
                return;
            }
            _data = model;
            //++ BUG0075-SPJ (NguyenPT 20160915) Use backup object instead
            _bkData = new OrderModel(_data);
            //-- BUG0075-SPJ (NguyenPT 20160915) Use backup object instead
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_isUpdateMode && (_data != null))
            {
                if (ValidateData())
                {
                    if (cbxDeliver.SelectedValue != null)
                    {
                        _data.DeliverId = cbxDeliver.SelectedValue.ToString();
                    }
                    if (cbxCCS.SelectedValue != null)
                    {
                        _data.CCSId = cbxCCS.SelectedValue.ToString();
                    }
                    _data.TotalPay     = totalPay;
                    _data.TotalMoney   = total;
                    _data.PromoteMoney = totalPromote;
                    _data.Order_type = (int)this._orderType;
                    _data.Type_amount = this.otherMoney;
                    string retId = CommonProcess.UpdateOrderToServer(_data);
                    if (!String.IsNullOrEmpty(retId))
                    {
                        _data.IsUpdateToServer = true;
                        CommonProcess.ShowInformMessage(Properties.Resources.UpdateOrderSuccess, MessageBoxButtons.OK);
                        //++ BUG0075-SPJ (NguyenPT 20160915) Write to file
                        CommonProcess.UpdateOrderToFile(_data);
                        //-- BUG0075-SPJ (NguyenPT 20160915) Write to file
                        this.Close();
                    }
                }
            }
        }
        private void rbOrderTypeSellvo_CheckedChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handle when changed check value in Normal radio button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void rbOrderTypeNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOrderTypeNormal.Checked)
            {
                otherMoney = 0.0;
                UpdateMoney();
                this._orderType = OrderType.ORDERTYPE_NORMAL;
            }
        }

        /// <summary>
        /// Handle when changed check value in Sell Vo radio button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void rbOrderTypeSellvo_Click(object sender, EventArgs e)
        {
            if (rbOrderTypeSellvo.Checked)
            {
                MoneyInputView view = new MoneyInputView();
                view.Title = Properties.Resources.InputCylinderPrice;
                if (this.otherMoney == 0.0)
                {
                    view.Money = 300000.0;
                }
                else
                {
                    view.Money = this.otherMoney;
                }
                view.ShowDialog();
                this.otherMoney = view.Money;
                this._orderType = OrderType.ORDERTYPE_SELLVO;
                UpdateMoney();
            }
        }

        /// <summary>
        /// Handle when changed check value in The chan radio button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void rbOrderTypeTheChan_Click(object sender, EventArgs e)
        {
            if (rbOrderTypeTheChan.Checked)
            {
                MoneyInputView view = new MoneyInputView();
                view.Title = Properties.Resources.InputTheChanValue;
                if (this.otherMoney == 0.0)
                {
                    view.Money = 300000.0;
                }
                else
                {
                    view.Money = this.otherMoney;
                }
                view.ShowDialog();
                this.otherMoney = view.Money;
                this._orderType = OrderType.ORDERTYPE_THECHAN;
                UpdateMoney();
            }
        }

        //++ BUG0059-SPJ (NguyenPT 20160831) Return cylinder
        private void rbReturnCylinder_Click(object sender, EventArgs e)
        {
            if (rbReturnCylinder.Checked)
            {
                MoneyInputView view = new MoneyInputView();
                view.Title = Properties.Resources.InputCylinderReturn;
                if (this.otherMoney == 0.0)
                {
                    view.Money = 300000.0;
                }
                else
                {
                    view.Money = this.otherMoney;
                }
                view.ShowDialog();
                this.otherMoney = view.Money;
                this._orderType = OrderType.ORDERTYPE_THUVO;
                UpdateMoney();
            }
        }
        //++ BUG0059-SPJ (NguyenPT 20160831) Return cylinder

        //++ BUG0068-SPJ (NguyenPT 20160904) Can change promote money
        private void lblPromote_DoubleClick(object sender, EventArgs e)
        {
            tbxPromoteMoney.Visible = true;
            tbxPromoteMoney.Text    = totalPromote.ToString();
            lblPromote.Visible      = false;
            tbxPromoteMoney.Focus();
        }

        private void tbxPromoteMoney_Leave(object sender, EventArgs e)
        {
            double money = 0.0;
            if (Double.TryParse(tbxPromoteMoney.Text, out money))
            {
                totalPromote = money;
                tbxPromoteMoney.Visible = false;
                lblPromote.Visible = true;
                UpdateMoney(true);
            }
            else
            {
                CommonProcess.ShowErrorMessage("Hãy nhập số tiền hợp lệ");
            }
        }

        private void btnChangePromote_Click(object sender, EventArgs e)
        {
            tbxPromoteMoney.Visible = true;
            tbxPromoteMoney.Text    = totalPromote.ToString();
            lblPromote.Visible      = false;
            tbxPromoteMoney.Focus();
        }
        //-- BUG0068-SPJ (NguyenPT 20160904) Can change promote money
    }
}
