using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace OBSPRO.Models
{
    public class user
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string emp_id { get; set; }
        public string role { get; set; }
        public bool isDefined { get; set; }

        public user() {
            try {
                Username = HttpContext.Current.Session["first_name"].ToString();
                LastName = HttpContext.Current.Session["last_name"].ToString();
                email = HttpContext.Current.Session["email"].ToString();
                emp_id = HttpContext.Current.Session["emp_id"].ToString();
                isDefined = true;
            }
            catch {
                Username = "";
                FirstName = "";
                LastName = "";
                email = "";
                emp_id = "";
                role = "";
                isDefined = false;
            }
        }

        public void setUser(){
            try
            {
                Username = HttpContext.Current.Session["first_name"].ToString();
                LastName = HttpContext.Current.Session["last_name"].ToString();
                email = HttpContext.Current.Session["email"].ToString();
                emp_id = HttpContext.Current.Session["emp_id"].ToString();
                isDefined = true;
            }
            catch
            {
                Username = "";
                FirstName = "";
                LastName = "";
                email = "";
                emp_id = "";
                role = "";
                isDefined = false;
            }
        }


    }
}