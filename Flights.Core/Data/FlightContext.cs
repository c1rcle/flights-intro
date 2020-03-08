using System.Collections.Generic;
using System.Linq;
using Flights.Core.Models;
using Flights.Core.Utility;

namespace Flights.Core.Data
{
    public class FlightContext : IFlightContext
    {
        private readonly List<Flight> flightData;

        public FlightContext() => flightData = Mock.GetMockData();

        public void AddFlight(FlightDto flight)
        {
            var newFlight = new Flight() 
            { 
                Operator = flight.Operator,
                Date = flight.Date, 
                Origin = flight.Origin, 
                Destination = flight.Destination 
            };
            newFlight.Identifier = flightData.DefaultIfEmpty().Max(x => x.Identifier) + 1;
            flightData.Add(newFlight);
        }

        public List<Flight> GetAllFlights() => new List<Flight>(flightData);

        public List<Flight> GetFlightsByOperator(string oper)
        {
            return new List<Flight>(flightData.FindAll(x => x.Operator == oper));
        }

        public void RemoveFlight(Flight flight) => flightData.Remove(flight);

        public void UpdateFlight(Flight flight)
        {
            var flightToUpdate = flightData.Find(x => x.Identifier == flight.Identifier);
            foreach (var property in flight.GetType().GetProperties())
            {
                property.SetValue(flightToUpdate, property.GetValue(flight));
            }
        }
  }
}