using System;
using System.Collections.Generic;
using System.Linq;

namespace Product.Models
{
    public class Attribute
    {
        public Attribute()
        {
            fantastic = new Fantastic();
            rating = new Rating();
        }
        
        public Fantastic fantastic { get; set; }
        public Rating rating { get; set; }
    }
}