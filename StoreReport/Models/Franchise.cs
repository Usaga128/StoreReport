using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreReport.Models
{
    public class Franchise
    {
        public int FranchiseID
        { set; get; }
        public string Name
        { set; get; }
        public DateTime CreatedDate
        { set; get; }
        public int Status
        { set; get; }
    }
}
