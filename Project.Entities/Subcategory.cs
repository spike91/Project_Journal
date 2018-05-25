using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class Subcategory
    {
        public int SubcategoryID { get; set; }
        public string Name { get; set; }

        public ICollection<JournalarticleSubcategory> JournalarticleSubcategoies { get; set; }
        public ICollection<SubcategoryCategory> SubcategoryCategories { get; set; }
    }
}
