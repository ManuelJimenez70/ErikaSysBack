using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record ModuleIdString
    {
        public string value { get; init; }

        internal ModuleIdString(string value)
        {
            this.value = value;
        }

        public static ModuleIdString create(string value)
        {
            validate(value);
            return new ModuleIdString(value);
        }

        private static void validate(string value)
        {
      
            if (value != null && value.Length > 15)
            {
                throw new ArgumentNullException("El valor no puede ser mayor a 15 caracteres");
            }
            //agregar que el valor no puede ser mayor  a 50 caracteres
        }
    }
}
