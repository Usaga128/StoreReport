using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReport.Models
{
    public class UserByRoute
    {
        public int UserByRouteID { get; set; }

        public string UserName { get; set; }

        public string RouteId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
