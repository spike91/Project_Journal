using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.App.ViewModels;
using Project.App.ViewModels.JournalModels;
using Project.DataBase;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Project.App.ViewComponents
{
    public class JournalListViewComponent : ViewComponent
    {
        private readonly Context db;

        public JournalListViewComponent(Context context)
        {
            db = context;
        }

        public IViewComponentResult Invoke(int maxPriority, bool isDone)
        {
            IQueryable<Concretejournal> journals = db.Concretejournals.Include(x => x.Journal).ThenInclude(y => y.PublishingCompany).Include(x => x.Journalarticles).ThenInclude(x => x.JournalarticleSubcategories).ThenInclude(z => z.Subcategory);
            journals = journals.OrderByDescending(s => s.Date).Take(10);

            return View("Journals", journals);
        }
    }
}
