using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitiInfo.API.Entities
{
    public class PointOfInterest
    {
        [Key] // Since the property name is Id, the convention would refer this as an Primary Key. [Key] attribute is redudant here.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // for explicitly stating the identity value
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public PointOfInterest(string name)
        {
            Name = name;
        }

        // Navigation Property- Convention Based
        // The City type cannot be mapped as the scalar type by the database, so it will be the navigation property
        public City? City { get; set; }
        // The CityId will infer to City Property. Not needed but is added for the clarity
        public int CityId { get; set; }

        // Navigation Property- Explicit Approach
        //[ForeignKey("CityId")]
        //public City? City { get; set; }
        
    }
}