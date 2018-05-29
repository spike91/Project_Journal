using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.App.ViewModels;
using Project.App.ViewModels.JournalModels;
using Project.App.ViewModels.ConcreteJournalModels;
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

        public async Task<IActionResult> ConcreteJournalInfo(int id)
        {
            Concretejournal journal = await db.Concretejournals.Include(c => c.Journal).Where(c => c.ConcretejournalID == id).FirstOrDefaultAsync();

            InfoViewModel viewModel = new InfoViewModel()
            {
                Journal = journal,
                Articles = await db.Journalarticles.Where(j => j.ConcreteJournalID == id).ToListAsync(),
                Authors = await db.Persons.Where(p => p.PersonJournalarticles.Where(x => x.Journalarticle.ConcreteJournalID == id).Count() >= 1).ToListAsync(),
                Comments = await db.Comments.Where(c => c.ConcretejournalComments.Where(cc => cc.ConcretejournalID == id).Count() >= 1).ToListAsync()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Index(int? category, int? company, string name, int page = 1,
            ViewModels.JournalModels.SortState sortOrder = ViewModels.JournalModels.SortState.TitleAsc)
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
                case ViewModels.JournalModels.SortState.TitleDesc:
                    journals = journals.OrderByDescending(s => s.Title);
                    break;
                case ViewModels.JournalModels.SortState.LanguageAsc:
                    journals = journals.OrderBy(s => s.Language);
                    break;
                case ViewModels.JournalModels.SortState.LanguageDesc:
                    journals = journals.OrderByDescending(s => s.Language);
                    break;
                case ViewModels.JournalModels.SortState.CompanyAsc:
                    journals = journals.OrderBy(s => s.PublishingCompany.Name);
                    break;
                case ViewModels.JournalModels.SortState.CompanyDesc:
                    journals = journals.OrderByDescending(s => s.PublishingCompany.Name);
                    break;
                case ViewModels.JournalModels.SortState.CategoryAsc:
                    journals = journals.OrderBy(s => s.JournalCategories);
                    break;
                case ViewModels.JournalModels.SortState.CategoryDesc:
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
            ViewModels.JournalModels.IndexViewModel viewModel = new ViewModels.JournalModels.IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new ViewModels.JournalModels.SortViewModel(sortOrder),
                FilterViewModel = new ViewModels.JournalModels.FilterViewModel(db.Categories.ToList(), category, db.Publishingcompanies.ToList(), company, name),
                Journals = items
            };

            return View(viewModel);
        }

        public async Task<IActionResult> ConcreteJournals(int? category, int? subCategory, int? journal, string search, int page = 1,
            Project.App.ViewModels.ConcreteJournalModels.SortState sortOrder = Project.App.ViewModels.ConcreteJournalModels.SortState.TitleAsc, string type = "menu")
        {
            int pageSize = 5;

            //фильтрация
            IQueryable<Concretejournal> journals = db.Concretejournals.Include(x => x.Journal).ThenInclude(y => y.PublishingCompany).Include(x => x.Journal).ThenInclude(y => y.JournalCategories)
                .Include(x => x.Journalarticles).ThenInclude(x => x.JournalarticleSubcategories).ThenInclude(z => z.Subcategory)
                .Include(x => x.Journalarticles).ThenInclude(x => x.Keywords);

            if (journal != null && journal != 0)
            {
                journals = journals.Where(p => p.Journal.JournalID == journal);
            }
            if (category != null && category != 0)
            {
                journals = journals.Where(p => p.Journal.JournalCategories.Where(x => x.CategoryID == category).Count() >= 1);
            }
            if (subCategory != null && subCategory != 0)
            {
                journals = journals.Where(p => p.Journalarticles.Where(x => x.JournalarticleSubcategories.Where(z => z.Subcategory.SubcategoryID == subCategory).Count() >= 1).Count() >= 1);
            }
            if (!String.IsNullOrEmpty(search))
            {
                journals = journals.Where(p => p.Journalarticles
                .Where(k => k.Keywords
                .Where(z => z.Word.Name.Contains(search)
                        ).Count() >= 1 
                || k.PersonJournalarticles
                .Where(per => (per.Person.FirstName+per.Person.LastName)
                .Contains(search)
                        ).Count() >= 1
                                        ).Count() >= 1
                || (p.Journal.Title + " " + p.Number).Contains(search)
                );
            }

            // сортировка
            switch (sortOrder)
            {
                case ViewModels.ConcreteJournalModels.SortState.TitleDesc:
                    journals = journals.OrderByDescending(s => s.Journal.Title + " " + s.Number);
                    break;
                case ViewModels.ConcreteJournalModels.SortState.DateAsc:
                    journals = journals.OrderBy(s => s.Date);
                    break;
                case ViewModels.ConcreteJournalModels.SortState.DateDesc:
                    journals = journals.OrderByDescending(s => s.Date);
                    break;
                case ViewModels.ConcreteJournalModels.SortState.JournalAsc:
                    journals = journals.OrderBy(s => s.Journal.Title);
                    break;
                case ViewModels.ConcreteJournalModels.SortState.JournalDesc:
                    journals = journals.OrderByDescending(s => s.Journal.Title);
                    break;
                case ViewModels.ConcreteJournalModels.SortState.CategoryAsc:
                    journals = journals.OrderBy(s => s.Journalarticles);
                    break;
                case ViewModels.ConcreteJournalModels.SortState.CategoryDesc:
                    journals = journals.OrderByDescending(s => s.Journalarticles);
                    break;
                default:
                    journals = journals.OrderBy(s => s.Journal.Title + " " + s.Number);
                    break;
            }

            // пагинация
            var count = await journals.CountAsync();
            var items = await journals.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            ViewModels.ConcreteJournalModels.IndexViewModel viewModel = new ViewModels.ConcreteJournalModels.IndexViewModel
            {
                Type = type,
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new ViewModels.ConcreteJournalModels.SortViewModel(sortOrder),
                FilterViewModel = new ViewModels.ConcreteJournalModels.FilterViewModel(db.Subcategories.ToList(), subCategory, db.Journals.ToList(), journal, search),
                Journals = items
            };

            return View(viewModel);
        }
    }
}