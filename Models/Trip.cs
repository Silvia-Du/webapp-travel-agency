using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        [StringLength(70, ErrorMessage = "Il campo nome non può avre piu di 70 caratteri")]
        public string? Title { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "La descrizione è obbligatoria")]
        //[SetCorrectLenghtValidation]
        public string? Description { get; set; }

        [Column("Image")]
        [Required(ErrorMessage = "L'immagine è obbligatoria")]
        public string? Image { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Il prezzo è un campo obbligatorio")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Il numero di giorni è un campo obbligatorio")]
        public int DaysNum { get; set; }

        [Required(ErrorMessage = "Il numero di tappe è un campo obbligatorio")]
        public int StagesNum { get; set; }

        [Required(ErrorMessage = "La data di inizio è un campo obbligatorio")]
        [StringLength(10, ErrorMessage = "Inserisci il formato data gg-mm-aaaa")]
        public string? StartDate { get; set; }
        [StringLength(10, ErrorMessage = "Inserisci il formato data gg-mm-aaaa")]
        [Required(ErrorMessage = "La data di fine è un campo obbligatorio")]
        public string? EndDate { get; set; }

        //relations

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int DestinationId { get; set; }
        public Destination? Destination { get; set; }

        public int AgeRangeId { get; set; }
        public AgeRange? AgeRange { get; set; }

        public List<Booking>? Bookings { get; set; }

        public List<Message>? Messages { get; set; }

    }
}
