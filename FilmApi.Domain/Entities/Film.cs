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

        public decimal TicketPrice { get; set; }

        public int Imdb { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Person> Persons { get; set; } = new List<Person>(); 
    }
}