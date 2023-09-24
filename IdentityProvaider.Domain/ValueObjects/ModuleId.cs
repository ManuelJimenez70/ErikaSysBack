using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record ModuleId
    {
        public int value { get; init; }

        internal ModuleId(int value)
        {
            validate(value);
            this.value = value;
        }

        public static ModuleId create(int value)
        {
            return new ModuleId(value);
        }

        public static implicit operator int(ModuleId moduleId)
        {
            return moduleId.value;
        }
        private static void validate(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentNullException("El valor del Id Modulo tiene que ser mayor a cero");
            }
        }

       
    }
}
