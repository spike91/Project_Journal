using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class Publishingcompany
    {
        public int PublishingcompanyID { get; set; }
        public string Name { get; set; }
        public string Site { get; set; }

        public ICollection<Journal> Journals { get; set; }
    }
}
