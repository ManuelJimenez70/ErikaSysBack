using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record State
    {
        public string value { get; init; }

        internal State(string value)
        {
            this.value = value;
        }

        public static State create(string value)
        {
            validate(value);
            return new State(value);
        }

        private static void validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("El valor no puede ser nulo");
            }
            //agregar que el valor no puede ser mayor  a 50 caracteres
        }
    }
}
