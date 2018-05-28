using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.App.ViewModels;
using Project.DataBase;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.ViewComponents
{
    public class PriorityListViewComponent : ViewComponent
    {
        private readonly Context db;

        public PriorityListViewComponent(Context context)
        {
            db = context;
        }

        public IViewComponentResult Invoke(
       int maxPriority, bool isDone)
        {
            List<Category> list = db.Categories.Include(c => c.SubcategoryCategories).ThenInclude(sc => sc.Subcategory).ToList();
            return View(new MenuViewModel { Categories = list });
        }
    }
}
