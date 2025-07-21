using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Context
{
    public class ApiContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-PS5F1P6O\\SQLEXPRESS;Initial Catalog=ApiYummyDb;Integrated Security=True;TrustServerCertificate=True;");

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Image> Images { get; set; }
         
    }
}