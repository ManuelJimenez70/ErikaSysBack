using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record UserTypeDocument
    {
        public string value { get; init; }

        internal UserTypeDocument(string value)
        {
            this.value = value;
        }

        public static UserTypeDocument create(string value)
        {
            validate(value);
            return new UserTypeDocument(value);
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
            if (value.Length > 3)
            {
                throw new ArgumentNullException("El tipo de documento supera la longitud máxima");
            }
            if (!value.ToLower().Equals("cc") && !value.ToLower().Equals("ti"))
            {
                throw new ArgumentNullException("No existe ese tipo de identificacion. Ej: CC, TI");
            }
        }
    }
}
