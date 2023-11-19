using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record CheckId
    {
        public int value { get; init; }

        internal CheckId(int value)
        {
            validate(value);
            this.value = value;
        }

        public static CheckId create(int value)
        {
            return new CheckId(value);
        }

        public static implicit operator int(CheckId actionId)
        {
            return actionId.value;
        }
        private static void validate(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentNullException("El valor del Id Check tiene que ser mayor a cero");
            }
        }
    }
}
