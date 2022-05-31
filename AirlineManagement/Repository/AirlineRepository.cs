using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineManagement.Models;

namespace AirlineManagement.Repository
{
    public class AirlineRepository : IAirlineRepository
    {
        #region Private fields
        private readonly AppDBContext _context;
        #endregion

        #region Constructors
        public AirlineRepository(AppDBContext context)
        {
            this._context = context;
        }
        #endregion

        #region Public Methods

        public IEnumerable<Airline> GetAirlines()
        {
            return _context.Airlines.ToList();
        }

        public Airline GetAirlineById(int id)
        {
            return GetAirline(id);
        }

        public Airline AddAirline(Airline airline)
        {
            _context.Airlines.Add(airline);
            _context.SaveChanges();
            return airline;
        }


        public Airline UpdateAirlineStatus(int id, bool isActive)
        {
            Airline airline = GetAirline(id);
            if (airline != null)
            {
                airline.IsActive = isActive;
                _context.Airlines.Update(airline);
                _context.SaveChanges();
            }
            return airline;
        }

        public Airline DeleteAirline(int id)
        {
            Airline airline = GetAirline(id);
            if (airline != null)
            {
                _context.Airlines.Remove(airline);
                _context.SaveChanges();
            }
            return airline;
        }

        #endregion

        #region Private Methods

        private Airline GetAirline(int id)
        {
            return _context.Airlines.FirstOrDefault(x => x.AirlineId == id);
        }

        # endregion
    }
}
