using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;
using TesteGol.Api.Requests;
using TesteGol.Api.Responses;
using TesteGol.Commands.Flights;
using TesteGol.Model.Repositories;

namespace TesteGol.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("flights")]
    public class FlightsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFlightRepository _flightRepository;

        public FlightsController(IMediator mediator, IFlightRepository flightRepository)
        {
            _mediator = mediator;
            _flightRepository = flightRepository;
        }

        #region GET
        [HttpGet]
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await _flightRepository
                .GetAll()
                .ConfigureAwait(false);



            return Ok((from flight in flights
                       select new FlightResponse
                       {
                           Name = flight.Name,
                           DepartureTime = flight.DepartureTime,
                           Destination = flight.Destination,
                           Origin = flight.Origin,
                           Id = flight.Id
                       }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFlight(Guid id)
        {
            var flight = await _flightRepository
                .GetById(id)
                .ConfigureAwait(false);



            return Ok(new FlightResponse
            {
                Name = flight.Name,
                DepartureTime = flight.DepartureTime,
                Destination = flight.Destination,
                Origin = flight.Origin,
                Id = flight.Id
            });
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> CreateFlight([FromBody] FlightRequest request)
        {
            var command = new CreateFlightCommand(
                name: request.Name,
                departureTime: request.DepartureTime,
                origin: request.Origin,
                destination: request.Destination);

            var response = await _mediator
                .Send(command)
                .ConfigureAwait(false);


            return CreatedAtAction("CreateFlight", response);
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFlight(Guid id, [FromBody] FlightRequest request)
        {
            var command = new UpdateFlightCommand(
                id: id,
                name: request.Name,
                departureTime: request.DepartureTime,
                origin: request.Origin,
                destination: request.Destination);

            await _mediator
               .Send(command)
               .ConfigureAwait(false);


            return Ok();
        }
        #endregion

        #region DELETE
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFlight(Guid id)
        {
            var command = new DeleteFlightCommand(id: id);

            await _mediator
               .Send(command)
               .ConfigureAwait(false);


            return Ok();
        }
        #endregion

        [HttpOptions]
        public IActionResult Options()
        {
            HttpContext.Response.Headers.Add("Allow", "*");
            return Ok();
        }
    }
}
