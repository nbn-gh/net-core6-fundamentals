namespace CitiInfo.API.Models
{
    public class CityWithoutPointsOnInterestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
