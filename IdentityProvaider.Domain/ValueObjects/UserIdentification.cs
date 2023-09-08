using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record UserIdentification
    {
        public string value { get; set; }
        internal UserIdentification(string value)
        {
            this.value = value;
        }
        public static UserIdentification create(string value)
        {
            validate(value);
            return new UserIdentification(value);
        }
        private static void validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("El valor no puede ser nulo");
            }
            if (value.Length > 15) {
                throw new ArgumentNullException("El valor no puede ser mayor a 15 caracteres");
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("El valor no puede ser nulo");
            }
            //agregar que el valor no puede ser mayor  a 50 caracteres
        }
    }
}
