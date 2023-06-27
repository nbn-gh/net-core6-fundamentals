using System.ComponentModel.DataAnnotations;

namespace CitiInfo.API.Models
{
    public class PointOfInterestUpdateDto
    {
        [Required(ErrorMessage = "you should provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
