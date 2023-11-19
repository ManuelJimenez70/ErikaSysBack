using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record RoomId
    {
        public int value { get; init; }

        internal RoomId(int value)
        {
            validate(value);
            this.value = value;
        }

        public static RoomId create(int value)
        {
            return new RoomId(value);
        }

        public static implicit operator int(RoomId actionId)
        {
            return actionId.value;
        }
        private static void validate(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentNullException("El valor del Id Room tiene que ser mayor a cero");
            }
        }
    }
}
