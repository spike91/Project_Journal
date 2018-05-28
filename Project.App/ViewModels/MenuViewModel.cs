using Project.DataBase;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.ViewModels
{
    public class MenuViewModel
    {
        public List<Category> Categories { get; set; }
        public MenuViewModel()
        {
            Categories = new List<Category>();
        }
    }
}
