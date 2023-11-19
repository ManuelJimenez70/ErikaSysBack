using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Entities
{
    public class Reservation
    {
        public int id_reservation { get; init; }
        public RoomId id_room { get; set; }
        public ReservationDate  reservation_date { get; private set; }
        public State state { get; set; }
        public UserName titular_person_name { get; set; }

        public UserIdentification titular_person_id { get; set; }
        public CreationDate creation_date { get; set; }

        public Reservation() {
            creation_date = CreationDate.create(DateTime.Now);
            state = State.create("Activo");
        }
        public Reservation(int id_reservation)
        {
            this.id_reservation = id_reservation;
            state = State.create("Activo");
            creation_date = CreationDate.create(DateTime.Now);
        }
        public void setUserId(UserIdentification titular_person_id)
        {
            this.titular_person_id = titular_person_id;
        }
        public void setUserName(UserName titular_person_name)
        {
            this.titular_person_name = titular_person_name;
        }
        public void setReservationDate(ReservationDate reservation_date)
        {
            this.reservation_date = reservation_date;
        }
        public void setRoomId(RoomId id_room)
        {
            this.id_room = id_room;
        }
        public void setState(State state)
        {
            this.state = state;
        }
    }
}
