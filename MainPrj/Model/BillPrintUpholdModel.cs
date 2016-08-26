using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MainPrj.Model
{
    class BillPrintUpholdModel : BillPrintModel
    {
        private string _reason;

        /// <summary>
        /// Reason of Uphold.
        /// </summary>
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public BillPrintUpholdModel() : base()
        {
            _reason = string.Empty;
            Title = "PHIẾU BẢO TRÌ";
        }
        /// <summary>
        /// Override Print Content method.
        /// </summary>
        /// <param name="Offset">Offset start draw</param>
        /// <param name="graphics">Graphics object</param>
        /// <returns>Offset end of draw</returns>
        public override int PrintContent(int Offset, System.Drawing.Graphics graphics)
        {
            Font font = new Font(Properties.Settings.Default.BilllFont, 16);
            SizeF size = graphics.MeasureString(_reason, font, Properties.Settings.Default.BillSizeW);
            int startX = 5;
            int startY = 5;
            int positionX = startX + (Properties.Settings.Default.BillSizeW - (int)size.Width) / 2;
            SolidBrush brush = new SolidBrush(Color.Black);
            graphics.DrawString(_reason, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(Properties.Settings.Default.BillSizeW, size.Height)));
            return Offset + (int)size.Height;
        }
    }
}
