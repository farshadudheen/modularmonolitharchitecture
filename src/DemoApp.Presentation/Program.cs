using DemoApp.Domain.Models;
using DemoApp.Infrastructure.Configurations;
using DemoApp.Infrastructure.Data;
using DemoApp.Presentation.Middlewares;
using DemoApp.SharedKernel.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DemoAppDbContext>(options =>
    options.UseInMemoryDatabase("DemoApp"));
//builder.Services.AddDbContext<DemoAppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MyAppDb")));
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DemoAppDbContext>();

    // Seed initial data
    if (!context.Users.Any())
    {
        context.Users.AddRange(
            new User { Name = "Alice Smith", Email = "alice@example.com" },
            new User { Name = "Bob Johnson", Email = "bob@example.com" }
        );
        context.SaveChanges();
    }
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRequestLogging();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
