using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.App.ViewModels;
using Project.App.ViewModels.JournalModels;
using Project.DataBase;
using Project.Entities;

namespace Project.App.Controllers
{
    public class JournalController : Controller
    {
        Context db;

        public JournalController(Context context)
        {
            this.db = context;
        }

        public async Task<IActionResult> Index(int? category, int? company, string name, int page = 1,
            SortState sortOrder = SortState.TitleAsc)
        {        
            int pageSize = 5;

            //фильтрация
            IQueryable<Journal> journals = db.Journals.Include(x => x.JournalCategories).Include(x => x.PublishingCompany);

            if (company != null && company != 0)
            {
                journals = journals.Where(p => p.PublishingCompanyID == company);
            }
            if (category != null && category != 0)
            {
                journals = journals.Where(p => p.JournalCategories.Where(x => x.CategoryID == category).Count() >= 1);
            }
            if (!String.IsNullOrEmpty(name))
            {
                journals = journals.Where(p => p.Title.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.TitleDesc:
                    journals = journals.OrderByDescending(s => s.Title);
                    break;
                case SortState.LanguageAsc:
                    journals = journals.OrderBy(s => s.Language);
                    break;
                case SortState.LanguageDesc:
                    journals = journals.OrderByDescending(s => s.Language);
                    break;
                case SortState.CompanyAsc:
                    journals = journals.OrderBy(s => s.PublishingCompany.Name);
                    break;
                case SortState.CompanyDesc:
                    journals = journals.OrderByDescending(s => s.PublishingCompany.Name);
                    break;
                case SortState.CategoryAsc:
                    journals = journals.OrderBy(s => s.JournalCategories);
                    break;
                case SortState.CategoryDesc:
                    journals = journals.OrderByDescending(s => s.JournalCategories);
                    break;
                default:
                    journals = journals.OrderBy(s => s.Title);
                    break;
            }

            // пагинация
            var count = await journals.CountAsync();
            var items = await journals.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Categories.ToList(), category, db.Publishingcompanies.ToList(), company, name),
                Journals = items
            };

            return View(viewModel);
        }
    }
}