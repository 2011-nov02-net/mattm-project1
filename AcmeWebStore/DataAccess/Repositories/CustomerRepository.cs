using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CustomerRepository
    {
        private readonly AcmedbContext dbContext;

        public CustomerRepository(AcmedbContext context)
        {
            dbContext = context;
        }

        /// <summary> Method to add a new customer to the DB </summary>
        /// <params> Takes in a customer object</params>
        public void addCustomer(DataAccess.Customer customer)
        {

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

        }
        /// <summary> Method to return a list of current Customers</summary>

        public IEnumerable<DataAccess.Customer> getCustomers()
        {
            var customerList = dbContext.Customers.ToList();

            return customerList.Select(x => new DataAccess.Customer()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FavoriteStore = x.FavoriteStore
            }).ToList();

        }
        /// <summary> Method to find a customer by name </summary>
        /// <params> Takes in a customer object of the customer to be searched on</params>
        public IEnumerable<DataAccess.Customer> getcustomerByName(Customer searchCustomer)
        {
            var matchList = dbContext.Customers.Where(x => x.FirstName.Contains(searchCustomer.FirstName) && x.LastName.Contains(searchCustomer.LastName)).ToList();

            return matchList;
        }


    }
}
