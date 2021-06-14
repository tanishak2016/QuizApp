using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_App.Models
{
    public class SuperAdmin_Login
    {

        [Required(ErrorMessage = "Please enter Password")]
        [Display(Name = "Password")]
        
        public string supAdminPassword { get; set; }
    }
}
