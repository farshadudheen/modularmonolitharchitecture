namespace DemoApp.Domain.Rules
{
    public static class ProductRules
    {
        public static bool IsPriceValid(decimal price) => price > 0;
    }
}
