using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.Application.DTOs.ActorDto
{
    public class GetByIdActorDto
    {
        public int ActorId {get ; set;}

        public string NameSurname {get ; set;}

        public string Gender {get ; set;}

        public int Age {get ; set;} 
    }
}