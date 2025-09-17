using Microsoft.EntityFrameworkCore;
using WebApi_Entity_Framework.Data.Models;

namespace WebApi_Entity_Framework.Data.RepositoryEF
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private FacturacionDbContext _context;

        public InvoiceRepository(FacturacionDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Factura factura)
        {
            await _context.Facturas.AddAsync(factura);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(int id)
        {
            var invoiceDeleted = await GetByIdAsync(id);
            if (invoiceDeleted != null)
            {
                invoiceDeleted.Activo = false;
                _context.Update(invoiceDeleted);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Factura>> GetAllAsync()
        {
            return await _context.Facturas.ToListAsync();
        }

        public async Task<Factura?> GetByIdAsync(int id)
        {
            return await _context.Facturas.Include(f => f.Detallesfacturas)
                .ThenInclude(p => p.IdArticuloNavigation)
                .FirstOrDefaultAsync(f => f.NroFactura == id);
        }

        public async Task UpdateAsync(Factura factura)
        {
            if (factura != null)
            {
                _context.Facturas.Update(factura);
                await _context.SaveChangesAsync();
            }
        }
    }
}
