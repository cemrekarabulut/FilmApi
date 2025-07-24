using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FilmApi.Application.DTOs.FilmDto
{
     public class CreateFilmDto
    {
        public string FilmName { get; set; }

        public decimal TicketPrice { get; set; }

        public string ImageUrl { get; set; }

        public int Imdb { get; set; }

        public int CategoryId { get; set; }
    }
}