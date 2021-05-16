using HolidayMakeSPA.Authentication.Interfaces;
using HolidayMakeSPA.Authentication.Models;
using HolidayMakeSPA.Authentication.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HolidayMakeSPA.Authentication.Services
{
    public class UserService : IUserService
    {
        private readonly AuthenticationSettings authenticationSettings;
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository, IOptions<AuthenticationSettings> options)
        {
            this.userRepository = userRepository;
            this.authenticationSettings = options.Value;
        }

        public async Task<UserResponse> GetUserAsync(GetUserRequest request, CancellationToken cancellationToken = default)
        {
            var response = await userRepository.GetByEmailAsync(request.Email, cancellationToken);
            return new UserResponse { Name = response.Name, Email = response.Email };
        }

        public async Task<TokenResponse> SignInAsync(SignInRequest request, CancellationToken cancellationToken = default)
        {
            bool response = await userRepository.AuthenticateAsync(request.Email, request.Password, cancellationToken);
            return response == false ? null : new TokenResponse { Token = GenerateSecurityToken(request) };
        }

        public async Task<UserResponse> SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default)
        {
            var user = new User { Email = request.Email, UserName = request.Email, Name = request.Name };
            bool result = await userRepository.SignUpAsync(user, request.Password, cancellationToken);
            return !result ? null : new UserResponse { Name = request.Name, Email = request.Email };
        }

        private string GenerateSecurityToken(SignInRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(authenticationSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Email, request.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(authenticationSettings.ExpirationDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}