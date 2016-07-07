using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace OBSPRO.App_Code
{
    public class DataRetrieval
    {
        private string api_url = Common.ReadSetting("apiBaseURL");

        public  string getLCs()
        {
            string endPoint = "obs_getLC";
            WebRequest request = WebRequest.Create(api_url+endPoint);
            request.Method = "GET";
            request.ContentType = "application/json";      
            string JsonString = String.Empty;
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    JsonString = reader.ReadToEnd();
                }//end of using
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
           
            return JsonString;
        }

        public string getObserver(string first_name, string last_name, string email)
        {
            string endPoint = "obs_getObserver";
            WebRequest request = WebRequest.Create(api_url +endPoint);
            request.Method = "POST";
            request.ContentType = "application/json";
            ASCIIEncoding encoding = new ASCIIEncoding();
            string parsedContent = "{\"dsc_observer_emp_first_name\":\"" + first_name + "\",\"dsc_observer_emp_last_name\":\"" + last_name + "\",\"dsc_observer_emp_email_addr\":\"" + email + "\"}";
            Byte[] bytes = encoding.GetBytes(parsedContent);
            string JsonString = String.Empty;
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
                    return JsonString;
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }

        }
        public string getOpenReadyObservations(string emp_id)
        {
            string endPoint = "obs_getOpenReady";
            WebRequest request = WebRequest.Create(api_url + endPoint);
            request.Method = "POST";
            request.ContentType = "application/json";
            ASCIIEncoding encoding = new ASCIIEncoding();
            string parsedContent = "{\"dsc_observer_emp_id\":\""+emp_id+"\"}";
            Byte[] bytes = encoding.GetBytes(parsedContent);
            string JsonString = String.Empty;
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
                    return JsonString;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        //this method retrieves the saved obs form instances with submitted answers
        public string getObsCollForm(int form_inst_id)
        {
            string endPoint = "obs_getCollform";
            WebRequest request = WebRequest.Create(api_url + endPoint);
            request.Method = "POST";
            request.ContentType = "application/json";
            ASCIIEncoding encoding = new ASCIIEncoding();
            string parsedContent = "{\"ObsColFormInstID\":" + form_inst_id + "}";
            Byte[] bytes = encoding.GetBytes(parsedContent);
            string JsonString = String.Empty;
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
                    return JsonString;
                }
            }
            catch (Exception e)
            {
                return "ERROR: " + e.Message;
            }
        }

        public string getObserverRole(string userName)
        {
            string endPoint = "observerrole";
            WebRequest request = WebRequest.Create(api_url + endPoint);
            request.Method = "POST";
            request.ContentType = "application/json";
            ASCIIEncoding encoding = new ASCIIEncoding();
            string parsedContent = "{\"name\":\"" + userName + "\"}";
            Byte[] bytes = encoding.GetBytes(parsedContent);
            string JsonString = String.Empty;
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
                    return JsonString;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        } 
    }
}