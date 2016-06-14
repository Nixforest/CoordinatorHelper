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
    public class UserLoginModel
    {
        [DataMember(Name = "first_name", IsRequired = false)]
        protected string first_name;

        public string First_name
        {
            get { return first_name; }
            set { first_name = value; }
        }
        [DataMember(Name = "email", IsRequired = false)]
        protected string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        protected RoleType role;
        private string roleStr;
        private string user_id;

        public string User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public string RoleStr
        {
            get { return roleStr; }
            set { roleStr = value; }
        }

        public RoleType Role
        {
            get { return role; }
            set { role = value; }
        }

        public UserLoginModel()
        {
            this.first_name = String.Empty;
            this.email      = String.Empty;
            this.role       = RoleType.ROLE_ADMIN;
            this.roleStr    = String.Empty;
            this.user_id    = string.Empty;
        }
        public UserLoginModel(UserLoginModel copy)
        {
            this.first_name = copy.first_name;
            this.email      = copy.email;
            this.role       = copy.Role;
            this.roleStr    = copy.roleStr;
            this.roleStr    = copy.roleStr;
            this.user_id    = copy.user_id;
        }
    }
}
