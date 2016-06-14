using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MainPrj.Model;
using System.Collections.Generic;
using MainPrj.Util;

namespace MainPrj.View
{
    ///	<summary>
    ///	Inherited ListView to allow in-place editing of subitems
    ///	</summary>
    public class EditableListView : System.Windows.Forms.ListView
    {
        #region Interop structs, imports and constants
        /// <summary>
        /// MessageHeader for WM_NOTIFY
        /// </summary>
        private struct NMHDR
        {
            public IntPtr hwndFrom;
            public Int32 idFrom;
            public Int32 code;
        }


        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wPar, IntPtr lPar);
        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int len, ref	int[] order);

        // ListView messages
        private const int LVM_FIRST = 0x1000;
        private const int LVM_GETCOLUMNORDERARRAY = (LVM_FIRST + 59);

        // Windows Messages that will abort editing
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int WM_SIZE = 0x05;
        private const int WM_NOTIFY = 0x4E;

        private const int HDN_FIRST = -300;
        private const int HDN_BEGINDRAG = (HDN_FIRST - 10);
        private const int HDN_ITEMCHANGINGA = (HDN_FIRST - 0);
        private const int HDN_ITEMCHANGINGW = (HDN_FIRST - 20);
        #endregion

        #region Members
        /// <summary>
        /// List of columns type
        /// </summary>
        private List<Type> columnTypes = new List<Type>();
        /// <summary>
        /// List of editor in each column.
        /// </summary>
        private List<Control> columnEditors = new List<Control>();
        /// <summary>
        /// TextBox editor.
        /// </summary>
        private TextBox _textbox;
        /// <summary>
        /// ComboBox editor.
        /// </summary>
        private ComboBox _combobox;
        ///	<summary>
        ///	Required designer variable.
        ///	</summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// ComboBox editor.
        /// </summary>
        public ComboBox Combobox
        {
            get { return _combobox; }
            set { _combobox = value; }
        }

        private bool _doubleClickActivation = true;
        /// <summary>
        /// Is a double click required to start editing a cell?
        /// </summary>
        public bool DoubleClickActivation
        {
            get { return _doubleClickActivation; }
            set { _doubleClickActivation = value; }
        }

        /// <summary>
        /// List of columns type.
        /// </summary>
        public List<Type> ColumnTypes
        {
            get { return columnTypes; }
            set
            {
                columnTypes = value;
                // Set column editors
                SetColumnEditors();
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Event sub item clicked.
        /// </summary>
        public event SubItemEventHandler SubItemClicked;
        /// <summary>
        /// Event sub item begin editing.
        /// </summary>
        public event SubItemEventHandler SubItemBeginEditing;
        /// <summary>
        /// Event sub item end editing.
        /// </summary>
        public event SubItemEndEditingEventHandler SubItemEndEditing;
        #endregion

        #region Component	Designer generated code
        ///	<summary>
        ///	Required method	for	Designer support - do not modify 
        ///	the	contents of	this method	with the code editor.
        ///	</summary>
        private void InitializeComponent()
        {
            this._combobox = new System.Windows.Forms.ComboBox();
            this._textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _combobox
            // 
            this._combobox.DisplayMember = "Text";
            this._combobox.Location = new System.Drawing.Point(0, 0);
            this._combobox.Name = "_combobox";
            this._combobox.Size = new System.Drawing.Size(121, 21);
            this._combobox.TabIndex = 0;
            this._combobox.ValueMember = "Value";
            this._combobox.Visible = false;
            // 
            // _textbox
            // 
            this._textbox.Location = new System.Drawing.Point(0, 0);
            this._textbox.Name = "_textbox";
            this._textbox.Size = new System.Drawing.Size(100, 20);
            this._textbox.TabIndex = 1;
            this._textbox.Visible = false;
            // 
            // EditableListView
            // 
            this.Controls.Add(this._combobox);
            this.Controls.Add(this._textbox);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        public EditableListView()
        {
            // This	call is	required by	the	Windows.Forms Form Designer.
            InitializeComponent();

            base.FullRowSelect = true;
            base.View = System.Windows.Forms.View.Details;
            base.AllowColumnReorder = true;
            this.SubItemClicked += new SubItemEventHandler(Handler_SubItemClicked);
            this._combobox.SelectedIndexChanged += new EventHandler(combobox_SelectedValueChanged);
        }

        /// <summary>
        /// Set columns editors.
        /// </summary>
        public void SetColumnEditors()
        {
            // Check if column types list if match with Columns count
            if (this.columnTypes.Count != this.Columns.Count)
            {
                return;
            }
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (ColumnTypes[i] == typeof(TextBox))              // Type TextBox
                {
                    columnEditors.Insert(i, _textbox);
                }
                else if (ColumnTypes[i] == typeof(ComboBox))        // Type ComboBox
                {
                    columnEditors.Insert(i, Combobox);
                }
                else
                {
                    columnEditors.Insert(i, null);
                }
            }
        }
        /// <summary>
        /// Handle when change selected value on ComboBox
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void combobox_SelectedValueChanged(object sender, System.EventArgs e)
        {
            EndEditing(true);
        }
        /// <summary>
        /// Handle click sub item event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void Handler_SubItemClicked(object sender, SubItemEventArgs e)
        {
            //if (e.SubItem == 3) // Password field
            //{
            //    // the current value (text) of the subitem is ****, so we have to provide
            //    // the control with the actual text (that's been saved in the item's Tag property)
            //    e.Item.SubItems[e.SubItem].Text = e.Item.Tag.ToString();
            //}

            StartEditing(columnEditors[e.SubItem], e.Item, e.SubItem);
        }

        ///	<summary>
        ///	Clean up any resources being used.
        ///	</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// Retrieve the order in which columns appear
        /// </summary>
        /// <returns>Current display order of column indices</returns>
        public int[] GetColumnOrder()
        {
            IntPtr lPar = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)) * Columns.Count);

            IntPtr res = SendMessage(Handle, LVM_GETCOLUMNORDERARRAY, new IntPtr(Columns.Count), lPar);
            if (res.ToInt32() == 0)	// Something went wrong
            {
                Marshal.FreeHGlobal(lPar);
                return null;
            }

            int[] order = new int[Columns.Count];
            Marshal.Copy(lPar, order, 0, Columns.Count);

            Marshal.FreeHGlobal(lPar);

            return order;
        }


        /// <summary>
        /// Find ListViewItem and SubItem Index at position (x,y)
        /// </summary>
        /// <param name="x">relative to ListView</param>
        /// <param name="y">relative to ListView</param>
        /// <param name="item">Item at position (x,y)</param>
        /// <returns>SubItem index</returns>
        public int GetSubItemAt(int x, int y, out ListViewItem item)
        {
            item = this.GetItemAt(x, y);

            if (item != null)
            {
                int[] order = GetColumnOrder();
                Rectangle lviBounds;
                int subItemX;

                lviBounds = item.GetBounds(ItemBoundsPortion.Entire);
                subItemX = lviBounds.Left;
                for (int i = 0; i < order.Length; i++)
                {
                    ColumnHeader h = this.Columns[order[i]];
                    if (x < subItemX + h.Width)
                    {
                        return h.Index;
                    }
                    subItemX += h.Width;
                }
            }

            return -1;
        }


        /// <summary>
        /// Get bounds for a SubItem
        /// </summary>
        /// <param name="Item">Target ListViewItem</param>
        /// <param name="SubItem">Target SubItem index</param>
        /// <returns>Bounds of SubItem (relative to ListView)</returns>
        public Rectangle GetSubItemBounds(ListViewItem Item, int SubItem)
        {
            int[] order = GetColumnOrder();

            Rectangle subItemRect = Rectangle.Empty;
            if (SubItem >= order.Length)
            {
                throw new IndexOutOfRangeException("SubItem " + SubItem + " out of range");
            }

            if (Item == null)
            {
                throw new ArgumentNullException("Item");
            }

            Rectangle lviBounds = Item.GetBounds(ItemBoundsPortion.Entire);
            int subItemX = lviBounds.Left;

            ColumnHeader col;
            int i;
            for (i = 0; i < order.Length; i++)
            {
                col = this.Columns[order[i]];
                if (col.Index == SubItem)
                {
                    break;
                }
                subItemX += col.Width;
            }
            subItemRect = new Rectangle(subItemX, lviBounds.Top, this.Columns[order[i]].Width, lviBounds.Height);
            return subItemRect;
        }

        /// <summary>
        /// Windows Procedure.
        /// </summary>
        /// <param name="msg">Message</param>
        protected override void WndProc(ref	Message msg)
        {
            switch (msg.Msg)
            {
                // Look	for	WM_VSCROLL,WM_HSCROLL or WM_SIZE messages.
                case WM_VSCROLL:
                case WM_HSCROLL:
                case WM_SIZE:
                    EndEditing(false);
                    break;
                case WM_NOTIFY:
                    // Look for WM_NOTIFY of events that might also change the
                    // editor's position/size: Column reordering or resizing
                    NMHDR h = (NMHDR)Marshal.PtrToStructure(msg.LParam, typeof(NMHDR));
                    if (h.code == HDN_BEGINDRAG ||
                        h.code == HDN_ITEMCHANGINGA ||
                        h.code == HDN_ITEMCHANGINGW)
                        EndEditing(false);
                    break;
            }

            base.WndProc(ref msg);
        }


        #region Initialize editing depending of DoubleClickActivation property
        /// <summary>
        /// Handle mouse up event.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (DoubleClickActivation)
            {
                return;
            }

            EditSubitemAt(new Point(e.X, e.Y));
        }
        /// <summary>
        /// Handle double click event.
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            if (!DoubleClickActivation)
            {
                return;
            }

            Point pt = this.PointToClient(Cursor.Position);

            EditSubitemAt(pt);
        }

        ///<summary>
        /// Fire SubItemClicked
        ///</summary>
        ///<param name="p">Point of click/doubleclick</param>
        private void EditSubitemAt(Point p)
        {
            ListViewItem item;
            int idx = GetSubItemAt(p.X, p.Y, out item);
            if (idx >= 0)
            {
                OnSubItemClicked(new SubItemEventArgs(item, idx));
            }
        }
        #endregion

        #region In-place editing functions
        /// <summary>
        /// The control performing the actual editing.
        /// </summary>
        private Control _editingControl;
        /// <summary>
        /// The LVI being edited.
        /// </summary>
        private ListViewItem _editItem;
        /// <summary>
        /// The SubItem being edited.
        /// </summary>
        private int _editSubItem;
        /// <summary>
        /// Handle sub item begin editing event.
        /// </summary>
        /// <param name="e">SubItemEventArgs</param>
        protected void OnSubItemBeginEditing(SubItemEventArgs e)
        {
            if (SubItemBeginEditing != null)
                SubItemBeginEditing(this, e);
        }
        /// <summary>
        /// Handle sub item end editing event.
        /// </summary>
        /// <param name="e">SubItemEndEditingEventArgs</param>
        protected void OnSubItemEndEditing(SubItemEndEditingEventArgs e)
        {
            if (SubItemEndEditing != null)
                SubItemEndEditing(this, e);
        }
        /// <summary>
        /// Handle sub item clicked event.
        /// </summary>
        /// <param name="e">SubItemEventArgs</param>
        protected void OnSubItemClicked(SubItemEventArgs e)
        {
            if (SubItemClicked != null)
                SubItemClicked(this, e);
        }

        /// <summary>
        /// Begin in-place editing of given cell
        /// </summary>
        /// <param name="c">Control used as cell editor</param>
        /// <param name="Item">ListViewItem to edit</param>
        /// <param name="SubItem">SubItem index to edit</param>
        public void StartEditing(Control c, ListViewItem Item, int SubItem)
        {
            // Check column cannot editable.
            if (c == null)
            {
                return;
            }
            OnSubItemBeginEditing(new SubItemEventArgs(Item, SubItem));

            Rectangle rcSubItem = GetSubItemBounds(Item, SubItem);

            if (rcSubItem.X < 0)
            {
                // Left edge of SubItem not visible - adjust rectangle position and width
                rcSubItem.Width += rcSubItem.X;
                rcSubItem.X = 0;
            }
            if (rcSubItem.X + rcSubItem.Width > this.Width)
            {
                // Right edge of SubItem not visible - adjust rectangle width
                rcSubItem.Width = this.Width - rcSubItem.Left;
            }

            // Subitem bounds are relative to the location of the ListView!
            rcSubItem.Offset(Left, Top);

            // In case the editing control and the listview are on different parents,
            // account for different origins
            Point origin    = new Point(0, 0);
            Point lvOrigin  = this.Parent.PointToScreen(origin);
            Point ctlOrigin = c.Parent.PointToScreen(origin);

            rcSubItem.Offset(lvOrigin.X - ctlOrigin.X, lvOrigin.Y - ctlOrigin.Y);

            // Position and show editor
            c.Bounds  = rcSubItem;
            c.Text    = Item.SubItems[SubItem].Text;
            c.Visible = true;
            c.BringToFront();
            c.Focus();

            _editingControl           = c;
            _editingControl.Leave    += new EventHandler(_editControl_Leave);
            _editingControl.KeyPress += new KeyPressEventHandler(_editControl_KeyPress);

            _editItem    = Item;
            _editSubItem = SubItem;
        }

        /// <summary>
        /// Handle leave edit control event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void _editControl_Leave(object sender, EventArgs e)
        {
            // cell editor losing focus
            EndEditing(true);
        }
        /// <summary>
        /// Handle press key event on control.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">KeyPressEventArgs</param>
        private void _editControl_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)(int)Keys.Escape:
                    {
                        EndEditing(false);
                        break;
                    }

                case (char)(int)Keys.Enter:
                    {
                        EndEditing(true);
                        break;
                    }
            }
        }

        /// <summary>
        /// Accept or discard current value of cell editor control
        /// </summary>
        /// <param name="AcceptChanges">Use the _editingControl's Text as new SubItem text or discard changes?</param>
        public void EndEditing(bool AcceptChanges)
        {
            if (_editingControl == null)
                return;

            SubItemEndEditingEventArgs e = new SubItemEndEditingEventArgs(
                _editItem,		// The item being edited
                _editSubItem,	// The subitem index being edited
                AcceptChanges ?
                    _editingControl.Text :	// Use editControl text if changes are accepted
                    _editItem.SubItems[_editSubItem].Text,	// or the original subitem's text, if changes are discarded
                !AcceptChanges	// Cancel?
            );

            OnSubItemEndEditing(e);

            _editItem.SubItems[_editSubItem].Text = e.DisplayText;

            _editingControl.Leave -= new EventHandler(_editControl_Leave);
            _editingControl.KeyPress -= new KeyPressEventHandler(_editControl_KeyPress);

            _editingControl.Visible = false;

            _editingControl = null;
            _editItem = null;
            _editSubItem = -1;

        }
        #endregion
        /// <summary>
        /// Create product listview.
        /// </summary>
        /// <param name="model">Product model</param>
        /// <param name="index">Index</param>
        /// <returns>ListViewItem</returns>
        public ListViewItem CreateListViewItem(ProductModel model, int index)
        {
            // Create array data
            string[] arr = new string[(int)ProductColumns.PRODUCT_TABLE_COLUMN_NUM];
            // No column
            arr[(int)ProductColumns.PRODUCT_TABLE_COLUMN_NO] = String.Format("{0}", index);
            // Id column
            arr[(int)ProductColumns.PRODUCT_TABLE_COLUMN_ID] = model.Materials_no;
            // Name column
            arr[(int)ProductColumns.PRODUCT_TABLE_COLUMN_NAME] = model.Name;
            // Quantity column
            arr[(int)ProductColumns.PRODUCT_TABLE_COLUMN_QUANTITY] = String.Format("{0}", model.Quantity);
            // Price column
            arr[(int)ProductColumns.PRODUCT_TABLE_COLUMN_PRICE] = String.Format("{0}", model.Price);
            // Money column
            arr[(int)ProductColumns.PRODUCT_TABLE_COLUMN_MONEY] = CommonProcess.FormatMoney(model.Money);

            // Create listview item object
            ListViewItem item = new ListViewItem(arr);
            // Set tag value
            item.Tag = model.Id;

            return item;
        }
        /// <summary>
        /// Create promote listview.
        /// </summary>
        /// <param name="model">Promote model</param>
        /// <param name="index">Index</param>
        /// <returns>ListViewItem</returns>
        public ListViewItem CreateListViewItem(PromoteModel model, int index)
        {
            // Create array data
            string[] arr = new string[(int)PromoteColumns.PROMOTE_TABLE_COLUMN_NUM];
            // No column
            arr[(int)PromoteColumns.PROMOTE_TABLE_COLUMN_NO] = String.Format("{0}", index);
            // Id column
            arr[(int)PromoteColumns.PROMOTE_TABLE_COLUMN_ID] = model.Materials_no;
            // Name column
            arr[(int)PromoteColumns.PROMOTE_TABLE_COLUMN_NAME] = model.Name;
            // Quantity column
            arr[(int)PromoteColumns.PROMOTE_TABLE_COLUMN_QUANTITY] = String.Format("{0}", model.Quantity);

            // Create listview item object
            ListViewItem item = new ListViewItem(arr);
            // Set tag value
            item.Tag = model.Id;

            return item;
        }
    }

	/// <summary>
	/// Event Handler for SubItem events
	/// </summary>
	public delegate void SubItemEventHandler(object sender, SubItemEventArgs e);
	/// <summary>
	/// Event Handler for SubItemEndEditing events
	/// </summary>
	public delegate void SubItemEndEditingEventHandler(object sender, SubItemEndEditingEventArgs e);

	/// <summary>
	/// Event Args for SubItemClicked event
	/// </summary>
	public class SubItemEventArgs : EventArgs
	{
		public SubItemEventArgs(ListViewItem item, int subItem)
		{
			_subItemIndex = subItem;
			_item = item;
		}
		private int _subItemIndex = -1;
		private ListViewItem _item = null;
		public int SubItem
		{
			get { return _subItemIndex; }
		}
		public ListViewItem Item
		{
			get { return _item; }
		}
	}


	/// <summary>
	/// Event Args for SubItemEndEditingClicked event
	/// </summary>
	public class SubItemEndEditingEventArgs : SubItemEventArgs
	{
		private string _text = string.Empty;
		private bool _cancel = true;

		public SubItemEndEditingEventArgs(ListViewItem item, int subItem, string display, bool cancel) :
			base(item, subItem)
		{
			_text = display;
			_cancel = cancel;
		}
		public string DisplayText
		{
			get { return _text; }
			set { _text = value; }
		}
		public bool Cancel
		{
			get { return _cancel; }
			set { _cancel = value; }
		}
	}
}
