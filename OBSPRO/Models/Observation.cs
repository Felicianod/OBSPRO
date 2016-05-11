using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OBSPRO.Models
{
    public class Observation
    {
      
        [Display(Name = "Location")]
        public string LC { get; set; }

   
        [Display(Name = "User Name")]
        public string user_name { get; set; }
    }
}