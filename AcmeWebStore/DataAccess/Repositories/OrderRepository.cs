using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            Console.WriteLine(newOrder);
            DataAccess.Order DAOrder = Mapper.MapOrderToDAOrder(newOrder);
            dbContext.Orders.Add(DAOrder);
            dbContext.SaveChanges();
            int newId = DAOrder.Id;
            var order = dbContext.Orders.Include(o => o.OrderDetails).Where(o => o.Id == newId).FirstOrDefault();
            foreach(OrderDetail item in DAOrder.OrderDetails)
            {
                order.OrderDetails.Add(item);
            } 
           
        }
        public void Save()
        {
            //_logger.LogInformation("Saving changes to the database");
            dbContext.SaveChanges();
        }

    }
}
