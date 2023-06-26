using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        public string Flightsource { get; set; }
        public string Flightdestination { get; set; }
        public DateTime FlightDateTime { get; set; }

        public bool StatusIsOperational { get; set;}
    }
}