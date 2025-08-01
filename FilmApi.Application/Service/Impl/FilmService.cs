using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.FeatureModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Repositories;
using AutoMapper;
using FilmApi.Application.DTOs.FilmDto;


namespace FilmApi.Application.Service.Impl
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public FilmService(IFilmRepository filmRepository, IMapper mapper,ICategoryRepository categoryRepository)
        {
            _filmRepository = filmRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ResultFilmDto>> GetAllAsync()
        {
            var films = await _filmRepository.GetAllAsync();
            return _mapper.Map<List<ResultFilmDto>>(films);
        }

        public async Task AddAsync(CreateFilmDto createFilm)
        {
             var film = _mapper.Map<Film>(createFilm);

        film.Categories.Clear();
         foreach (var categoryId in createFilm.CategoryIds)
        {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category != null)
        {
            film.Categories.Add(category);
        }
        else
        {
            throw new Exception($"Kategori bulunamadı: {categoryId}");
        }
        }

          await _filmRepository.AddAsync(film);
        }

        public async Task<ResultFilmDto> GetByIdAsync(int id)
        {
            var film = await _filmRepository.GetByIdAsync(id);
            return _mapper.Map<ResultFilmDto>(film);
        }

        public async Task UpdateAsync(UpdateFilmDto updateFilm)
        {
            var film = _mapper.Map<Film>(updateFilm);
            await _filmRepository.UpdateAsync(film);
        }

        public async Task DeleteAsync(int id)
        {
            var film = await _filmRepository.GetByIdAsync(id);
            if (film != null)
            {
                await _filmRepository.DeleteAsync(film);
            }
        }
    }
}