using Microsoft.AspNetCore.Mvc;
using ShopBridgeAPI.Application.Features.Products.Commands.CreateProduct;
using ShopBridgeAPI.Application.Features.Products.Commands.DeleteProductById;
using ShopBridgeAPI.Application.Features.Products.Commands.UpdateProduct;
using ShopBridgeAPI.Application.Features.Products.Queries.GetAllProducts;
using ShopBridgeAPI.Application.Features.Products.Queries.GetProductById;
using System.Threading.Tasks;

namespace ShopBridgeAPI.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> ShowAllProducts([FromQuery] GetAllProductsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllProductsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailsByID(int id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddNewProduct(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductCommand command)
        {
            //if (id != command.Id)
            //{
            //    return BadRequest();
            //}
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }
    }

}
