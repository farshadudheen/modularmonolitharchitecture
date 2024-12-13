namespace DemoApp.Application.DTOs
{
    //DTO (Data Transfer Object) is a simple object that is used to transfer data between different layers
    public record UserDTO(int Id, string Name, string Email);
}
