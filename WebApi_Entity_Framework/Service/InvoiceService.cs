using WebApi_Entity_Framework.Data.Models;
using WebApi_Entity_Framework.Data.RepositoryEF;
using WebApi_Entity_Framework.Dto;

namespace WebApi_Entity_Framework.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repo;

        public InvoiceService(IInvoiceRepository repo)
        {
            _repo = repo;
        }


        public async Task<bool> CreateAsync(Factura factura)
        {
            await _repo.CreateAsync(factura);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<List<Factura>> GetAllAsync()
        {
            var factura = (await _repo.GetAllAsync())
                          .Where(x => x.Activo)
                          .ToList();
            return factura;
        }

        public async Task<Factura?> GetByIdAsync(int id)
        {
            var factura = await _repo.GetByIdAsync(id);
            if (factura != null)
            {
                return factura;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(int id, Factura factura)
        {
            var existingInvoice = await _repo.GetByIdAsync(id);
            if (existingInvoice == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(factura.Cliente))
            {
                return false;
            }

            await _repo.UpdateAsync(factura);
            return true;
        }
    }
}
