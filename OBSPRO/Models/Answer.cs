using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBSPRO.Models
{
    public class Answer
    {
        public int answerId { set; get; }
        public int cfiqid { set; get; }
        public int obscolanswgt { set; get; }
        public int answerOrder { set; get; }
        public string answerText { set; get; }
    }
}