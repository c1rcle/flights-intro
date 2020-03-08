using Flights.Core.Data;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Api.Controllers
{
    [Route("flights/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private IFlightContext flightData;

        public FlightController(IFlightContext flightData) => this.flightData = flightData;
    }
}