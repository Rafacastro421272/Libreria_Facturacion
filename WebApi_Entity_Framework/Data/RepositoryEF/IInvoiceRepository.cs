using WebApi_Entity_Framework.Data.Models;

namespace WebApi_Entity_Framework.Data.RepositoryEF
{
    public interface IInvoiceRepository
    {
        Task CreateAsync(Factura factura);
        Task<List<Factura>> GetAllAsync();
        Task<Factura?> GetByIdAsync(int id);
        Task UpdateAsync(Factura factura);
        Task DeleteAsync(int id);
    }
}
