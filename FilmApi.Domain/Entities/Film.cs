namespace FilmApi.Domain.Entities
{
    public class Film
    {
        public int FilmId { get; set; }
        public required string FilmName { get; set; }
        public decimal TicketPrice { get; set; }
        public double ImdbRating { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}