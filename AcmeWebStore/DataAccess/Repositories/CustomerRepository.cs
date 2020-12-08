using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AcmedbContext dbContext;

        private readonly ILogger<CustomerRepository> logger;

        public CustomerRepository(AcmedbContext context, ILogger<CustomerRepository> _logger)
        {
            dbContext = context;
            logger = _logger;
        }

        /// <summary> Method to add a new customer to the DB </summary>
        /// <params> Takes in a Library customer object</params>
        public void AddCustomer(Library.Model.Customer customer)
        {

            dbContext.Customers.Add(Mapper.MapCustomerToDA(customer));

        }
        /// <summary> Method to return a list of current Customers</summary>

        public List<DataAccess.Customer> getCustomers()
        {
            var customerList = dbContext.Customers.ToList();
            logger.LogInformation("Retrieving all customer");

            return customerList.Select(x => new DataAccess.Customer()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FavoriteStore = x.FavoriteStore
            }).ToList();

        }
        /// <summary> Method to find a customer by name </summary>
        /// <params> Takes in a Library customer object of the customer to be searched on</params>
        /// <returns> Returns a Library Model Customer</returns>
 
        public Library.Model.Customer GetCustomerByName(Library.Model.Customer customer)
        {
            var returnCustomer = new DataAccess.Customer();
            
            
                returnCustomer = dbContext.Customers.Where(x => x.FirstName.Contains(customer.firstName) && x.LastName.Contains(customer.lastName)).FirstOrDefault();
            if(returnCustomer == null)
            {
                var failedCustomer = new Library.Model.Customer();
                failedCustomer.firstName = "0";
                failedCustomer.lastName = "0";
                return failedCustomer;
            }
            else
            {
                return Mapper.MapDACustomerToLibWithOrders(returnCustomer);
            }
            
           
        }
        /// <summary> Method to find a customer by name including orders</summary>
        /// <params> Takes in a Library customer object of the customer to be searched on</params>
        /// <returns> Returns a Library Model Customer with orders</returns>
        public Library.Model.Customer GetCustomerByNameWithOrders(Library.Model.Customer customer)
        {
            var returnCustomer = new DataAccess.Customer();


            returnCustomer = dbContext.Customers.Include(x=> x.Orders).ThenInclude(x => x.OrderDetails).Where(x => x.FirstName.Contains(customer.firstName) && x.LastName.Contains(customer.lastName)).FirstOrDefault();
            if (returnCustomer == null)
            {
                var failedCustomer = new Library.Model.Customer();
                failedCustomer.firstName = "0";
                failedCustomer.lastName = "0";
                return failedCustomer;
            }
            else
            {
                return Mapper.MapDACustomerToLibWithOrders(returnCustomer);
            }

        }
        /// <summary> Method to find a customer by Id </summary>
        /// <params> Takes in int of the ID to search on</params>
        /// <returns> Returns a Library Model Customer</returns>
        public Library.Model.Customer GetCustomerById(int id)
        {
            return Mapper.MapDACustomerToLib(dbContext.Customers.Where(c => c.Id == id).FirstOrDefault());
        }

        public void Save()
        {
            //_logger.LogInformation("Saving changes to the database");
            dbContext.SaveChanges();
        }
      
    }
}
