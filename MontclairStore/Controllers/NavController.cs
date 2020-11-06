using MontclairModels;
using MontclairStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MontclairStore.Controllers
{
    public class NavController : Controller
    {
        private ApplicationDbContext repository;

        public NavController(ApplicationDbContext repo)
        {
            repository = repo;
        }
        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Categories
                .Select(x => x.Category_Name)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}