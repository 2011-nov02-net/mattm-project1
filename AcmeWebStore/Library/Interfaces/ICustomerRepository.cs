using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Library.Model.Customer customer);

        Library.Model.Customer GetCustomerByName(Library.Model.Customer customer);

        Library.Model.Customer GetCustomerById(int id);
        void Save();
    }
}
