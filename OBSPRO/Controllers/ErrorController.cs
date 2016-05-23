using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBSPRO.Controllers
{
    
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        public ActionResult displayError(string errorMsg)
        {
            ViewData["errorMessage"] = errorMsg;
            return View();
        }
    }
}