using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteGol.Commands.Flights
{
    public class DeleteFlightCommand: IRequest<DeleteFlightCommandResponse>
    {
        public DeleteFlightCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
