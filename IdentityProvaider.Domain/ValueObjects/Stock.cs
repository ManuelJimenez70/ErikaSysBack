using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record Stock
    {
        public int value { get; init; }

        internal Stock(int value)
        {
            this.value = value;
        }

        public static Stock create(int value)
        {
            return new Stock(value);
        }

        public static implicit operator int(Stock credentialId)
        {
            return credentialId.value;
        }

    }
}

