using Libreria_Facturacion.Data.Interfaces;
using Libreria_Facturacion.Data.Utils;
using Libreria_Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_Facturacion.Data.Implementations
{
    public class ProductRepository : IProductRepository
    {
        public bool DeleteById(int id)
        {
            var param = new List<SpParameter>()
            {
                new SpParameter()
                {
                    Name = "IdArticulo",
                    Value = id
                }
            };

            int rows = DataHelper.GetInstance().ExecuteSPNonQuery("DeleteArticulo", param);
            return rows > 0;
        }

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();

            var dt = DataHelper.GetInstance().ExecuteSPQuery("GetAllArticulo");

            foreach (DataRow row in dt.Rows)
            {
                Product p = new Product();
                p.Id = Convert.ToInt32(row["id_articulo"]);
                p.Name = (string)row["nombre"];
                p.UnitPrice = (decimal)row["pre_unitario"];
                list.Add(p);
            }
            return list;
        }

        public Product GetById(int id)
        {

            List<SpParameter> param = new List<SpParameter>()
            {
                new SpParameter()
                {
                    Name = "@idarticulo",
                    Value = id
                }
            };


            var dt = DataHelper.GetInstance().ExecuteSPQuery("GetArticuloById", param);


            if (dt != null && dt.Rows.Count > 0)
            {
                Product p = new Product()
                {
                    Id = (int)dt.Rows[0]["id_articulo"],
                    Name = (string)dt.Rows[0]["nombre"],
                    UnitPrice = (decimal)dt.Rows[0]["pre_unitario"]
                };
                return p;
            }

            return null;
        }

        public bool Save(Product product)
        {
            int rowsAffected = 0;
            var param = new List<SpParameter>
            {
                new SpParameter { Name = "@Nombre", Value = product.Name },
                new SpParameter { Name = "@PrecioUnitario", Value = product.UnitPrice },
                new SpParameter { Name = "@Activo", Value = product.Status ? 1 : 0 }
            };

            if (product.Id == 0)
            {
                rowsAffected = DataHelper.GetInstance().ExecuteSPNonQuery("InsertArticulo", param);
            }
            else
            {
                param.Add(new SpParameter { Name = "@IdArticulo", Value = product.Id });
                rowsAffected = DataHelper.GetInstance().ExecuteSPNonQuery("UpdateArticulo", param);
            }
            return rowsAffected > 0;
        }
    }
}
