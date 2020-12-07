﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Model;

namespace DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AcmedbContext dbContext;

        public CustomerRepository(AcmedbContext context)
        {
            dbContext = context;
        }

        /// <summary> Method to add a new customer to the DB </summary>
        /// <params> Takes in a customer object</params>
        public void AddCustomer(Library.Model.Customer customer)
        {

            dbContext.Customers.Add(Mapper.MapCustomerToDA(customer));

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
        public Library.Model.Customer GetCustomerByName(Library.Model.Customer customer)
        {
            var returnCustomer = new Library.Model.Customer();
            return returnCustomer = Mapper.MapDACustomerToLib(dbContext.Customers.Where(x => x.FirstName.Contains(customer.firstName) && x.LastName.Contains(customer.lastName)).FirstOrDefault());
            
        }

        public void Save()
        {
            //_logger.LogInformation("Saving changes to the database");
            dbContext.SaveChanges();
        }
      
    }
}
