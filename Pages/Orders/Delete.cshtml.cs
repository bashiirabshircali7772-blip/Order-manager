using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASPCRUDAssignment.Data;
using ASPCRUDAssignment.Models;

namespace ASPCRUDAssignment.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Used only for displaying details on GET
        public Order Order { get; set; } = null!;

        // Only the Id is needed from the POST form
        [BindProperty]
        public int OrderId { get; set; }

        // GET: show confirmation page with order details
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            Order = order;
            OrderId = order.Id;
            return Page();
        }

        // POST: perform the deletion
        public async Task<IActionResult> OnPostAsync()
        {
            var order = await _context.Orders.FindAsync(OrderId);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Order deleted.";
            }

            return RedirectToPage("Index");
        }
    }
}
