using System;

namespace TesteGol.Api.Responses
{
    public class FlightResponse
    {        
        public string Name { get; set; }        
        public DateTime DepartureTime { get; set; }        
        public string Origin { get; set; }        
        public string Destination { get; set; }
        public Guid Id { get; set; }
    }
}
