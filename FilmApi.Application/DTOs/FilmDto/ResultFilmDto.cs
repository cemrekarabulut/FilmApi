using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Application.DTOs;
using FilmApi.Application.DTOs.PersonDto;
using FilmApi.Application.DTOs.CategoryDto;

namespace FilmApi.Application.DTOs.FilmDto
{
    public class ResultFilmDto
    {
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public string Description { get; set; }
        public decimal TicketPrice { get; set; }
        public int Imdb { get; set; }

        public List<int> CategoryIds { get; set; }

       public List<ResultCategoryDto> Categories { get; set; }
        public List<ResultPersonDto> Actors { get; set; }    
        public ResultPersonDto Director { get; set; }  
    }
}