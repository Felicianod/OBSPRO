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
    
    public partial class OBS_RVW_FORM_INST
    {
        public long obs_cfi_id { get; set; }
        public long obs_inst_id { get; set; }
        public int dsc_reviewer_emp_id { get; set; }
    
        public virtual DSC_EMPLOYEE DSC_EMPLOYEE { get; set; }
        public virtual OBS_INST OBS_INST { get; set; }
    }
}