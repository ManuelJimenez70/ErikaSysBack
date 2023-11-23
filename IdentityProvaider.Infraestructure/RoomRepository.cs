using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Infraestructure
{
    public class RoomRepository : IRoomRepository
    {

        DatabaseContext db;

        public RoomRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task AddCheck(Check check)
        {
            await db.AddAsync(check);
            await db.SaveChangesAsync();
        }

        public async Task AddReservation(Reservation reservation)
        {
            await db.AddAsync(reservation);
            await db.SaveChangesAsync();
        }

        public async Task AddRoom(Room room)
        {
            await db.AddAsync(room);
            await db.SaveChangesAsync();
        }

        public async Task<Check> GetCheckById(CheckId Id)
        {
            return await db.Checks.FindAsync((int)Id);

        }

        public async Task<List<Reservation>> GetAvalibleReservationsOfRoom(RoomId room) {

            List<Reservation> reservations =  db.Reservations.Where(r => r.id_room.value == room.value && r.reservation_date.value >= DateTime.Now.ToUniversalTime() - TimeSpan.FromDays(1)).ToList<Reservation>();

            return reservations;
        }


        public async Task<List<Check>> GetChecksByNum(int numI, int numF, State state)
        {
            var checks = db.Checks.Where(r => r.state.value == state.value).Skip(numI).Take((numF - numI)).ToList();
            return checks;
        }

        public async Task<Reservation> GetReservationById(ReservationId Id)
        {
            return await db.Reservations.FindAsync((int)Id);
        }

        public async Task<List<Reservation>> GetReservationsByNum(int numI, int numF, State state)
        {
            var reservations = db.Reservations.Where(r => r.state.value == state.value && r.reservation_date.value >= DateTime.Now.ToUniversalTime()).Skip(numI).Take((numF - numI)).ToList();

            return reservations;
        }

        public async Task<Room> GetRoomById(RoomId Id)
        {
            return await db.Rooms.FindAsync((int)Id);
        }

        public async Task<List<Room>> GetRoomsByNum(int numI, int numF, State state)
        {
            var rooms = db.Rooms.Where(r => r.state.value == state.value).Skip(numI).Take((numF - numI)).ToList();
            return rooms;
        }

        public async Task UpdateCheck(Check check)
        {
            db.Update(check);
            db.SaveChanges();
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            db.Update(reservation);
            db.SaveChanges();
        }

        public async Task UpdateRoom(Room room)
        {
            db.Update(room);
            db.SaveChanges();
        }

        public async Task DoCheckout(Check check)
        {
            db.Update(check);
            db.SaveChanges();
        }
    }
}
