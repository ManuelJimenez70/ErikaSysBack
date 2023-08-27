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
        //var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
        // Get ip client
        //string name = System.Net.Dns.GetHostName();
        //string ip = System.Net.Dns.GetHostAddresses(name)[1].ToString();
        //http://api.ipapi.com/2800:484:b387:b5f0:9099:91f6:255f:4d25?access_key=48565ca8121d0eb5414aca7a23549f61
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.myip.com");
            //InfoUser infoUser = null;
            MyIp myIp = null;
            if (response.IsSuccessStatusCode)
            {
                try
                {            
                    myIp = await response.Content.ReadFromJsonAsync<MyIp>();
                    string urlApi = "http://api.ipapi.com/";
                    string paramsApi = "?access_key=48565ca8121d0eb5414aca7a23549f61";

                    /*
                    response = await client.GetAsync(urlApi + fe.ip + paramsApi);
                    dynamic infoUser = new ExpandoObject();
                     infoUser = await response.Content.ReadFromJsonAsync<dynamic>();
                    //var info = await response.Content.ReadFromJsonAsync<InfoUser>();
                    var user = await response.Content.ReadAsStringAsync();
                    //JsonReader reader = new JsonTextReader(new StringReader(user));


                    //JProperty p = (JProperty)JToken.ReadFrom(reader);                    
                    //Assert.AreEqual("pie", p.Name);
                    //Assert.AreEqual(true, (bool)p.Value);        
                    Console.WriteLine("######");
                    Console.WriteLine(infoUser.city);*/




                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }                  
            //string userIP = Request.UserHostAddress;
            await userServices.HandleCommand(createPerfilCommand);
            return Ok(createPerfilCommand);
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
