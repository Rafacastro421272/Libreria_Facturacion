using Libreria_Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_Facturacion.Data.Interfaces
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetALL();

        Invoice GetByID(int id);

        bool Save(Invoice invoice);

        bool DeleteById(int id);

    }
}
