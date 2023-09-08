using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record UserLastName
    {
        public string value { get; set; }
        internal UserLastName(string value)
        {
            this.value = value;
        }
        public static UserLastName create(string value)
        {
            validate(value);
            return new UserLastName(value);
        }
        private static void validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("El Apellido no puede ser nulo");
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("El valor no puede ser nulo");
            }
            if (value.Length > 25)
            {
                throw new ArgumentNullException("El valor del Apellido no puede ser mayor a 25 caracteres");
            }
        }
    }
}
