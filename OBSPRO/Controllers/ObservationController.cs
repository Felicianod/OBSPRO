using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OBSPRO.Models;
using OBSPRO.App_Code;
using Newtonsoft.Json.Linq;
using PagedList;
using PagedList.Mvc;

namespace OBSPRO.Controllers

{
    public class ObservationController : Controller
    {
        APIDataParcer apiParcer = new APIDataParcer();
        User usr = new User();

        [HttpGet]
        public ActionResult Index( string searchString, string sortBy, FormCollection form_data, int? page, int? PageSize)
        {            
            usr.setUser();
            ViewBag.CurrentItemsPerPage = PageSize ?? 15;
            string frmStatus = null;
            try
            {
                frmStatus = Request.QueryString["frmStatus"];
            }
            catch { }
            bool searchAll = (searchString == null && sortBy == null && frmStatus ==null) ? true : false;
            frmStatus = searchAll ? "Started,Ready for Review,REVIEWED" : frmStatus;
            frmStatus = frmStatus == null ? "" : frmStatus;
            ViewBag.searchText = searchString;
            ViewBag.sortStartDateParameter = String.IsNullOrEmpty(sortBy) ? "StartDate" : "";
            ViewBag.sortTitleParameter = sortBy == "Title" ? "Title desc" : "Title";
            ViewBag.sortEmpObservedParameter = sortBy == "Observed Emplpoyee" ? "Observed Emplpoyee desc" : "Observed Emplpoyee";
            ViewBag.sortObserverParameter = sortBy == "Observer" ? "Observer desc" : "Observer";
            ViewBag.sortADPParameter = sortBy == "ADP ID" ? "ADP ID desc" : "ADP ID";
            ViewBag.sortStatusParameter = sortBy == "Status" ? "Status desc" : "Status";
            ViewBag.sortComplDateParameter = sortBy == "Complete Date" ? "Complete Date desc" : "Complete Date";
            ViewBag.sortLocationParameter = sortBy == "Location" ? "Location desc" : "Location";
            ViewBag.Open = (searchAll ? "Started,Ready for Review,REVIEWED" : frmStatus).Contains("Started")?"checked":"";
            ViewBag.Ready = (searchAll ? "Started,Ready for Review,REVIEWED" : frmStatus).Contains("Ready for Review") ? "checked" : "";
            ViewBag.Completed = (searchAll ? "Started,Ready for Review,REVIEWED" : frmStatus).Contains("REVIEWED") ? "checked" : "";
            ViewBag.FullfrmStatus = frmStatus;
            if (usr.role == "Not Authorized" || usr.role == "")
            {

                return View(apiParcer.getAllObservations(usr.emp_id, frmStatus, searchString, sortBy).ToPagedList(page ?? 1, PageSize ?? 15));
            }
            else
            {          
                return View(apiParcer.getAllObservations(null,frmStatus, searchString, sortBy).ToPagedList(page ?? 1, PageSize ?? 15));
            }
                
        }

        [HttpGet]
        public ActionResult viewForm(int? id)
        {
            int formId = id ?? 0;
            if (formId < 1) return RedirectToAction("Message", "Error", new { ErrorMsg = "Invalid or Missing Form Id. Please Select a Valid Form Id and Try Again." });

            OBSCollectionForm formRetrieved;
            try { 
                formRetrieved = apiParcer.getFormInstance(formId); 
            }
            catch(Exception ex) {
                return RedirectToAction("Message", "Error", new { ErrorMsg = ex.Message });
            }            
            return View(formRetrieved);
        }


        //this method is to call api to mark observation as reviewed
        [HttpPost]
        public string completeObsReview(int? id)
        {
            int obsInstID = id ?? 0;
            if (obsInstID == 0) { return "Failed"; }
            return apiParcer.completeObs(obsInstID);
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
