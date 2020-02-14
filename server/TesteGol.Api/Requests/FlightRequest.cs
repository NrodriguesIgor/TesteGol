using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteGol.Api.Requests
{
    public class FlightRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Destination { get; set; }
    }
}
