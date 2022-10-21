using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il titolo è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il campo nome non può avre piu di 100 caratteri")]
        public string? Title { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Il testo è obbligatorio")]
        public string? Text { get; set; }

        [Required(ErrorMessage = "Il nome mittente è obbligatorio")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "L'email inserita non è valida")]
        [Required(ErrorMessage = "L'email di cotatto è obbligatoria")]
        public string? Email { get; set; }

        //relations

        public int TripId { get; set; }
        public Trip? Trip { get; set; }

    }
    
}
