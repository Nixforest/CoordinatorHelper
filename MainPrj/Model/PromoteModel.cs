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
        private string materials_no;
        private string typeId;
        /// <summary>
        /// Constructor.
        /// </summary>
        public PromoteModel()
        {
            id           = string.Empty;
            name         = string.Empty;
            quantity     = 0;
            materials_no = string.Empty;
            typeId = string.Empty;
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
        /// Material no.
        /// </summary>
        public string Materials_no
        {
            get { return materials_no; }
            set { materials_no = value; }
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
