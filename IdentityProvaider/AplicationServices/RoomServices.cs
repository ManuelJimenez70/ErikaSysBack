using IdentityProvaider.API.Commands;
using IdentityProvaider.API.Queries;
using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;

namespace IdentityProvaider.API.AplicationServices
{
    public class RoomServices
    {
        private readonly IRoomRepository repository;

        public RoomServices(IRoomRepository repository)
        {
            this.repository = repository;
        }
        //--------------------- Rooms
        public async Task<ContentResponse> HandleCommand(CreateRoomCommand createRoom)
        {
            try
            {
                var room = new Room();
                room.setNumber(RoomNumber.create(createRoom.number));
                room.setRoomMaxCap(RoomMaxCap.create(createRoom.max_capacity));
                room.setPrice(Price.create(createRoom.price_per_nigth));
                await repository.AddRoom(room);
                return ContentResponse.createResponse(true, "HABITACIÓN CREADA CORRECTAMENTE", "SUCCESS");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                return ContentResponse.createResponse(true, "HABITACIÓN CREADA CORRECTAMENTE", "SUCCESS");
            }
            catch (Exception ex)
            {
                return ContentResponse.createResponse(true, "HABITACIÓN CREADA CORRECTAMENTE", "SUCCESS");
            }
        }

        public async Task<Room> GetRoom(int roomId)
        {
            return await repository.GetRoomById(RoomId.create(roomId));
        }

        public async Task<List<Room>> GetRoomsByNum(int numI, int numF, string state)
        {
            return await repository.GetRoomsByNum(numI, numF, State.create(state));
        }

        public async Task<ContentResponse> HandleCommand(UpdateRoomCommand updateRoomCommand)
        {

            try
            {

                RoomId id = RoomId.create(updateRoomCommand.id);
                var room = await repository.GetRoomById(id);
                string number = string.IsNullOrEmpty(updateRoomCommand.number) ? room.number.value : updateRoomCommand.number;
                room.setNumber(RoomNumber.create(number));

                if (updateRoomCommand.max_capacity.HasValue)
                {
                    room.setRoomMaxCap(RoomMaxCap.create((int)updateRoomCommand.max_capacity));
                }
                if (updateRoomCommand.price_per_nigth.HasValue)
                {
                    room.setPrice(Price.create((int)updateRoomCommand.price_per_nigth));
                }
                await this.repository.UpdateRoom(room);
                return ContentResponse.createResponse(true, "HABITACIÓN ACTUALIZADA CORRECTAMENTE", "SUCCESS");
            }
            catch (Exception ex)
            {
                return ContentResponse.createResponse(false, "ERROR AL ACTUALIZAR HABITACIÓN", ex.Message);
            }

        }

        //--------------- Reservations

        public async Task<ContentResponse> HandleCommand(CreateReservationCommand createReservation)
        {
            try {
                var reservation = new Reservation();
                Room room = await repository.GetRoomById(RoomId.create((int)createReservation.id_room));
                if (room != null)
                {
                    reservation.setRoomId(RoomId.create(createReservation.id_room));
                }
                else
                {
                    return ContentResponse.createResponse(false, "ERROR AL CREAR RESERVACIÓN", "Habitación inexistente");
                }
                reservation.setReservationDate(ReservationDate.create(createReservation.reservation_date));
                reservation.setUserName(UserName.create(createReservation.titular_person_name));
                reservation.setUserId(UserIdentification.create(createReservation.titular_person_id));
                await repository.AddReservation(reservation);

                return ContentResponse.createResponse(true, "RESERVACIÓN CREADA CORRECTAMENTE", "SUCCESS");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                return ContentResponse.createResponse(false, "ERROR AL CREAR RESERVACIÓN", "Ya existe una RESERVACIÓN con ese Id: " + ex.Message);
            }
            catch (Exception ex)
            {
                return ContentResponse.createResponse(false, "ERROR AL CREAR RESERVACIÓN", ex.Message);
            }


        }

       

        public async Task<ContentResponse> HandleCommand(UpdateReservationCommand updateReservationCommand)
        {
            try {

                ReservationId id = ReservationId.create(updateReservationCommand.id);
                var reservation = await repository.GetReservationById(id);

                if (updateReservationCommand.id_room.HasValue)
                {
                    try
                    {
                        Room room = await repository.GetRoomById(RoomId.create((int)updateReservationCommand.id_room));
                        reservation.setRoomId(RoomId.create(room.id_room));
                    }
                    catch (Exception e)
                    {
                        return ContentResponse.createResponse(false, "ERROR AL ACTUALIZAR RESERVACIÓN", e.Message);
                    }
                }

                if (updateReservationCommand.reservation_date.HasValue)
                {
                    reservation.setReservationDate(ReservationDate.create((DateTime)updateReservationCommand.reservation_date));
                }

                string personName = string.IsNullOrEmpty(updateReservationCommand.titular_person_name) ? reservation.titular_person_name.value : updateReservationCommand.titular_person_name;
                reservation.setUserName(UserName.create(personName));

                string personId = string.IsNullOrEmpty(updateReservationCommand.titular_person_id) ? reservation.titular_person_id.value : updateReservationCommand.titular_person_id;
                reservation.setUserId(UserIdentification.create(personId));

                await this.repository.UpdateReservation(reservation);
                return ContentResponse.createResponse(true, "RESERVACIÓN ACTUALIZADA CORRECTAMENTE", "SUCCESS");
            }
            catch (Exception ex)
            {
                return ContentResponse.createResponse(false, "ERROR AL ACTUALIZAR RESERVACIÓN", ex.Message);
            }
        }


