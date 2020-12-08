﻿using System;
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

        public Library.Model.Order GetOrderById(int id)
        {
            Library.Model.Order order = new Library.Model.Order();
            order = Mapper.MapDaOrderToLib(dbContext.Orders.Where(x => x.Id == id).Include(o => o.OrderDetails).FirstOrDefault());
            return order;
        }
    }
}
