using Flights.Core.Data;
using Flights.Core.Models;
using Flights.Core.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Api.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightContext flightData;

        public FlightsController(IFlightContext flightData) => this.flightData = flightData;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(flightData.GetAllFlights());
        }

        [HttpGet("{search}")]
        public IActionResult GetByOperator([FromQuery] string flightOperator)
        {
            var data = flightData.GetFlightsByOperator(flightOperator);
            return data != null ? Ok(data) : (IActionResult) BadRequest();
        }

        [HttpPost("{add}")]
        public IActionResult Add([FromBody] FlightDto flight)
        {
            var model = Mapper.MapProperties<FlightDto, Flight>(flight, new Flight());
            if (!TryValidateModel(model, nameof(model))) return BadRequest();
            return Ok(flightData.AddFlight(model));
        }

        [HttpPut("{update}")]
        public IActionResult Update([FromBody] Flight flight)
        {
            if (!flightData.UpdateFlight(flight)) return BadRequest();
            return Ok();
        }

        [HttpDelete("{delete}")]
        public IActionResult Delete([FromQuery] int identifier)
        {
            if (!flightData.RemoveFlight(identifier)) return BadRequest();
            return Ok();
        }
    }
}