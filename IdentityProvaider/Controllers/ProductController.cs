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

        private readonly ProductService productServices;

        public ProductController(ProductService productServices)
        {
            this.productServices = productServices;
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProduct)
        {
            await productServices.CreateProduct(createProduct);
            return Ok(createProduct);
        }
     

        [HttpGet("getProductsByRange")]
        public async Task<IActionResult> GetUser(int numI, int numF)
        {
            return Ok(await productServices.GetProductsByNum(numI, numF));
        }
        [HttpGet("getProductById/{id}")]
        public async Task<IActionResult> GetUserById(int id) 
        { 
            var response = await productServices.GetProductById(id);
            return Ok(response);
        }

        [HttpPost("updateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProduct)
        {
            var product = new HttpClient();
            HttpResponseMessage response = await product.GetAsync("https://api.myip.com");
            MyIp myIp = new MyIp();
            try
            {
                myIp = await response.Content.ReadFromJsonAsync<MyIp>();
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
            await productServices.UpdateProduct(updateProduct);
            return Ok(updateProduct);
        }

        
    }

}
