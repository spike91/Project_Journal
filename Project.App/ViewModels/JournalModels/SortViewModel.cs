using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.ViewModels.JournalModels
{
    public class SortViewModel
    {
        public SortState TitleSort { get; private set; } 
        public SortState LanguageSort { get; private set; }   
        public SortState CompanySort { get; private set; }   
        public SortState CategorySort { get; private set; }   
        public SortState Current { get; private set; }    

        public SortViewModel(SortState sortOrder)
        {
            TitleSort = sortOrder == SortState.TitleAsc ? SortState.TitleDesc : SortState.TitleAsc;
            LanguageSort = sortOrder == SortState.LanguageAsc ? SortState.LanguageDesc : SortState.LanguageAsc;
            CompanySort = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;
            CategorySort = sortOrder == SortState.CategoryAsc ? SortState.CategoryDesc : SortState.CategoryAsc;
            Current = sortOrder;
        }
    }
}
