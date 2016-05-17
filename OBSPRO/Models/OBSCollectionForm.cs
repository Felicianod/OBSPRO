using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBSPRO.Models
{
    public class OBSCollectionForm
    {
        public string ErrorMessage = String.Empty;
        public string observedEmployeeId { set; get; }
        public string observedEmployeeFullName { set; get; }
        public string observerEmployeeId { set; get; }
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
        public string obsColFormInstId { set; get; }
        public DateTime colFormStartDateTime { set; get; }
        public string dBColFormStatus { set; get; }
        public string colFormStatus { set; get; }

        public List<Section> sections = new List<Section>();

    }
}