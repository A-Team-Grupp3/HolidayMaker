using HolidayMakeSPA.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HolidayMakeSPA.Authentication.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> GetUserAsync(GetUserRequest request, CancellationToken cancellationToken = default);

        Task<UserResponse> SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default);

        Task<TokenResponse> SignInAsync(SignInRequest request, CancellationToken cancellationToken = default);
    }
}