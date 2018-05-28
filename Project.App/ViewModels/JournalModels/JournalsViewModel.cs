using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.ViewModels.JournalModels
{
    public class JournalsViewModel
    {
        public IEnumerable<Journal> Journals { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
