using BookingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Repository
{
    public interface IBookingRepository
    {
        Booking AddBooking(Booking obj);
        IEnumerable<Booking> GetBookings();
        Booking GetBookingByPNR(int PNR);
    }
}
