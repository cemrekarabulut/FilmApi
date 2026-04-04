using System.ComponentModel.DataAnnotations;

namespace FilmApi.Application.DTOs.PersonDto
{
    public class CreatePersonDto
    {
        [Required(ErrorMessage = "Ad soyad zorunludur.")]
        [MaxLength(150, ErrorMessage = "Ad soyad en fazla 150 karakter olabilir.")]
        public required string NameSurname { get; set; }

        [Required(ErrorMessage = "Cinsiyet zorunludur. Geçerli değerler: Male, Female, Unknown.")]
        public required string Gender { get; set; }

        [Range(1, 120, ErrorMessage = "Yaş 1 ile 120 arasında olmalıdır.")]
        public int Age { get; set; }

        [Required]
        public int FeatureId { get; set; }
    }
}