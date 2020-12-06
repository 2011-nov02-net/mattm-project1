using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class Mapper
    {
        /// <summary>
        /// Maps an Entity Framework restaurant DAO to a business model,
        /// including all reviews if present.
        /// </summary>
        /// <param name="Location">The restaurant DAO.</param>
        /// <returns>The restaurant business model.</returns>
        public static Library.Model.Location MapLocationWithInventory(DataAccess.Location location)
        {
            return new Library.Model.Location
            {
                
                Id = location.Id,
                Address = location.Address,
                City = location.City,
                State = location.State,
                Country = location.Country,                
                inventory = MapInventory(location.LocationStocks)
            };
        }

        public static Dictionary<Library.Model.Product, int> MapInventory(ICollection<DataAccess.LocationStock> items)
        {
            var dictionary = new Dictionary<Library.Model.Product, int>();

            foreach (LocationStock x in items)
            {
                dictionary.Add(MapProduct(x.Product), x.Quantity);
            }
            return dictionary;

        }

        public static Library.Model.Product MapProduct(DataAccess.Product product)
        {
            Library.Model.Product returnProd = new Library.Model.Product();
            returnProd.Name = product.Name;
            returnProd.Price = product.Price;
            returnProd.Id = product.Id;

            return returnProd;
        }
    }
}
