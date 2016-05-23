using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBSPRO.Models
{
    public class OBSCollectionForm
    {
        public string ErrorMessage = String.Empty;
        public int observedEmployeeId { set; get; }
        public string observedEmployeeFullName { set; get; }
        public int observerEmployeeId { set; get; }
        public string observerEmployeeFullName { set; get; }
        public DateTime hiredDate { set; get; }
        public string lc_id { set; get; }
        public string lc_Name { set; get; }
        public string customer_id { set; get; }
        public  int obsColFormId { set; get; }
        public string colFormTitle { set; get; }
        public string colFormSubtitle { set; get; }
        public string colFormVersion { set; get; }
        public string obsInstId { set; get; }
        public long obsColFormInstId { set; get; }
        public DateTime colFormStartDateTime { set; get; }
        public string strColFormStartDateTime { set; get; }
        public DateTime colFormSubmittedDateTime { set; get; }
        public string strColFormSubmittedDateTime { set; get; }
        public string dBColFormStatus { set; get; }
        public string colFormStatus { set; get; }
        
        public List<Section> sections = new List<Section>();

    }
}