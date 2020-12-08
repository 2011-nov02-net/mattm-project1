﻿using System;
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

        /// <summary> Method to return a list of current locations </summary>
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

        public Library.Model.Location GetLocationById(int id)
        {
            Library.Model.Location location = new Library.Model.Location();
            DataAccess.Location DaLocation = new DataAccess.Location();
            DaLocation = dbContext.Locations.FirstOrDefault(l => l.Id == id);
            location = DataAccess.Mapper.MapLocation(DaLocation);
            return location;

        }

        public Library.Model.Location GetLocationByIdWithInventory(int id)
        {
            Library.Model.Location location = new Library.Model.Location();
            DataAccess.Location DaLocation = new DataAccess.Location();
            DaLocation = dbContext.Locations.Include(l => l.LocationStocks).ThenInclude(l => l.Product).Where(l => l.Id == id).FirstOrDefault();
            location = DataAccess.Mapper.MapLocationWithInventory(DaLocation);
            return location;
        }

        //IEnumerable<Library.Model.Location> ILocationRepository.getLocations()
        //{
        //    throw new NotImplementedException();
        //}

        public void Save()
        {
            //_logger.LogInformation("Saving changes to the database");
           dbContext.SaveChanges();
        }
       
    }
}
