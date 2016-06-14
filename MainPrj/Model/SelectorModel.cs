using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model
{
    [DataContract]
    public class SelectorModel : IComparable<SelectorModel>
    {
        /// <summary>
        /// Id.
        /// </summary>
        [DataMember(Name = "id", IsRequired = false)]
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Name.
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Address
        /// </summary>
        private string address = string.Empty;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public int CompareTo(SelectorModel other)
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
    }
}
