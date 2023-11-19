using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record ReservationId
    {
        public int value { get; init; }

        internal ReservationId(int value)
        {
            validate(value);
            this.value = value;
        }

        public static ReservationId create(int value)
        {
            return new ReservationId(value);
        }

        public static implicit operator int(ReservationId actionId)
        {
            return actionId.value;
        }
        private static void validate(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentNullException("El valor del Id Reservation tiene que ser mayor a cero");
            }
        }
    }
}
