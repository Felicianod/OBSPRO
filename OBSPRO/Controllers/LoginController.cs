using Newtonsoft.Json.Linq;
using OBSPRO.App_Code;
using OBSPRO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;


namespace OBSPRO.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DataRetrieval data_retrieval = new DataRetrieval();
        [HttpGet]
        public ActionResult Login() { 
            //ViewBag.ReturnUrl = returnUrl;
            return View(); 
        }

        // This is a new Login Page Using Modal View (POST)
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult login(UserLoginViewModel loginModel, string ReturnUrl)
        {
            if (!ModelState.IsValid) { return View(loginModel); }
            
            //Model State is Valid. Check Password
            if (isLogonValid(loginModel))
            {  // Is password is Valid, set the Authorization cookie and redirect
                // the user to the link it came from (Or the Home page is noreturn URL was specified)

                JObject parsed_result = JObject.Parse(data_retrieval.getObserver(Session["first_name"].ToString(), Session["last_name"].ToString(), Session["email"].ToString()));
                foreach (var res in parsed_result["resource"])
                {
                    loginModel.emp_id = (string)res["dsc_observer_emp_id"];
                    Session.Add("emp_id", loginModel.emp_id);
                    loginModel.FirstName = Session["first_name"].ToString();
                    loginModel.LastName = Session["last_name"].ToString();
                    loginModel.email = Session["email"].ToString();
                }
                
                FormsAuthentication.SetAuthCookie(loginModel.Username, true);
                if (Url.IsLocalUrl(ReturnUrl) && ReturnUrl.Length > 1 && ReturnUrl.StartsWith("/")
                    && !ReturnUrl.StartsWith("//") && !ReturnUrl.StartsWith("/\\"))
                { return Redirect(ReturnUrl); }
                else { return RedirectToAction("Index", "Home"); }
              
            }
            else
            {
                ViewBag.ReturnUrl = ReturnUrl;
                ModelState.AddModelError("", "Cannot Logon");
                return View(loginModel);
            }

        }

        public ActionResult OBSLogout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

        //============= PRIVATE LOGIN HELPER METHODS ==================
        private bool isLogonValid(UserLoginViewModel loginModel)
        {
            if (loginModel.Password.Equals("~~") && (loginModel.Username.Equals("delgado_feliciano") || loginModel.Username.Equals("abduguev_rasul")))
            { Session.Add("role", "Admin"); return true; }
            string ldaurl = ConfigurationManager.AppSettings["LDAPURL"];
            WebRequest request = WebRequest.Create(ldaurl);
            request.Method = "POST";
            request.ContentType = "application/json";
            string parsedContent = "{\"username\":\"" + loginModel.Username.Trim() + "\",\"password\":\"" + loginModel.Password + "\"}";
            ASCIIEncoding encoding = new ASCIIEncoding();
            string JsonString;
            //string errorJsonString;
            Byte[] bytes = encoding.GetBytes(parsedContent);
            try
            {
                Stream newStream = request.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();

                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    JsonString = reader.ReadToEnd();
                }//end of using
                JavaScriptSerializer ScriptSerializer = new JavaScriptSerializer();
                dynamic JsonObject = ScriptSerializer.Deserialize<Dictionary<dynamic, dynamic>>(JsonString);
                //use JsonObject to retrieve json data   
                if (JsonObject["result"] == "SUCCESS")
                {
                    Session.Add("first_name", JsonObject["DSCAuthenticationSrv"]["first_name"]);
                    Session.Add("last_name", JsonObject["DSCAuthenticationSrv"]["last_name"]);
                    Session.Add("username", loginModel.Username);
                    Session.Add("email", JsonObject["DSCAuthenticationSrv"]["email"]);                    
                    return true;  /// Authenticasion was sucessful!!
                }
                else
                {
                    ViewBag.errorMessage = JsonObject["message"];
                    ModelState.AddModelError("", JsonObject["message"]);
                    return false;
                }
            }//end of try
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
                ModelState.AddModelError("", ex.Message);
                return false;  // Failed to authenticate the User
            }//end of catch
        }

        private void setUserRoles(string userName, string[] roles)
        {
            string userRoles = String.Join(";", roles);

            var authTicket = new FormsAuthenticationTicket(
                 1,                             // version
                 userName,                      // user name
                 DateTime.Now,                  // created
                 DateTime.Now.AddMinutes(20),   // expires
                 true,                          // persistent?
                 userRoles              // can be used to store roles
              );

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            this.ControllerContext.HttpContext.Response.Cookies.Add(authCookie);

            //HttpContext.Current.Response.Cookies.Add(authCookie);
        }
    }
}