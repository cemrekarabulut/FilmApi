using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.Domain.Entities
{
    public class Feature
    {
        public int FeatureId { get; set; }

        public string Job { get; set; }

        public string Description { get; set; }
    
    }
}