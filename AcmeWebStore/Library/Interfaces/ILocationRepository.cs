using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Interfaces
{
    public interface ILocationRepository
    {
        int CountLocations();

        IEnumerable<Location> GetLocations();

        Location GetLocationByIdWithInventory(int id);

        Location GetLocationById(int id);
        
        
        void Save();
    }
   
}
