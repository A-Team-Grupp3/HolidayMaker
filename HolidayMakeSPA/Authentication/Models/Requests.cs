namespace HolidayMakeSPA.Authentication.Models
{
    public class GetUserRequest
    {
        public string Email { get; set; }
    }

    public class SignInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignUpRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}