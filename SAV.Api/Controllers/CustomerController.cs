using Microsoft.AspNetCore.Mvc;
using SAV.Api.Data.Entity;
using SAV.Api.Data.Interface;

namespace SAV.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> _repository;

        public CustomerController(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetAllCustomer() 
        {
            var customer = await _repository.GetDataFromApi();
            return Ok(customer);
        }
    }
}
