namespace FilmApi.Application.DTOs.CommentDto
{
    public class ResultCommentDto
    {
        public int CommentId { get; set; }
        public string NameSurname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string MessageDetails { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}