using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReport.Models
{
    public class ReportAnswer
    {
        public int ReportAnswerID
        { set; get; }
        public int ReportCheckID
        { set; get; }
        [Required]
        public int CheckID
        { set; get; }
        public string Answer
        { set; get; }
        public DateTime CreatedDate
        { set; get; }
    }

}
