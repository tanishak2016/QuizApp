using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_App.Areas.Main.Models
{
    public class contributor
    {
        public int? contributorId { get; set; }

      
        public string fullName { get; set; }

        public string address { get; set; }

        public string mobileNo { get; set; }
        //[Required]
        //[Display(Name = "Email")]
        //[EmailAddress]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        //ErrorMessage = "Invalid email format")]
        
        public string emailId { get; set; }

        [Required]
        public string userName { get; set; }

        public string password { get; set; }

        public string contributor_createdBy { get; set; }

        public string adminLocation { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }

    }
}
