using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;
using InventoryManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;
        public SearchController(IInventoryRepository repository)
        {
            this._inventoryRepository = repository;
        }


        #region Endpoints
        [HttpGet]
        public ActionResult<IEnumerable<Inventory>> Get([FromQuery]string from, [FromQuery] string to)
        {
            try
            {
                IEnumerable<Inventory> inventories = _inventoryRepository.GetAirlines(from, to).ToList();
                if(inventories != null && inventories.Count() > 0)
                {                    
                    return Ok(GeneratreResponseData(true, inventories, ""));
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, GeneratreResponseData(false, null, $"No Airlines available for this route !!"));
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GeneratreResponseData(false, ex.Message, "Internal Server Error"));
            }
        }

        [HttpGet("{airlineId}")]
        public ActionResult<IEnumerable<Inventory>> Get(int airlineId)
        {
            try
            {
                IEnumerable<Inventory> inventories = _inventoryRepository.GetAirlines(airlineId).ToList();
                if(inventories != null && inventories.Count() > 0)
                {
                    return Ok(GeneratreResponseData(true, inventories, ""));
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, GeneratreResponseData(false, null, $"Airline: {airlineId} not found !!"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GeneratreResponseData(false, ex.Message, "Internal Server Error"));
            }
        }


        [HttpPost]
        public ActionResult<Inventory> Post([FromBody] Inventory obj)
        {
            try
            {
                Inventory inventory = _inventoryRepository.ScheduleAirline(obj);
                if(inventory !=  null)
                {
                    return Ok(GeneratreResponseData(true, inventory, ""));
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, GeneratreResponseData(false, null, "Bad Request"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GeneratreResponseData(false, ex.Message, "Internal Server Error"));
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public ActionResult<Inventory> Delete(int id)
        {
            try
            {
                Inventory inventory = _inventoryRepository.DeleteInventory(id);
                if(inventory != null)
                {
                    return Ok(GeneratreResponseData(true, null, "Delete Sucess"));
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, GeneratreResponseData(false, null, $"No such inventory not found !!"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GeneratreResponseData(false, ex.Message, "Internal Server Error"));
            }
        }
        #endregion

        #region

        private object GeneratreResponseData(bool isSuccess, object data, string message)
        {
            return new { isSuccess, data, message};
        }

        #endregion
    }
}
