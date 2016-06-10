using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Promote model.
    /// </summary>
    public class PromoteModel
    {
        private string id;
        private string name;
        private int quantity;
        /// <summary>
        /// Constructor.
        /// </summary>
        public PromoteModel()
        {
            id = string.Empty;
            name = string.Empty;
            quantity = 0;
        }
        /// <summary>
        /// Quantity of promote.
        /// </summary>
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        /// <summary>
        /// Name of promote.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Id of promote.
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
