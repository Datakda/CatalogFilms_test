using Catalog_films_test.Models;
using Catalog_films_test.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_films_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppBDContext db;
        public HomeController(AppBDContext context,ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            IndexHomeViewModel  model = new IndexHomeViewModel();

            model.NameUser = User.Identity.Name;
            model.CountAllFilms = db.Films.Count();
            model.CountUserFilms = db.Films.Where(x => x.UserId == db.Users.FirstOrDefault(usr => usr.Login == User.Identity.Name).Id).Count();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
