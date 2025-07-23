using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FilmApi.Models.FeatureModels
{
    public class CreateFeatureModel
    {
        public string Job { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }      
    }
}