using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OBSPRO.App_Code;
using OBSPRO.Models;
using Newtonsoft.Json.Linq;

namespace OBSPRO.Controllers
{
    public class HomeController : Controller
    {
        Dashboard dashboard = new Dashboard();
        DataRetrieval data_retrieval = new DataRetrieval();
        public ActionResult Index()
        {

            //obs.LC = "Corporate";
            //obs.user_name = User.Identity.Name;
            // obs.LC = api.getObserver("Rasul", "Abduguev", "rasul.abduguev@dsc-logistics.com");
            string raw_data = data_retrieval.getOpenReadyObservations("468");
            JObject parsed_result = JObject.Parse(raw_data);
            foreach (var res in parsed_result["resource"])
            {
                Observation obs = new Observation();
                obs.form_inst_id = (string)res["ObsColFormInstID"];
                obs.observed_id = (string)res["dsc_observed_emp_id"];
                obs.observer_id = (string)res["dsc_observer_emp_id"];
                obs.status = (string)res["obs_inst_status"];
                obs.observed_first_name = (string)res["dsc_observed_first_name"];
                obs.observed_last_name = (string)res["dsc_observed_last_name"];
                obs.observed_adp_id = (string)res["ObservedADPID"];
                obs.form_title = (string)res["ColFormTitle"];
                obs.obs_start_time = (string)res["ColFormStartDateTime"];
                switch (obs.status)
                {
                    case "OPEN":
                        dashboard.user_open_obs.Add(obs);
                        break;
                    case "READY TO VERIFY":
                        dashboard.user_ready_obs.Add(obs);
                        break;
                    case "COMPLETE":
                        dashboard.user_complete_obs.Add(obs);
                        break;
                }
            }
            return View(dashboard);
        }
    }

        
}