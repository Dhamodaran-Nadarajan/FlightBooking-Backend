using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AirlineManagement.Models;
using AirlineManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {
        private readonly IAirlineRepository _airlineRepository;
        public AirlinesController(IAirlineRepository repos)
        {
            this._airlineRepository = repos;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult<IEnumerable<Airline>> GetAirlines()
        {
            try
            {
                IEnumerable<Airline> airlines = _airlineRepository.GetAirlines();
                if (airlines != null)
                {
                    return Ok(airlines.ToList());
                }
                else
                {
                    return NotFound("No Airlines available in the database.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Airline> GetAirlineById(int id)
        {
            try
            {
                Airline airline = _airlineRepository.GetAirlineById(id);
                if (airline != null)
                {
                    return Ok(airline);
                }
                else
                {
                    string msg = $"Airline {id} not found.";
                    return NotFound(GenerateResponseData(false, null, msg));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddAirline([FromBody] Airline obj)
        {
            try
            {
                Airline airline = _airlineRepository.AddAirline(obj);
                return Created("",airline);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Put(int id)
        {
            try
            {
                Airline airline = _airlineRepository.UpdateAirlineStatus(id);
                if (airline != null)
                {
                    return Ok(airline);
                }
                else
                {
                    return NotFound($"Airline not found. Unable to Update Airline ID: {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteAirline(int id)
        {
            try
            {
                Airline airline = _airlineRepository.DeleteAirline(id);
                if (airline != null)
                {
                    return Ok(airline);
                }
                else
                {
                    return NotFound($"Airline not found. Unable to delete Airline ID: {id}");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }            
        }

        private object GenerateResponseData(bool isSuccess, Airline airline, string msg)
        {
            var obj = new { isSuccess = isSuccess, data = airline, message = msg };
            return obj;
        }
    }
}
