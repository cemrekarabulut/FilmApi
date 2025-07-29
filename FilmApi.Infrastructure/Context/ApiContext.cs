using System;
using Microsoft.EntityFrameworkCore;
using FilmApi.Domain.Entities;
using FilmApi.Domain.Enumeration;

namespace FilmApi.Infrastructure.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-PS5F1P6O\\SQLEXPRESS;Initial Catalog=ApiFilmDb;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Categories)
                .WithMany(c => c.Films)
                .UsingEntity(j => j.ToTable("FilmCategories"));

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Persons)
                .WithMany(p => p.Films)
                .UsingEntity(j => j.ToTable("FilmActors"));

            modelBuilder.Entity<Person>()
                .Property(a => a.Gender)
                .HasConversion(
                    g => g.Name,
                    name => Gender.FromName(name)
                );

            base.OnModelCreating(modelBuilder);
        }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public ApiContext() { }
    }
        
}
