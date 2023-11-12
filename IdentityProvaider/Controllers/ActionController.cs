using IdentityProvaider.API.AplicationServices;
using IdentityProvaider.API.Commands;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IdentityProvaider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly ActionServices actionServices;

        public ActionController(ActionServices actionServices)
        {
            this.actionServices = actionServices;
        }

        [HttpPost("createAction")]
        public async Task<IActionResult> AddUser(CreateActionCommand createActionCommand)
        {
            await actionServices.HandleCommand(createActionCommand);
            return Ok(createActionCommand);
        }

        [HttpPost("recordAction")]
        public async Task<IActionResult> RecordAction(RecordSaleCommand recordSaleCommand)
        {
            var response = await actionServices.HandleCommand(recordSaleCommand);
            return Ok(response);
           
        }


        [HttpPost("recordActionExamples")]
        public async Task<IActionResult> RecordActionExamples()
        {
            Random random = new Random();
            try
            {
                var response = await actionServices.HandleCommand(new RecordSaleCommand(random.Next(101), random.Next(1, 3), random.Next(1, 64), random.Next(1, 4), random.Next(1, 11), "pruebas", DateTime.Now.AddDays(-random.Next(1, 60))));
                return Ok(response);
            }
            catch(Exception) {
                return Ok(RecordActionExamples());
            }
        
        }
        [HttpGet("getActionsByRangeDateType")]
        public async Task<IActionResult> GetActionsByRangeDate(DateTime dateI, DateTime dateF, string type)
        {
            return Ok(await actionServices.GetActionsByRangeDate(dateI, dateF, type));
        }
        [HttpGet("getActionsByRangeDateModule")]
        public async Task<IActionResult> GetActionsByRangeDate(DateTime dateI, DateTime dateF, int moduleId)
        {
            return Ok(await actionServices.GetActionsByRangeDate(dateI, dateF, moduleId));
        }
        [HttpGet("getActionsByRangeDateModuleType")]
        public async Task<IActionResult> GetActionsByRangeDate(DateTime dateI, DateTime dateF, int moduleId, string type)
        {
            return Ok(await actionServices.GetActionsByRangeDate(dateI, dateF, moduleId, type));
        }

        [HttpGet("getActionsByRangeDate")]
        public async Task<IActionResult> GetActionsByRangeDate(DateTime dateI, DateTime dateF)
        {
            return Ok(await actionServices.GetActionsByRangeDate(dateI, dateF));
        }

        [HttpGet("getActionsByUserId")]
        public async Task<IActionResult> GetActionsByUserId(int id_user)
        {
            return Ok(await actionServices.GetActionsByUserId(id_user));
        }


        [HttpGet("getModulesWithProducts")]
        public async Task<IActionResult> GetModulesWithProducts()
        {
            try
            {
                var response = await actionServices.GetModulesWithProducts();
                return Ok(ContentResponse.createResponse(true, "SUCCESS", response));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }
        }

        
        
    }
}
