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
        private double totalPay = 0.0;
        double total = 0.0;
        double totalPromote = 0.0;
        private SerialPort port = new SerialPort();
        /// <summary>
        /// Constructor.
        /// </summary>
        public OrderView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handle click Cancel button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
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
            // Customer information
            tbxCustomer.Text = String.Format("{0} - {1}\r\n{2}",
                DataPure.Instance.CustomerInfo != null ? DataPure.Instance.CustomerInfo.Name : String.Empty,
                DataPure.Instance.CustomerInfo != null ? DataPure.Instance.CustomerInfo.ActivePhone : String.Empty,
                DataPure.Instance.CustomerInfo != null ? DataPure.Instance.CustomerInfo.Address : String.Empty);

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
                                int quantity = item.Quantity;
                                // Check editing value is valid or not
                                if (int.TryParse(quantityStr, out quantity))
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
            lblDeliver.Text = String.Format(Properties.Resources.IdIs, cbxDeliver.SelectedValue.ToString());
        }

        /// <summary>
        /// Handle when selected index changed in CCS combobox
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void cbxCCS_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCCS.Text = String.Format(Properties.Resources.IdIs, cbxCCS.SelectedValue.ToString());
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
                model.Customer = new CustomerModel(DataPure.Instance.CustomerInfo);
                model.Products.AddRange(products);
                foreach (ProductModel item in products)
                {
                    model.Cylinders.Add(new CylinderModel());
                }
                model.Promotes.AddRange(promotes);
                model.TotalPay = totalPay;
                model.TotalMoney = total;
                model.PromoteMoney = totalPromote;
                model.Id = System.DateTime.Now.ToString(Properties.Settings.Default.CallIdFormat);
                string ret = CommonProcess.CreateOrderToServer(model);
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
                DataPure.Instance.ListOrders.Add(model);
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
            if ((DataPure.Instance.CustomerInfo == null)
                || (String.IsNullOrEmpty(DataPure.Instance.CustomerInfo.Id)))
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
            return retVal;
        }
        /// <summary>
        /// Update money field.
        /// </summary>
        private void UpdateMoney()
        {
            total        = 0.0;
            totalPromote = 0.0;
            totalPay     = 0.0;
            foreach (ProductModel item in products)
            {
                total += item.Money;
                if (item.IsGas())
                {
                    totalPromote += Properties.Settings.Default.PromoteMoney * item.Quantity;
                }
            }
            foreach (PromoteModel item in promotes)
            {
                totalPromote -= Properties.Settings.Default.PromoteMoney * item.Quantity;
            }
            //if (promotes.Count != 0)    // Customer take promote
            //{
            //    totalPromote = 0.0;
            //}
            //else                        // Customer don't take promote
            //{
            //    totalPromote = Properties.Settings.Default.PromoteMoney;
            //}
            totalPay = total - totalPromote;

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
                BillPrintModel printModel = new BillPrintModel();
                printModel.Brand = Properties.Settings.Default.BillBrand;
                printModel.Phone = DataPure.Instance.Agent.Phone;
                printModel.CustomerName = DataPure.Instance.CustomerInfo != null ?
                    String.Format("{0}-{1}", DataPure.Instance.CustomerInfo.ActivePhone,
                    DataPure.Instance.CustomerInfo.Name) : String.Empty;
                printModel.CustomerAddress = DataPure.Instance.CustomerInfo != null ? DataPure.Instance.CustomerInfo.Address : String.Empty;
                printModel.AgentAddress    = DataPure.Instance.Agent.Address;
                printModel.Products.AddRange(products);
                printModel.Promotes.AddRange(promotes);
                printModel.TotalMoney   = this.total;
                printModel.TotalPromote = this.totalPromote;
                printModel.TotalPay     = this.totalPay;
                printModel.Print();
            }
        }
    }
}
