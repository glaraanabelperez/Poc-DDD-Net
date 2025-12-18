using Aplication.Models;
using Aplication.Validations;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Aplication.Handlers.Command
{
    [GarantiaRequiereProveedor]
    public class ProductCreateCommand : IRequest<Response>
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Numero de serie es obligatorio")]
        public string Serie { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El depósito es obligatorio.")]
        [Range(1, long.MaxValue, ErrorMessage = "El depósito debe ser un número válido.")]
        public long Deposito { get; set; }

        public long ProveedorId { get; set; } = 0;

        [Required]
        public bool Garantia { get; set; }

    }

}
