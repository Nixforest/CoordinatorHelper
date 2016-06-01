using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Response data from server.
    /// </summary>
    [DataContract]
    public class UserLoginResponseModel : BaseResponseModel
    {
        [DataMember(Name = "record", IsRequired = false)]
        protected UserLoginModel record;

        public UserLoginModel Record
        {
            get { return record; }
            set { record = value; }
        }
        [DataMember(Name = "role_id", IsRequired = false)]
        protected string role_id;
        [DataMember(Name = "role_name", IsRequired = false)]
        protected string role_name;

        public string Role_name
        {
            get { return role_name; }
            set { role_name = value; }
        }
        public string Role_id
        {
            get { return role_id; }
            set { role_id = value; }
        }
        public UserLoginResponseModel()
        {
            this.code = String.Empty;
            this.message = String.Empty;
            this.status = String.Empty;
            this.token = String.Empty;
        }
    }
}
