
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Models
{
    public class JobDetail
    {
        [Key]
        public string? Machine {get; set; }

        public string? JobName { get; set; }
        public string? JobID { get; set; }

    }
}
