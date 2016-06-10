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
        /// <summary>
        /// Constructor.
        /// </summary>
        public ProductModel()
        {
            id = string.Empty;
            name = string.Empty;
            quantity = 0;
            price = 0.0;
            money = 0.0;
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
    }
}
