using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteGol.Commands.Flights
{
    public class UpdateFlightCommand : IRequest<UpdateFlightCommandResponse>
    {
        public UpdateFlightCommand(Guid id, string name, DateTime departureTime, string origin, string destination)
        {
            Id = id;
            Name = name;
            DepartureTime = departureTime;
            Origin = origin;
            Destination = destination;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }
}
