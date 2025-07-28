using FilmApi.Models.ActorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Application.Service;
using FilmApi.Infrastructure.Repositories;
using FilmApi.Domain.Entities;
using System.Threading.Tasks;
using FilmApi.Application.DTOs.PersonDto;
using FilmApi.Application.DTOs.FilmDto;
namespace FilmApi.Application.Service
{
    public interface IPersonService
    {
        Task<List<ResultPersonDto>> GetAllAsync();
        Task AddAsync(CreatePersonDto createActor);
        Task<ResultPersonDto> GetByIdAsync(int id);
        Task UpdateAsync(UpdatePersonDto updatePerson);
        Task DeleteAsync(int id);
        Task<List<ResultFilmDto>> GetFilmsByActorIdAsync(int actorId);
        Task AddFilmToActorAsync(int actorId, int filmId);
    }

}
