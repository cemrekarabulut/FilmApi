using FilmApi.Models.ActorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Application.Service;
using FilmApi.Infrastructure.Repositories;
using FilmApi.Domain.Entities;
using System.Threading.Tasks;
using FilmApi.Models;
using FilmApi.Application.DTOs.ActorDto;

namespace FilmApi.Application.Service
{
    public interface IActorService
    {
    Task<List<ResultActorDto>> GetAllAsync();
    Task AddAsync(CreateActorDto createActor);
    Task<ResultActorDto> GetByIdAsync(int id);
    Task UpdateAsync(UpdateActorDto updateActor);
    Task DeleteAsync(int id);
    }

}
