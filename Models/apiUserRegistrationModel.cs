using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_App.Models
{
    public class apiUserRegistrationModel
    {
        public String id { get; set; }
        [Required]
        public string userFullName { get; set; }
        [Required]
        public String userMobile { get; set; }
        [Required]
        public String userEmailID { get; set; }
        [Required]
        public String userUserName { get; set; }
        [Required]
        public String userPassword { get; set; }

        public String userDateCreated { get; set; }

        public String userDateModified { get; set; }
    }
}
