using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.App.Models;
using Project.App.ViewModels;
using Project.DataBase;
using Project.Entities;

namespace Project.App.Controllers
{
    public class HomeController : Controller
    {

        Context db;

        public HomeController(Context context)
        {
            this.db = context;
        }

        public IActionResult Index()
        {
            List<Category> list = db.Categories.Include(c => c.SubcategoryCategories).ThenInclude(sc => sc.Subcategory).ToList();
            return View(new MenuViewModel { Categories =  list});
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        public IActionResult AddJournal()
        {
            return View();
        }

        public IActionResult UpdateJournal()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
