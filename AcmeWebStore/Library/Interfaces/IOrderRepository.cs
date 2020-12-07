using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Interfaces
{
    public interface IOrderRepository
    {
        // void CreateOrder(Order x);

        void Save();
    }
}
