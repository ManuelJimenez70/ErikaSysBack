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
    public class ProductController : ControllerBase
    {

        private readonly ProductService userServices;

        public ProductController(ProductService userServices)
        {
            this.userServices = userServices;
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProduct)
        {
            await userServices.CreateProduct(createProduct);
            return Ok(createProduct);
        }
     

        [HttpGet("getProductsByRange")]
        public async Task<IActionResult> GetUser(int numI, int numF)
        {
            return Ok(await userServices.GetProductsByNum(numI, numF));
        }

        
    }

}
