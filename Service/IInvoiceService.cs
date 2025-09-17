using Libreria_Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_Facturacion.Service
{
    public interface IInvoiceService
    {
        List<Invoice> GetInvoices();
        Invoice GetInvoice(int id);
        bool SaveInvoice(Invoice invoice);
        bool DeleteInvoice(int id);
    }
}
