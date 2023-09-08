using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record Rol
    {
        public string value { get; init; }

        internal Rol(string value)
        {
            this.value = value;
        }

        public static Rol create(string value)
        {
            validate(value);
            return new Rol(value);
        }

        private static void validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("El valor no puede ser nulo");
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("El valor no puede ser nulo");
            }
            if (value.Length > 15)
            {
                throw new ArgumentNullException("El nombre del rol no puede ser mayor a 15 caracteres");
            }
            //agregar que el valor no puede ser mayor  a 50 caracteres
        }


    }
}
