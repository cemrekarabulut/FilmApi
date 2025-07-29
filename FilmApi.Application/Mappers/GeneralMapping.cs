using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmApi.Application.DTOs.PersonDto;
using FilmApi.Application.DTOs.CategoryDto;
using FilmApi.Application.DTOs.CommentDto;
using FilmApi.Application.DTOs.FilmDto;
using FilmApi.Application.DTOs.FeatureDto;
using FilmApi.Domain.Entities;
using FilmApi.Domain.Enumeration;


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

            CreateMap<Person, CreatePersonDto>().ReverseMap();
            CreateMap<Person, GetByIdPersonDto>().ReverseMap();
            CreateMap<Person, UpdatePersonDto>().ReverseMap();
            CreateMap<Person, ResultPersonDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();

            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, GetByIdCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<Comment, ResultCommentDto>().ReverseMap();

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();

            CreateMap<Category, ResultCategoryWithFilmsDto>();
            CreateMap<Film, ResultFilmDto>();


            /* CreateMap<CreateFilmWithoutCategoryIdDto, Film>()
             .ForMember(dest => dest.FilmName, opt => opt.MapFrom(src => src.FilmName))
             .ForMember(dest => dest.FilmId, opt => opt.Ignore());*/

          CreateMap<CreateFilmWithoutCategoryIdDto, Film>()
         .ForMember(dest => dest.Categories, opt => opt.Ignore())  // CategoryId yerine Categories
         .ForMember(dest => dest.FilmId, opt => opt.Ignore());     // Id otomatik olsun

            CreateMap<CreateCategoryDto, Category>()
            .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
            .ForMember(dest => dest.Films, opt => opt.MapFrom(src => src.Films));


            CreateMap<CreateCategoryDto, Category>()
            .ForMember(dest => dest.Films, opt => opt.MapFrom(src => src.Films));
            CreateMap<CreateFilmWithoutCategoryIdDto, Film>();

            CreateMap<Person, ResultPersonDto>()
           .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Name))
           .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Feature.Job));

            CreateMap<CreatePersonDto, Person>()
           .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Gender.FromName(src.Gender)));

            // Film Mapping
            CreateMap<Film, ResultFilmDto>().ReverseMap();
             
            CreateMap<Film, ResultFilmDto>()
            .ForMember(dest => dest.CategoryIds,
               opt => opt.MapFrom(src => src.Categories.Select(c => c.CategoryId).ToList()))
            .ReverseMap()
            .ForMember(dest => dest.Categories,
               opt => opt.Ignore());  // ReverseMap'te kategorileri ignore et, çünkü burada doğrudan ekleyemeyiz

            CreateMap<CreateFilmDto, Film>()
            .ForMember(dest => dest.Categories,
               opt => opt.Ignore()); // Kategorileri ayrı bir servis/metot ile ekle

        }
    }
}