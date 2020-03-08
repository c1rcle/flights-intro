using System;
using System.ComponentModel.DataAnnotations;

namespace Flights.Core.Models
{
    public class Flight
    {
        public int Identifier { get; set; }

        [Required]
        public string Operator { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "Not a valid ICAO identifier!")]
        public string Origin { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "Not a valid ICAO identifier!")]
        public string Destination { get; set; }
    }
}