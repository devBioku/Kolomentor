using DocumentFormat.OpenXml.InkML;
using kolomentor.Data;
using kolomentor.Data.Services;
using kolomentor.ExtensionMethods;
using kolomentor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Controllers
{
    public class MentorshipController : Controller
    {
        private readonly IMentorshipService _service;

        public MentorshipController(IMentorshipService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Details(int id)
        {
            var Details = await _service.GetByIdAsync(id);
            if (Details == null) return View("NotFound");
            return View(Details);
        }

    }
}
