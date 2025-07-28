using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.Application.DTOs.PersonDto
{
    public class CreatePersonDto
    {

        public string NameSurname { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }
        
        public int FeatureId { get; set; }
    }
}