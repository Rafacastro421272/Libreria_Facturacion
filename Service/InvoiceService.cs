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

    public class InvoiceService
    {
        private IInvoiceRepository _repository;
        public InvoiceService()
        {
            _repository = new InvoiceRepository();
        }

        public List<Invoice> GetInvoices()
        {
            return _repository.GetALL();
        }

        public Invoice GetInvoice(int id)
        {
            return _repository.GetByID(id);
        }

        public bool SaveInvoice(Invoice invoice)
        {
            return _repository.Save(invoice);
        }

        public bool DeleteInvoice(int id)
        {
            return _repository.DeleteById(id);
        }
    }
}
