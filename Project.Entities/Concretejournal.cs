using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class Concretejournal
    {
        public int ConcretejournalID { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string Pages { get; set; }
        public string Image { get; set; } = null;
        public DateTime Date { get; set; }

        public int JournalID { get; set; }
        public Journal Journal { get; set; }

        public ICollection<ConcretejournalComment> ConcretejournalComments { get; set; }
        public ICollection<Journalarticle> Journalarticles { get; set; }
    }
}
