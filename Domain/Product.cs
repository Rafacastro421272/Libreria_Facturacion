using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_Facturacion.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Status { get; set; } = true;

        public override string ToString()
        {
            return $@"Product Id: {Id} - Product Name: {Name}   - Unit Price: $ {UnitPrice}";
        }
    }
}
