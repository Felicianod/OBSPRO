using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace OBSPRO.App_Code
{
    public class DataRetrieval
    {
        private string api_url = "http://dscapidev.dsccorp.net/dscrest/api/v1/getobsemp/";

        public  string getLCs()
        {
            string endPoint = "obs_getLC";
            WebRequest request = WebRequest.Create(api_url+ ""+endPoint);
            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();
            string JsonString = String.Empty;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                JsonString = reader.ReadToEnd();
            }//end of using
            return JsonString;
        }


    }
}