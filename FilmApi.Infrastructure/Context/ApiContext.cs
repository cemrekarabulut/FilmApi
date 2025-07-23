using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FilmApi.Domain.Entities;
namespace FilmApi.Infrastructure.Context;



public class ApiContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
         if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-PS5F1P6O\\SQLEXPRESS;Initial Catalog=ApiFilmDb;Integrated Security=True;TrustServerCertificate=True;");
    }

    }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Image> Images { get; set; } 

       protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Film>()
        .HasMany(f => f.Categories)
        .WithMany(c => c.Films)
        .UsingEntity(j => j.ToTable("FilmCategories")); // Join tablo adı

    base.OnModelCreating(modelBuilder);
}
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {
    
}

 }
    
