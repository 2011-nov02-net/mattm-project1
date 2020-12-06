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
        public void CreateOrder(Order newOrder, int customerId, int locationId)
        {
            dbContext.Orders.Add(newOrder);
           
        }
    }
}
