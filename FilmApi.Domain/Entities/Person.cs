using FilmApi.Domain.Enumeration;

namespace FilmApi.Domain.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public required string NameSurname { get; set; }
        public Gender? Gender { get; set; }
        public int Age { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; } = null!;
        public string? Job { get; set; }
        public ICollection<Film> Films { get; set; } = new List<Film>();
    }
}