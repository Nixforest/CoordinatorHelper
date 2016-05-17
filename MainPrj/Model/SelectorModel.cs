using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainPrj.Model
{
    public class SelectorModel
    {
        /// <summary>
        /// Id.
        /// </summary>
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Name.
        /// </summary>
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Address
        /// </summary>
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}
