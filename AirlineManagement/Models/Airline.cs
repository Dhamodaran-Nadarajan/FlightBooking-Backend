using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagement.Models
{
    public class Airline
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public int ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public bool IsActive { get; set; }
        public string ContactLogo { get; set; }
    }
}
