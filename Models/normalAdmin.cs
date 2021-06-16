using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_App.Models
{
    public class normalAdmin
    {
        public int adminID { get; set; } = 0;
        public String adminName { get; set; }
        public String adminMobile { get; set; }
        public string adminUserName { get; set; } 
        public String adminUserPassword { get; set; }
        public DateTime adminDateCreate { get; set; }
        public DateTime adminDateModified { get; set; }
        public String flag { get; set; }

    }
}
