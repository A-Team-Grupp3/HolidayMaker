namespace HolidayMakeSPA.Authentication.Options
{
    public class AuthenticationSettings
    {
        public string Secret { get; set; }
        public int ExpirationDays { get; set; }
    }
}