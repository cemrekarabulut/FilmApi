using System.ComponentModel.DataAnnotations;

namespace FilmApi.Application.DTOs.PersonDto
{
    public class UpdatePersonDto
    {
        [Required]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Ad soyad zorunludur.")]
        [MaxLength(150)]
        public required string NameSurname { get; set; }

        [Required(ErrorMessage = "Cinsiyet zorunludur. Geçerli değerler: Male, Female, Unknown.")]
        public required string Gender { get; set; }

        [Range(1, 120, ErrorMessage = "Yaş 1 ile 120 arasında olmalıdır.")]
        public int Age { get; set; }
    }
}