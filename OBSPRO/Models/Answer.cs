using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBSPRO.Models
{
    public class Answer
    {
        public string answerId { set; get; }
        public string cfiqid { set; get; }
        public string obscolanswgt { set; get; }
        public string answerOrder { set; get; }
        public string answerText { set; get; }
    }
}