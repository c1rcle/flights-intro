using System.Collections.Generic;
using Flights.Core.Models;

namespace Flights.Core.Data
{
    public interface IFlightContext
    {
        FlightDto AddFlight(Flight flight);

        List<FlightDto> GetFlightsByOperator(string flightOperator);

        List<FlightDto> GetAllFlights();

        bool UpdateFlight(Flight flight);

        bool RemoveFlight(int identifier);
    }
}