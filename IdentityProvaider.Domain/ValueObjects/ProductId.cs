using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record ProductId
    {
        public int value { get; init; }

        internal ProductId(int value)
        {
            validate(value);
            this.value = value;
        }

        public static ProductId create(int value)
        {
            return new ProductId(value);
        }

        public static implicit operator int(ProductId productId)
        {
            return productId.value;
        }
        private static void validate(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentNullException("El valor del Id Producto tiene que ser mayor a cero");
            }
        }
    }
}
