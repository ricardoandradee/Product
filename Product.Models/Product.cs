using System;
using System.Collections.Generic;
using System.Linq;

namespace Product.Models
{
    public class Product
    {
        public Product()
        {
            attribute = new Attribute();
        }
        
        public int id { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public Attribute attribute { get; set; }
    }
}