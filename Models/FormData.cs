using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class FormData
    {
        [Key]
        public string? DeveloperName { get; set; }
        public JobDetail[] FileData { get; set; }
        public string timeStamp { get; set; }
        public int timeZone { get; set; }
        public string userInfo {get; set;}

    }
}
