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

        [HttpGet("getActionsByRangeDateType")]
        public async Task<IActionResult> GetActionsByRangeDate(DateTime dateI, DateTime dateF, string type)
        {
            return Ok(await actionServices.GetActionsByRangeDate(dateI, dateF, type));
        }

        [HttpGet("getActionsByRangeDate")]
        public async Task<IActionResult> GetActionsByRangeDate(DateTime dateI, DateTime dateF)
        {
            return Ok(await actionServices.GetActionsByRangeDate(dateI, dateF));
        }
    }
}
