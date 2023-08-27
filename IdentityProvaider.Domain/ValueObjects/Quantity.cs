using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record Quantity
    {
        public int value { get; init; }

        internal Quantity(int value)
        {
            validate(value);
            this.value = value;
        }

        public static Quantity create(int value)
        {
            return new Quantity(value);
        }

        public static implicit operator int(Quantity quantity)
        {
            return quantity.value;
        }
        private static void validate(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentNullException("La cantidad tiene que ser mayor a cero");
            }
        }
    }
}
