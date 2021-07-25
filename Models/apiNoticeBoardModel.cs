using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_App.Models
{
    public class apiNoticeBoardModel
    {
        public String NoticeID { get; set; }
        [Required]
        public String NoticeTitle { get; set; }
        [Required]
        public String NoticeDescription { get; set; }
        [Required]
        public String NoticeCreatedBy { get; set; }
        public String NoticeDateCreated { get; set; }
        [Required]
        public String NoticeDateModified { get; set; }
        [Required]
        public String NoticeDateExpiry { get; set; }
    }
}
