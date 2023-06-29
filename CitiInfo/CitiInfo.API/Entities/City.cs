using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitiInfo.API.Entities
{
    public class City
    {
        [Key] // Since the property name is Id, the convention would refer this as an Primary Key. [Key] attribute is redudant here.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // for explicitly stating the identity value
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }
        public ICollection<PointOfInterest> PointsOfInterest { get; set; } = new List<PointOfInterest>();

        public City(string name)
        {
            Name= name;       
        }
    }
}
