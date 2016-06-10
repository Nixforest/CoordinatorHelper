using MainPrj.Model;
using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class OrderView : Form
    {
        private List<ProductModel> products = new List<ProductModel>();
        private List<PromoteModel> promotes = new List<PromoteModel>();
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
            lblCustomerName.Text = DataPure.Instance.CustomerInfo != null ? DataPure.Instance.CustomerInfo.Name : String.Empty;
            lblCustomerAddress.Text = DataPure.Instance.CustomerInfo != null ? DataPure.Instance.CustomerInfo.Address : String.Empty;
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
            this.listViewPromote.ColumnTypes = new List<Type>()
            {
                null,
                null,
                null,
                typeof(ComboBox),
            };
            this.listViewPromote.SubItemEndEditing += new SubItemEndEditingEventHandler(listViewPromote_SubItemEndEditing);
            for (int i = 0; i < 50; i++)
            {
                this.listViewProduct.Combobox.Items.Add(i);
                this.listViewPromote.Combobox.Items.Add(i);
            }
        }

        private void listViewPromote_SubItemEndEditing(object sender, SubItemEndEditingEventArgs e)
        {
            PromoteColumns column = (PromoteColumns)e.SubItem;
            switch (column)
            {
                case PromoteColumns.PROMOTE_TABLE_COLUMN_NO:
                    break;
                case PromoteColumns.PROMOTE_TABLE_COLUMN_ID:
                    break;
                case PromoteColumns.PROMOTE_TABLE_COLUMN_NAME:
                    break;
                case PromoteColumns.PROMOTE_TABLE_COLUMN_QUANTITY:
                    if (this.listViewPromote.SelectedItems.Count > 0)
                    {
                        string id = this.listViewPromote.SelectedItems[0].Tag.ToString();
                        foreach (PromoteModel item in this.promotes)
                        {
                            if (item.Id.Equals(id))
                            {
                                string quantityStr = e.DisplayText;
                                int quantity = item.Quantity;
                                if (int.TryParse(quantityStr, out quantity))
                                {
                                    item.Quantity = quantity;
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
                case ProductColumns.PRODUCT_TABLE_COLUMN_QUANTITY:
                    if (this.listViewProduct.SelectedItems.Count > 0)
                    {
                        string id = this.listViewProduct.SelectedItems[0].Tag.ToString();
                        foreach (ProductModel item in this.products)
                        {
                            if (item.Id.Equals(id))
                            {
                                string quantityStr = e.DisplayText;
                                int quantity = item.Quantity;
                                if (int.TryParse(quantityStr, out quantity))
                                {
                                    item.Quantity = quantity;
                                    item.Money = item.Quantity * item.Price;
                                    this.listViewProduct.SelectedItems[0].SubItems[(int)ProductColumns.PRODUCT_TABLE_COLUMN_MONEY].Text = CommonProcess.FormatMoney(item.Money);
                                }
                                else
                                {
                                    e.DisplayText = item.Quantity.ToString();
                                }
                                break;
                            }
                        }
                    }
                    break;
                case ProductColumns.PRODUCT_TABLE_COLUMN_PRICE:
                    if (this.listViewProduct.SelectedItems.Count > 0)
                    {
                        string id = this.listViewProduct.SelectedItems[0].Tag.ToString();
                        foreach (ProductModel item in this.products)
                        {
                            if (item.Id.Equals(id))
                            {
                                string priceStr = e.DisplayText;
                                double price = item.Price;
                                if (double.TryParse(priceStr, out price))
                                {
                                    item.Price = price;
                                    item.Money = item.Quantity * item.Price;
                                    this.listViewProduct.SelectedItems[0].SubItems[(int)ProductColumns.PRODUCT_TABLE_COLUMN_MONEY].Text = CommonProcess.FormatMoney(item.Money);
                                }
                                else
                                {
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
                default:
                    break;
            }
        }
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
                    Id = item.Materials_no,
                    Name = item.Name,
                    Address = item.Label
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
                        double price = 0.0;
                        if (CommonProcess.IsValidDouble(item.Price))
                        {
                            price = double.Parse(item.Price);
                        }
                        PromoteModel model = new PromoteModel
                        {
                            Id = item.Materials_no,
                            Name = item.Name,
                            Quantity = 1,
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
                        listViewPromote.Items.Clear();
                        int index = 0;
                        foreach (PromoteModel promote in promotes)
                        {
                            listViewPromote.Items.Add(listViewPromote.CreateListViewItem(promote, ++index));
                        }
                        break;
                    }
                }
                UpdateMoney();
            }
        }
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
                    Id = item.Materials_no,
                    Name = item.Name,
                    Address = item.Label
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
                        price = 50000.0;
                        ProductModel model = new ProductModel
                        {
                            Id = item.Materials_no,
                            Name = item.Name,
                            Quantity = 1,
                            Price = price,
                            Money = price,
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
                        listViewProduct.Items.Clear();
                        int index = 0;
                        foreach (ProductModel product in products)
                        {
                            product.Money = product.Quantity * product.Price;
                            listViewProduct.Items.Add(listViewProduct.CreateListViewItem(product, ++index));
                        }
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
            this.Close();
        }
        private void UpdateMoney()
        {
            double total = 0.0;
            double totalPromote = 0.0;
            double totalPay = 0.0;
            foreach (ProductModel item in products)
            {
                total += item.Money;
            }
            foreach (PromoteModel item in promotes)
            {
                totalPromote += item.Quantity * 20000;
            }
            totalPay = total - totalPromote;

            // Update UI
            lblTotal.Text = CommonProcess.FormatMoney(total);
            lblPromote.Text = CommonProcess.FormatMoney(totalPromote);
            lblTotalPay.Text = CommonProcess.FormatMoney(totalPay);
        }

        private void tbxItem_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.tbxItem.Text))
            {
                this.tbxItem.Text = Properties.Resources.SearchString;
                this.tbxItem.ForeColor = SystemColors.GrayText;
            }
        }

        private void tbxItem_Enter(object sender, EventArgs e)
        {
            if (this.tbxItem.Text.Equals(Properties.Resources.SearchString))
            {
                this.tbxItem.Text = string.Empty;
                this.tbxItem.ForeColor = Color.Black;
            }
        }

        private void tbxPromote_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.tbxPromote.Text))
            {
                this.tbxPromote.Text = Properties.Resources.SearchString;
                this.tbxPromote.ForeColor = SystemColors.GrayText;
            }
        }

        private void tbxPromote_Enter(object sender, EventArgs e)
        {
            if (this.tbxPromote.Text.Equals(Properties.Resources.SearchString))
            {
                this.tbxPromote.Text = string.Empty;
                this.tbxPromote.ForeColor = Color.Black;
            }
        }
    }
}
