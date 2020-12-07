using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IProductRepository
    {
        Library.Model.Product GetProductById(int id);
        void Save();
    }
}
