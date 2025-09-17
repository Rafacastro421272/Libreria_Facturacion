using Libreria_Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_Facturacion.Service
{
    public interface IProductService
    {
        List<Product> GetProducts();


        Product GetProduct(int id);

        bool Save(Product product);


        bool Delete(int id);
    }
}
