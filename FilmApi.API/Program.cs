using FilmApi.Application.Service;
using FilmApi.Application.Service.Impl;
using FilmApi.Infrastructure.Context;
using FilmApi.Infrastructure.Repositories;
using FilmApi.Infrastructure.Repositories.Impl;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();



// Services
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddAutoMapper(typeof(FilmApi.Application.Mappers.GeneralMapping));
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IFilmService, FilmService>();



// ⚠️ EKLENDİ
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ⚠️ EKLENDİ
app.MapControllers();

app.Run();
