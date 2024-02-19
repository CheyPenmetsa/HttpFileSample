using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var customers = Enumerable.Range(1, 3)
                    .Select(i => 
                    new CustomerId {
                        Id = i, FirstName = $"FN {i}", LastName = $"LN {i}", Age=15*i, Address=$"{i} Main Stree", Email=$"{i}@gmail.com" 
                    })
                    .ToList();

            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            return Ok(customer);
        }

        [HttpDelete]
        public IActionResult Delete(int customerId)
        {
            if(Request.Headers.TryGetValue("x-api-key", out var headerValue))
            {
                return Ok($"Customer {customerId} was deleted.");
            }
            return BadRequest("Required header missing.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = new CustomerId
            {
                Id = id,
                FirstName = $"FN {id}",
                LastName = $"LN {id}",
                Age = 5 * id,
                Address = $"{id} Main Stree",
                Email = $"{id}@gmail.com"
            };

            return Ok(customer);
        }
    }
}
