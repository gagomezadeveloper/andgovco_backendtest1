using System;
using System.Collections.Generic;

namespace AndGovCo_backendTest_1.Models
{
    public class ProductState
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}