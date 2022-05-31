using AirlineManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagement.Repository
{
    public interface IAirlineRepository
    {
        IEnumerable<Airline> GetAirlines();
        Airline AddAirline(Airline airline);
        Airline GetAirlineById(int id);
        Airline DeleteAirline(int id);
        Airline UpdateAirlineStatus(int id, bool isActive);
    }
}
