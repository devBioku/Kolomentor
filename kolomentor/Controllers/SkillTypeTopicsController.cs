using DocumentFormat.OpenXml.InkML;
using kolomentor.Data;
using kolomentor.Data.Services;
using kolomentor.ExtensionMethods;
using kolomentor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Controllers
{
    public class SkillTypeTopicsController : Controller
    {
        private readonly ISkillTypeTopicService _service;

        public SkillTypeTopicsController(ISkillTypeTopicService service)
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
        public async Task<IActionResult> Create(string SkillTypeTopicTitle, int SkillTypeId, int pseudoMentorId, string SkillTypeTopicDescription, SkillType skillType, SkillTypeTopic skillTypeTopic, Mentor mentor)
        {
            if ((SkillTypeTopicTitle != null) && (SkillTypeTopicDescription != null) && (SkillTypeId != null))
            {
                await _service.AddAsync(skillTypeTopic);
                //return RedirectToAction("AllSkills", "Skills");
                return RedirectToAction("Details", "Mentors", new { id = pseudoMentorId });
            }
            //var skillobject = new Skill();
            ViewBag.skillTypeId = skillType.Id;
            ViewBag.pseudoMentorId = mentor.Id;

            return View();

        }

        // public async Task<IActionResult> Edit(int id)
        // {
        //     var skill = await _service.GetByIdAsync(id);
        //     if (skill == null)
        //     {
        //         return View("NotFound");
        //     }
        //     ViewBag.skillTypeId = skill.SkillTypeId;
        //     return View(skill);
        // }

        public async Task<IActionResult> Edit(int id, int pseudoMentorId)
        {
            var skillTypeTopic = await _service.GetSkillTypeTopicByIdAsync(id);
            if (skillTypeTopic == null)
            {
                return View("NotFound");
            }

            ViewBag.skillTypeId = skillTypeTopic.Id;
            ViewBag.pseudoMentorId = skillTypeTopic.pseudoMentorId;
            
            return View(skillTypeTopic);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string SkillTypeTopicTitle, string SkillTypeTopicDescription, SkillTypeTopic skillTypeTopic)
        {
            if ((SkillTypeTopicTitle != null) && (SkillTypeTopicDescription != null))
            {
                await _service.UpdateAsync(id, skillTypeTopic);
                return RedirectToAction("Configuration", "Mentors", new { id = skillTypeTopic.pseudoMentorId });
                //return RedirectToAction("AllSkills", "Skills");
            }
            return View(skillTypeTopic);

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
