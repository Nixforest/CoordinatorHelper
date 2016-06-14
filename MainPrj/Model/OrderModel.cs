using MainPrj.Util;
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
        private string id;
        private string creatorId;
        private string deliverId;
        private string ccsId;
        private List<ProductModel> products;
        private List<PromoteModel> promotes;
        private double totalMoney;
        private double promoteMoney;
        private double totalPay;
        private CustomerModel customer;
        private List<CylinderModel> cylinder;
        private string note;
        private string webId;
        /// <summary>
        /// Constructor.
        /// </summary>
        public OrderModel()
        {
            id           = string.Empty;
            creatorId    = string.Empty;
            deliverId    = string.Empty;
            ccsId        = string.Empty;
            products     = new List<ProductModel>();
            promotes     = new List<PromoteModel>();
            totalMoney   = 0.0;
            promoteMoney = 0.0;
            totalPay     = 0.0;
            customer     = new CustomerModel();
            cylinder     = new List<CylinderModel>();
            note         = string.Empty;
            webId        = string.Empty;
        }
        /// <summary>
        /// Id get from server when create order.
        /// </summary>
        public string WebId
        {
            get { return webId; }
            set { webId = value; }
        }
        /// <summary>
        /// Note.
        /// </summary>
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        /// <summary>
        /// Cylinder.
        /// </summary>
        public List<CylinderModel> Cylinders
        {
            get { return cylinder; }
            set { cylinder = value; }
        }
        /// <summary>
        /// Customer.
        /// </summary>
        public CustomerModel Customer
        {
            get { return customer; }
            set { customer = value; }
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
        /// <summary>
        /// Id.
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Check if keyword is contained inside object.
        /// </summary>
        /// <param name="keyword">Keyword</param>
        /// <returns>True if contained, False otherwise</returns>
        public bool IsContainString(string keyword)
        {
            bool result = false;
            if (String.IsNullOrEmpty(keyword))
            {
                return true;
            }
            result |= CommonProcess.NormalizationString(this.Customer.ActivePhone).Contains(keyword.ToLower());
            result |= CommonProcess.NormalizationString(this.Customer.Name).Contains(keyword.ToLower());
            result |= CommonProcess.NormalizationString(this.Customer.Address).Contains(keyword.ToLower());
            return result;
        }
    }
}
