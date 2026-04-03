using FilmApi.Application.Mappers;
using FilmApi.Application.Service;
using FilmApi.Application.Service.Impl;
using FilmApi.Infrastructure.Context;
using FilmApi.Infrastructure.Repositories;
using FilmApi.Infrastructure.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ── Database ───────────────────────────────────────────────────────────────
builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ── CORS ───────────────────────────────────────────────────────────────────
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
        policy.WithOrigins("http://localhost:3001")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// ── Repositories ───────────────────────────────────────────────────────────
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();

// ── Services ───────────────────────────────────────────────────────────────
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IFilmService, FilmService>();

// ── AutoMapper ─────────────────────────────────────────────────────────────
builder.Services.AddAutoMapper(cfg => { }, typeof(GeneralMapping).Assembly);

// ── Controllers & API ──────────────────────────────────────────────────────
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "FilmApi",
        Version = "v1",
        Description = "Film, kişi, kategori ve yorum yönetimi için REST API."
    });
});

// ──────────────────────────────────────────────────────────────────────────
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "FilmApi v1");
        options.RoutePrefix = string.Empty; // Swagger root'ta açılır
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowReactApp"); // UseRouting'den sonra, UseAuthorization'dan önce — doğru sıra

app.UseAuthorization();

app.MapControllers();

app.Run();
