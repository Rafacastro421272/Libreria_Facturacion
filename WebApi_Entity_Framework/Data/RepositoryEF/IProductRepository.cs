using WebApi_Entity_Framework.Data.Models;

namespace WebApi_Entity_Framework.Data.RepositoryEF
{
    public interface IProductRepository
    {
        Task CreateAsync(Articulo articulo);
        Task <List<Articulo>> GetAllAsync();
        Task<Articulo?> GetByIdAsync(int id);
        Task UpdateAsync(Articulo articulo);
        Task DeleteAsync(int id);
    }
}
