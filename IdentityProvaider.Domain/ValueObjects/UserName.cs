using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record UserName
    {
        public string value { get; init; }

        internal UserName(string value)
        {
            this.value = value;
        }

        public static UserName create(string value)
        {
            validate(value);
            return new UserName(value);
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
                throw new ArgumentNullException("El valor del nombre no puede ser mayor a 25 caracteres");
            }
        }
    }
}
