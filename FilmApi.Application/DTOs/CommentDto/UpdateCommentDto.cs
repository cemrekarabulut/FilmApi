using System.ComponentModel.DataAnnotations;

namespace FilmApi.Application.DTOs.CommentDto
{
    public class UpdateCommentDto
    {
        [Required]
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Ad soyad zorunludur.")]
        [MaxLength(150)]
        public required string NameSurname { get; set; }

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [MaxLength(200)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Konu zorunludur.")]
        [MaxLength(300)]
        public required string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj içeriği zorunludur.")]
        [MaxLength(2000)]
        public required string MessageDetails { get; set; }
    }
}