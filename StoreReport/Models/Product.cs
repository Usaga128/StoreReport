using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReport.Models
{
    public class Product
    {
        public int ProductID
        { set; get; }
        [Required]
        public string ProductCode
        { set; get; }
        [Required]
        public string Name
        { set; get; }
        public string Description
        { set; get; }
        public int ProductTypeID
        { set; get; }
    }
}
