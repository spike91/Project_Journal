using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class JournalarticleSubcategory
    {
        public int JournalarticleID { get; set; }
        public Journalarticle Journalarticle { get; set; }
        public int SubcategoryID { get; set; }
        public Subcategory Subcategory { get; set; }

    }
}
