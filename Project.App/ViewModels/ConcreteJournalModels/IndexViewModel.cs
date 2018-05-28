using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.ViewModels.ConcreteJournalModels
{
    public class IndexViewModel
    {
        public IEnumerable<Concretejournal> Journals { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
