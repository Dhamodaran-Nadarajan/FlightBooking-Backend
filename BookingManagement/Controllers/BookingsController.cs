using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingManagement.Models;
using BookingManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingsController(IBookingRepository repos)
        {
            this._bookingRepository = repos;
        }



        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                IEnumerable<Booking> bookings = _bookingRepository.GetBookings();
                if (bookings != null && bookings.Count() > 0)
                {
                    return Ok(bookings);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, GenerateResponseData(false, null, "No bookings found !!!"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponseData(false, ex.Message, "Internal Server Error"));
            }
        }

        [HttpGet("{PNR}")]
        public ActionResult<Booking> Get(int PNR)
        {
            try
            {
                Booking booking = _bookingRepository.GetBookingByPNR(PNR);
                if (booking != null)
                {
                    return Ok(booking);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, GenerateResponseData(false, null, "Invalid PNR !!!"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponseData(false, ex.Message, "Internal Server Error"));
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Booking> Post([FromBody] Booking obj)
        {
            try
            {
                int passengersCount = obj.NoOfPassengers;
                int passengersDataCount = obj.Passengers.Count();
                if(passengersCount != passengersDataCount)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, GenerateResponseData(false, null, "Passengers count and passengers data doesn't match !!"));
                }

                Random r = new Random();
                obj.PNR = r.Next();
                Booking booking = _bookingRepository.AddBooking(obj);
                if (booking != null)
                {
                    return Ok(booking);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, GenerateResponseData(false, null, "Bad Request"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponseData(false, ex.Message, "Internal Server Error"));
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Booking obj)
        {
            if(true)
            {
            }
        }

        // DELETE api/values/5
        [HttpDelete("{PNR}")]
        public ActionResult Delete(int PNR)
        {
            try
            {
                Booking booking = _bookingRepository.GetBookingByPNR(PNR);
                if (booking != null)
                {
                    if(_bookingRepository.DeleteBookingByPNR(PNR))
                    {
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "Delete Unsuccessfull..!!");
                    }

                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Invalid PNR !!!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("passengers/{id}")]
        public ActionResult<IEnumerable<string>> GetPassengers(int id) {
            try
            {
                IEnumerable<Passenger> passengers = _bookingRepository.GetPassengers(id);
                if (passengers != null && passengers.Count() > 0)
                {
                    return Ok(passengers);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No passengers found !!!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponseData(false, ex.Message, "Internal Server Error"));
            }
        }

        private object GenerateResponseData(bool isSuccess, object data, string message)
        {
            return new { isSuccess, data, message };
        }
    }
}
