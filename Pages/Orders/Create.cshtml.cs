using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASPCRUDAssignment.Data;
using ASPCRUDAssignment.Models;

namespace ASPCRUDAssignment.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; } = new Order();

        // GET: display blank form
        public IActionResult OnGet()
        {
            return Page();
        }

        // POST: save new order
        public async Task<IActionResult> OnPostAsync()
        {
            // TotalValue is [NotMapped] computed — remove it from validation
            ModelState.Remove("Order.TotalValue");

            if (!ModelState.IsValid)
                return Page();

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Order created successfully!";
            return RedirectToPage("Index");
        }
    }
}
