using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record CheckOutDate
    {
        public DateTime value { get; set; }
        internal CheckOutDate(DateTime value)
        {
            this.value = value;
        }

        public static CheckOutDate create(DateTime value)
        {
            return new CheckOutDate(DateTime.SpecifyKind(value, DateTimeKind.Utc));
        }

    }
}
