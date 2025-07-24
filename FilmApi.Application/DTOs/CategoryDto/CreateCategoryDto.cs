using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Application.DTOs.FilmDto;
using FilmApi.Domain.Entities; // veya Film class'ı hangi namespace içindeyse


namespace FilmApi.Application.DTOs.CategoryDto
{
    public class CreateCategoryDto
    {
        public string CategoryName{ get ; set;}

        public List<CreateFilmWithoutCategoryIdDto> Films { get ; set;} 
    }
}