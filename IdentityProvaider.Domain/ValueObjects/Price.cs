using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record Price
    {

        public int value { get; init; }

        internal Price(int value)
        {
            this.value = value;
        }

        public static Price create(int value)
        {
            validate(value);
            return new Price(value);
        }

        public static implicit operator int(Price credentialId)
        {
            return credentialId.value;
        }
        private static void validate(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentNullException("El precio tiene que ser mayor a cero");
            }
        }
    }
}
