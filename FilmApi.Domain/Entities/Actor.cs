using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.Domain.Entities
{
    public class Actor
    {
        public int ActorId {get ; set;}

        public string NameSurname {get ; set;}

        public string Gender {get ; set;}

        public int Age {get ; set;}
    }
}