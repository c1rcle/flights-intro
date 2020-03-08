using System.Collections.Generic;
using Flights.Core.Models;

namespace Flights.Core.Data
{
    public interface IFlightContext
    {
        void AddFlight(Flight flight);

        List<Flight> GetFlightsByOperator(string oper);

        List<Flight> GetAllFlights();

        void UpdateFlight(Flight flight);

        void RemoveFlight(Flight flight);
    }
}