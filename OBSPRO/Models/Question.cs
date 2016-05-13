using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBSPRO.Models
{
    public class Question
    {
        public int uniqueQuestionId { set; get; }
        public int questionId { set; get; }
        public int cfiqid { set; get; }
        public int questionOrder { set; get; }
        public string sectionName { set; get; }       
        public string questionText { set; get; }
        public string answerType { set; get; }
        public string showsNA { set; get; }
        public string canAddComment { set; get; }
        public string mustAddComment { set; get; }
        public string answerChanged { set; get; }
        public int obscolformquestwgt { set; get; }
        public string comments { set; get; }
        public List<Answer> answers = new List<Answer>();
        public List<Answer> answerValues = new List<Answer>();


    }
}