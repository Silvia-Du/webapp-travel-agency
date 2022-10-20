using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class AgeRange
    {
        [Key]
        public int Id { get; set; }
        [Column("name")]
        [Required(ErrorMessage = "La fascia d'età è obbligatoria")]
        public int Range { get; set; }

        //relation
        public List<Trip>? Trips { get; set; }
    }
}
