﻿namespace webapp_travel_agency.Models
{
    public class DettailsUtility
    {
        public Destination? Destination { get; set; }
        public List<Destination>? Destinations { get; set; }
        public AgeRange? AgeRange { get; set; }
        public List<AgeRange>? Ranges { get; set; }


        public DettailsUtility()
        {
            Destination = new();
            Destinations = new();
            AgeRange = new();
            Ranges = new();

        }
    }
}
