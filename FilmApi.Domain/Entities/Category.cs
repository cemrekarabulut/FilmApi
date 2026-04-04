namespace FilmApi.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public ICollection<Film> Films { get; set; } = new List<Film>();
    }
}