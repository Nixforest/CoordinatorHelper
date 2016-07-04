using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.Model
{
    public class BillPrintModel
    {
        private string brand;
        private string phone;
        private string customerName;
        private string customerAddress;
        private string agentAddress;
        private List<ProductModel> products;
        private List<PromoteModel> promotes;
        private double totalMoney;
        private double totalPromote;
        private double totalPay;
        public BillPrintModel()
        {
            brand           = string.Empty;
            phone           = string.Empty;
            customerName    = string.Empty;
            customerAddress = string.Empty;
            agentAddress    = string.Empty;
            products        = new List<ProductModel>();
            promotes        = new List<PromoteModel>();
            totalMoney      = 0.0;
            totalPromote    = 0.0;
            totalPay        = 0.0;
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
        /// Agent address.
        /// </summary>
        public string AgentAddress
        {
            get { return agentAddress; }
            set { agentAddress = value; }
        }

        /// <summary>
        /// Customer's address.
        /// </summary>
        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }

        /// <summary>
        /// Customer's name.
        /// </summary>
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        /// <summary>
        /// Phone.
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        /// <summary>
        /// Brand.
        /// </summary>
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        /// <summary>
        /// Print bill.
        /// </summary>
        public void Print()
        {
            PrintDialog pd     = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font          = new Font(Properties.Settings.Default.BilllFont, 15);
            PaperSize psize    = new PaperSize("Custom", 100, 200);
            pd.Document        = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = Properties.Settings.Default.BillSizeH;
            pdoc.DefaultPageSettings.PaperSize.Width  = Properties.Settings.Default.BillSizeW;
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            //DialogResult result = pd.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    PrintPreviewDialog pp = new PrintPreviewDialog();
            //    pp.Document = pdoc;
            //    result = pp.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        pdoc.Print();
            //    }
            //}
            pdoc.Print();
        }
        /// <summary>
        /// Handle print bill.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">PrintPageEventArgs</param>
        private void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font         = new Font(Properties.Settings.Default.BilllFont, 10);
            float fontHeight  = font.GetHeight();
            SolidBrush brush  = new SolidBrush(Color.Black);
            string text       = string.Empty;
            SizeF size        = new SizeF();
            int positionX = 0;
            int startX    = 5;
            int startY    = 5;
            int Offset    = 0;
            // Brand
            text      = this.Brand;
            font      = new Font(Properties.Settings.Default.BilllFont, 20, FontStyle.Bold);
            size      = graphics.MeasureString(text, font);
            positionX = startX + (Properties.Settings.Default.BillSizeW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, positionX, startY + Offset);

            // Phone
            Offset    = Offset + (int)size.Height;
            text      = String.Format("ĐT: {0}", this.Phone);
            font      = new Font(Properties.Settings.Default.BilllFont, 16);
            size      = graphics.MeasureString(text, font);
            positionX = startX + (Properties.Settings.Default.BillSizeW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, positionX, startY + Offset);

            // Title
            Offset = Offset + (int)size.Height;
            text = "PHIẾU GIAO GAS";
            font = new Font(Properties.Settings.Default.BilllFont, 16, FontStyle.Underline);
            size = graphics.MeasureString(text, font);
            positionX = startX + (Properties.Settings.Default.BillSizeW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, positionX, startY + Offset);

            // Date
            Offset = Offset + (int)size.Height;
            text = String.Format("Ngày: {0}", System.DateTime.Now.ToString("dd/MM/yy HH:mm:ss"));
            font = new Font(Properties.Settings.Default.BilllFont, 8, FontStyle.Italic);
            size = graphics.MeasureString(text, font);
            positionX = (Properties.Settings.Default.BillSizeW - (int)size.Width) - startX;
            graphics.DrawString(text, font, brush, positionX, startY + Offset);

            // Customer name
            Offset = Offset + (int)size.Height;
            text = String.Format("Khách hàng: {0}", this.CustomerName);
            font = new Font(Properties.Settings.Default.BilllFont, 12, FontStyle.Bold);
            size = graphics.MeasureString(text, font, Properties.Settings.Default.BillSizeW);
            positionX = startX;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(Properties.Settings.Default.BillSizeW, size.Height)));

            // Customer address
            Offset = Offset + (int)size.Height;
            text = String.Format("Địa chỉ: {0}\nVPGD: {1}", this.CustomerAddress, this.AgentAddress);
            font = new Font(Properties.Settings.Default.BilllFont, 10, FontStyle.Italic);
            size = graphics.MeasureString(text, font, Properties.Settings.Default.BillSizeW);
            positionX = startX;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(Properties.Settings.Default.BillSizeW, size.Height)));

            // Products label Name
            int nameW = 130;
            int qtyW = 20;
            int moneyW = 60;
            int totalW = 60;
            Offset = Offset + (int)size.Height;
            text = "Tên hàng";
            font = new Font(Properties.Settings.Default.BilllFont, 8, FontStyle.Bold | FontStyle.Underline);
            size = graphics.MeasureString(text, font, nameW);
            positionX = startX + (nameW - (int)size.Width) / 2;
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
            font = new Font(Properties.Settings.Default.BilllFont, 8);
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
            positionX = startX + (nameW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(nameW, size.Height)));

            text = "SL";
            size = graphics.MeasureString(text, font, qtyW);
            positionX = startX + nameW + (qtyW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(qtyW, size.Height)));
            font = new Font(Properties.Settings.Default.BilllFont, 8);
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

            // Total money
            Offset = Offset + (int)size.Height;
            text = "Tổng hóa đơn:";
            font = new Font(Properties.Settings.Default.BilllFont, 12, FontStyle.Bold);
            size = graphics.MeasureString(text, font, Properties.Settings.Default.BillSizeW);
            positionX = startX;
            graphics.DrawString(text, font, brush, new RectangleF(new PointF(positionX, startY + Offset),
                new SizeF(Properties.Settings.Default.BillSizeW, size.Height)));
            text = CommonProcess.FormatMoney(this.TotalMoney);
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
            // Underline
            Offset = Offset + (int)size.Height;
            text = "-----------------------------------------";
            font = new Font(Properties.Settings.Default.BilllFont, 10);
            size = graphics.MeasureString(text, font);
            positionX = startX + (Properties.Settings.Default.BillSizeW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, positionX, startY + Offset);
            // Glad
            Offset = Offset + (int)size.Height;
            text = "Bảo trì bếp & chăm sóc khách hàng";
            font = new Font(Properties.Settings.Default.BilllFont, 12);
            size = graphics.MeasureString(text, font);
            positionX = startX + (Properties.Settings.Default.BillSizeW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, positionX, startY + Offset);
            // Glad
            Offset = Offset + (int)size.Height;
            text = "ĐT: 0838 408 408";
            font = new Font(Properties.Settings.Default.BilllFont, 12);
            size = graphics.MeasureString(text, font);
            positionX = startX + (Properties.Settings.Default.BillSizeW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, positionX, startY + Offset);
            // Glad
            Offset = Offset + (int)size.Height;
            text = "Cảm ơn quý khách và hẹn gặp lại!";
            font = new Font(Properties.Settings.Default.BilllFont, 12);
            size = graphics.MeasureString(text, font);
            positionX = startX + (Properties.Settings.Default.BillSizeW - (int)size.Width) / 2;
            graphics.DrawString(text, font, brush, positionX, startY + Offset);
        }
    }
}
