using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record ActionType
    {
        public string value { get; init; }

        internal ActionType(string value)
        {
            this.value = value;
        }

        public static ActionType create(string value)
        {
            validate(value);
            return new ActionType(value);
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
                throw new ArgumentNullException("El tipo de acción supera la longitud máxima");
            }
            if (!(value.Equals("out") || value.Equals("in"))) {
                throw new ArgumentNullException("No existe ese tipo de acción");
            }
            //agregar que el valor no puede ser mayor  a 50 caracteres
        }
    }
}
