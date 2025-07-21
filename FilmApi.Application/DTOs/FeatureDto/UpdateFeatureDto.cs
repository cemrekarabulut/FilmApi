using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.Application.DTOs.FeatureDto
{
    public class UpdateFeatureDto
    {
        public int FeatureId { get; set; }

        public string Job { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }   
    }
}