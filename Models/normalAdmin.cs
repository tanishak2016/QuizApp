using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_App.Models
{
    public class normalAdmin
    {
        public int adminID { get; set; } = 0;
        [Required]
        public String adminName { get; set; }
        [Required]
        public String adminMobile { get; set; }
        [Required]
        public string adminUserName { get; set; }
        [Required]
        public String adminUserPassword { get; set; }
        [Required]
        public DateTime adminDateCreate { get; set; }
        public DateTime adminDateModified { get; set; }
        public String flag { get; set; }

    }
}
