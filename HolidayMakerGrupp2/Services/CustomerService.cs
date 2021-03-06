using HolidayMakerGrupp2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerGrupp2.Services
{
    public static class CustomerService
    {
        public static async Task<IEnumerable<Customer>> Get()
        {
            using var ctx = new HolidayMakerGrupp2Context();

            return await ctx.Customers.AsAsyncEnumerable().ToListAsync();
        }

        public static async Task<IEnumerable<Customer>> GetById(int id)
        {
            using var ctx = new HolidayMakerGrupp2Context();

            var customer = ctx.Customers.AsAsyncEnumerable().Where(c => c.Id == id).ToListAsync();

            return await customer;
        }

        public static async Task<IEnumerable<Customer>> GetByName(string name)
        {
            using var ctx = new HolidayMakerGrupp2Context();

            if (string.IsNullOrWhiteSpace(name))
            {
                return ctx.Customers.ToList();
            }
            else
            {
                return await ctx.Customers.AsAsyncEnumerable().Where(c => c.Firstname.ToLower().Contains(name)).ToListAsync();
            }
        }

        //Oklar enligt Carl
        public static async Task<Customer> DeleteCustomer(int id)
        {
            using var ctx = new HolidayMakerGrupp2Context();

            var customerToDelete = await ctx.Customers.AsAsyncEnumerable().Where(c => c.Id == id).SingleAsync();
            ctx.Customers.Remove(customerToDelete);
            ctx.SaveChanges();
            return customerToDelete;
        }

        public static async Task<int> AddCustomer(string firstName, string lastName, string address, string city, string email, string phoneNr, int zipcode)
        {
            using var ctx = new HolidayMakerGrupp2Context();

            Guid g = Guid.NewGuid();

            var createdCustomer = await ctx.Customers.AddAsync(new Customer
            {
                Firstname = firstName,
                Lastname = lastName,
                Address = address,
                City = city,
                Email = email,
                PhoneNr = phoneNr,
                Zipcode = zipcode,
                GuId = g.ToString()
            });
            ctx.SaveChanges();
            return createdCustomer.Entity.Id;
        }

        public static async Task<int> ChangeCustomer(int id, Customer customer)
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
            ctx.SaveChanges();

            return oldCustomer.Id;
        }
    }
}