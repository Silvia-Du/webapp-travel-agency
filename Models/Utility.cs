namespace webapp_travel_agency.Models
{
    public class Utility
    {
        public Trip? Trip { get; set; }

        public Destination? Destination { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Destination>? Destinations { get; set; }
        public List<AgeRange>? Ranges { get; set; }

        public Utility()
        {
            Trip = new();
            Destination = new();
            Categories = new();
            Destinations = new();
            Ranges = new();
        }
    }
}
