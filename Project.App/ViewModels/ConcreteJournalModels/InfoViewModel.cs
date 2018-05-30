using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.ViewModels.ConcreteJournalModels
{
    public class InfoViewModel
    {
        public Concretejournal Journal { get; set; }
        public Publishingcompany Company { get; set; }
        public List<Person> Authors { get; set; }
        public List<Journalarticle> Articles { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Subcategory> Categories { get; set; }
    }
}
