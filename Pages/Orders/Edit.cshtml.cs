using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPCRUDAssignment.Data;
using ASPCRUDAssignment.Models;

namespace ASPCRUDAssignment.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; } = null!;

        // GET: load the order for editing
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            Order = order;
            return Page();
        }

        // POST: save changes
        public async Task<IActionResult> OnPostAsync()
        {
            // Remove TotalValue from validation (it's [NotMapped] computed)
            ModelState.Remove("Order.TotalValue");

            if (!ModelState.IsValid)
                return Page();

            var orderInDb = await _context.Orders.FindAsync(Order.Id);
            if (orderInDb == null)
                return NotFound();

            // Manually copy updated values onto the tracked entity
            orderInDb.CustomerName = Order.CustomerName;
            orderInDb.ProductName  = Order.ProductName;
            orderInDb.Quantity     = Order.Quantity;
            orderInDb.Price        = Order.Price;
            orderInDb.OrderDate    = Order.OrderDate;

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Order updated successfully!";
            return RedirectToPage("Index");
        }
    }
}
