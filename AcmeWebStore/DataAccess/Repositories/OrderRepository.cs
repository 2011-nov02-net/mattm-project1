using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AcmedbContext dbContext;
        private readonly ILogger<OrderRepository> logger;
        public OrderRepository(AcmedbContext context, ILogger<OrderRepository> _logger)
        {
            dbContext = context;
            logger = _logger;
        }

        /// <summary> Method to get all orders </summary>
        /// <params> none</params>
        /// <returns> Returns a list of Library Model Orders</returns>
        public List<Library.Model.Order> GetOrders()
        {
            List<Library.Model.Order> newList = new List<Library.Model.Order>();
            List<DataAccess.Order> DaList = new List<DataAccess.Order>();
               DaList=  dbContext.Orders.Include(o => o.OrderDetails).ToList();
            foreach(DataAccess.Order order in DaList)
            {
                newList.Add(Mapper.MapDaOrderToLib(order));
            }
            return newList;

        }
        /// <summary> Method to add a new order to DB </summary>
        /// <params> Library.Model.Order</params>
        /// <returns> Returns a a boolean to show success of add</returns>
        public bool AddOrder(Library.Model.Order order)
        {
            foreach(KeyValuePair<Library.Model.Product, int> pair in order.OrderContents)
            {
                bool sufficientStock = pair.Value < dbContext.LocationStocks.Where(p => p.ProductId == pair.Key.Id && p.LocationId == order.LocationId).FirstOrDefault().Quantity;
                if(sufficientStock == false)
                {
                    logger.LogInformation($"Not enough stock for product #{pair.Key.Id}");
                    return false;
                    throw new ArgumentException("Insufficient Stock");
                }
            }
          
            DataAccess.Order DAOrder = Mapper.MapOrderToDAOrder(order);
            dbContext.Orders.Add(DAOrder);
            dbContext.SaveChanges();
            int newId = DAOrder.Id;
            var newOrder = dbContext.Orders.Include(o => o.OrderDetails).Where(o => o.Id == newId).FirstOrDefault();
            foreach(OrderDetail item in DAOrder.OrderDetails)
            {
                newOrder.OrderDetails.Add(item);

                var result = dbContext.LocationStocks.Where(x => x.ProductId == item.ProductId && x.LocationId == item.LocationId).FirstOrDefault();
                result.Quantity = (result.Quantity - item.Quantity);
                dbContext.SaveChanges();
            }
            return true;
        }
        public void Save()
        {
            //_logger.LogInformation("Saving changes to the database");
            dbContext.SaveChanges();
        }

        /// <summary> Method to get order by id </summary>
        /// <params> int id to search on</params>
        /// <returns> Returns a list of Library Model Orders</returns>
        public Library.Model.Order GetOrderById(int id)
        {
            Library.Model.Order order = new Library.Model.Order();
            order = Mapper.MapDaOrderToLib(dbContext.Orders.Where(x => x.Id == id).Include(o => o.OrderDetails).FirstOrDefault());
            return order;
        }
    }
}
