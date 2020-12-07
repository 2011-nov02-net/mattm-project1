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
