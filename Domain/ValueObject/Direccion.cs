using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public class Direccion
    {
        public string? telefono { get; set; }

        public Direccion(string telefono_)
        {
            if (string.IsNullOrEmpty(telefono_))
                throw new ArgumentException("El proveedor debe tener telefono");

            telefono = telefono_;
        }

        public string Calle { get; private set; }
        public string Numero { get; private set; }
        public string? Piso { get; private set; }
        public string? Departamento { get; private set; }
        public string Ciudad { get; private set; }
        public string Provincia { get; private set; }
        public string CodigoPostal { get; private set; }
        public string Pais { get; private set; }

        // Regex
        private static readonly Regex CalleRegex = new(@"^[A-Za-z-9 .'-]{3,100}$");
        private static readonly Regex NumeroRegex = new(@"^[0-9A-Za-z]{1,10}$");
        private static readonly Regex DepartamentoRegex = new(@"^[0-9A-Za-z]{0,5}$");
        private static readonly Regex CodigoPostalRegex = new(@"^[A-Za-z0-9]{3,10}$");
        private static readonly Regex CiudadProvinciaRegex = new(@"^[A-Za-z .'-]{2,50}$");
        private static readonly Regex PaisRegex = new(@"^[A-Za-z .'-]{2,50}$");

        public Direccion(
            string calle,
            string numero,
            string? piso,
            string? departamento,
            string ciudad,
            string provincia,
            string codigoPostal,
            string pais)
        {
            
                calle = Normalize(calle)?? "";
                numero = Normalize(numero) ?? "";
                piso = Normalize(piso);
                departamento = Normalize(departamento);
                ciudad = Normalize(ciudad) ?? "";
                provincia = Normalize(provincia) ?? "";
                codigoPostal = Normalize(codigoPostal) ?? "";
                pais = Normalize(pais) ?? "";

            if (string.IsNullOrEmpty(calle) || string.IsNullOrEmpty(numero) || string.IsNullOrEmpty(ciudad)
                || string.IsNullOrEmpty(provincia) || string.IsNullOrEmpty(codigoPostal) || string.IsNullOrEmpty(pais))
            {
                throw new ArgumentException("Los campos obligatorios no pueden estar vacíos");
            }

            // Validaciones
            if (!CalleRegex.IsMatch(calle))
                throw new ArgumentException("La calle es inválida");

            if (!NumeroRegex.IsMatch(numero))
                throw new ArgumentException("El número es inválido");

            if (piso is not null && piso.Length > 5)
                throw new ArgumentException("El piso es demasiado largo");

            if (departamento is not null && !DepartamentoRegex.IsMatch(departamento))
                throw new ArgumentException("Departamento inválido");

            if (!CiudadProvinciaRegex.IsMatch(ciudad))
                throw new ArgumentException("Ciudad inválida");

            if (!CiudadProvinciaRegex.IsMatch(provincia))
                throw new ArgumentException("Provincia inválida");

            if (!CodigoPostalRegex.IsMatch(codigoPostal))
                throw new ArgumentException("Código postal inválido");

            if (!PaisRegex.IsMatch(pais))
                throw new ArgumentException("País inválido");

            Calle = calle;
            Numero = numero;
            Piso = piso;
            Departamento = departamento;
            Ciudad = ciudad;
            Provincia = provincia;
            CodigoPostal = codigoPostal;
            Pais = pais;
        }

        private string? Normalize(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return Regex.Replace(input.Trim(), @"\s+", " ");
        }
    }

}
