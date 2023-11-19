using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Entities
{
    public class Inventory
    {
        public int id_product { get; set; }
        public Product? product { get; private set; }

        public int id_room { get; set; }
        public Room? room { get; private set; }

        public Stock stock { get; private set; }

        public Inventory() { 
        }

        public Inventory(int id_product, int id_room)
        {
            this.id_product = id_product;
            this.id_room = id_room;
        }

        public void setProduct(Product product)
        {
            this.product = product;
        }

        public void setRoom(Room room)
        {
            this.room = room;
        }


    }
}
