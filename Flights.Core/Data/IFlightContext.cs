using System.Collections.Generic;
using Flights.Core.Models;

namespace Flights.Core.Data
{
    public interface IFlightContext
    {
        void AddFlight(FlightDto flight);

        List<FlightDto> GetFlightsByOperator(string flightOperator);

        List<FlightDto> GetAllFlights();

        void UpdateFlight(Flight flight);

        void RemoveFlight(Flight flight);
    }
}