using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MainPrj.Model.Update
{
    /// <summary>
    /// Order detail model.
    /// </summary>
    [DataContract]
    public class OrderDetailModel
    {
        [DataMember(Name = "materials_id", IsRequired = false)]
        protected string materials_id;
        [DataMember(Name = "materials_type_id", IsRequired = false)]
        protected string materials_type_id;
        [DataMember(Name = "qty", IsRequired = false)]
        protected string qty;
        [DataMember(Name = "price", IsRequired = false)]
        protected string price;
        [DataMember(Name = "amount", IsRequired = false)]
        protected string amount;
        [DataMember(Name = "seri", IsRequired = false)]
        protected string seri;

        /// <summary>
        /// Material seri.
        /// </summary>
        public string Seri
        {
            get { return seri; }
            set { seri = value; }
        }

        /// <summary>
        /// Total money must pay.
        /// </summary>
        public string TotalPay
        {
            get { return amount; }
            set { amount = value; }
        }

        /// <summary>
        /// Price.
        /// </summary>
        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// Quantity.
        /// </summary>
        public string Quantity
        {
            get { return qty; }
            set { qty = value; }
        }

        /// <summary>
        /// Type id.
        /// </summary>
        public string Materials_type_id
        {
            get { return materials_type_id; }
            set { materials_type_id = value; }
        }

        /// <summary>
        /// Id.
        /// </summary>
        public string Materials_id
        {
            get { return materials_id; }
            set { materials_id = value; }
        }
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns>String object</returns>
        public override string ToString()
        {
            string retVal = String.Empty;
            MemoryStream msU = new MemoryStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(OrderDetailModel));
            try
            {
                js.WriteObject(msU, this);
                msU.Position = 0;
                var sr = new StreamReader(msU);
                retVal = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
            }
            return retVal;
        }
    }
}
