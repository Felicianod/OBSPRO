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
    
    public partial class OBS_COL_FORM_INST_SIGS
    {
        public long obs_cfis_id { get; set; }
        public int dsc_emp_id { get; set; }
        public long obs_cfi_id { get; set; }
        public string obs_cfis_ntwk_path { get; set; }
        public string obs_cfis_filename { get; set; }
        public string obs_cfis_elec_ack_yn { get; set; }
        public System.DateTime obs_cfis_add_dt { get; set; }
        public string obs_cfis_observer_emp_yn { get; set; }
        public string obs_cfis_observed_emp_yn { get; set; }
        public string obs_cfis_reviewer_emp_yn { get; set; }
    
        public virtual DSC_EMPLOYEE DSC_EMPLOYEE { get; set; }
        public virtual OBS_COLLECT_FORM_INST OBS_COLLECT_FORM_INST { get; set; }
    }
}
