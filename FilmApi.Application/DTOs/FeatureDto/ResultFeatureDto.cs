namespace FilmApi.Application.DTOs.FeatureDto
{
    public class ResultFeatureDto
    {
        public int FeatureId { get; set; }
        public string Job { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}