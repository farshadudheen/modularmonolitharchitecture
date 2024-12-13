using DemoApp.Application.Interfaces;
using DemoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp.Presentation.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        // Define the Users property to hold the list of users
        public List<User> Users { get; set; } = new();

        // This method is called on GET requests
        public void OnGet()
        {
            Users = _userService.GetAllUsers().ToList(); // Fetch users from the service
        }

        // This method is called on POST requests
        public IActionResult OnPost(string name, string email)
        {
            _userService.CreateUser(name, email); // Add a new user using the service
            return RedirectToPage(); // Redirect back to the same page to display updated users
        }
    }
}
