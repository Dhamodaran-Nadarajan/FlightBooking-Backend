using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Repository
{
    public interface IInventoryRepository
    {
        Inventory DeleteInventory(int inventoryId);
        Inventory ScheduleAirline(Inventory inventory);
        Inventory GetAirlines(int airlineId);
        IEnumerable<Inventory> GetAirlines(string from, string to);
    }
}
