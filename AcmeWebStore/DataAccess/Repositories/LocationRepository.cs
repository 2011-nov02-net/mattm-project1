using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

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
    }
}
