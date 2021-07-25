using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_App.Areas.Main.Models
{
    public class NoticeBoardProperties
    {
        public Int32 NoticeID { get; set; }
        
        public String NoticeTitle { get; set; }
       
        public String NoticeDescription { get; set; }
        
        public String NoticeCreatedBy { get; set; }
        public String NoticeDateCreated { get; set; }
       
        public String NoticeDateModified { get; set; }
       
        public String NoticeDateExpiry { get; set; }
    }
}
