using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ejercicio4Modulo3.Services.Interfaces;
using Ejercicio4Modulo3.Domain.Entities;
using Ejercicio4Modulo3.Domain.DTOs;
using System.Globalization;
using System.Threading.Tasks;
using Ejercicio4Modulo3.Repository;

namespace Ejercicio4Modulo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {

        //- Correr el script para tener los datos de la BD
        //- Se debe crear con la arquitectura en capas( el controller y services) para poder unicamente dar de
        // alta un proveedor y recuperar todos los proveedores
        //- Todas las peticiones tienen que ser async
        //- Crear un middleware personalizado, que grabe en base de datos en la tabla logs cada interaccion que exista con los endpoints expuestos:
        // Si hay un error en la peticion se debe grabar success = false  sino success = true
        // para completar los datos de path y verbo http deben usar los metodos/propiedades
        // de la variable "context" que se disponibiliza al implementar IMiddleware


        // Inyección Dependencias
        private IProveedorService _proveedorService;
  
        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet("GetProveedores")]
        public async Task<IActionResult> GetProveedoresAsync()
        {
            var Proveedores = await _proveedorService.GetProveedoresAsync();
            return Ok(Proveedores);
        }

        [HttpPost("AddProveedor")]
        public async Task<IActionResult> AddProveedorAsync([FromBody] DTONewProveedor proveedor)
        {

            Proveedor NewProveedor = new Proveedor()
            {
                CodProveedor = proveedor.CodProveedor,
                RazonSocial = proveedor.RazonSocial
            };
            var Proveedor = await _proveedorService.AddProveedorAsync(NewProveedor);
            return Ok(Proveedor);
        }
    }
}
