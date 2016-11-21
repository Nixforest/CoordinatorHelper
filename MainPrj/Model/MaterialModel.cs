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
    /// Material model.
    /// </summary>
    [DataContract]
    public class MaterialModel : IComparable<MaterialModel>
    {
        [DataMember(Name = "label", IsRequired = false)]
        protected string label;
        [DataMember(Name = "value", IsRequired = false)]
        protected string value;
        [DataMember(Name = "id", IsRequired = false)]
        protected string id;
        [DataMember(Name = "materials_no", IsRequired = false)]
        protected string materials_no;
        [DataMember(Name = "name", IsRequired = false)]
        protected string name;
        [DataMember(Name = "unit", IsRequired = false)]
        protected string unit;
        [DataMember(Name = "materials_type_id", IsRequired = false)]
        protected string materials_type_id;
        [DataMember(Name = "name_vi", IsRequired = false)]
        protected string name_vi;
        [DataMember(Name = "unit_use", IsRequired = false)]
        protected string unit_use;
        [DataMember(Name = "price", IsRequired = false)]
        protected string price;
        //++ BUG0061-SPJ (NguyenPT 20161121) Sell vo different
        [DataMember(Name = "parent_id", IsRequired = false)]
        protected string parent_id;

        /// <summary>
        /// Id of group material.
        /// </summary>
        public string Parent_id
        {
            get { return parent_id; }
            set { parent_id = value; }
        }
        //-- BUG0061-SPJ (NguyenPT 20161121) Sell vo different

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Unit_use
        {
            get { return unit_use; }
            set { unit_use = value; }
        }

        public string Name_vi
        {
            get { return name_vi; }
            set { name_vi = value; }
        }

        public string Materials_type_id
        {
            get { return materials_type_id; }
            set { materials_type_id = value; }
        }

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Materials_no
        {
            get { return materials_no; }
            set { materials_no = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        public bool IsContainString(string keyword)
        {
            if (String.IsNullOrEmpty(keyword))
            {
                return true;
            }
            return this.label.ToLower().Contains(keyword.ToLower());
        }

        public int CompareTo(MaterialModel other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return this.Name.CompareTo(other.Name);
            }
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
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns>String object</returns>
        public override string ToString()
        {
            string retVal = string.Empty;
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(MaterialModel));
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
