using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class JournalCategory
    {
        public int JournalID { get; set; }
        public Journal Journal { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
