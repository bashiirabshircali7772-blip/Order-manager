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
        // Waxaan halkan ku darnay 'int id' si uu u akhriyo id-ga url-ka ku jira
        public async Task<IActionResult> OnPostAsync(int id)
        {
            // Remove TotalValue from validation (it's [NotMapped] computed)
            ModelState.Remove("Order.TotalValue");

            if (!ModelState.IsValid)
                return Page();

            // Waxaan isticmaalaynaa 'id' si aan u soo helno xogta saxda ah
            var orderInDb = await _context.Orders.FindAsync(id);
            if (orderInDb == null)
                return NotFound();

            // Waxaan koobiyeynaa xogtii cusubayd ee form-ka laga soo buuxiyey
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