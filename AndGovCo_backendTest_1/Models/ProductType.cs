using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndGovCo_backendTest_1.Models
{
    public class ProductType
    {
        public int ProductTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool State { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}