using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Entities
{
    public class Check
    {
        public int id_check { get; set; }
        public RoomId id_room { get; private set; }
        public ReservationId? id_reservation { get; private set; }
        public State state { get; private set; }

        public CreationDate checkin_date { get; private set; }

        public CheckOutDate? checkout_date { get; private set; }
        public UserName titular_person_name { get; set; }
        public Quantity num_hosts { get; set; }
        public UserIdentification titular_person_id { get; set; }

        public Check() {
            this.checkin_date = CreationDate.create(DateTime.Now);
            state = State.create("Activo");
        }

        public Check(int id_check)
        {
            this.id_check = id_check;
            this.checkin_date = CreationDate.create(DateTime.Now);
            state = State.create("Activo");
        }


        public void setState(State state)
        {
            this.state = state;
        }
        public void setRoomId(RoomId id_room)
        {
            this.id_room = id_room;
        }

        public void setReservationId(ReservationId id_reservation)
        {
            this.id_reservation = id_reservation;
        }

        public void setCheckOutDate(CheckOutDate checkout_date)
        {
            this.checkout_date = checkout_date;
        }

        public void setUserId(UserIdentification titular_person_id)
        {
            this.titular_person_id = titular_person_id;
        }

        public void setUserName(UserName titular_person_name)
        {
            this.titular_person_name = titular_person_name;
        }

        public void setNumHosts(Quantity num_hosts)
        {
            this.num_hosts = num_hosts;
        }


    }
}
