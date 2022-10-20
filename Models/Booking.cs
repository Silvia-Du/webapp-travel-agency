using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        //intestatario
        public int BuyerId { get; set; }
        public Buyer? Buyer { get; set; }

        //viaggio
        public int TripId { get; set; }
        public Trip? Trip { get; set; }

        //partecipanti
        public List<Traveler>? Travelers { get; set; }


    }
}
