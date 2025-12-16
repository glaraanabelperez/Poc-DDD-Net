using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Validations
{

    public class GarantiaRequiereProveedorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var instance = validationContext.ObjectInstance;
            var tipo = validationContext.ObjectType;

            var garantiaProp = tipo.GetProperty("Garantia");
            var proveedorIdProp = tipo.GetProperty("ProveedorId");

            bool garantia = (bool)(garantiaProp?.GetValue(instance)?? false);
            long proveedorId = (long)proveedorIdProp?.GetValue(instance);

            if (garantia && proveedorId == 0)
            {
                return new ValidationResult(
                    "Si el producto tiene garantía, ProveedorId es obligatorio.",
                    new[] { "ProveedorId" }  
                );
            }

            return ValidationResult.Success;
        }
    }
}
