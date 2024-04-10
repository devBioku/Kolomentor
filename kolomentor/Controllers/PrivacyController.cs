using kolomentor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Controllers
{
    public class PrivacyController : Controller
    {
        private readonly AppDbContext _context;

        public PrivacyController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Privacy()
        {
            var allCareers = await _context.Careers.ToListAsync();
            return View();
        }
    }

}
