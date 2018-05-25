using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class Journalarticle
    {
        public int JournalArticleID{ get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Page { get; set; }

        public int ConcreteJournalID { get; set; }
        public Concretejournal ConcreteJournal { get; set; }

        public ICollection<PersonJournalarticle> PersonJournalarticles { get; set; }
        public ICollection<JournalarticleSubcategory> JournalarticleSubcategories { get; set; }
        public ICollection<KeyWord> Keywords { get; set; }
    }
}