        public async Task<Reservation> GetReservation(int reservationId)
        {
            return await repository.GetReservationById(ReservationId.create(reservationId));
        }

        public async Task<List<Reservation>> GetReservationsByNum(int numI, int numF, string state)
        {
            return await repository.GetReservationsByNum(numI, numF, State.create(state));
        }


        //--------------- Checks

        public async Task<ContentResponse> HandleCommand(CreateCheckCommand createCheck)
        {
            try {
                var check = new Check();
                Room room = await repository.GetRoomById(RoomId.create((int)createCheck.id_room));
                if (room != null)
                {
                    check.setRoomId(RoomId.create(room.id_room));
                }
                else
                {
                    return ContentResponse.createResponse(false, "ERROR AL CREAR CHECK", "Habitación inexistente");
                }
                if (createCheck.id_reservation.HasValue)
                {
                    Reservation reservation = await repository.GetReservationById(ReservationId.create((int)createCheck.id_reservation));
                    if (reservation != null)
                    {
                        check.setReservationId(ReservationId.create(reservation.id_reservation));
                    }
                    else
                    {
                        return ContentResponse.createResponse(false, "ERROR AL CREAR CHECK", "Reservación inexistente");
                    }
                }
                check.setNumHosts(Quantity.create(createCheck.num_hosts));
                check.setUserName(UserName.create(createCheck.titular_person_name));
                check.setUserId(UserIdentification.create(createCheck.titular_person_id));
                await repository.AddCheck(check);
                return ContentResponse.createResponse(true, "CHECK CREADO CORRECTAMENTE", "SUCCESS");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                return ContentResponse.createResponse(false, "ERROR AL CREAR CHECK", "Ya existe un CHECK con ese Id: " + ex.Message);
            }
            catch (Exception ex)
            {
                return ContentResponse.createResponse(false, "ERROR AL CREAR CHECK", ex.Message);
            }

        }

        public async Task<ContentResponse> HandleCommand(UpdateCheckCommand updateCheckCommand)
        {
            try {

                CheckId id = CheckId.create(updateCheckCommand.id);
                var check = await repository.GetCheckById(id);
                if (updateCheckCommand.id_room.HasValue)
                {
                    Room room = await repository.GetRoomById(RoomId.create((int)updateCheckCommand.id_room));
                    if (room != null)
                    {
                        check.setRoomId(RoomId.create(room.id_room));
                    }
                    else
                    {
                        return ContentResponse.createResponse(false, "ERROR AL ACTUALIZAR CHECK", "Habitación inexistente");
                    }
                }
                string personName = string.IsNullOrEmpty(updateCheckCommand.titular_person_name) ? check.titular_person_name.value : updateCheckCommand.titular_person_name;
                check.setUserName(UserName.create(personName));
                string personId = string.IsNullOrEmpty(updateCheckCommand.titular_person_id) ? check.titular_person_id.value : updateCheckCommand.titular_person_id;
                check.setUserId(UserIdentification.create(personId));
                if (updateCheckCommand.id_reservation.HasValue)
                {
                    Reservation reservation = await repository.GetReservationById(ReservationId.create((int)updateCheckCommand.id_reservation));
                    if (reservation != null)
                    {
                        check.setReservationId(ReservationId.create(reservation.id_reservation));
                    }
                    else
                    {
                        return ContentResponse.createResponse(false, "ERROR AL ACTUALIZAR CHECK", "Reservación inexistente");
                    }
                }
                if (updateCheckCommand.num_hosts.HasValue)
                {
                    check.setNumHosts(Quantity.create((int)updateCheckCommand.num_hosts));
                }
                await this.repository.UpdateCheck(check);
                return ContentResponse.createResponse(true, "CHECK ACTUALIZADO CORRECTAMENTE", "SUCCESS");

            }
            catch (Exception ex)
            {
                return ContentResponse.createResponse(false, "ERROR AL ACTUALIZAR CHECK", ex.Message);
            }
        }
        public async Task<Check> GetCheckById(int checknId)
        {
            return await repository.GetCheckById(CheckId.create(checknId));
        }

        public async Task<List<Check>> GetChecksByNum(int numI, int numF, string state)
        {
            return await repository.GetChecksByNum(numI, numF, State.create(state));
        }
    }
}
