using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolidayMakerGrupp2.Models.Database;
using HolidayMakerGrupp2.Services;

namespace HolidayMakerGrupp2.APIControllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class CustomersController : ControllerBase
 {
  [HttpPost]
  public async Task<IActionResult> AddCustomer(Customer customer)
  {
   var createdCustomer = await CustomerService.AddCustomer(customer);
   if (createdCustomer != null)
   {
    return Created("", createdCustomer);
   }
   // TODO: gör mer specifik felhantering
   return BadRequest();
  }

  [HttpGet]
  public async Task<IActionResult> Get(string name)
  {
   if (string.IsNullOrWhiteSpace(name))
   {
    return Ok(await CustomerService.Get());
   }
   else
   {
    return Ok(await CustomerService.GetByName(name));
   }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> Get(int id)
  {
   var customer = await CustomerService.GetById(id);
   if (customer != null)
   {
    return Ok(customer);
   }
   return NotFound();
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
  {
   var updatedCustomer = await CustomerService.UpdateCustomer(id, customer);
   if (updatedCustomer != null)
   {
    return Ok(updatedCustomer);
   }
   return NotFound();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
   var deletedCustomer = await CustomerService.DeleteCustomer(id);
   if (deletedCustomer != null)
   {
    return Ok(deletedCustomer);
   }
   return BadRequest();
  }
 }
}