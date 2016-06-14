using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Cylinder model.
    /// </summary>
    public class CylinderModel
    {
        private string id;
        private string typeId;
        private int quantity;
        private string serial;
        private string name;
        /// <summary>
        /// Name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Serial.
        /// </summary>
        public string Serial
        {
            get { return serial; }
            set { serial = value; }
        }
        /// <summary>
        /// Quantity.
        /// </summary>
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        /// <summary>
        /// Type id.
        /// </summary>
        public string TypeId
        {
            get { return typeId; }
            set { typeId = value; }
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
        ///  Constructor.
        /// </summary>
        public CylinderModel()
        {
            this.id       = string.Empty;
            this.typeId   = string.Empty;
            this.quantity = 0;
            this.serial   = string.Empty;
        }
    }
}
