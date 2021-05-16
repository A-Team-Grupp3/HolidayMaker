namespace HolidayMakeSPA.Authentication.Models
{
    public class TokenResponse
    {
        public string Token { get; set; }
    }

    public class UserResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}