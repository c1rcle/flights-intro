using System.ComponentModel.DataAnnotations;
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
        public IActionResult GetByOperator([FromQuery][Required] string flightOperator)
        {
            var data = flightData.GetFlightsByOperator(flightOperator);
            return data != null ? Ok(data) : (IActionResult) BadRequest();
        }

        [HttpPost]
        public IActionResult Add([FromBody] FlightDto flight)
        {
            var model = Mapper.MapProperties<FlightDto, Flight>(flight, new Flight());
            if (!TryValidateModel(model, nameof(model))) return BadRequest();
            return Ok(flightData.AddFlight(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Flight flight)
        {
            if (!flightData.UpdateFlight(flight)) return BadRequest();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery][Required] int identifier)
        {
            if (!flightData.RemoveFlight(identifier)) return BadRequest();
            return Ok();
        }
    }
}