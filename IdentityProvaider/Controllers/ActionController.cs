using IdentityProvaider.API.AplicationServices;
using IdentityProvaider.API.Commands;
using Microsoft.AspNetCore.Mvc;

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
    }
}
