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

            try
            {
                await productServices.CreateProduct(createProduct);

                return Ok(ContentResponse.createResponse(true, "PRODUCTO CREADO CORRECTAMENTE", "SUCCESS"));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR AL CREAR PRODUCTO", "Ya existe el PRODUCTO con ese Id: " + ex.Message));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR AL CREAR PRODUCTO", ex.Message));
            }
           
        }
     

        [HttpGet("getProductsByRange")]
        public async Task<IActionResult> GetProducts(int numI, int numF)
        {

            try
            {
                var products = await productServices.GetProductsByNum(numI, numF);

                return Ok(ContentResponse.createResponse(true, "SUCCESS", products));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }

        }


        [HttpGet("getProductsByRangeState")]
        public async Task<IActionResult> GetProducts(int numI, int numF, string state)
        {

            try
            {
                var products = await productServices.GetProductsByNum(numI, numF, state);

                return Ok(ContentResponse.createResponse(true, "SUCCESS", products));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }

        }

        [HttpGet("getProductByModule")]
        public async Task<IActionResult> GetProductByModule(int numI, int numF, string? state, string id_module)
        {

            try
            {
                var products = await productServices.GetProductByModule(numI, numF, state, id_module);

                return Ok(ContentResponse.createResponse(true, "SUCCESS", products));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }

        }

        [HttpGet("getProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id) 
        {
            try
            {
                var response = await productServices.GetProductById(id);
                return Ok(ContentResponse.createResponse(true, "SUCCESS", response));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR", ex.Message));
            }
        }

        [HttpPost("updateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProduct)
        {

            try
            {
                await productServices.UpdateProduct(updateProduct);
                return Ok(ContentResponse.createResponse(true, "PRODUCTO ACTUALIZADO CORRECTAMENTE", "SUCCESS"));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR AL ACTUALIZAR PRODUCTO", "Ya existe el PRODUCTO con ese Id: " + ex.Message));
            }
            catch (Exception ex)
            {
                return Ok(ContentResponse.createResponse(false, "ERROR AL ACTUALIZAR PRODUCTO", ex.Message));
            }
        }

        
    }

}
