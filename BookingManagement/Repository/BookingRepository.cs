using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingManagement.Models;

namespace BookingManagement.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDBContext _context;

        public BookingRepository(BookingDBContext context)
        {
            this._context = context;
        }

        public Booking AddBooking(Booking obj)
        {
            _context.Bookings.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public IEnumerable<Booking> GetBookings()
        {
           return _context.Bookings.ToList();
        }

        public Booking GetBookingByPNR(int PNR)
        {
            return _context.Bookings.FirstOrDefault(x => x.PNR == PNR);
        }
    }
}
