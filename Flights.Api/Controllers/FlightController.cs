using Flights.Core.Data;
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
    }
}