using Ejercicio4Modulo3.Repository;
using Microsoft.EntityFrameworkCore;
using Ejercicio4Modulo3.Domain.Entities;

namespace Ejercicio4Modulo3.Services.Interfaces
{
    public interface IProveedorService
    {

        public Task<List<Proveedor>> GetProveedoresAsync();

        public Task<Proveedor> AddProveedorAsync(Proveedor proveedor);

    }
}
