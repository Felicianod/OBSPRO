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
        User usr = new User();
        APIDataParcer apiParcer = new APIDataParcer();
        public ActionResult Index()
        {
            usr.setUser();
            if (!usr.isDefined) { 
                //User is not defined so Session has expired. Kick user back to Login Page
                return RedirectToAction("Login", "Login", null);
            }
            try
            {
                if (User.IsInRole("Admin") || User.IsInRole("Super User") || User.IsInRole("Editor") || User.IsInRole("Viewer"))
                {
                    return View(apiParcer.getDashboard());
                }
                else
                {
                    return View(apiParcer.getDashboard());
                }
            }
            catch
            {
                return View(apiParcer.getDashboard(usr.emp_id));
            }
            
        }
    }

        
}