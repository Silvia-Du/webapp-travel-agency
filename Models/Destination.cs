using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }
        [Column("name")]
        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        public string? Name { get; set; }

        //relations
        public List<Trip>? Trips { get; set; }
        public List<TravelStage>? Traits { get; set; }
    }
}
