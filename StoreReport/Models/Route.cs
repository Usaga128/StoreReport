using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReport.Models
{
    public class Route
    {
        public int RouteID
        { set; get; }
        [Required]
        public string Name
        { set; get; }
        public DateTime CreatedDate
        { set; get; }
    }
}
