using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OBSPRO.Models;
using OBSPRO.App_Code;
using Newtonsoft.Json.Linq;

namespace OBSPRO.Controllers

{
    public class ObservationController : Controller
    {
        DataRetrieval api = new DataRetrieval();
        [HttpGet]
        public ActionResult Index()
        {
            
            List<Observation> all_obs = new List<Observation>();
            //obs.LC = "Corporate";
            //obs.user_name = User.Identity.Name;
            // obs.LC = api.getObserver("Rasul", "Abduguev", "rasul.abduguev@dsc-logistics.com");
            string raw_data = api.getOpenReadyObservations("468");
            JObject parsed_result = JObject.Parse(raw_data);
            foreach(var res in parsed_result["resource"])
            {
                Observation obs = new Observation();
                obs.form_inst_id = (string)res["ObsColFormInstID"];
                obs.observed_id = (string)res["dsc_observed_emp_id"];
                obs.observer_id = (string)res["dsc_observer_emp_id"];
                obs.status = (string)res["obs_inst_status"];
                obs.observed_first_name = (string)res["dsc_observed_first_name"];
                obs.observed_last_name = (string)res["dsc_observed_last_name"];
                obs.observed_adp_id = (string)res["ObservedADPID"];
                obs.form_title= (string)res["ColFormTitle"];               
                obs.obs_start_time = (string)res["ColFormStartDateTime"];
                all_obs.Add(obs);

            }
            return View(all_obs);
        }

        // GET: Observation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Observation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Observation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Observation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Observation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Observation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Observation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
