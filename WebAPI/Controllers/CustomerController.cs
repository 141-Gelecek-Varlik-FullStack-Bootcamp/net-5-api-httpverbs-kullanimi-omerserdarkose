using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>()
        {
            new Customer
            {
                Id = 1,
                FirstName ="Cengiz",
                LastName = "Bozkurt",
                PhoneNumber="5305555555"
            },
            new Customer
            {
                Id = 2,
                FirstName ="Ali",
                LastName = "Atay",
                PhoneNumber="5305555555"
            },
            new Customer
            {
                Id = 3,
                FirstName ="Serkan",
                LastName = "Keskin",
                PhoneNumber="5305555555"
            }
        };


        [HttpGet]
        public IEnumerable<Customer> Getcustomers()
        {
            return customers;
        }


        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            var customer = customers.Where(customer => customer.Id == id).SingleOrDefault();
            return customer;
        }


        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer newCustomer)
        {
            var customer = customers.Where(customer => customer.Id == newCustomer.Id).SingleOrDefault();

            if (customer != null)
            {
                return BadRequest();
            }
            customers.Add(newCustomer);
            return Ok(customers);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer updCustomer)
        {
            var customer = customers.Where(customer => customer.Id == id).SingleOrDefault();

            if (customer == null)
            {
                return BadRequest();
            }

            customer.FirstName = (customer.FirstName != default ? updCustomer.FirstName : customer.FirstName);
            customer.LastName = (customer.LastName != default ? updCustomer.LastName : customer.LastName);
            customer.PhoneNumber = (customer.PhoneNumber != default ? updCustomer.PhoneNumber : customer.PhoneNumber);
            return Ok(customer);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = customers.Where(customer => customer.Id == id).SingleOrDefault();

            if (customer == null)
            {
                return BadRequest();
            }
            customers.Remove(customer);
            return Ok();
        }
    }
}
