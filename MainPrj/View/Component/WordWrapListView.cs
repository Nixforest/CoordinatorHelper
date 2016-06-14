using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View.Component
{
    public class WordWrapListView : EditableListView
    {
        private const int LVM_FIRST = 0x1000;
        private const int LVM_INSERTITEMA = (WordWrapListView.LVM_FIRST + 7);
        private const int LVM_INSERTITEMW = (WordWrapListView.LVM_FIRST + 77);
        private Graphics graphics;

        public WordWrapListView()
        {
            this.graphics = this.CreateGraphics();
            base.View = System.Windows.Forms.View.Details;

            this.AutoSizeRowHeight = true;

        }

        //overriding WndProc because there are no item added events
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                // Detect item insert and adjust the row size if necessary based on the text
                // add in LVM_DELETEITEM and LVM_DELETEALLITEMS and reset this.rowHeight if you want to reduce the row height on remove
                case WordWrapListView.LVM_INSERTITEMA:
                case WordWrapListView.LVM_INSERTITEMW:
                    {
                        ListViewItem lvi = this.Items[this.Items.Count - 1];
                        if (lvi != null)
                        {
                            for (int i = 1; i < lvi.SubItems.Count; ++i)
                            {
                                ListViewItem.ListViewSubItem lvsi = lvi.SubItems[i];

                                string text = lvsi.Text;

                                int tmpHeight = 0;
                                int maxWidth = this.Columns[i].Width;

                                SizeF stringSize = this.graphics.MeasureString(text, this.Font);

                                if (stringSize.Width > 0)
                                {
                                    tmpHeight = (int)Math.Ceiling((stringSize.Width / maxWidth) * stringSize.Height);

                                    if (tmpHeight > this.rowHeight)
                                    {
                                        this.RowHeight = tmpHeight;
                                    }
                                }
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
            base.WndProc(ref m);
        }

        private void updateRowHeight()
        {
            //small image list hack
            //ImageList imgList = new ImageList();
            ////imgList.ImageSize = new Size(this.rowHeight, this.rowHeight);
            //imgList.ImageSize = new Size(1, this.rowHeight);
            //this.SmallImageList = imgList;
        }

        [System.ComponentModel.DefaultValue(true)]
        public bool AutoSizeRowHeight { get; set; }

        private int rowHeight;
        public int RowHeight
        {
            get
            {
                return this.rowHeight;
            }
            private set
            {
                //Remove value > this.rowHeight if you ever want to scale down the height on remove item
                //if (value > this.rowHeight && this.AutoSizeRowHeight)
                if (this.AutoSizeRowHeight)
                {
                    this.rowHeight = value;
                    this.updateRowHeight();
                }
            }
        }

        // only allow details view
        [Browsable(false), Bindable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Windows.Forms.View View
        {
            get
            {
                return base.View;
            }
            set
            {

            }
        }
    }
}
