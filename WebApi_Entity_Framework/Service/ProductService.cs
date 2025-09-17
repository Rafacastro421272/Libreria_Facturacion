using WebApi_Entity_Framework.Data.Models;
using WebApi_Entity_Framework.Data.RepositoryEF;
using WebApi_Entity_Framework.Dto;

namespace WebApi_Entity_Framework.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }


        public async Task<bool> CreateAsync(Articulo articulo)
        {
            await _repository.CreateAsync(articulo);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<List<Articulo>> GetAllAsync()
        {
            var producto = (await _repository.GetAllAsync())
                          .Where(x => x.Activo)
                          .ToList();
            return producto;
        }

        public async Task<Articulo?> GetByIdAsync(int id)
        {
            var producto = await _repository.GetByIdAsync(id);

            if (producto != null)
            {
                return producto;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(int id, Articulo articulo)
        {
            var existingProduct = await _repository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(articulo.Nombre))
            {
                return false;
            }

            await _repository.UpdateAsync(articulo);
            return true;
        }
    }
}
