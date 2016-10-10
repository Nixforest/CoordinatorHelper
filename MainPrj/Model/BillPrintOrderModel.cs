using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MainPrj.Model
{
    public class BillPrintOrderModel: BillPrintModel
    {
        private List<ProductModel> products;
        private List<PromoteModel> promotes;
        private double totalMoney;
        private double totalPromote;
        private double totalPay;
        /// <summary>
        /// Constructor.
        /// </summary>
        public BillPrintOrderModel() : base()
        {
            products     = new List<ProductModel>();
            promotes     = new List<PromoteModel>();
            totalMoney   = 0.0;
            totalPromote = 0.0;
            totalPay     = 0.0;
            Title        = "PHIẾU GIAO GAS";
        }

        /// <summary>
        /// Total money must pay.
        /// </summary>
        public double TotalPay
        {
            get { return totalPay; }
            set { totalPay = value; }
        }
        /// <summary>
        /// Total promotes money.
        /// </summary>
        public double TotalPromote
        {
            get { return totalPromote; }
            set { totalPromote = value; }
        }

        /// <summary>
        /// Total money.
        /// </summary>
        public double TotalMoney
        {
            get { return totalMoney; }
            set { totalMoney = value; }
        }
        /// <summary>
        /// List of promotes.
        /// </summary>
        public List<PromoteModel> Promotes
        {
            get { return promotes; }
            set { promotes = value; }
        }

        /// <summary>
        /// List of products.
        /// </summary>
        public List<ProductModel> Products
        {
            get { return products; }
            set { products = value; }
        }
        /// <summary>
        /// Override Print Content method.
        /// </summary>
        /// <param name="Offset">Offset start draw</param>
        /// <param name="graphics">Graphics object</param>
        /// <returns>Offset end of draw</returns>
        public override int PrintContent(int Offset, Graphics graphics)
        {
            // Products label Name
            int nameW = 94;
            int qtyW = 25;
            int moneyW = 63;
            int totalW = 63;
            string text = string.Empty;
            SizeF size = new SizeF();
            int positionX = 0;
            int startX = 5;
            int startY = 5;
            SolidBrush brush = new SolidBrush(Color.Black);
            //Offset = Offset + (int)size.Height;
            text = "Tên hàng";
            Font font = new Font(Properties.Settings.Default.BilllFont, 8, FontStyle.Bold | FontStyle.Underline);
            size = graphics.MeasureString(text, font, nameW);
            //positionX = startX + (nameW - (int)size.Width) / 2;
            positionX = startX;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(nameW, size.Height)));

            text = "SL";
            size = graphics.MeasureString(text, font, qtyW);
            positionX = startX + nameW + (qtyW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(qtyW, size.Height)));

            text = "ĐG";
            size = graphics.MeasureString(text, font, moneyW);
            positionX = startX + nameW + qtyW + (moneyW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(moneyW, size.Height)));

            text = "T.Tiền";
            size = graphics.MeasureString(text, font, totalW);
            positionX = startX + nameW + qtyW + moneyW + (totalW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(totalW, size.Height)));
            // Products
            font = new Font(Properties.Settings.Default.BilllFont, 10);
            foreach (ProductModel product in this.Products)
            {
                Offset = Offset + (int)size.Height;

                text = product.Quantity.ToString();
                size = graphics.MeasureString(text, font, qtyW);
                positionX = startX + nameW + (qtyW - (int)size.Width) / 2;
                graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                    new SizeF(qtyW, size.Height)));

                text = CommonProcess.FormatMoney(product.Price);
                size = graphics.MeasureString(text, font, moneyW);
                positionX = startX + nameW + qtyW + (moneyW - (int)size.Width) / 2;
                graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                    new SizeF(moneyW, size.Height)));

                text = CommonProcess.FormatMoney(product.Money);
                size = graphics.MeasureString(text, font, totalW);
                positionX = startX + nameW + qtyW + moneyW + (totalW - (int)size.Width) / 2;
                graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                    new SizeF(totalW, size.Height)));

                text = product.Name;
                size = graphics.MeasureString(text, font, nameW);
                positionX = startX;
                graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                    new SizeF(nameW, size.Height)));
            }
            //++ BUG0056-SPJ (NguyenPT 20160830) Handle order type
            string name = string.Empty;
            if (this.OrderType.Equals(OrderType.ORDERTYPE_FULLORDER))
            {
                name = Properties.Resources.Cylinder;
            }
            else if (this.OrderType.Equals(OrderType.ORDERTYPE_THECHAN))
            {
                name = Properties.Resources.Bond;
            }
            if (!string.IsNullOrEmpty(name))
            {
                Offset = Offset + (int)size.Height;

                text = "1";
                size = graphics.MeasureString(text, font, qtyW);
                positionX = startX + nameW + (qtyW - (int)size.Width) / 2;
                graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                    new SizeF(qtyW, size.Height)));

                text = CommonProcess.FormatMoney(this.OtherMoney);
                size = graphics.MeasureString(text, font, moneyW);
                positionX = startX + nameW + qtyW + (moneyW - (int)size.Width) / 2;
                graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                    new SizeF(moneyW, size.Height)));

                text = CommonProcess.FormatMoney(this.OtherMoney);
                size = graphics.MeasureString(text, font, totalW);
                positionX = startX + nameW + qtyW + moneyW + (totalW - (int)size.Width) / 2;
                graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                    new SizeF(totalW, size.Height)));

                text = name;
                size = graphics.MeasureString(text, font, nameW);
                positionX = startX;
                graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                    new SizeF(nameW, size.Height)));
            }
            //-- BUG0056-SPJ (NguyenPT 20160830) Handle order type

            // Promote label
            Offset = Offset + (int)size.Height;
            text = "Quà tặng kèm theo";
            font = new Font(Properties.Settings.Default.BilllFont, 10, FontStyle.Bold | FontStyle.Underline | FontStyle.Italic);
            size = graphics.MeasureString(text, font, Properties.Settings.Default.BillSizeW);
            positionX = startX;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(Properties.Settings.Default.BillSizeW, size.Height)));

            // Promote label Name
            Offset = Offset + (int)size.Height;
            nameW = 150;
            text = "Tên quà tặng";
            font = new Font(Properties.Settings.Default.BilllFont, 8, FontStyle.Bold | FontStyle.Underline);
            size = graphics.MeasureString(text, font, nameW);
            //positionX = startX + (nameW - (int)size.Width) / 2;
            positionX = startX;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(nameW, size.Height)));

            text = "SL";
            size = graphics.MeasureString(text, font, qtyW);
            positionX = startX + nameW + (qtyW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(qtyW, size.Height)));
            font = new Font(Properties.Settings.Default.BilllFont, 10);
            foreach (PromoteModel promote in this.Promotes)
            {
                Offset = Offset + (int)size.Height;
                text = promote.Quantity.ToString();
                size = graphics.MeasureString(text, font, qtyW);
                positionX = startX + nameW + (qtyW - (int)size.Width) / 2;
                graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                    new SizeF(qtyW, size.Height)));
                text = promote.Name;
                size = graphics.MeasureString(text, font, nameW);
                positionX = startX;
                graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                    new SizeF(nameW, size.Height)));
            }

            // Underline
            Offset = Offset + (int)size.Height;
            text = "-----------------------------------------";
            font = new Font(Properties.Settings.Default.BilllFont, 10);
            size = graphics.MeasureString(text, font);
            positionX = startX + (Properties.Settings.Default.BillSizeW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, positionX, startY + Offset);

            // Total money
            Offset = Offset + (int)size.Height;
            text = "Tổng hóa đơn:";
            font = new Font(Properties.Settings.Default.BilllFont, 12, FontStyle.Bold);
            size = graphics.MeasureString(text, font, Properties.Settings.Default.BillSizeW);
            positionX = startX;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(Properties.Settings.Default.BillSizeW, size.Height)));
            //++ BUG0056-SPJ (NguyenPT 20160830) Handle order type
            //text = CommonProcess.FormatMoney(this.TotalMoney);
            text = CommonProcess.FormatMoney(this.TotalMoney + this.OtherMoney);
            //-- BUG0056-SPJ (NguyenPT 20160830) Handle order type
            font = new Font(Properties.Settings.Default.BilllFont, 12, FontStyle.Bold);
            size = graphics.MeasureString(text, font, Properties.Settings.Default.BillSizeW);
            positionX = (Properties.Settings.Default.BillSizeW - (int)size.Width) - startX;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(Properties.Settings.Default.BillSizeW, size.Height)));

            // Total promote
            Offset = Offset + (int)size.Height;
            text = "Tổng chiết khấu:";
            font = new Font(Properties.Settings.Default.BilllFont, 10, FontStyle.Italic);
            size = graphics.MeasureString(text, font, Properties.Settings.Default.BillSizeW);
            positionX = startX;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(Properties.Settings.Default.BillSizeW, size.Height)));
            text = CommonProcess.FormatMoney(this.TotalPromote);
            font = new Font(Properties.Settings.Default.BilllFont, 10, FontStyle.Italic);
            size = graphics.MeasureString(text, font, Properties.Settings.Default.BillSizeW);
            positionX = (Properties.Settings.Default.BillSizeW - (int)size.Width) - startX;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(Properties.Settings.Default.BillSizeW, size.Height)));

            // Total pay
            Offset = Offset + (int)size.Height;
            text = "Tổng phải thu:";
            font = new Font(Properties.Settings.Default.BilllFont, 12, FontStyle.Bold);
            size = graphics.MeasureString(text, font, Properties.Settings.Default.BillSizeW);
            positionX = startX;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(Properties.Settings.Default.BillSizeW, size.Height)));
            text = CommonProcess.FormatMoney(this.TotalPay);
            font = new Font(Properties.Settings.Default.BilllFont, 12, FontStyle.Bold);
            size = graphics.MeasureString(text, font, Properties.Settings.Default.BillSizeW);
            positionX = (Properties.Settings.Default.BillSizeW - (int)size.Width) - startX;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(Properties.Settings.Default.BillSizeW, size.Height)));
            return Offset + (int)size.Height;
        }
    }
}
