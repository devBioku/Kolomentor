using kolomentor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using kolomentor.Data.Services;


namespace kolomentor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMentorService _service; 

        public HomeController(ILogger<HomeController> logger, IMentorService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMentors = await _service.GetAllAsync(n => n.Career);
            return View(allMentors);
        }

        //         public async Task<IActionResult> Mentors()
        // {
        //     // var allMentors = await _service.GetAllAsync(n => n.Career);
        //     var allMentors = await _service.GetAllMentorAsync();
        //     return View(allMentors);
        // }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}