using Microsoft.AspNetCore.Mvc;
using SAV.Api.Data.Entity;
using SAV.Api.Data.Interface;

namespace SAV.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _repository;

        public ProductsController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetProducts")]

        public async Task<IActionResult> GetAllProducts() 
        {
            var product = await _repository.GetDataFromApi();
            return Ok(product);
        }
    }
}
