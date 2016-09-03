﻿using MainPrj.Util;
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
    /// Product model.
    /// </summary>
    [DataContract]
    public class ProductModel
    {
        [DataMember(Name = "id", IsRequired = false)]
        private string id;
        [DataMember(Name = "name", IsRequired = false)]
        private string name;
        [DataMember(Name = "quantity", IsRequired = false)]
        //++ BUG0044-SPJ (NguyenPT 20160822) Change quantity data type
        //private int quantity;
        private double quantity;
        //-- BUG0044-SPJ (NguyenPT 20160822) Change quantity data type
        [DataMember(Name = "price", IsRequired = false)]
        private double price;
        [DataMember(Name = "money", IsRequired = false)]
        private double money;
        [DataMember(Name = "materials_no", IsRequired = false)]
        private string materials_no;
        [DataMember(Name = "typeId", IsRequired = false)]
        private string typeId;
        /// <summary>
        /// Constructor.
        /// </summary>
        public ProductModel()
        {
            id           = string.Empty;
            name         = string.Empty;
            //++ BUG0044-SPJ (NguyenPT 20160822) Change quantity data type
            //quantity     = 0;
            quantity     = 0.0;
            //-- BUG0044-SPJ (NguyenPT 20160822) Change quantity data type
            price        = 0.0;
            money        = 0.0;
            materials_no = string.Empty;
            typeId       = string.Empty;
        }
        /// <summary>
        /// Material type id.
        /// </summary>
        public string TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }
        /// <summary>
        /// Material No.
        /// </summary>
        public string Materials_no
        {
            get { return materials_no; }
            set { materials_no = value; }
        }
        /// <summary>
        /// Total Money.
        /// </summary>
        public double Money
        {
            get { return money; }
            set { money = value; }
        }
        /// <summary>
        /// Price of product.
        /// </summary>
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// Quantity of product.
        /// </summary>
        //++ BUG0044-SPJ (NguyenPT 20160822) Change quantity data type
        //public int Quantity
        public double Quantity
        //-- BUG0044-SPJ (NguyenPT 20160822) Change quantity data type
        {
            get { return quantity; }
            set { quantity = value; }
        }
        /// <summary>
        /// Name of product.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Id of product.
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Check if this is GAS.
        /// </summary>
        /// <returns>TRUE if material no is contain "GAS"</returns>
        public bool IsGas()
        {
            if (TypeId.Equals("4")
                || TypeId.Equals("11")
                || TypeId.Equals("19")
                || TypeId.Equals("7"))
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
            if (TypeId.Equals("5"))
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
            if (TypeId.Equals("3"))
            {
                return true;
            }
            return false;
        }
        //++ BUG0059-SPJ (NguyenPT 20160831) Return cylinder
        /// <summary>
        /// Check if material is cylinder.
        /// </summary>
        /// <returns>True if material is cylinder, false otherwise</returns>
        public bool IsCylinder()
        {
            if (TypeId.Equals("1")
                || TypeId.Equals("12")
                || TypeId.Equals("10")
                || TypeId.Equals("14"))
            {
                return true;
            }
            return false;
        }
        //-- BUG0059-SPJ (NguyenPT 20160831) Return cylinder
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns>String object</returns>
        public override string ToString()
        {
            string retVal = string.Empty;
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(ProductModel));
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
    }
}
