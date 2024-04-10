using DocumentFormat.OpenXml.InkML;
using kolomentor.Data;
using kolomentor.Data.Services;
using kolomentor.ExtensionMethods;
using kolomentor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Controllers
{
    public class SkillTypesController : Controller
    {
        private readonly ISkillTypeService _service;

        public SkillTypesController(ISkillTypeService service)
        {
            _service = service;
        }
        public async Task<IActionResult> AllSkillTypes()
        {
            var allSkills = await _service.GetAllAsync();
            return View(allSkills);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string SkillTypeTitle, int SkillId, int pseudoMentorId, string SkillTypeTitleDescription, Skill skill, SkillType skillType, Mentor mentor)
        {
            if ((SkillTypeTitle != null) && (SkillTypeTitleDescription != null) && (SkillId != null))
            {

                await _service.AddAsync(skillType);
                // return RedirectToAction("AllSkills", "Skills");
                return RedirectToAction("Details", "Mentors", new { id = pseudoMentorId });


            }
            //var skillobject = new Skill();
            ViewBag.skillId = skill.Id;
            ViewBag.pseudoMentorId =mentor.Id;

            return View();

        }

        

        public async Task<IActionResult> Edit(int id, Mentor mentor)
        {
            var skillType = await _service.GetSkillTypeByIdAsync(id);
            if (skillType == null)
            {
                return View("NotFound");
            }
            ViewBag.skillId = skillType.SkillId;
            ViewBag.pseudoMentorId = skillType.Skill.MentorId;

            return View(skillType );
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string SkillTypeTitle, string SkillTypeTitleDescription, SkillType skillType, Mentor mentor, int pseudoMentorId)
        {
            if ((SkillTypeTitle != null) && (SkillTypeTitleDescription != null))
            {
                await _service.UpdateAsync(id, skillType);
                // return RedirectToAction("Configuration", "Mentors", new { id = skillType.Skill.MentorId });
                // return RedirectToAction("AllSkills", "Skills");
                return RedirectToAction("Configuration", "Mentors", new { id = pseudoMentorId });
            }
            
            ViewBag.pseudoMentorId =mentor.Id;
            return RedirectToAction("Configuration", "Mentors", new { id = pseudoMentorId });
        }

        public async Task<IActionResult> Details(int id, SkillType getskillType, Mentor mentor)
        {
            
            var skillTypeId = getskillType.Id;
            var skillType = await _service.GetByIdAsync(id);
            if (skillType == null)
            {
                return View("NotFound");
            }
            return View(skillType);
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
