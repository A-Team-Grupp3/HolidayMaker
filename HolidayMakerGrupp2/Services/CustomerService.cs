using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerGrupp2.Models.Database;

namespace HolidayMakerGrupp2.Services
{
    public class CustomerService
    {
        private HolidayMakerGrupp2Context ctx = new HolidayMakerGrupp2Context();
        


        public CustomerService()
        {

        }

        public IEnumerable<Customer> Get()
        {
            return ctx.Customers.ToList();
        }

        public IEnumerable<Customer> GetById(int id)
        {
            var customer = ctx.Customers.Where(c => c.Id == id);

            return customer;
        }

        public IEnumerable<Customer> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return ctx.Customers.ToList();
            }
            else
            {
                return ctx.Customers.Where(c => c.Firstname.ToLower().Contains(name)).ToList();
            }
        }

        //Oklar enligt Carl
        public string DeleteCustomer(int id)
        {
            var customerToDelete = ctx.Customers.Where(c => c.Id == id).Single<Customer>(); //Behövs single<Customer>?
            ctx.Customers.Remove(customerToDelete);
            ctx.SaveChanges();
            return "Customer was succesfully Deleted"; //Ändras till något annat?
        }

        public int AddCustomer(string firstName, string lastName, string address, string city, string email, string phoneNr, int zipcode)
        {
            Guid g = Guid.NewGuid();


            var createdCustomer = ctx.Customers.Add(new Customer
            {


                Firstname = firstName,
                Lastname = lastName,
                Address = address,
                City = city,
                Email = email,
                PhoneNr = phoneNr,
                Zipcode = zipcode,
                GuId = g.ToString()



            }) ;
            ctx.SaveChanges();
            return createdCustomer.Entity.Id;
        }

    }
}
