using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPCRUDAssignment.Data;
using ASPCRUDAssignment.Models;

namespace ASPCRUDAssignment.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Orders { get; set; } = new List<Order>();

        public async Task OnGetAsync()
        {
            Orders = await _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }
}
