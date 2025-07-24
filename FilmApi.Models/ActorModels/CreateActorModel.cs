using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FilmApi.Models.ActorModels
{
    public class CreateActorModel
    {
        public int ActorId { get; set; }
        
        public string NameSurname { get; set; }

        public string Gender { get; set; }

        public string Age { get; set; }
    }
}