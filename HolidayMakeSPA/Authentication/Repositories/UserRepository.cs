using HolidayMakeSPA.Authentication.Interfaces;
using HolidayMakeSPA.Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HolidayMakeSPA.Authentication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserRepository(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<bool> AuthenticateAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            var result = await signInManager.PasswordSignInAsync(email, password, false, false);
            return result.Succeeded;
        }

        public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await userManager.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<bool> SignUpAsync(User user, string password, CancellationToken cancellationToken = default)
        {
            var result = await userManager.CreateAsync(user, password);
            return result.Succeeded;
        }
    }
}