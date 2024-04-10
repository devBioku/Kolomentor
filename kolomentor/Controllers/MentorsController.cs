using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using kolomentor.Data;
using kolomentor.Data.Services;
using kolomentor.Data.ViewModel;
using kolomentor.ExtensionMethods;
using kolomentor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nest;
using System;
using System.Diagnostics.Metrics;

namespace kolomentor.Controllers
{
    public class MentorsController : Controller
    {
        private readonly IMentorService _service;


        public MentorsController(IMentorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Detail()
        {
            return View();
        }

        private void KeepMenteeInformation(Mentee mentee)
        {

            var getMenteeObject = HttpContext.Session.GetComplexObjectSession<SessionModel>("RegisterMentorMentees");
            if (getMenteeObject != null)
            {
                getMenteeObject!.Mentees!.Add(mentee);
                HttpContext.Session.SetComplexObjectSession("RegisterMentorMentees", getMenteeObject);
            }
            else
            {
                getMenteeObject = new SessionModel();
                getMenteeObject!.Mentees!.Add(mentee);
                HttpContext.Session.SetComplexObjectSession("RegisterMentorMentees", getMenteeObject);
            }
        }

        public async Task<IActionResult> Mentors()
        {
            var allMentors = await _service.GetAllAsync(n => n.Career);
            return View(allMentors);
        }

        public async Task<IActionResult> SelectMentor(Mentee mentee)
        {

            var allMentors = await _service.GetAllAsync(n => n.Career);
            KeepMenteeInformation(mentee);
            var mentorMenteeModel = new MentorMenteeModel();

            var getMenteeObjectFromSession = HttpContext.Session.GetComplexObjectSession<SessionModel>("RegisterMentorMentees");


            if (getMenteeObjectFromSession != null)
            {

                mentorMenteeModel.Mentee = getMenteeObjectFromSession!.Mentees!.Last();


            }

            ViewBag.FullName = mentorMenteeModel.Mentee.FullName;
            ViewBag.Email = mentorMenteeModel.Mentee.Email;
            ViewBag.Gender = mentorMenteeModel.Mentee.Gender;
            ViewBag.EducationLevel = mentorMenteeModel.Mentee.EducationLevel;
            ViewBag.CareerId = mentorMenteeModel.Mentee.CareerId;
            ViewBag.ExecutiveSummary = mentorMenteeModel.Mentee.ExecutiveSummary;
            


            // return View(response.Mentors);
            return View(allMentors);
        }


        public async Task<IActionResult> Details(int id, Mentee mentee, Mentor mentor)
        {
            var mentorDetails = await _service.GetMentorByIdAsync(id);

            if (mentorDetails == null) return View("NotFound");

            //KeepMenteeInformation(mentee);
            var mentorMenteeModel = new MentorMenteeModel();

            var getMenteeObjectFromSession = HttpContext.Session.GetComplexObjectSession<SessionModel>("RegisterMentorMentees");
            
            ViewBag.MentorName = mentorDetails.FullName;
            ViewBag.MentorJobTitle = mentorDetails.JobTitle;
            return View(mentorDetails);

        }

        public async Task<IActionResult> Configuration(int id, Mentee mentee, Mentor mentor)
        {
            var mentorDetails = await _service.GetMentorByIdAsync(id);

            if (mentorDetails == null) return View("NotFound");

            //KeepMenteeInformation(mentee);
            var mentorMenteeModel = new MentorMenteeModel();

            var getMenteeObjectFromSession = HttpContext.Session.GetComplexObjectSession<SessionModel>("RegisterMentorMentees");
            
            ViewBag.MentorName = mentorDetails.FullName;
            ViewBag.MentorJobTitle = mentorDetails.JobTitle;
            return View(mentorDetails);

        }


        public async Task<IActionResult> ConfirmMentor(int id, Mentee mentee)
        {
            var mentorDetails = await _service.GetMentorByIdAsync(id);

            if (mentorDetails == null) return View("NotFound");

            //KeepMenteeInformation(mentee);
            var mentorMenteeModel = new MentorMenteeModel();

            var getMenteeObjectFromSession = HttpContext.Session.GetComplexObjectSession<SessionModel>("RegisterMentorMentees");


            if (getMenteeObjectFromSession != null)
            {

                mentorMenteeModel.Mentee = getMenteeObjectFromSession!.Mentees!.FirstOrDefault();


            }

            ViewBag.FullName = mentorMenteeModel.Mentee.FullName;
            ViewBag.Email = mentorMenteeModel.Mentee.Email;
            ViewBag.Gender = mentorMenteeModel.Mentee.Gender;
            ViewBag.EducationLevel = mentorMenteeModel.Mentee.EducationLevel;
            ViewBag.CareerId = mentorMenteeModel.Mentee.CareerId;
            ViewBag.ExecutiveSummary = mentorMenteeModel.Mentee.ExecutiveSummary;
            ViewBag.MentorName = mentorDetails.FullName;
            ViewBag.MentorJobTitle = mentorDetails.JobTitle;

            return View(mentorDetails);

        }

        public async Task<IActionResult> Create()
        {
            var MentorDropDownData = await _service.GetCareerDropDownValues();
            ViewBag.careers = new SelectList(MentorDropDownData.Careers, "Id", "Category");
            return View();
        }

        //public async Task<IActionResult> Create()
        //{
        //    var MentorDropDownData = await _service.GetCareerDropDownValues();
        //    ViewBag.careers = new SelectList(MentorDropDownData.Careers, "Id", "Category");
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Create(string FullName, string Email, string JobTitle, string ExecutiveSummary, string PlaceOfWork, string Password, string ConfirmPassword, int CareerId, Enum Gender, NewMentorVM mentor)
        {
            var result = new
            {
                FullName = FullName,
                Email = Email,
                JobTitle = JobTitle,
                ExecutiveSummary = ExecutiveSummary,
                PlaceOfWork = PlaceOfWork,
                CareerId = CareerId,
                Password = Password,
                ConfirmPassword = ConfirmPassword,

            };

            if (result == null || mentor.Gender == null)
            {
                var MentorDropDownData = await _service.GetCareerDropDownValues();
                ViewBag.careers = new SelectList(MentorDropDownData.Careers, "Id", "Category");
                return View(mentor);
            }
            await _service.AddNewMentorAsync(mentor);
            return RedirectToAction(nameof(Mentors));
        }






        public async Task<IActionResult> Edit(int id)
        {
            var mentorDetails = _service.GetMentorByIdAsync(id);

            if (mentorDetails == null) return View("NotFound");

            var response = new NewMentorVM()
            {
                Id = mentorDetails.Id,
                FullName = mentorDetails.Result.FullName,
                Email = mentorDetails.Result.Email,
                Gender = mentorDetails.Result.Gender,
                JobTitle = mentorDetails.Result.JobTitle,
                ExecutiveSummary = mentorDetails.Result.ExecutiveSummary,
                PlaceOfWork = mentorDetails.Result.PlaceOfWork,
                CareerId = (int)mentorDetails.Result.CareerId,



            };
            var MentorDropDownData = await _service.GetCareerDropDownValues();
            ViewBag.careers = new SelectList(MentorDropDownData.Careers, "Id", "Category");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, string FullName, string Email, string JobTitle, string ExecutiveSummary, string PlaceOfWork, int CareerId, string Password, string ConfirmPassword, Enum Gender, NewMentorVM mentor)
        {
            if (Id != mentor.Id && ConfirmPassword == Password)
            {
                return View("NotFound");
            }
            var result = new
            {
                FullName = FullName,
                Email = Email,
                JobTitle = JobTitle,
                ExecutiveSummary = ExecutiveSummary,
                PlaceOfWork = PlaceOfWork,
                CareerId = CareerId,
                Password = Password,
                ConfirmPassword = ConfirmPassword,
            };

            if (result == null || Gender == null)
            {
                var MentorDropDownData = await _service.GetCareerDropDownValues();
                ViewBag.careers = new SelectList(MentorDropDownData.Careers, "Id", "Category");
                return View(mentor);
            }
            await _service.UpdateMentorAsync(mentor);
            return RedirectToAction(nameof(Mentors));
        }


        public async Task<IActionResult> DeleteAsync(int id)
        {
            var mentorDetails = await _service.GetByIdAsync(id);
            if (mentorDetails == null) return View("NotFound");
            return View(mentorDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var mentorDetails = await _service.GetByIdAsync(id);
            if (mentorDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Mentors));
        }

        public async Task<IActionResult> Dashboard(int id, Mentee mentee, Mentor mentor)
        {
            var mentorDetails = await _service.GetMentorByIdAsync(id);

            if (mentorDetails == null) return View("NotFound");

            //KeepMenteeInformation(mentee);
            var mentorMenteeModel = new MentorMenteeModel();

            var getMenteeObjectFromSession = HttpContext.Session.GetComplexObjectSession<SessionModel>("RegisterMentorMentees");
            
            ViewBag.MentorName = mentorDetails.FullName;
            ViewBag.MentorJobTitle = mentorDetails.JobTitle;
            return View(mentorDetails);

        }

  
    }

}
