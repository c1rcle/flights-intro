using System;

namespace Flights.Core.Models
{
    public class FlightDto
    {
        public string Operator { get; set; }

        public DateTime Date { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }
    }
}