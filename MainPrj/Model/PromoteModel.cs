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
    /// Promote model.
    /// </summary>
    [DataContract]
    public class PromoteModel
    {
        [DataMember(Name = "id", IsRequired = false)]
        private string id;
        [DataMember(Name = "name", IsRequired = false)]
        private string name;
        [DataMember(Name = "quantity", IsRequired = false)]
        private int quantity;
        [DataMember(Name = "materials_no", IsRequired = false)]
        private string materials_no;
        [DataMember(Name = "typeId", IsRequired = false)]
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
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns>String object</returns>
        public override string ToString()
        {
            string retVal = string.Empty;
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(PromoteModel));
            try
            {
                js.WriteObject(ms, this);
                ms.Position = 0;
                var sr = new StreamReader(ms);
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
