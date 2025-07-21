using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmApi.Application.DTOs.ActorDto;
using FilmApi.Application.DTOs.CategoryDto;
using FilmApi.Application.DTOs.CommentDto;
using FilmApi.Application.DTOs.FilmDto;
using FilmApi.Application.DTOs.FeatureDto;
using FilmApi.Domain.Entities;



namespace FilmApi.Application.Mappers
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Film, CreateFilmDto>().ReverseMap();
            CreateMap<Film, GetByIdFilmDto>().ReverseMap();
            CreateMap<Film, UpdateFilmDto>().ReverseMap();
            CreateMap<Film, ResultFilmDto>().ReverseMap();

            CreateMap<Actor, CreateActorDto>().ReverseMap();
            CreateMap<Actor, GetByIdActorDto>().ReverseMap();
            CreateMap<Actor, UpdateActorDto>().ReverseMap();
            CreateMap<Actor, ResultActorDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();

            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, GetByIdCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<Comment, ResultCommentDto>().ReverseMap();

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
        }
    }
}