using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public class RolId
    {
        public int value { get; init; }

        internal RolId(int value)
        {
            this.value = value;
        }

        public static RolId create(int value)
        {
            validate(value);
            return new RolId(value);
        }

        public static implicit operator int(RolId credentialId)
        {
            return credentialId.value;
        }
        private static void validate(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentNullException("El valor del Id Rol tiene que ser mayor a cero");
            }
        }
    }
}
