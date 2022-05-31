using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Inventory
    {
        [Required]
        public int Id { get; set; }

        // Primary Key column of Airline Management - Airline Model
        [Required]
        public int AirlineId { get; set; }

        [Required]
        [MaxLength(50)]
        public string From { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string To { get; set; }

        [Required]
        public DateTime Departure { get; set; }

        [Required]
        public DateTime Arrival { get; set; }

        [Required]
        public int BusinessSeats { get; set; }

        [Required]
        public int NonBusinessSeats { get; set; }

        [Required]
        public float TicketPrice { get; set; }
        
        public string ScheduledDays { get; set; }
        public string Meal { get; set; }
    }
}
