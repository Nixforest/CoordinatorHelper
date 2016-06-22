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
    /// Cylinder model.
    /// </summary>
    [DataContract]
    public class CylinderModel
    {
        [DataMember(Name = "id", IsRequired = false)]
        private string id;
        [DataMember(Name = "typeId", IsRequired = false)]
        private string typeId;
        [DataMember(Name = "quantity", IsRequired = false)]
        private int quantity;
        [DataMember(Name = "serial", IsRequired = false)]
        private string serial;
        [DataMember(Name = "name", IsRequired = false)]
        private string name;
        [DataMember(Name = "materials_no", IsRequired = false)]
        private string materials_no;
        /// <summary>
        /// Materials no.
        /// </summary>
        public string Materials_no
        {
            get { return materials_no; }
            set { materials_no = value; }
        }
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
            this.id           = string.Empty;
            this.typeId       = string.Empty;
            this.quantity     = 0;
            this.serial       = string.Empty;
            this.name         = string.Empty;
            this.materials_no = string.Empty;
        }
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns>String object</returns>
        public override string ToString()
        {
            string retVal = String.Empty;
            MemoryStream msU = new MemoryStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CylinderModel));
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
