using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_films_test.Controllers
{
    public class FilmController : Controller
    {

        //списка всех фильмов (с пагинацией);
        public IActionResult Index()
        {
            return View();
        }

        //страница создания нового фильма.
        public IActionResult Add()
        {
            return View();
        }

       // страница редактирования данных о фильме;
        public IActionResult Edit()
        {
            return View();
        }


        //страница одного отдельного фильма;

    }
}
