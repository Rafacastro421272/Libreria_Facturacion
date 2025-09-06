using Libreria_Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_Facturacion.Data.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        Product GetById(int id);

        bool Save(Product product);

        bool DeleteById(int id);
    }
}
