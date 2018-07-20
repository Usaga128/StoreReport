using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReport.Models
{
    public class Checks
    {
        public int ChecksID
        { set; get; }
        [Required]
        public string Question
        { set; get; }
        //SI/NO Boolean
        public string QuestionType
        { set; get; }
    }
}
