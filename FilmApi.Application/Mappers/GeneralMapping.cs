using AutoMapper;
using FilmApi.Application.DTOs.CategoryDto;
using FilmApi.Application.DTOs.CommentDto;
using FilmApi.Application.DTOs.FeatureDto;
using FilmApi.Application.DTOs.FilmDto;
using FilmApi.Application.DTOs.PersonDto;
using FilmApi.Domain.Entities;
using FilmApi.Domain.Enumeration;

namespace FilmApi.Application.Mappers
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            // ── Film ──────────────────────────────────────────────────
            CreateMap<Film, ResultFilmDto>()
                .ForMember(dest => dest.CategoryIds,
                    opt => opt.MapFrom(src => src.Categories.Select(c => c.CategoryId).ToList()))
                .ForMember(dest => dest.Actors, opt => opt.Ignore())
                .ForMember(dest => dest.Director, opt => opt.Ignore());

            CreateMap<CreateFilmDto, Film>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                .ForMember(dest => dest.FilmId, opt => opt.Ignore());

            CreateMap<UpdateFilmDto, Film>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore());

            CreateMap<CreateFilmWithoutCategoryIdDto, Film>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                .ForMember(dest => dest.FilmId, opt => opt.Ignore());

            // ── Person ────────────────────────────────────────────────
            CreateMap<Person, ResultPersonDto>()
                .ForMember(dest => dest.Gender,
                    opt => opt.MapFrom(src => src.Gender != null ? src.Gender.Name : string.Empty))
                .ForMember(dest => dest.Job,
                    opt => opt.MapFrom(src => src.Feature != null ? src.Feature.Job : string.Empty));

            CreateMap<CreatePersonDto, Person>()
                .ForMember(dest => dest.Gender,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrWhiteSpace(src.Gender) ? Gender.Unknown : Gender.FromName(src.Gender)));

            CreateMap<UpdatePersonDto, Person>()
                .ForMember(dest => dest.Gender,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrWhiteSpace(src.Gender) ? Gender.Unknown : Gender.FromName(src.Gender)));

            // ── Category ──────────────────────────────────────────────
            CreateMap<Category, ResultCategoryDto>();
            CreateMap<Category, ResultCategoryWithFilmsDto>()
                .ForMember(dest => dest.Films,
                    opt => opt.MapFrom(src => src.Films));

            CreateMap<CreateCategoryDto, Category>()
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
                .ForMember(dest => dest.Films, opt => opt.MapFrom(src => src.Films ?? new List<CreateFilmWithoutCategoryIdDto>()));

            CreateMap<UpdateCategoryDto, Category>();

            // ── Comment ───────────────────────────────────────────────
            CreateMap<Comment, ResultCommentDto>();
            CreateMap<CreateCommentDto, Comment>()
                .ForMember(dest => dest.CommentId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<UpdateCommentDto, Comment>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            // ── Feature ───────────────────────────────────────────────
            CreateMap<Feature, ResultFeatureDto>();
            CreateMap<CreateFeatureDto, Feature>()
                .ForMember(dest => dest.FeatureId, opt => opt.Ignore())
                .ForMember(dest => dest.Persons, opt => opt.Ignore());
            CreateMap<UpdateFeatureDto, Feature>()
                .ForMember(dest => dest.Persons, opt => opt.Ignore());
        }
    }
}
