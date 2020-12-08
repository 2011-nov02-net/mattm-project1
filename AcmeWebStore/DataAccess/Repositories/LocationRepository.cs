using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Model;

namespace DataAccess.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AcmedbContext dbContext;
        public LocationRepository(AcmedbContext context)
        {
            dbContext = context;
        }

        public int CountLocations()
        {
            var count = dbContext.Locations.Count();
            return count;
        }
        /// <summary> Method to find all locations </summary>
        /// <params> none</params>
        /// <returns> none</returns>
        public IEnumerable<Library.Model.Location> GetLocations()
        {
            var locationList = dbContext.Locations.ToList();
                return locationList.Select(x => new Library.Model.Location()
                {
                    Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    State = x.State,
                    Country = x.Country
                });          
        }
        /// <summary> Method to find a location by Id </summary>
        /// <params> Int of location id to search</params>
        /// <returns> Returns a Library Model Location</returns>
        public Library.Model.Location GetLocationById(int id)
        {
            Library.Model.Location location = new Library.Model.Location();
            DataAccess.Location DaLocation = new DataAccess.Location();
            DaLocation = dbContext.Locations.FirstOrDefault(l => l.Id == id);
            location = DataAccess.Mapper.MapLocation(DaLocation);
            return location;

        }
        /// <summary> Method to find a location by id with inventory </summary>
        /// <params> Int of location id to search</params>
        /// <returns> Returns a Library Model Location with inventory</returns>
        public Library.Model.Location GetLocationByIdWithInventory(int id)
        {
            Library.Model.Location location = new Library.Model.Location();
            DataAccess.Location DaLocation = new DataAccess.Location();
            DaLocation = dbContext.Locations.Include(l => l.LocationStocks).ThenInclude(l => l.Product).Where(l => l.Id == id).FirstOrDefault();
            location = DataAccess.Mapper.MapLocationWithInventory(DaLocation);
            return location;
        }
        /// <summary> Method to find a location by id with orders </summary>
        /// <params> Int of location id to search</params>
        /// <returns> Returns a Library Model Location with orders</returns>
        public Library.Model.Location GetLocationByIdWithOrders(int id)
        {
            Library.Model.Location returnLocation = new Library.Model.Location();
            var DaLocation = dbContext.Locations.Include(l => l.OrderDetails).ThenInclude(l => l.Order).Where(l => l.Id == id).FirstOrDefault();
            returnLocation = Mapper.MapLocationWithOrders(DaLocation);
            foreach(int orderId in returnLocation.OrderIds)
            {
                var order = dbContext.Orders.Include(o => o.OrderDetails).Where(o => o.Id == orderId).FirstOrDefault();
                returnLocation.Orders.Add(Mapper.MapDaOrderToLib(order));
            }
            return returnLocation;
        }

     
        public void Save()
        {
            //_logger.LogInformation("Saving changes to the database");
           dbContext.SaveChanges();
        }
       
    }
}
