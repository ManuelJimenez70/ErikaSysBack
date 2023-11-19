using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.ValueObjects
{
    public record ReservationDate
    {
        public DateTime value { get; set; }
        internal ReservationDate(DateTime value)
        {
            this.value = value;
        }

        public static ReservationDate create(DateTime value)
        {
            validate(value);
            return new ReservationDate(DateTime.SpecifyKind(value, DateTimeKind.Utc));
        }

        private static void validate(DateTime value)
        {
            
            if (value == new DateTime())
            {
                throw new ArgumentNullException("La fecha no puede ser la default");
            
            }else if ((value < DateTime.Now)) { 
                throw new ArgumentException("La fecha ingresada es menor a la actual.");
            }
        }
    }
}
