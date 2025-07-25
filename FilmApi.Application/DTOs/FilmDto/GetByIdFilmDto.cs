using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.Application.DTOs.FilmDto
{
    public class GetByIdFilmDto
    {
        public int FilmId { get; set; }

        public string FilmName { get; set; }

        public string FilmCategory { get; set; }

        public decimal TicketPrice { get; set; }

        public int Imdb{ get; set;}

        public int CategoryId { get; set; } 
    }
}