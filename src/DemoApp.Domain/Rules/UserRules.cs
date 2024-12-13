namespace DemoApp.Domain.Rules
{
    public static class UserRules
    {
        public static bool IsValidEmail(string email) => email.Contains("@");
    }
}
