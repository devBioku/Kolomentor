using DocumentFormat.OpenXml.InkML;
using kolomentor.Data;
using kolomentor.Data.Services;
using kolomentor.ExtensionMethods;
using kolomentor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Controllers
{
    public class CareersController : Controller
    {
        private readonly ICareerService _service;

        public CareersController(ICareerService service)
        {
            _service = service;
        }
        public async Task<IActionResult> AllCareers()
        {
            var allCareers = await _service.GetAllAsync();
            return View(allCareers);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Category, string MentorId, string Description, Career career)
        {
            if ((Category != null && Category.Length >= 2) && (Description != null && Description.Length >= 50) && (MentorId != null))
            {
                await _service.AddAsync(career);
                return RedirectToAction("AllCareers", "Careers");

            }
            return View();

        }


        public async Task<IActionResult> Edit(int id)
        {
            var career = await _service.GetByIdAsync(id);
            if (career == null)
            {
                return View("NotFound");
            }
            return View(career);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string Category, string Description, Career career)
        {
            if ((Category != null && Category.Length >= 2) && (Description != null && Description.Length >= 50))
            {
                await _service.UpdateAsync(id, career);
                return RedirectToAction("AllCareers", "Careers");

            }
            return View(career);

        }

        public async Task<IActionResult> Details(int id)
        {

            var career = await _service.GetByIdAsync(id);
            if (career == null)
            {
                return View("NotFound");
            }
            return View(career);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var careerDetails = await _service.GetByIdAsync(id);
            if (careerDetails == null)
            {
                return View("NotFound");
            }
            return View(careerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var careerDetails = await _service.GetByIdAsync(id);
            if (careerDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction("AllCareers", "Careers");
        }


        

    }
}
