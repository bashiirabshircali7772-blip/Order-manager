using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ASPCRUDAssignment.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Razor Pages
builder.Services.AddRazorPages();

// Register EF Core with SQLite for portable hosting
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

// Default route → Orders index
app.MapGet("/", context =>
{
    context.Response.Redirect("/Orders");
    return Task.CompletedTask;
});

// Ensure the SQLite database is created and seeded on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();

    if (!db.Orders.Any())
    {
        db.Orders.AddRange(
            new ASPCRUDAssignment.Models.Order
            {
                CustomerName = "Bashiir Abshir Ali",
                ProductName = "Wireless Headphones",
                Quantity = 2,
                Price = 79.99m,
                OrderDate = new DateTime(2025, 1, 10)
            },
            new ASPCRUDAssignment.Models.Order
            {
                CustomerName = "Maaido Abdi Said",
                ProductName = "Mechanical Keyboard",
                Quantity = 1,
                Price = 149.95m,
                OrderDate = new DateTime(2025, 1, 15)
            },
            new ASPCRUDAssignment.Models.Order
            {
                CustomerName = "Aniso Farah Jama",
                ProductName = "USB-C Hub",
                Quantity = 3,
                Price = 34.50m,
                OrderDate = new DateTime(2025, 1, 20)
            },
            new ASPCRUDAssignment.Models.Order
            {
                CustomerName = "Mohamed Ali Nur",
                ProductName = "Laptop Stand",
                Quantity = 1,
                Price = 59.99m,
                OrderDate = new DateTime(2025, 2, 5)
            },
            new ASPCRUDAssignment.Models.Order
            {
                CustomerName = "Abdirahman Abdi Farah",
                ProductName = "Webcam HD",
                Quantity = 2,
                Price = 89.00m,
                OrderDate = new DateTime(2025, 2, 10)
            }
        );
        db.SaveChanges();
    }
}

app.Run();
