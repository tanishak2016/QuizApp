using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_App.Models
{
    public class contributor
    {
        public int contributorId { get; set; }
        public string fullName { get; set; }
        public string address { get; set; }
        public string mobileNo { get; set; }
        public string emailId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string contributor_createdBy { get; set; }
        public string adminLocation { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModifiied { get; set; }

    }
}
