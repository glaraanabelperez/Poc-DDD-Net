using System.Text.RegularExpressions;

namespace DoamDomainin.ValueObject
{
    public record Telefono
    {
        public string telefono  { get; set; }

        public Telefono (string telefono_)
        {
            if (string.IsNullOrEmpty(telefono_))
                throw new ArgumentException("El proveedor debe tener telefono");

            telefono = telefono_;
        }
      
    }

}