using WebApi_Entity_Framework.Data.Models;
using WebApi_Entity_Framework.Dto;

namespace WebApi_Entity_Framework.Service
{
    public interface IProductService
    {
        Task<List<Articulo>> GetAllAsync();
        Task<Articulo?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Articulo articulo);
        Task<bool> UpdateAsync(int id, Articulo articulo);
        Task<bool> DeleteAsync(int id);
    }
}
