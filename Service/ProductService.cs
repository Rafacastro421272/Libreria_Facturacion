using Libreria_Facturacion.Data.Implementations;
using Libreria_Facturacion.Data.Interfaces;
using Libreria_Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_Facturacion.Service
{
    public class ProductService
    {
        private IProductRepository _repository;
        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public List<Product> GetProducts()
        {
            return _repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return _repository.GetById(id);
        }

        public bool Save(Product product)
        {
            return _repository.Save(product);
        }

        public bool Delete(int id)
        {
            return _repository.DeleteById(id);
        }
    }
}
