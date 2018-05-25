using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class SubcategoryCategory
    {
        public int SubcategoryID { get; set; }
        public Subcategory Subcategory { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
