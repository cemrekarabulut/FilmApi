using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.API.Models
{
    public class CreateActorModel
    {
        public string NameSurname { get; set; }

        public string Gender { get; set; }

        public string Age { get; set; }
    }
}