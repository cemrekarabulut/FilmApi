using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.Domain.Entities
{
    public class Image
    {
        public int ImageId { get; set; }

        public string Title { get; set; }

        public int ImageUrl { get; set; } 
    }
}