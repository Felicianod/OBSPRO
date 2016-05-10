using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OBSPRO.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult OBSLogin() { return View(); } 


        public ActionResult OBSLogout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}