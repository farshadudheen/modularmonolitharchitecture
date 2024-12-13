namespace DemoApp.Domain.ValueObjects
{
    //Records are immutable by default, meaning their properties cannot be changed after initialization.
    public record Address(string Street, string City, string ZipCode);
}
