using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_App.Models
{
    public class contributor
    {
        public int? contributorId { get; set; }

        [Required]
        public string fullName { get; set; }

        [Required]
        public string address { get; set; }
        
        [Required]
        public string mobileNo { get; set; }

        [Required]
        public string emailId { get; set; }

        [Required]
        public string userName { get; set; }
        
        [Required]
        public string password { get; set; }

        [Required]
        public string contributor_createdBy { get; set; }

        [Required]
        public string adminLocation { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }

    }
}
