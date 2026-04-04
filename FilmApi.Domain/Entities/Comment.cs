namespace FilmApi.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public required string NameSurname { get; set; }
        public required string Email { get; set; }
        public required string Subject { get; set; }
        public required string MessageDetails { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}