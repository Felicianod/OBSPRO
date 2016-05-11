using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OBSPRO.App_Code;
namespace OBSPRO.Models
{
    public class Dashboard
    {
        public string user_name;
        public List<Observation> user_open_obs = new List<Observation>();
        public List<Observation> user_ready_obs = new List<Observation>();
        public List<Observation> user_complete_obs = new List<Observation>();
    }
}