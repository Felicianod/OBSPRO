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
    
    public partial class OBS_COL_FORM_INST_ANS
    {
        public long obs_cfia_id { get; set; }
        public long obs_cfiq_id { get; set; }
        public string obs_cfia_ans_val { get; set; }
        public Nullable<short> obs_cfia_ans_wgt { get; set; }
        public Nullable<short> obs_cfia_ans_order { get; set; }
    
        public virtual OBS_COL_FORM_INST_QUEST OBS_COL_FORM_INST_QUEST { get; set; }
    }
}
