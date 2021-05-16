using HolidayMakeSPA.Authentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HolidayMakeSPA.Authentication.Context
{
    public class AuthenticationContext : IdentityDbContext<User>
    {
        public AuthenticationContext()
        {
        }

        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}