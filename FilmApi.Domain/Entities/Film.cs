using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FilmApi.Domain.Entities
{
    public class Film
    {
       public int FilmId { get; set; }

        public string FilmName { get; set; }

        public string FilmCategory { get; set; }

        public decimal TicketPrice { get; set; }

        public string ImageUrl { get; set; }

        public int Imdb{ get; set;}

        public int CategoryId { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
         
    }
}