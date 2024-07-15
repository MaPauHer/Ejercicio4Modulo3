using System.ComponentModel.DataAnnotations;

namespace Ejercicio4Modulo3.Domain.DTOs
{
    public class DTONewProveedor
    {
        [Required(ErrorMessage = "El codigo del nuevo proveedor es requerido.")]
        public string CodProveedor { get; set; }

        [Required(ErrorMessage = "La razón social del nuevo proveedor es requerido.")]
        public string RazonSocial { get; set; }
    }
}
