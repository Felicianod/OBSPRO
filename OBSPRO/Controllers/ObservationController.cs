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
        User usr = new User();
        [HttpGet]
        public ActionResult Index()
        {
            
            List<Observation> all_obs = new List<Observation>();
            usr.setUser();
           // string raw_data = api.getOpenReadyObservations("468");
            JObject parsed_result = JObject.Parse(api.getOpenReadyObservations(usr.emp_id));
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
                obs.obs_start_time = Convert.ToDateTime((string)res["ColFormStartDateTime"]);
                all_obs.Add(obs);

            }
            return View(all_obs);
        }

        [HttpGet]
        public ActionResult viewForm(int id = 0)
        {
            ViewData["formInsId"] = id.ToString();
            ViewBag.Title = "Form Instance Details";
            //if (id == null) { return HttpNotFound(); }

            //oInstanceForm selectedColForm = new oInstanceForm(id);
            //if (selectedColForm == null) { return HttpNotFound(); }

            //return View(selectedColForm);
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
