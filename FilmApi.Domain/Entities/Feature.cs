namespace FilmApi.Domain.Entities
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public required string Job { get; set; }
        public string? Description { get; set; }
        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}