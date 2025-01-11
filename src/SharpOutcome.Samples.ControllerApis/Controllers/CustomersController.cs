using Microsoft.AspNetCore.Mvc;

namespace SharpOutcome.Samples.ControllerApis.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static readonly Dictionary<int, Customer> _customers = new()
        {
            { 1, new Customer("Jorge") },
            { 2, new Customer("Paulo") },
            { 3, new Customer("Adriana") }
        };

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var result = GetCustomer(id);

            return result switch
            {
                Some<Customer> customer => Ok(customer.Value),
                _ => NotFound() // the operator _ matches both None<Customer> and null
            };
        }

        private static Option<Customer> GetCustomer(int id)
        {
            return Option<Customer>.CreateFromValue(_customers.GetValueOrDefault(id));
        }

        public class Customer
        {
            public string Name { get; init; }

            public Customer(string name)
            {
                Name = name ?? throw new ArgumentNullException(nameof(name));
            }
        }
    }
}