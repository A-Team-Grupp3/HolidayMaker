using HolidayMakerGrupp2.Models.Database;
using HolidayMakerGrupp2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolidayMakerGrupp2.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public CustomersController()
        {
        }

        [HttpPost]
        public async Task<int> AddCustomer(string firstName, string lastName, string address, string city, string email, string phoneNr, int zipcode)
        {
            return await CustomerService.AddCustomer(firstName, lastName, address, city, email, phoneNr, zipcode);
        }

        [HttpDelete]
        public async Task<Customer> Delete(int id)
        {
            return await CustomerService.DeleteCustomer(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return await CustomerService.Get();
            }
            else
            {
                return await CustomerService.GetByName(name);
            }
        }

        [HttpPut]
        public async Task<int> UpdateCustomer(int id, string firstname, string lastName, string email, string address, string city, string phonenr, int zipcode)
        {
            Customer customer = new Customer()
            {
                Firstname = firstname,
                Lastname = lastName,
                Email = email,
                Address = address,
                City = city,
                PhoneNr = phonenr,
                Zipcode = zipcode
            };
            return await CustomerService.ChangeCustomer(id, customer);
        }
    }
}