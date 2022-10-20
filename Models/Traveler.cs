using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Traveler
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(70, ErrorMessage = "Il campo nome non può avre piu di 70 caratteri")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [StringLength(70, ErrorMessage = "Il cognome non può avre piu di 70 caratteri")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [Range(1, 130, ErrorMessage = "l'età deve essere compreso tra 1 e 130")]
        public int Age { get; set; }
        public List<Booking>? Bookings { get; set; }

    }
}
