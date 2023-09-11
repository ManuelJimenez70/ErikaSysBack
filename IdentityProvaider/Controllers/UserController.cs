using IdentityProvaider.API.AplicationServices;
using IdentityProvaider.API.Commands;
using IdentityProvaider.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace IdentityProvaider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserServices userServices;

        public UserController(UserServices userServices)
        {
            this.userServices = userServices;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> AddUser(CreateUserCommand createPerfilCommand)
        {
            try
            {
                await userServices.HandleCommand(createPerfilCommand);
                return Ok(ContentResponse.createResponse(true, "USUARIO CREADO CORRECTAMENTE","SUCCESS"));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR AL CREAR USUARIO", "Ya existe el usuario con ese Id: " + ex.Message));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR AL CREAR USUARIO", ex.Message));
            }
  
        }

        [HttpGet("getUserById/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {

            return Ok(await userServices.GetUser(id));
        }

        [HttpGet("getUsersByRange")]
        public async Task<IActionResult> GetUser(int numI, int numF, string state)
        {


            try
            {
                var users = await userServices.GetUsersByNum(numI, numF, state);

                return Ok(ContentResponse.createResponse(true, "SUCCESS", users));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }
        }

        [HttpPost("updateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand updatePerfil)
        {

            try
            {
                await userServices.HandleCommand(updatePerfil);
                return Ok(ContentResponse.createResponse(true, "USUARIO ACTUALIZADO CORRECTAMENTE", "SUCCESS"));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR AL ACTUALIZAR USUARIO", "Ya existe el USUARIO con ese Id: " + ex.Message));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR AL ACTUALIZAR USUARIO", ex.Message));
            }

            
        }


        [HttpPost("updatePassword")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordCommand updatePassword)
        {
            try
            {
                await userServices.HandleCommand(updatePassword);

                return Ok(ContentResponse.createResponse(true, "CONTRASEÑA ACTUALIZADA CORRECTAMENTE", "SUCCESS"));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }

        }        

        [HttpGet("getRolesByIdUser/{id}")]
        public async Task<IActionResult> getUser(int id)
        {

            try
            {
                var response = await userServices.GetRolesByIdUser(id);

                return Ok(ContentResponse.createResponse(true, "SUCCESS", response));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }
        }

        [HttpGet("getSessionByIdUser/{id}")]
        public async Task<IActionResult> getSession(int id)
        {

            try
            {
                var response = await userServices.GetSessionsByIdUser(id);

                return Ok(ContentResponse.createResponse(true, "SUCCESS", response));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }
        }

        [HttpGet("getUsersInSession")]
        public async Task<IActionResult> getUserInSession()
        {

            try
            {
                var response = await userServices.getUsersInSession();

                return Ok(ContentResponse.createResponse(true, "SUCCESS", response));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }
        }


        [HttpGet("getUsersInSession/{top}/{initTime}")]
        public async Task<IActionResult> getUserInSessionByParams(int top, DateTime initTime)
        {
            try
            {
                var response = await userServices.getUsersInSessionByParams(top, initTime);

                return Ok(ContentResponse.createResponse(true, "SUCCESS", response));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginCommand login)
        {
            var response = await userServices.HandleCommand(login);
            return Ok(response);
        }

        [HttpGet("getHistoryOfLogState")]
        public async Task<IActionResult> getHistoryOfLogState(int id_user)
        {

            try
            {
                var response = await userServices.getHistoryOfLogState(id_user);

                return Ok(ContentResponse.createResponse(true, "SUCCESS", response));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }
        }
    }
    

}
