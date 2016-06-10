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
    public partial class SelectorView : Form
    {
        /// <summary>
        /// List of data.
        /// </summary>
        private List<SelectorModel> listData = new List<SelectorModel>();
        /// <summary>
        /// Selected id.
        /// </summary>
        private string selectedId = String.Empty;

        public string SelectedId
        {
            get { return selectedId; }
            set { selectedId = value; }
        }

        public List<SelectorModel> ListData
        {
            get { return listData; }
            set { listData = value; }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public SelectorView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handle when loading form.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void SelectorView_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < listData.Count; i++)
            {
                ListViewItem item;
                string[] arr = new string[(int)SelectorColumns.SELECTOR_COLUMN_NUM];

                arr[(int)SelectorColumns.SELECTOR_COLUMN_NO] = String.Format("{0}", i + 1);
                arr[(int)SelectorColumns.SELECTOR_COLUMN_NAME] = listData[i].Name;
                arr[(int)SelectorColumns.SELECTOR_COLUMN_ADDRESS] = listData[i].Address;
                arr[(int)SelectorColumns.SELECTOR_COLUMN_ID] = listData[i].Id;
                item = new ListViewItem(arr);
                this.listViewSelector.Items.Add(item);
                //this.listViewSelector.Select();
                //if (this.listViewSelector.Items.Count > 0)
                //{
                //    this.listViewSelector.Items[0].Selected = true;
                //    this.selectedId = this.listViewSelector.Items[0].SubItems[(int)SelectorColumns.SELECTOR_COLUMN_ID].Text;
                //}
            }
        }
        /// <summary>
        /// Handle when double-click on listView.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void listViewSelector_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listViewSelector.SelectedItems.Count > 0)
            {
                this.selectedId = this.listViewSelector.SelectedItems[0].SubItems[(int)SelectorColumns.SELECTOR_COLUMN_ID].Text;
                this.Close();
            }
        }
        /// <summary>
        /// Handle when form closing.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void SelectorView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if selected id is empty
            //if (String.IsNullOrEmpty(this.selectedId))
            //{
            //    // Show message box
            //    DialogResult result = CommonProcess.ShowInformMessage(Properties.Resources.AreYouSureNotSelectCustomer);
            //    if (result.Equals(DialogResult.No))
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }
        /// <summary>
        /// Handle when active listview.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void listViewSelector_Enter(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handle when press key on listview.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void listViewSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (this.listViewSelector.SelectedItems.Count > 0)
                {
                    this.selectedId = this.listViewSelector.SelectedItems[0].SubItems[(int)SelectorColumns.SELECTOR_COLUMN_ID].Text;
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Handle when item selection change on listview.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void listViewSelector_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
        }
        /// <summary>
        /// Handle when click Close button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.listViewSelector.SelectedItems.Count > 0)
            {
                this.selectedId = this.listViewSelector.SelectedItems[0].SubItems[(int)SelectorColumns.SELECTOR_COLUMN_ID].Text;
                this.Close();
            }
            this.Close();
        }
        public void SetHeaderText(SelectorColumns column, string header)
        {
            this.listViewSelector.Columns[(int)column].Text = header;

        }
    }
}
