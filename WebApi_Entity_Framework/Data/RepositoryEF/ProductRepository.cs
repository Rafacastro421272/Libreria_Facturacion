using Microsoft.EntityFrameworkCore;
using WebApi_Entity_Framework.Data.Models;

namespace WebApi_Entity_Framework.Data.RepositoryEF
{
    public class ProductRepository : IProductRepository
    {
        private FacturacionDbContext _context;

        public ProductRepository(FacturacionDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Articulo articulo)
        {
            await _context.Articulos.AddAsync(articulo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var articulo = await GetByIdAsync(id);
            if (articulo != null)
            {
                articulo.Activo = false;
                _context.Articulos.Update(articulo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Articulo>> GetAllAsync()
        {
            return await _context.Articulos.ToListAsync();
        }

        public async Task<Articulo?> GetByIdAsync(int id)
        {
            return await _context.Articulos.FindAsync(id);
        }

        public async Task UpdateAsync(Articulo articulo)
        {
            if (articulo != null)
            {
                _context.Articulos.Update(articulo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
