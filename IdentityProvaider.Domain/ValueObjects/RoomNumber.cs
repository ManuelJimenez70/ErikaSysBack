using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record RoomNumber
    {
        public string value { get; init; }

        internal RoomNumber(string value)
        {
            this.value = value;
        }

        public static RoomNumber create(string value)
        {
            validate(value);
            return new RoomNumber(value);
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
            if (value.Length > 20)
            {
                throw new ArgumentNullException("El valor del nombre no puede ser mayor a 20 caracteres");
            }
        }

    }
}

