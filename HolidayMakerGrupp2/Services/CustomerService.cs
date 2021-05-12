using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerGrupp2.Models.Database;

namespace HolidayMakerGrupp2.Services
{
 public static class CustomerService
 {
  public static async Task<IEnumerable<Customer>> Get()
  {
   using var ctx = new HolidayMakerGrupp2Context();
   return await ctx.Customers.ToListAsync();
  }

  public static async Task<Customer> GetById(int id)
  {
   using var ctx = new HolidayMakerGrupp2Context();
   return await ctx.Customers.FindAsync(id);
  }

  public static async Task<IEnumerable<Customer>> GetByName(string name)
  {
   using var ctx = new HolidayMakerGrupp2Context();
    return await ctx.Customers.AsAsyncEnumerable().Where(c => c.Firstname.ToLower().Contains(name)).ToListAsync();
  }

  public static async Task<Customer> DeleteCustomer(int id)
  {
   using var ctx = new HolidayMakerGrupp2Context();

   var customerToDelete = await ctx.Customers.FindAsync(id);
   ctx.Customers.Remove(customerToDelete);
   await ctx.SaveChangesAsync();
   return customerToDelete;
  }

  public static async Task<Customer> AddCustomer(Customer customer)
  {
   using var ctx = new HolidayMakerGrupp2Context();
   customer.GuId = Guid.NewGuid().ToString();
   var createdCustomer = ctx.Customers.Add(customer);
   await ctx.SaveChangesAsync();
   return createdCustomer.Entity;
  }

  public static async Task<Customer> UpdateCustomer(int id, Customer customer)
  {
   using var ctx = new HolidayMakerGrupp2Context();

   var oldCustomer = await ctx.Customers.FindAsync(id);

   if (oldCustomer.Firstname != customer.Firstname)
   {
    oldCustomer.Firstname = customer.Firstname;
   }
   if (oldCustomer.Lastname != customer.Lastname)
   {
    oldCustomer.Lastname = customer.Lastname;
   }
   if (oldCustomer.Email != customer.Email)
   {
    oldCustomer.Email = customer.Email;
   }
   if (oldCustomer.Address != customer.Address)
   {
    oldCustomer.Address = customer.Address;
   }
   if (oldCustomer.City != customer.City)
   {
    oldCustomer.City = customer.City;
   }
   if (oldCustomer.PhoneNr != customer.PhoneNr)
   {
    oldCustomer.PhoneNr = customer.PhoneNr;
   }
   if (oldCustomer.Zipcode != customer.Zipcode)
   {
    oldCustomer.Zipcode = customer.Zipcode;
   }
   await ctx.SaveChangesAsync();

   return oldCustomer;
  }
 }
}