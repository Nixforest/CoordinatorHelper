using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Order model.
    /// </summary>
    public class OrderModel
    {
        private string creatorId;
        private string deliverId;
        private string ccsId;
        private List<ProductModel> products;
        private List<PromoteModel> promotes;
        private double totalMoney;
        private double promoteMoney;
        private double totalPay;
        public OrderModel()
        {
            creatorId = string.Empty;
            deliverId = string.Empty;
            ccsId = string.Empty;
            products = new List<ProductModel>();
            promotes = new List<PromoteModel>();
            totalMoney = 0.0;
            promoteMoney = 0.0;
            totalPay = 0.0;
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
        /// Promote money.
        /// </summary>
        public double PromoteMoney
        {
            get { return promoteMoney; }
            set { promoteMoney = value; }
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
        /// CCS id.
        /// </summary>
        public string CCSId
        {
            get { return ccsId; }
            set { ccsId = value; }
        }
        /// <summary>
        /// Deliver id.
        /// </summary>
        public string DeliverId
        {
            get { return deliverId; }
            set { deliverId = value; }
        }
        /// <summary>
        /// Creator id.
        /// </summary>
        public string CreatorId
        {
            get { return creatorId; }
            set { creatorId = value; }
        }
    }
}
