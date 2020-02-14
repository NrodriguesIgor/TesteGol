using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TesteGol.Commands.Flights;
using TesteGol.Model.Entities;
using TesteGol.Model.Repositories;
using TesteGol.Persistency.Context;

namespace TesteGol.Commands.Handlers
{
    public class FlightCommandHandler :
        IRequestHandler<CreateFlightCommand, CreateFlightCommandResponse>,
        IRequestHandler<DeleteFlightCommand, DeleteFlightCommandResponse>,
        IRequestHandler<UpdateFlightCommand, UpdateFlightCommandResponse>

    {
        private readonly IFlightRepository _flightRepository;
        private readonly DefaultContext _context;

        public FlightCommandHandler(IFlightRepository flightRepository, DefaultContext context)
        {
            _flightRepository = flightRepository;
            _context = context;
        }

        public async Task<CreateFlightCommandResponse> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new Exception($"objeto de commando nulo: {nameof(request)}");
            }

            var flight = new Flight(
                name: request.Name,
                departureTime: request.DepartureTime,
                origin: request.Origin,
                destination: request.Destination);

            await _flightRepository
                .Create(flight)
                .ConfigureAwait(false);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);


            return await Task.FromResult(new CreateFlightCommandResponse(flight.Id))
                .ConfigureAwait(false);
        }

        public async Task<DeleteFlightCommandResponse> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            {
                if (request == null)
                {
                    throw new Exception($"objeto de commando nulo: {nameof(request)}");
                }


                await _flightRepository
                    .Delete(request.Id)
                    .ConfigureAwait(false);

                await _context
                    .SaveChangesAsync()
                    .ConfigureAwait(false);


                return await Task.FromResult(new DeleteFlightCommandResponse())
                    .ConfigureAwait(false);
            }
        }

        public async Task<UpdateFlightCommandResponse> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new Exception($"objeto de commando nulo: {nameof(request)}");
            }

            var flight = await _flightRepository
                .GetById(request.Id)
                .ConfigureAwait(false);

            if (flight == null)
            {
                throw new Exception($"O vôo: {request.Name} não existe");
            }

            flight.ChangeInfos(
                name: request.Name,
                departureTime: request.DepartureTime,
                origin: request.Origin,
                destination: request.Destination);

            await _flightRepository
                .Update(request.Id, flight)
                .ConfigureAwait(false);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);


            return await Task.FromResult(new UpdateFlightCommandResponse())
                .ConfigureAwait(false);
        }


    }
}
