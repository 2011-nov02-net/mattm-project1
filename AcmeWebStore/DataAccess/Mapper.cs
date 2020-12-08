using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class Mapper
    {
        /// <summary> Method to map a DA Location w/ inventory to Library location </summary>
        /// <params> DA Location</params>
        /// <returns> Library Model Location</returns>
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
        /// <summary> Method to map a Library Location to DA location </summary>
        /// <params> Library Location</params>
        /// <returns> DA Model Location</returns>
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
        /// <summary> Method to map a DA Location to Library location with order </summary>
        /// <params> DA Location</params>
        /// <returns> Library Model Location</returns>
        public static Library.Model.Location MapLocationWithOrders(DataAccess.Location location)
        {
            Library.Model.Location libLocation = new Library.Model.Location();
            libLocation.Id = location.Id;
            libLocation.Address = location.Address;
            libLocation.City = location.City;
            libLocation.Country = location.Country;
            foreach(OrderDetail detail in location.OrderDetails)
            {
                if (libLocation.OrderIds.Contains(detail.OrderId))
                {
                    continue;
                }
                else
                {
                    libLocation.OrderIds.Add(detail.OrderId);
                }
             
            }
            return libLocation;
        }
        /// <summary> Method to map a locationstock to Library location inventory </summary>
        /// <params> DA location stock</params>
        /// <returns> Dictionary of Library product/int</returns>
        public static Dictionary<Library.Model.Product, int> MapInventory(ICollection<DataAccess.LocationStock> items)
        {
            var dictionary = new Dictionary<Library.Model.Product, int>();

            foreach (LocationStock x in items)
            {
                dictionary.Add(MapProduct(x.Product), x.Quantity);
            }
            return dictionary;

        }
        /// <summary> Method to map a DA product to model product </summary>
        /// <params> DA product</params>
        /// <returns> model product</returns>
        public static Library.Model.Product MapProduct(DataAccess.Product product)
        {
            Library.Model.Product returnProd = new Library.Model.Product();
            returnProd.Name = product.Name;
            returnProd.Price = product.Price;
            returnProd.Id = product.Id;

            return returnProd;
        }
        /// <summary> Method to map a Library customer to DA customer </summary>
        /// <params> Model customer</params>
        /// <returns> DA customer</returns>
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
        /// <summary> Method to map a DA Customer to model customer </summary>
        /// <params>DA customer</params>
        /// <returns> Model customer</returns>
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

        /// <summary> Method to map a DA Customer to model customer with orders </summary>
        /// <params> DA customer</params>
        /// <returns> model customer</returns>
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
        /// <summary> Method to map a DA product to model product </summary>
        /// <params> DA product</params>
        /// <returns> model product</returns>
        public static Library.Model.Product MapDAProductToLib(DataAccess.Product product)
        {
            Library.Model.Product libProduct = new Library.Model.Product();
            libProduct.Id = product.Id;
            libProduct.Name = product.Name;
            libProduct.Price = product.Price;
            return libProduct;

        }
        /// <summary> Method to map a Library product to DA product </summary>
        /// <params> Library product</params>
        /// <returns> DA product</returns>
        public static DataAccess.Product MapLibProductToDA(Library.Model.Product product)
        {
            DataAccess.Product DAProd = new Product();
            DAProd.Id = product.Id;
            DAProd.Name = product.Name;
            DAProd.Price = product.Price;
            return DAProd;
        }
        /// <summary> Method to map a Library order to DA order </summary>
        /// <params> Library order</params>
        /// <returns> DA order</returns>
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
        /// <summary> Method to map a DA Prder to model order </summary>
        /// <params> DA order</params>
        /// <returns> model order</returns>
        public static Library.Model.Order MapDaOrderToLib(DataAccess.Order order)
        {
            Library.Model.Order newOrder = new Library.Model.Order();
            newOrder.CustomerId = order.CustomerId;
            newOrder.Id = order.Id;
            newOrder.Details = MapOrderDetailsToLib(order);
            return newOrder;
       
        }
        /// <summary> Method to map a DA order details to a model order </summary>
        /// <params> DA order w/ details</params>
        /// <returns> library model w/order</returns>
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
