using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class Journal
    {
        public int JournalID { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public string Site { get; set; }
        public string Image { get; set; } = null;

        public int PublishingCompanyID { get; set; }
        public Publishingcompany PublishingCompany { get; set; }

        public ICollection<JournalCategory> JournalCategories { get; set; }
        public ICollection<Concretejournal> Concretejournals { get; set; }
    }
}
