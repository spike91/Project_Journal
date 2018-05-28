using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.ViewModels.ConcreteJournalModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Subcategory> categories, int? subCategory, List<Journal> journals, int? journal, string title)
        {
            categories.Insert(0, new Subcategory { Name = "Все",  SubcategoryID = 0 });
            Categories = new SelectList(categories, "SubcategoryID", "Name", subCategory);
            SelectedCategory = subCategory;

            journals.Insert(0, new Journal { Title = "Все", JournalID = 0 });
            Journals = new SelectList(journals, "JournalID", "Title", journal);
            SelectedJournal = journal;

            SelectedTitle = title;
        }
        public SelectList Categories { get; private set; } 
        public int? SelectedCategory { get; private set; }
        public SelectList Journals { get; private set; }
        public int? SelectedJournal { get; private set; }
        public string SelectedTitle { get; private set; }    
    }
}
