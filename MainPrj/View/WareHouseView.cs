using MainPrj.Model;
using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class WareHouseView : Form
    {
        private ImageList _listProductImg = new ImageList();
        private ImageList _listPromoteImg = new ImageList();
        private Dictionary<string, MaterialBitmap> _listProductImgMaterial = new Dictionary<string, MaterialBitmap>();
        private Dictionary<string, MaterialBitmap> _listPromoteImgMaterial = new Dictionary<string, MaterialBitmap>();
        public WareHouseView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handle real-time search on list products.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbxSearch.Text.Trim().Equals(Properties.Resources.SearchString))
            {
                return;
            }
            this.listViewSourceProduct.Items.Clear();
            Dictionary<string, MaterialModel> listProducts = new Dictionary<string, MaterialModel>();
            foreach (MaterialModel item in DataPure.Instance.TempData.Material_gas)
            {
                if (item.IsContainString(tbxSearch.Text.Trim()))
                {
                    listProducts.Add(item.Materials_no, item);
                }
            }
            LoadListProducts(listProducts);
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
        /// Handle when load form.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void WareHouseView_Load(object sender, EventArgs e)
        {
            LoadAllProducts();
            LoadAllPromotes();
            // Product
            int size                        = Properties.Settings.Default.ImageSize;
            this._listProductImg.ImageSize  = new Size(size, size);
            this._listProductImg.ColorDepth = ColorDepth.Depth24Bit;
            CommonProcess.ListView_SetSpacing(this.listViewSelectedProduct, (short)(size + 20), (short)(size + 32));
            this.listViewSelectedProduct.LargeImageList = this._listProductImg;

            _listProductImgMaterial              = CommonProcess.CloneDictionary<string, MaterialBitmap>(
                                                    DataPure.Instance.ListRecentProductsImg);
            foreach (string item in DataPure.Instance.ListRecentProductsImg.Keys)
            {
                AddProductSelected(DataPure.Instance.ListRecentProductsImg[item].Model);
            }

            // Promote
            this._listPromoteImg.ImageSize = new Size(size, size);
            this._listPromoteImg.ColorDepth = ColorDepth.Depth24Bit;
            CommonProcess.ListView_SetSpacing(this.listViewSelectedPromote, (short)(size + 20), (short)(size + 32));
            this.listViewSelectedPromote.LargeImageList = this._listPromoteImg;
            _listPromoteImgMaterial = CommonProcess.CloneDictionary<string, MaterialBitmap>(
                                                    DataPure.Instance.ListRecentPromotesImg);
            foreach (string item in DataPure.Instance.ListRecentPromotesImg.Keys)
            {
                AddPromoteSelected(DataPure.Instance.ListRecentPromotesImg[item].Model);
            }
        }

        private void LoadAllPromotes()
        {
            this.listViewSourcePromote.Items.Clear();
            LoadListPromotes(DataPure.Instance.GetListMaterialPromote());
        }
        /// <summary>
        /// Add products to listview.
        /// </summary>
        /// <param name="model">Model</param>
        private void AddProductSelected(MaterialModel model)
        {
            if (model != null)
            {
                Color color = Color.Black;
                foreach (string key in CommonProcess.MATERIAL_COLOR.Keys)
                {
                    if (model.Name.ToLower().Contains(key))
                    {
                        color = CommonProcess.MATERIAL_COLOR[key];
                    }
                }
                MaterialBitmap bitmap = this._listProductImgMaterial[model.Materials_no];
                if (bitmap.Bitmap == null)
                {
                    bitmap.Bitmap = CommonProcess.CreateAvatar(bitmap.Text,
                        Properties.Settings.Default.ImageSize, color, Properties.Settings.Default.ImageFontSize);
                    bitmap.Color = color;
                }
                this._listProductImg.Images.Add(bitmap.Bitmap);
                //this._listProductImgMaterial.Add(bitmap.Model.Materials_no, bitmap);
                ListViewItem lvi = new ListViewItem(bitmap.Text);
                lvi.ImageIndex        = this._listProductImg.Images.Count - 1;
                lvi.Tag               = bitmap;
                this.listViewSelectedProduct.Items.Add(lvi);
            }
        }
        /// <summary>
        /// Add promote to listview.
        /// </summary>
        /// <param name="model">Model</param>
        private void AddPromoteSelected(MaterialModel model)
        {
            if (model != null)
            {
                Color color = Color.Black;
                foreach (string key in CommonProcess.MATERIAL_COLOR.Keys)
                {
                    if (model.Name.ToLower().Contains(key))
                    {
                        color = CommonProcess.MATERIAL_COLOR[key];
                    }
                }
                MaterialBitmap bitmap = this._listPromoteImgMaterial[model.Materials_no];
                if (bitmap.Bitmap == null)
                {
                    bitmap.Bitmap = CommonProcess.CreateAvatar(bitmap.Text,
                        Properties.Settings.Default.ImageSize, color, Properties.Settings.Default.ImageFontSize);
                    bitmap.Color = color;
                }
                this._listPromoteImg.Images.Add(bitmap.Bitmap);
                ListViewItem lvi = new ListViewItem(bitmap.Text);
                lvi.ImageIndex = this._listPromoteImg.Images.Count - 1;
                lvi.Tag = bitmap;
                this.listViewSelectedPromote.Items.Add(lvi);
            }
        }
        /// <summary>
        /// Load all products.
        /// </summary>
        private void LoadAllProducts()
        {
            this.listViewSourceProduct.Items.Clear();
            LoadListProducts(DataPure.Instance.GetListMaterialGas());
        }
        /// <summary>
        /// Load list products.
        /// </summary>
        /// <param name="listProducts">List data to load</param>
        private void LoadListProducts(Dictionary<string, MaterialModel> listProducts)
        {
            if (listProducts != null)
            {
                foreach (string item in listProducts.Keys)
                {
                    ListViewItem itemLV;
                    string[] arr = new string[2];
                    arr[0]       = String.Format("{0} - {1}", listProducts[item].Materials_no, listProducts[item].Name);
                    arr[1]       = string.Empty;
                    itemLV       = new ListViewItem(arr);
                    itemLV.Tag   = listProducts[item].Materials_no;
                    this.listViewSourceProduct.Items.Add(itemLV);
                }
            }
        }

        /// <summary>
        /// Handle click on All button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnAll_Click(object sender, EventArgs e)
        {
            tbxSearch.Text      = Properties.Resources.SearchString;
            tbxSearch.ForeColor = SystemColors.GrayText;
            LoadAllProducts();
        }
        /// <summary>
        /// Handle add product into reuse list.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            HandleAddProduct();
        }
        /// <summary>
        /// Handle add product.
        /// </summary>
        private void HandleAddProduct()
        {
            if (this.listViewSourceProduct.SelectedItems.Count > 0)
            {
                string id           = this.listViewSourceProduct.SelectedItems[0].Tag.ToString();
                MaterialModel model = DataPure.Instance.GetListMaterialGas()[id];
                if (!_listProductImgMaterial.ContainsKey(model.Materials_no))
                {
                    MaterialBitmap bitmap = new MaterialBitmap()
                    {
                        Model = model,
                        Text = model.Materials_no
                    };
                    _listProductImgMaterial.Add(model.Materials_no, bitmap);
                    AddProductSelected(model);
                }
            }
        }
        /// <summary>
        /// Handle double click on Products listview.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void listViewSource_DoubleClick(object sender, EventArgs e)
        {
            HandleAddProduct();
        }
        /// <summary>
        /// Handle click Save button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //DataPure.Instance.ListRecentProductsImg = this._listProductImgMaterial;
            //DataPure.Instance.ListRecentProductsImg = CommonProcess.CloneDictionary<string, MaterialBitmap>(
            //    _listProductImgMaterial);
            DataPure.Instance.ListRecentProductsImg = _listProductImgMaterial;
            DataPure.Instance.ListRecentPromotesImg = _listPromoteImgMaterial;
            CommonProcess.WriteSetting();
            CommonProcess.WriteSettingPromote();
            this.Close();
        }
        /// <summary>
        /// Handle after done edit label.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">LabelEditEventArgs</param>
        private void listViewSelected_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if ((this.listViewSelectedProduct.SelectedItems.Count > 0)
                && (e.Label != null))
            {
                ListViewItem item     = this.listViewSelectedProduct.SelectedItems[0];
                MaterialBitmap bitmap = (MaterialBitmap)item.Tag;
                bitmap.Text           = e.Label;
                bitmap.Bitmap = CommonProcess.CreateAvatar(e.Label, Properties.Settings.Default.ImageSize, bitmap.Color, Properties.Settings.Default.ImageFontSize);
                _listProductImg.Images[item.ImageIndex] = bitmap.Bitmap;
            }
        }
        /// <summary>
        /// Close.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Double click on list view.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void listViewSelected_DoubleClick(object sender, EventArgs e)
        {
            if (this.listViewSelectedProduct.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = this.colorDialog.ShowDialog();
                if (dialogResult.Equals(DialogResult.OK))
                {
                    ListViewItem item     = this.listViewSelectedProduct.SelectedItems[0];
                    MaterialBitmap bitmap = (MaterialBitmap)item.Tag;
                    bitmap.Color          = this.colorDialog.Color;
                    bitmap.Bitmap = CommonProcess.CreateAvatar(bitmap.Text, Properties.Settings.Default.ImageSize, bitmap.Color, Properties.Settings.Default.ImageFontSize);
                    _listProductImg.Images[item.ImageIndex] = bitmap.Bitmap;
                }
            }
        }
        /// <summary>
        /// Remove item.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            HandleRemoveProduct();
        }
        /// <summary>
        /// Handle remove product.
        /// </summary>
        private void HandleRemoveProduct()
        {
            if (this.listViewSelectedProduct.SelectedItems.Count > 0)
            {
                ListViewItem item     = this.listViewSelectedProduct.SelectedItems[0];
                MaterialBitmap bitmap = (MaterialBitmap)item.Tag;
                this._listProductImgMaterial.Remove(bitmap.Model.Materials_no);
                this.listViewSelectedProduct.Items.Remove(item);
            }
        }
        /// <summary>
        /// Handle key down event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">KeyEventArgs</param>
        private void WareHouseView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (this.listViewSelectedProduct.Focused)
                    {
                        HandleRemoveProduct();
                    }
                    else if (this.listViewSelectedPromote.Focused)
                    {
                        HandleRemovePromote();
                    }
                    break;
                default: break;
            }
        }

        private void tbxSearchPromote_TextChanged(object sender, EventArgs e)
        {
            if (tbxSearchPromote.Text.Trim().Equals(Properties.Resources.SearchString))
            {
                return;
            }
            this.listViewSourcePromote.Items.Clear();
            Dictionary<string, MaterialModel> listPromotes = new Dictionary<string, MaterialModel>();
            foreach (MaterialModel item in DataPure.Instance.TempData.Material_promotion)
            {
                if (item.IsContainString(tbxSearch.Text.Trim()))
                {
                    listPromotes.Add(item.Materials_no, item);
                }
            }
            LoadListPromotes(listPromotes);
        }

        private void LoadListPromotes(Dictionary<string, MaterialModel> listPromotes)
        {
            if (listPromotes != null)
            {
                foreach (string item in listPromotes.Keys)
                {
                    ListViewItem itemLV;
                    string[] arr = new string[2];
                    arr[0] = String.Format("{0} - {1}", listPromotes[item].Materials_no, listPromotes[item].Name);
                    arr[1] = string.Empty;
                    itemLV = new ListViewItem(arr);
                    itemLV.Tag = listPromotes[item].Materials_no;
                    this.listViewSourcePromote.Items.Add(itemLV);
                }
            }
        }

        private void tbxSearchPromote_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbxSearchPromote.Text.Trim()))
            {
                this.tbxSearchPromote.Text      = Properties.Resources.SearchString;
                this.tbxSearchPromote.ForeColor = SystemColors.GrayText;
            }
        }

        private void tbxSearchPromote_Enter(object sender, EventArgs e)
        {
            if (this.tbxSearchPromote.Text.Equals(Properties.Resources.SearchString))
            {
                this.tbxSearchPromote.Text      = string.Empty;
                this.tbxSearchPromote.ForeColor = Color.Black;
            }
        }

        private void btnAllPromote_Click(object sender, EventArgs e)
        {
            tbxSearchPromote.Text = Properties.Resources.SearchString;
            tbxSearchPromote.ForeColor = SystemColors.GrayText;
            LoadAllPromotes();
        }

        private void btnAddPromote_Click(object sender, EventArgs e)
        {
            HandleAddPromote();
        }

        private void HandleAddPromote()
        {
            if (this.listViewSourcePromote.SelectedItems.Count > 0)
            {
                string id = this.listViewSourcePromote.SelectedItems[0].Tag.ToString();
                MaterialModel model = DataPure.Instance.GetListMaterialPromote()[id];
                if (!_listPromoteImgMaterial.ContainsKey(model.Materials_no))
                {
                    MaterialBitmap bitmap = new MaterialBitmap()
                    {
                        Model = model,
                        Text = model.Materials_no
                    };
                    _listPromoteImgMaterial.Add(model.Materials_no, bitmap);
                    AddPromoteSelected(model);
                }
            }
        }

        private void listViewSourcePromote_DoubleClick(object sender, EventArgs e)
        {
            HandleAddPromote();
        }

        private void listViewSelectedPromote_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if ((this.listViewSelectedPromote.SelectedItems.Count > 0)
                && (e.Label != null))
            {
                ListViewItem item = this.listViewSelectedPromote.SelectedItems[0];
                MaterialBitmap bitmap = (MaterialBitmap)item.Tag;
                bitmap.Text = e.Label;
                bitmap.Bitmap = CommonProcess.CreateAvatar(e.Label, Properties.Settings.Default.ImageSize, bitmap.Color, Properties.Settings.Default.ImageFontSize);
                _listPromoteImg.Images[item.ImageIndex] = bitmap.Bitmap;
            }
        }

        private void listViewSelectedPromote_DoubleClick(object sender, EventArgs e)
        {
            if (this.listViewSelectedPromote.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = this.colorDialog.ShowDialog();
                if (dialogResult.Equals(DialogResult.OK))
                {
                    ListViewItem item = this.listViewSelectedPromote.SelectedItems[0];
                    MaterialBitmap bitmap = (MaterialBitmap)item.Tag;
                    bitmap.Color = this.colorDialog.Color;
                    bitmap.Bitmap = CommonProcess.CreateAvatar(bitmap.Text, Properties.Settings.Default.ImageSize, bitmap.Color);
                    _listPromoteImg.Images[item.ImageIndex] = bitmap.Bitmap;
                }
            }
        }
        
        private void HandleRemovePromote()
        {
            if (this.listViewSelectedPromote.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listViewSelectedPromote.SelectedItems[0];
                MaterialBitmap bitmap = (MaterialBitmap)item.Tag;
                this._listPromoteImgMaterial.Remove(bitmap.Model.Materials_no);
                this.listViewSelectedPromote.Items.Remove(item);
            }
        }

        private void btnRemovePromote_Click(object sender, EventArgs e)
        {
            HandleRemovePromote();
        }
    }
}
