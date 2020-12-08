using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Model;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AcmedbContext dbContext;
        public ProductRepository(AcmedbContext context)
        {
            dbContext = context;
        }
        /// <summary> Method to get product by id </summary>
        /// <params> int id to search on</params>
        /// <returns> Returns a Library Model product</returns>
        public Library.Model.Product GetProductById(int id)
        {
            return Mapper.MapDAProductToLib(dbContext.Products.Where(x => x.Id == id).ToList().FirstOrDefault()) ;
        }

        public void Save()
        {
            //_logger.LogInformation("Saving changes to the database");
            dbContext.SaveChanges();
        }

    }
}
