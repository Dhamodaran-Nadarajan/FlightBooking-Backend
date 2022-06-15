using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int ScheduleId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
        
        public int NoOfPassengers { get; set; }

        public List<Passenger> Passengers{ get; set; }

        public string MealPreferrence { get; set; }

        public string SeatNumbers { get; set; }

        public int PNR { get; set; }
    }

    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int Age { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [ForeignKey("Booking")]
        public int BookingId { get; set; }
    }
}
