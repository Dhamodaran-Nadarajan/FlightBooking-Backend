using BookingManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Repository
{
    public class BookingDBContext : DbContext
    {
        public BookingDBContext(DbContextOptions<BookingDBContext> options)
            : base(options)
        {
            
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
    }
}
