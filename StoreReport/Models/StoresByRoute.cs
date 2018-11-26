using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReport.Models
{
    public class StoresByRoute
    {
        public int StoresByRouteID
        { set; get; } 
        public int StoreID
        { set; get; }
        public int RouteID
        { set; get; }
        public int RouteName
        { set; get; }
        public int UserName
        { set; get; }
        public DateTime CreatedDate
        { set; get; }
        public int Order
        { set; get; }
    }
}
