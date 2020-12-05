using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository
    {
        private readonly AcmedbContext dbContext;
        public ProductRepository(AcmedbContext context)
        {
            dbContext = context;
        }
    }
}
