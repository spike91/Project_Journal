using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<JournalCategory> JournalCategories { get; set; }
        public ICollection<SubcategoryCategory> SubcategoryCategories { get; set; }
    }
}
