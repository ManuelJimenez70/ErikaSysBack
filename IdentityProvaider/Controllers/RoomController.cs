using IdentityProvaider.API.AplicationServices;
using IdentityProvaider.API.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProvaider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomServices roomServices;

        public RoomController(RoomServices roomServices)
        {
            this.roomServices = roomServices;
        }

        //------------- Rooms

        [HttpPost("createRoom")]
        public async Task<IActionResult> AddRoom(CreateRoomCommand createRoomCommand)
        {
            
                return Ok(await roomServices.HandleCommand(createRoomCommand));
            
        }

        [HttpGet("getRoomById/{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {

            try
            {
                var response = await roomServices.GetRoom(id);
                return Ok(ContentResponse.createResponse(true, "SUCCESS", response));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }
          
        }

        [HttpPost("updateRoom")]
        public async Task<IActionResult> UpdateRoom(UpdateRoomCommand updateRoom)
        {
            
                
                return Ok(await roomServices.HandleCommand(updateRoom));
          

        }

        [HttpGet("getRoomsByRangeState")]
        public async Task<IActionResult> GetRoom(int numI, int numF, string state)
        {

            try
            {
                var products = await roomServices.GetRoomsByNum(numI, numF, state);

                return Ok(ContentResponse.createResponse(true, "SUCCESS", products));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }

        }

        //------------- Reservations

  
        [HttpGet("getReservationById/{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {

            try
            {
                var response = await roomServices.GetReservation(id);
                return Ok(ContentResponse.createResponse(true, "SUCCESS", response));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }

        }

        [HttpPost("updateReservation")]
        public async Task<IActionResult> UpdateReservation(UpdateReservationCommand updateReservation)
        {
                return Ok(await roomServices.HandleCommand(updateReservation));
        }

        [HttpPost("createReservation")]
        public async Task<IActionResult> AddReservation(CreateReservationCommand createReservationCommand)
        {
                return Ok(await roomServices.HandleCommand(createReservationCommand));
        }

        [HttpGet("getReservationsByRangeState")]
        public async Task<IActionResult> GetReservation(int numI, int numF, string state)
        {

            try
            {
                var products = await roomServices.GetReservationsByNum(numI, numF, state);

                return Ok(ContentResponse.createResponse(true, "SUCCESS", products));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }

        }


        //------------- Reservations

        [HttpPost("createCheckIn")]
        public async Task<IActionResult> AddCheckIn(CreateCheckCommand createCheckCommand)
        {
            return Ok(await roomServices.HandleCommand(createCheckCommand));
        }

        [HttpPost("updateCheck")]
        public async Task<IActionResult> UpdateCheck(UpdateCheckCommand updateCheckCommand)
        {
            return Ok(await roomServices.HandleCommand(updateCheckCommand));
        }

        [HttpGet("getCheckById/{id}")]
        public async Task<IActionResult> GetCheck(int id)
        {

            try
            {
                var response = await roomServices.GetCheckById(id);
                return Ok(ContentResponse.createResponse(true, "SUCCESS", response));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }

        }

    

        [HttpGet("getChecksByRangeState")]
        public async Task<IActionResult> GetChecks(int numI, int numF, string state)
        {

            try
            {
                var products = await roomServices.GetChecksByNum(numI, numF, state);

                return Ok(ContentResponse.createResponse(true, "SUCCESS", products));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }

        }

    }
}
