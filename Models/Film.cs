using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_films_test.Models
{
    public class Film
    {   [Key]
        public int Id;

        public string Name;

        public string Description;

        public int Yers;

        public string Producer;

        public string UrlImage;

        public int OwnerUserID;


    }
}
