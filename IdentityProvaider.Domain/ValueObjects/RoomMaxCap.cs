using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record RoomMaxCap
    {
        public int value { get; init; }

        internal RoomMaxCap(int value)
        {
            this.value = value;
        }

        public static RoomMaxCap create(int value)
        {
            return new RoomMaxCap(value);
        }

        public static implicit operator int(RoomMaxCap roomMaxCap)
        {
            return roomMaxCap.value;
        }

    }
}

