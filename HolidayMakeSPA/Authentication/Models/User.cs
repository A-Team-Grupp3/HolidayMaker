using Microsoft.AspNetCore.Identity;

namespace HolidayMakeSPA.Authentication.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}