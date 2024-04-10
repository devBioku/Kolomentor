using kolomentor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Controllers
{
    public class GuestsController : Controller
    {
        private readonly AppDbContext _context;

        public GuestsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Guests()
        {
            var allGuests = await _context.Mentors.ToListAsync();
            return View(allGuests);
        }
    }


}
