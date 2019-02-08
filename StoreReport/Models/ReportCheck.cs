using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReport.Models
{
    public class ReportCheck
    {
        public int ReportID
        { set; get; }
        public int StoreID
        { set; get; }
        public int RouteID
        { set; get; }
        public int ProductID
        { set; get; }
        public DateTime CreatedDate
        { set; get; }
        public string CreatedBy
        { set; get; }
        public String Photo
        { set; get; }
        public String Notes
        { set; get; }
       

    }
}
