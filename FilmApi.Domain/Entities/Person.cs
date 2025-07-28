using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Domain.Enumeration;

namespace FilmApi.Domain.Entities
{
    public class Person
    {
        public int PersonId { get; set; }

        public string NameSurname { get; set; }

        public Gender Gender { get; set; } // enumeration

        public int Age { get; set; }

        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
        
        public ICollection<Film> Films { get; set; } = new List<Film>();

    }
}