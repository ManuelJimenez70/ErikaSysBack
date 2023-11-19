using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IdentityProvaider.Domain.Entities
{
    public class Room
    {
        public int id_room { get; init; }
        public RoomNumber number { get; private set; }
        public RoomMaxCap max_capacity { get; private set; }
        public Price price_per_night { get; private set; }
        public State state { get; private set; }
        public IList<Inventory> room_products { get; set; }
      


        public Room(){
            this.state = State.create("Activo"); 
        }

        public Room(int id_room)
        {
            this.id_room = id_room;
            this.state = State.create("Activo");
        }

        public void setNumber(RoomNumber number)
        {
            this.number = number;
        }

        public void setRoomMaxCap(RoomMaxCap max_capacity)
        {
            this.max_capacity = max_capacity;
        }

        public void setPrice(Price price_per_night)
        {
            this.price_per_night = price_per_night;
        }

        public void setState(State state)
        {
            this.state = state;
        }

    }

}
