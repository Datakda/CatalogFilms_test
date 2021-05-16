using Catalog_films_test.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_films_test.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Film> Films { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
