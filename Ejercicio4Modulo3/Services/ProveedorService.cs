using Ejercicio4Modulo3.Domain.Entities;
using Ejercicio4Modulo3.Repository;
using Ejercicio4Modulo3.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio4Modulo3.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly Ejercicio4Modulo3Context _context;

        public ProveedorService(Ejercicio4Modulo3Context context)
        {
            _context = context;
        }

        public async Task<List<Proveedor>> GetProveedoresAsync()
        {
            var proveedores = await _context.Proveedor.ToListAsync();
            return proveedores;
        }


        public async Task<Proveedor> AddProveedorAsync(Proveedor proveedor)
        {
            await _context.AddAsync(proveedor);
            await _context.SaveChangesAsync();
            return (proveedor);
        }

    }
}
