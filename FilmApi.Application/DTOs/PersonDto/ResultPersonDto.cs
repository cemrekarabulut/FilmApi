namespace FilmApi.Application.DTOs.PersonDto
{
    public class ResultPersonDto
    {
        public int PersonId { get; set; }
        public string NameSurname { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Job { get; set; } = string.Empty;
    }
}
