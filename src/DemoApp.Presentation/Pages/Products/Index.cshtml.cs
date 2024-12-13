using DemoApp.Application.Interfaces;
using DemoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp.Presentation.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        // Define the Products property to hold the list of products
        public List<Product> Products { get; set; } = new();

        // This method is called on GET requests
        public void OnGet()
        {
            Products = _productService.GetAllProducts().ToList(); // Fetch products from the service
        }

        // This method is called on POST requests
        public IActionResult OnPost(string name, decimal price)
        {
            _productService.AddProduct(name, price); // Add a new product using the service
            return RedirectToPage(); // Redirect back to the same page to display updated products
        }
    }
}
