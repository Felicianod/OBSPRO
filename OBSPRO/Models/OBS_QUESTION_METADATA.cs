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
    
    public partial class OBS_QUESTION_METADATA
    {
        public OBS_QUESTION_METADATA()
        {
            this.OBS_QUEST_ASSGND_MD = new HashSet<OBS_QUEST_ASSGND_MD>();
        }
    
        public int obs_quest_md_id { get; set; }
        public string obs_quest_md_value { get; set; }
        public string obs_quest_md_cat { get; set; }
    
        public virtual ICollection<OBS_QUEST_ASSGND_MD> OBS_QUEST_ASSGND_MD { get; set; }
    }
}
