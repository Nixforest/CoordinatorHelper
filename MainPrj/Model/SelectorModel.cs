using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model
{
    [DataContract]
    public class SelectorModel : BaseModel, IComparable<SelectorModel>, ICloneable
    {
        /// <summary>
        /// Compare method
        /// </summary>
        /// <param name="other">Compare object</param>
        /// <returns></returns>
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
        /// <summary>
        /// Clone method.
        /// </summary>
        /// <returns>Clone object</returns>
        public object Clone()
        {
            return new SelectorModel()
            {
                Id     = this.Id,
                Name   = this.Name,
                Detail = this.Detail
            };
        }
    }
}
