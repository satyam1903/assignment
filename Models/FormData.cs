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
       public  string? DeveloperName { get;  set; }
       public  string? Filepath { get; set; }

    }
}
