using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Domain.Entities; // veya Film class'ı hangi namespace içindeyse

namespace FilmApi.Application.DTOs.CategoryDto
{
    public class ResultCategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}