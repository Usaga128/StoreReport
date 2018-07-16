using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StoreReport.Models
{
    public class Store
    {
        public int StoreID
        { set; get; }
        public string Name
        { set; get; }
        public string Phone
        { set; get; }
        public string ContactName
        { set; get; }
        public string Address
        { set; get; }
        public string GeoAddress
        { set; get; }
        public string CreatedBy
        { set; get; }
        public DateTime CreatedDate
        { set; get; }
        public int Status
        { set; get; }
        public int FranchiseID
        { set; get; }
    }
}
