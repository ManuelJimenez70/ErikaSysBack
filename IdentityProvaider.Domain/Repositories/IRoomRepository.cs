using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomById(RoomId Id);
        Task<List<Room>> GetRoomsByNum(int numI, int numF, State state);
        Task AddRoom(Room room);
        Task UpdateRoom(Room room);

        Task<Reservation> GetReservationById(ReservationId Id);
        Task<List<Reservation>> GetReservationsByNum(int numI, int numF, State state);
        Task<List<Reservation>> GetAvalibleReservationsOfRoom(RoomId room);

        Task AddReservation(Reservation reservation);
        Task UpdateReservation(Reservation reservation);

        Task<Check> GetCheckById(CheckId Id);
        Task<List<Check>> GetChecksByNum(int numI, int numF, State state);
        Task AddCheck(Check check);
        Task UpdateCheck(Check check);
        Task DoCheckout(Check check);

    }
}
