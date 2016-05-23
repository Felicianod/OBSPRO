using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBSPRO.Models
{
    public class Section
    {
       public string sectionName { set; get; }
       public List<Question> questions = new List<Question>();
    }
}