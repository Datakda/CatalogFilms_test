using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_films_test.Models
{
    public class Film
    {   [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Yers { get; set; }

        public string Producer { get; set; }

        public string UrlImage { get; set; }

        public string UserLogin { get; set; } // внешний ключ

        


    }
}
