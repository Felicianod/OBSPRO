//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OBSPRO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DSC_LC
    {
        public DSC_LC()
        {
            this.DSC_EMPLOYEE = new HashSet<DSC_EMPLOYEE>();
            this.OBS_INST = new HashSet<OBS_INST>();
            this.OBS_COLLECT_FORM_TMPLT = new HashSet<OBS_COLLECT_FORM_TMPLT>();
        }
    
        public int dsc_lc_id { get; set; }
        public string dsc_lc_name { get; set; }
        public string dsc_lc_code { get; set; }
        public string dsc_lc_timezone { get; set; }
        public Nullable<System.DateTime> dsc_lc_eff_end_date { get; set; }
    
        public virtual ICollection<DSC_EMPLOYEE> DSC_EMPLOYEE { get; set; }
        public virtual ICollection<OBS_INST> OBS_INST { get; set; }
        public virtual ICollection<OBS_COLLECT_FORM_TMPLT> OBS_COLLECT_FORM_TMPLT { get; set; }
    }
}
