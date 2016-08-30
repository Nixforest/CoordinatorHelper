using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Order model.
    /// </summary>
    [DataContract]
    public class OrderModel : IComparable<OrderModel>
    {
        [DataMember(Name = "id", IsRequired = false)]
        private string id;
        [DataMember(Name = "creatorId", IsRequired = false)]
        private string creatorId;
        [DataMember(Name = "deliverId", IsRequired = false)]
        private string deliverId;
        [DataMember(Name = "ccsId", IsRequired = false)]
        private string ccsId;
        [DataMember(Name = "products", IsRequired = false)]
        private List<ProductModel> products;
        [DataMember(Name = "promotes", IsRequired = false)]
        private List<PromoteModel> promotes;
        [DataMember(Name = "totalMoney", IsRequired = false)]
        private double totalMoney;
        [DataMember(Name = "promoteMoney", IsRequired = false)]
        private double promoteMoney;
        [DataMember(Name = "totalPay", IsRequired = false)]
        private double totalPay;
        [DataMember(Name = "customer", IsRequired = false)]
        private CustomerModel customer;
        [DataMember(Name = "cylinder", IsRequired = false)]
        private List<CylinderModel> cylinders;
        [DataMember(Name = "note", IsRequired = false)]
        private string note;
        [DataMember(Name = "webId", IsRequired = false)]
        private string webId;
        [DataMember(Name = "isUpdateToServer", IsRequired = false)]
        private bool isUpdateToServer;
        [DataMember(Name = "status", IsRequired = false)]
        private OrderStatus status;
        //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        [DataMember(Name = "created_date", IsRequired = false)]
        private string created_date;
        //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        //++ BUG0056-SPJ (NguyenPT 20160828) Handle sell group of cylinders
        [DataMember(Name = "order_type", IsRequired = false)]
        protected int order_type;
        [DataMember(Name = "type_amount", IsRequired = false)]
        protected double type_amount;
        //-- BUG0056-SPJ (NguyenPT 20160828) Handle sell group of cylinders

        /// <summary>
        /// Constructor.
        /// </summary>
        public OrderModel()
        {
            id               = string.Empty;
            creatorId        = string.Empty;
            deliverId        = string.Empty;
            ccsId            = string.Empty;
            products         = new List<ProductModel>();
            promotes         = new List<PromoteModel>();
            totalMoney       = 0.0;
            promoteMoney     = 0.0;
            totalPay         = 0.0;
            customer         = new CustomerModel();
            cylinders        = new List<CylinderModel>();
            note             = string.Empty;
            webId            = string.Empty;
            isUpdateToServer = true;
            status           = OrderStatus.ORDERSTATUS_NEW;
            //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
            created_date = DateTime.Now.ToString(Properties.Resources.DefaultDateTimeFormat);
            //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
            //++ BUG0056-SPJ (NguyenPT 20160828) Handle sell group of cylinders
            order_type  = (int)OrderType.ORDERTYPE_NORMAL;
            type_amount = 0.0;
            //-- BUG0056-SPJ (NguyenPT 20160828) Handle sell group of cylinders
        }
        //public OrderModel(OrderModel copy)
        //{
        //    this.id = copy.id;
        //    this.creatorId = copy.creatorId;
        //    this.deliverId = copy.deliverId;
        //    this.ccsId = copy.ccsId;
        //    this.products = copy.products;
        //}
        //++ BUG0056-SPJ (NguyenPT 20160828) Handle sell group of cylinders
        /// <summary>
        /// Order type:
        /// 1. Normal
        /// 2. Sell_vo
        /// 3. The chan
        /// </summary>
        public int Order_type
        {
            get { return order_type; }
            set { order_type = value; }
        }
        /// <summary>
        /// Sell vo or The chan amount.
        /// </summary>
        public double Type_amount
        {
            get { return type_amount; }
            set { type_amount = value; }
        }
        //-- BUG0056-SPJ (NguyenPT 20160828) Handle sell group of cylinders
        //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        /// <summary>
        /// Created date.
        /// </summary>
        public string Created_date
        {
            get { return created_date; }
            set { created_date = value; }
        }
        //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        /// <summary>
        /// Flag check if this order is finished.
        /// </summary>
        public OrderStatus Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// Flag check if object is updated to server.
        /// </summary>
        public bool IsUpdateToServer
        {
            get { return isUpdateToServer; }
            set { isUpdateToServer = value; }
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
            get { return cylinders; }
            set { cylinders = value; }
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
            result |= CommonProcess.NormalizationString(this.Customer.ActivePhone).ToLower().Contains(keyword);
            result |= CommonProcess.NormalizationString(this.Customer.Name).ToLower().Contains(keyword);
            result |= CommonProcess.NormalizationString(this.Customer.Address).ToLower().Contains(keyword);
            return result;
        }
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns>String object</returns>
        public override string ToString()
        {
            string retVal = string.Empty;
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(OrderModel));
            try
            {
                js.WriteObject(ms, this);
                ms.Position = 0;
                var sr      = new StreamReader(ms);
                retVal      = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
            }
            return retVal;
        }
        /// <summary>
        /// Compare delegate
        /// </summary>
        /// <param name="other">Compared object</param>
        /// <returns>Id compare result</returns>
        public int CompareTo(OrderModel other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return other.Id.CompareTo(this.Id);
            }
        }
    }
}
