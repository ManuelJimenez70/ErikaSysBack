using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record ProductName
    {
        public string value { get; init; }

        internal ProductName(string value)
        {
            this.value = value;
        }

        public static ProductName create(string value)
        {
            validate(value);
            return new ProductName(value);
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
            if (value.Length > 50)
            {
                throw new ArgumentNullException("El valor no puede ser mayor a 15 caracteres");
            }
            //agregar que el valor no puede ser mayor  a 50 caracteres
        }
    }
}
