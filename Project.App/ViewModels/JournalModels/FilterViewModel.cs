using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.ViewModels.JournalModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Category> categories, int? category, List<Publishingcompany> companies, int? company, string title)
        {
            categories.Insert(0, new Category { CategoryName = "Все", CategoryID = 0 });
            Categories = new SelectList(categories, "CategoryID", "CategoryName", category);
            SelectedCategory = category;

            companies.Insert(0, new Publishingcompany { Name = "Все",  PublishingcompanyID = 0 });
            Companies = new SelectList(companies, "PublishingcompanyID", "Name", company);
            SelectedCompany = company;

            SelectedTitle = title;
        }
        public SelectList Categories { get; private set; } 
        public int? SelectedCategory { get; private set; }
        public SelectList Companies { get; private set; }
        public int? SelectedCompany { get; private set; }
        public string SelectedTitle { get; private set; }    
    }
}
