using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_films_test.Models
{
    public class AppContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Film> Films { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite(@"Data Source=.\Data\blogging.db");

    }
}
