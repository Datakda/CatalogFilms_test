using Catalog_films_test.Models;
using Catalog_films_test.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Catalog_films_test.Controllers
{
    public class FilmController : Controller
    {

        private AppBDContext db;
       
        IWebHostEnvironment _appEnvironment;
        public FilmController(AppBDContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }


        //списка всех фильмов (с пагинацией);
        public  IActionResult Index(int page = 1)
        {
            int pageSize = 3;   // количество элементов на странице

            List<Film> source = db.Films.ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Films = items
            };
            return View(viewModel);
        }

        
        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult Add(AddFilmModel model)
        {
            if (ModelState.IsValid) 
            {
                string path = "/Images/" + model.Image.FileName;
                // сохраняем файл в папку Images в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }

                Film film = new Film();

                film.Name = model.Name;
                film.Description = model.Description;
                film.Producer = model.Producer;
                film.Yers = model.Yers;
                film.UrlImage = path; 
                film.UserId = db.Users.FirstOrDefault(usr => usr.Login == User.Identity.Name).Id;


                db.Add(film);
                db.SaveChanges();
                ViewBag.Message = "Hello ASP.NET Core";
                ViewBag.Message = $"Спасибо {User.Identity.Name} фильм {model.Name} добавлен в каталог";
                return View();

            }
 
            return View();


            
        }

        // страница редактирования данных о фильме;
        public IActionResult Edit()
        {
            return View();
        }


        //страница одного отдельного фильма;
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else 
            {
            Film  film =  db.Films.Where(x => x.Id == id).FirstOrDefault();

                if (film != null) { return View(film); }
                else { return RedirectToAction("Index", "Home"); }
            }

            
        }
    }
}
