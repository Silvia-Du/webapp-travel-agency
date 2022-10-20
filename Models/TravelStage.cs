using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class TravelStage
    {

        [Key]
        public int Id { get; set; }
        [Column("name")]
        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        public string? Name { get; set; }

        //relation
        public List<Destination>? Destinations { get; set; }
    }
}
