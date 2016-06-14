using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Product model.
    /// </summary>
    public class ProductModel
    {
        private string id;
        private string name;
        private int quantity;
        private double price;
        private double money;
        private string materials_no;
        private string typeId;
        /// <summary>
        /// Constructor.
        /// </summary>
        public ProductModel()
        {
            id           = string.Empty;
            name         = string.Empty;
            quantity     = 0;
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
        public int Quantity
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
            if (this.materials_no.Contains("GAS"))
            {
                return true;
            }
            return false;
        }
    }
}
