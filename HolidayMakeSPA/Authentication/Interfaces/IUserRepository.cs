using HolidayMakeSPA.Authentication.Models;
using System.Threading;
using System.Threading.Tasks;

namespace HolidayMakeSPA.Authentication.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AuthenticateAsync(string email, string password, CancellationToken cancellationToken = default);

        Task<bool> SignUpAsync(User user, string password, CancellationToken cancellationToken = default);

        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}