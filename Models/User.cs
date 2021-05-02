﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_films_test.Models
{
    public class User
    {   
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
        public List<Film> Films { get; set; }


    }
}
