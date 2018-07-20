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
        [Required]
        public int Order
        { set; get; }
        public DateTime CreatedDate
        { set; get; }
        public int StoreID
        { set; get; }
    }
}
