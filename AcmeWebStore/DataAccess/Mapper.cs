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
        /// 
        
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

        public static Library.Model.Location MapLocation(DataAccess.Location location)
        {
            return new Library.Model.Location
            {
                Id = location.Id,
                Address = location.Address,
                City = location.City,
                State = location.State,
                Country = location.Country
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

        public static DataAccess.Customer MapCustomerToDA(Library.Model.Customer customer)
        {
            DataAccess.Customer DaCustomer = new DataAccess.Customer();
            DaCustomer.FirstName = customer.firstName;
            DaCustomer.LastName = customer.lastName;
            if(customer.favoriteStore != 0)
            {
                DaCustomer.FavoriteStore = customer.favoriteStore;
            }
            return DaCustomer;
           
        }

        public static Library.Model.Customer MapDACustomerToLib(DataAccess.Customer customer)
        {
            Library.Model.Customer libCustomer = new Library.Model.Customer();
            libCustomer.firstName = customer.FirstName;
            libCustomer.lastName = customer.LastName;
            libCustomer.Id = customer.Id;
            if (customer.FavoriteStore != null)
            {
                libCustomer.favoriteStore = customer.FavoriteStore;
            }
            return libCustomer;


        }


        public static Library.Model.Customer MapDACustomerToLibWithOrders(DataAccess.Customer customer)
        {
            Library.Model.Customer libCustomer = new Library.Model.Customer();
            libCustomer.firstName = customer.FirstName;
            libCustomer.lastName = customer.LastName;
            libCustomer.Id = customer.Id;
            if (customer.FavoriteStore != null)
            {
                libCustomer.favoriteStore = customer.FavoriteStore;
            }
 
            foreach(DataAccess.Order order in customer.Orders)
            {
                Library.Model.Order libOrder = new Library.Model.Order();
                libOrder.Id = order.Id;
                libOrder.CustomerId = order.CustomerId;
                libOrder.Details = MapOrderDetailsToLib(order);
                libCustomer.Orders.Add(libOrder);
            }
            return libCustomer;


        }
        public static Library.Model.Product MapDAProductToLib(DataAccess.Product product)
        {
            Library.Model.Product libProduct = new Library.Model.Product();
            libProduct.Id = product.Id;
            libProduct.Name = product.Name;
            libProduct.Price = product.Price;
            return libProduct;

        }

        public static DataAccess.Product MapLibProductToDA(Library.Model.Product product)
        {
            DataAccess.Product DAProd = new Product();
            DAProd.Id = product.Id;
            DAProd.Name = product.Name;
            DAProd.Price = product.Price;
            return DAProd;
        }

        public static DataAccess.Order MapOrderToDAOrder(Library.Model.Order order)
        {
            DataAccess.Order DAOrder = new DataAccess.Order();
            DAOrder.CustomerId = order.CustomerId;
            foreach(KeyValuePair<Library.Model.Product, int> entry in order.OrderContents){
                OrderDetail item = new OrderDetail();
                item.ProductId = entry.Key.Id;
                item.LocationId = order.LocationId;
                item.Quantity = entry.Value;

                DAOrder.OrderDetails.Add(item);
            }
           
            return DAOrder;
        }

        public static Library.Model.Order MapDaOrderToLib(DataAccess.Order order)
        {
            Library.Model.Order newOrder = new Library.Model.Order();
            newOrder.CustomerId = order.CustomerId;
            newOrder.Id = order.Id;
            newOrder.Details = MapOrderDetailsToLib(order);
            return newOrder;
       
        }

        public static List<Library.Model.OrderDetails> MapOrderDetailsToLib(DataAccess.Order order)
        {
            List<Library.Model.OrderDetails> returnDetails = new List<Library.Model.OrderDetails>();
            foreach(OrderDetail detail in order.OrderDetails)
            {
                Library.Model.OrderDetails newDetail = new Library.Model.OrderDetails();
                newDetail.Id = detail.Id;
                newDetail.LocationId = detail.LocationId;
                newDetail.OrderId = detail.OrderId;
                newDetail.ProductId = detail.ProductId;
                newDetail.Quantity = detail.Quantity;
                returnDetails.Add(newDetail);
            }

            return returnDetails;
        }

 

    }
}
