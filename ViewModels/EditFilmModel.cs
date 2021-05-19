using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_films_test.ViewModels
{
    public class EditFilmModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста введите название фильма")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите описание фильма")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите год выпуска фильма")]
        public int Yers { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите имя режисера")]
        public string Producer { get; set; }
        public string UrlImage { get; set; }
        public IFormFile Image { get; set; }
    }
}
