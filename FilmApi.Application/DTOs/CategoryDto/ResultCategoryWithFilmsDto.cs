using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Application.DTOs.FilmDto;

namespace FilmApi.Application.DTOs.CategoryDto
{
    public class ResultCategoryWithFilmsDto
    {
          public int CategoryId{ get ; set;}

        public string CategoryName{ get ; set;}

        public List<ResultFilmDto> Films { get ; set;}  
    }
}