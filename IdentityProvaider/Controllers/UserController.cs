using IdentityProvaider.API.AplicationServices;
using IdentityProvaider.API.Commands;
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
            var response = await userServices.GetUser(id);
            return Ok(response);
        }

        [HttpGet("getUsersByRange")]
        public async Task<IActionResult> GetUser(int numI, int numF, string state)
        {
            return Ok(await userServices.GetUsersByNum(numI,numF, state));
        }

        [HttpPost("updateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand updatePerfil)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.myip.com");
            MyIp myIp = null;
            try
            {
                myIp = await response.Content.ReadFromJsonAsync<MyIp>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            await userServices.HandleCommand(updatePerfil, myIp.ip);
            return Ok(updatePerfil);
        }


        [HttpPost("updatePassword")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordCommand updatePassword)
        {            
            return Ok(await userServices.HandleCommand(updatePassword));
        }        

        [HttpGet("getRolesByIdUser/{id}")]
        public async Task<IActionResult> getUser(int id)
        {
            var response = await userServices.GetRolesByIdUser(id);
            return Ok(response);
        }

        [HttpGet("getSessionByIdUser/{id}")]
        public async Task<IActionResult> getSession(int id)
        {
            return Ok(await userServices.GetSessionsByIdUser(id));
        }

        [HttpGet("getUsersInSession")]
        public async Task<IActionResult> getUserInSession()
        {
            return Ok(await userServices.getUsersInSession());
        }


        [HttpGet("getUsersInSession/{top}/{initTime}")]
        public async Task<IActionResult> getUserInSessionByParams(int top, DateTime initTime)
        {
            return Ok(await userServices.getUsersInSessionByParams(top,initTime));
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
            return Ok(await userServices.getHistoryOfLogState(id_user));
        }
    }
    public class MyIp
    {
        public string ip { get; set; }
        public string country { get; set; }
        public string cc { get; set; }        
    }

}
