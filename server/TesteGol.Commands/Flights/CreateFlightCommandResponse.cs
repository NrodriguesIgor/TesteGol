using System;

namespace TesteGol.Commands.Flights
{
    public class CreateFlightCommandResponse
    {
        public CreateFlightCommandResponse()
        {

        }
        public CreateFlightCommandResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
