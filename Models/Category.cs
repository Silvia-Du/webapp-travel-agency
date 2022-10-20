using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Column("name")]
        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il campo nome non può avre piu di 70 caratteri")]
        public string? Name { get; set; }

        //relation
        public List<Trip>? Trips { get; set; }
    }
}
