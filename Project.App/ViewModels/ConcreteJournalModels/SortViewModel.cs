using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.ViewModels.ConcreteJournalModels
{
    public class SortViewModel
    {
        public SortState TitleSort { get; private set; } 
        public SortState DateSort { get; private set; }   
        public SortState JournalSort { get; private set; }   
        public SortState CategorySort { get; private set; }   
        public SortState Current { get; private set; }    

        public SortViewModel(SortState sortOrder)
        {
            TitleSort = sortOrder == SortState.TitleAsc ? SortState.TitleDesc : SortState.TitleAsc;
            DateSort = sortOrder == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;
            JournalSort = sortOrder == SortState.JournalAsc ? SortState.JournalDesc : SortState.JournalAsc;
            CategorySort = sortOrder == SortState.CategoryAsc ? SortState.CategoryDesc : SortState.CategoryAsc;
            Current = sortOrder;
        }
    }
}
