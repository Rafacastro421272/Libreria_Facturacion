using WebApi_Entity_Framework.Data.Models;
using WebApi_Entity_Framework.Dto;

namespace WebApi_Entity_Framework.Service
{
    public interface IInvoiceService
    {
        Task<List<Factura>> GetAllAsync();
        Task<Factura?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Factura factura);
        Task<bool> UpdateAsync(int id, Factura factura);
        Task<bool> DeleteAsync(int id);
    }
}
