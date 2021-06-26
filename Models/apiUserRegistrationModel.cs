using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_App.Models
{
    public class apiUserRegistrationModel
    {
        public Int32 id { get; set; }
        public string userFullName { get; set; }
        public String userMobile { get; set; }
        public String userEmailID { get; set; }
        public String userUserName { get; set; }
        public String userPassword { get; set; }
        public String userDateCreated { get; set; }
        public String userDateModified { get; set; }
    }
}
