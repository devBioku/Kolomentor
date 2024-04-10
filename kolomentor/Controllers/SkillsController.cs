using DocumentFormat.OpenXml.InkML;
using kolomentor.Data;
using kolomentor.Data.Services;
using kolomentor.ExtensionMethods;
using kolomentor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillService _service;

        public SkillsController(ISkillService service)
        {
            _service = service;
        }
        public async Task<IActionResult> AllSkills()
        {
            var allSkills = await _service.GetAllAsync();
            return View(allSkills);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(string Title, int MentorId, string Description, Mentor mentor, Skill skill)
        {
            if ((Title != null) && (Description != null) && (MentorId != null))
            {

                await _service.AddAsync(skill);
                // return RedirectToAction("AllSkills", "Skills");
                return RedirectToAction("Details", "Mentors", new { id = MentorId });

            }
            //var skillobject = new Skill();
            ViewBag.mentorId = mentor.Id;

            return View();

        }

        public async Task<IActionResult> Edit(int id)
        {
            var skill = await _service.GetByIdAsync(id);
            if (skill == null)
            {
                return View("NotFound");
            }
            ViewBag.mentorId = skill.MentorId;
            return View(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string Title, string Description, Skill skill)
        {
            if ((Title != null) && (Description != null))
            {
                await _service.UpdateAsync(id, skill);
                return RedirectToAction("Configuration", "Mentors", new { id = skill.MentorId });


            }
            return View(skill);

        }

        public async Task<IActionResult> Details(int id)
        {

            var skill = await _service.GetByIdAsync(id);
            if (skill == null)
            {
                return View("NotFound");
            }
            return View(skill);
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
            var skillDetails = await _service.GetByIdAsync(id);
            if (skillDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction("AllSkills", "Skills");
        }
    }
}
