using System;
using System.Collections.Generic;
using Flights.Core.Models;

namespace Flights.Core.Utility
{
    public static class Mock
    {
        public static List<Flight> GetMockData()
        {
            return new List<Flight>()
            {
                new Flight() 
                { 
                    Identifier = 1, 
                    Operator = "Ryanair", 
                    Date = DateTime.Parse("12-03-2020 15:50"), 
                    Origin = "EPWR", 
                    Destination = "EPGD" 
                },
                new Flight() 
                { 
                    Identifier = 2, 
                    Operator = "Wizzair",
                    Date = DateTime.Parse("03-03-2020 21:45"), 
                    Origin = "LIBD", 
                    Destination = "EPWR" 
                },
                new Flight() 
                { 
                    Identifier = 3, 
                    Operator = "EasyJet", 
                    Date = DateTime.Parse("08-03-2020 10:40"), 
                    Origin = "EPKK", 
                    Destination = "LSGG" 
                }
            };
        }
    }
}