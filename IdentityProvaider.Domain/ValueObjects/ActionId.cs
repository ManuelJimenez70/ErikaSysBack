using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record ActionId
    {
        public int value { get; init; }

        internal ActionId(int value)
        {
            validate(value);
            this.value = value;
        }

        public static ActionId create(int value)
        {
            return new ActionId(value);
        }

        public static implicit operator int(ActionId actionId)
        {
            return actionId.value;
        }
        private static void validate(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentNullException("El valor del Id Action tiene que ser mayor a cero");
            }
        }
    }
}
