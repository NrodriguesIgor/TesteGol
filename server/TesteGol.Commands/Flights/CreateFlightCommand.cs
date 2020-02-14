using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteGol.Commands.Flights
{
    public class CreateFlightCommand : IRequest<CreateFlightCommandResponse>
    {
        public CreateFlightCommand(string name, DateTime departureTime, string origin, string destination)
        {
            Name = name;
            DepartureTime = departureTime;
            Origin = origin;
            Destination = destination;
        }

        public string Name { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }

    }
}
