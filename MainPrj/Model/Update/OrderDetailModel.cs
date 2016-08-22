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
        //++ BUG0044-SPJ (NguyenPT 20160822) Change quantity data type
        //protected int qty;
        protected double qty;
        //-- BUG0044-SPJ (NguyenPT 20160822) Change quantity data type
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
        //++ BUG0044-SPJ (NguyenPT 20160822) Change quantity data type
        //public int Quantity
        public double Quantity
        //-- BUG0044-SPJ (NguyenPT 20160822) Change quantity data type
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
        /// <summary>
        /// Check if material is Gas.
        /// </summary>
        /// <returns>True if material is Gas, false otherwise</returns>
        public bool IsGas()
        {
            if (materials_type_id.Equals("4")
                || materials_type_id.Equals("11")
                || materials_type_id.Equals("19")
                || materials_type_id.Equals("7"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if material is Gas stove.
        /// </summary>
        /// <returns>True if material is Gas stove, false otherwise</returns>
        public bool IsGasStove()
        {
            if (materials_type_id.Equals("5"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if material is Van.
        /// </summary>
        /// <returns>True if material is Van, false otherwise</returns>
        public bool IsVan()
        {
            if (materials_type_id.Equals("3"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if material is promote.
        /// </summary>
        /// <returns>True if material is promote, false otherwise</returns>
        public bool IsPromote()
        {
            if (materials_type_id.Equals("6"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if material is cylinder.
        /// </summary>
        /// <returns>True if material is cylinder, false otherwise</returns>
        public bool IsCylinder()
        {
            if (materials_type_id.Equals("1")
                || materials_type_id.Equals("12")
                || materials_type_id.Equals("10")
                || materials_type_id.Equals("14"))
            {
                return true;
            }
            return false;
        }
    }
}
