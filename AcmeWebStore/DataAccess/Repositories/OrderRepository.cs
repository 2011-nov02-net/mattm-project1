using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AcmedbContext dbContext;
        public OrderRepository(AcmedbContext context)
        {
            dbContext = context;
        }
        public void AddOrder(Library.Model.Order newOrder)
        {
            DataAccess.Order DAOrder = Mapper.MapOrderToDAOrder(newOrder);
            //dbContext.Orders.Add(Mapper.MapOrderToDAOrder(newOrder));
           
        }
        public void Save()
        {
            //_logger.LogInformation("Saving changes to the database");
            dbContext.SaveChanges();
        }

    }
}
