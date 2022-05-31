using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDBContext _context;
        //private readonly AirlineManagement.Repository.AppDBContext _airlineDbContext;
        
        #region
        public InventoryRepository(AppDBContext context)
        {
            this._context = context;
        }
        #endregion


        #region  Public Methods

        public IEnumerable<Inventory> GetAirlines(int airlineId)
        {
            //AirlineRepository repos = new AirlineRepository(_airlineDbContext);
            //Airline airline = repos.GetAirlineById(airlineId);
            //IEnumerable<Inventory> inventories =  _context.Inventories.Where(x => x.AirlineId == airlineId);
            //foreach(Inventory inv in inventories)
            //{
            //    inv.
            //}

            return _context.Inventories.Where(x => x.AirlineId == airlineId);

        }


        public IEnumerable<Inventory> GetAirlines(string origin, string destination)
        {
            IEnumerable<Inventory> inventories = _context.Inventories.Where( x => x.From.Equals(origin) && x.To.Equals(destination));
            return inventories;
        }        

        public Inventory ScheduleAirline(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            _context.SaveChanges();
            return inventory;
        }

        public Inventory DeleteInventory(int inventoryId)
        {
            Inventory inventory = _context.Inventories.FirstOrDefault( x => x.Id == inventoryId);
            if(inventory != null)
            {
                _context.Inventories.Remove(inventory);
                _context.SaveChanges();
            }
            return inventory;
        }
        #endregion
    }
}
