using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_films_test.Models
{
    public class User
    {   
        [Key]
        public int Id;

        public string Name;

        public List<Film> Films;


    }
}
