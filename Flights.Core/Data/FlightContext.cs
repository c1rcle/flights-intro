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

        public FlightDto AddFlight(Flight flight)
        {
            flight.Identifier = flightData.DefaultIfEmpty().Max(x => x.Identifier) + 1;
            flightData.Add(flight);
            return Mapper.MapProperties<Flight, FlightDto>(flight, new FlightDto());
        }

        public List<FlightDto> GetAllFlights()
        {
            var mappedObjects = flightData.Select(x => 
                Mapper.MapProperties<Flight, FlightDto>(x, new FlightDto())).ToList();
            return mappedObjects;
        }

        public List<FlightDto> GetFlightsByOperator(string flightOperator)
        {
            var mappedObjects = flightData.FindAll(x => x.Operator == flightOperator).Select(x => 
                Mapper.MapProperties<Flight, FlightDto>(x, new FlightDto())).ToList();
            return mappedObjects;
        }

        public bool RemoveFlight(int identifier)
        {
            var flightToRemove = flightData.Find(x => x.Identifier == identifier);
            if (flightToRemove == null) return false;

            flightData.Remove(flightToRemove);
            return true;
        }

        public bool UpdateFlight(Flight flight)
        {
            var flightToUpdate = flightData.Find(x => x.Identifier == flight.Identifier);
            if (flightToUpdate == null) return false;

            foreach (var property in flight.GetType().GetProperties())
            {
                property.SetValue(flightToUpdate, property.GetValue(flight));
            }
            return true;
        }
    }
}