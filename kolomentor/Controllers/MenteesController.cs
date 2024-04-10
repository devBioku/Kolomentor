using Azure;
using kolomentor.Data;
using kolomentor.Data.Services;
using kolomentor.Data.ViewModel;
using kolomentor.ExtensionMethods;
using kolomentor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace kolomentor.Controllers
{
    public class MenteesController : Controller
    {
        private readonly IMenteeService _service;
        //private List<Mentor> listOfMentors;
        //private string email;

        public MenteesController(IMenteeService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Mentees()
        {
            var allMentees = await _service.GetAllAsync();
            return View(allMentees);
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






        public async Task<IActionResult> Create()
        {
            // var getMenteeObjectFromSession = HttpContext.Session.GetComplexObjectSession<SessionModel>("RegisterMentorMentees");
            // if (getMenteeObjectFromSession != null)
            // {
            //     return RedirectToAction("Account", "Mentees");
            // }
            // else
            // {
            //     var MentorAndCareerDropDownData = await _service.GetMentorandCareerDropDownValues();
            //     ViewBag.careers = new SelectList(MentorAndCareerDropDownData.Careers, "Id", "Category");
            //     ViewBag.mentors = new SelectList(MentorAndCareerDropDownData.Mentors, "Id", "FullName");
            //     ViewBag.model = MentorAndCareerDropDownData.Mentors;

            //     return View();
            // }

            var MentorAndCareerDropDownData = await _service.GetMentorandCareerDropDownValues();
            ViewBag.careers = new SelectList(MentorAndCareerDropDownData.Careers, "Id", "Category");
            ViewBag.mentors = new SelectList(MentorAndCareerDropDownData.Mentors, "Id", "FullName");
            ViewBag.model = MentorAndCareerDropDownData.Mentors;

            return View();

        }




        [HttpPost]
        public async Task<IActionResult> Create(string FullName, string Email, Enum Gender, Enum EducationLevel, int CareerId, string ExecutiveSummary, int Id, NewMenteeVM mentee)
        {
            var getMenteeObjectFromSession = HttpContext.Session.GetComplexObjectSession<SessionModel>("RegisterMentorMentees");


            mentee.MentorId = Id;

            var result = new
            {
                FullName = FullName,
                Email = Email,
                CareerId = CareerId,
                ExecutiveSummary = ExecutiveSummary,


            };
            if (result == null || mentee.Gender == null || mentee.EducationLevel == null)
            {
                var MentorAndCareerDropDownData = await _service.GetMentorandCareerDropDownValues();
                ViewBag.careers = new SelectList(MentorAndCareerDropDownData.Careers, "Id", "Category");
                ViewBag.mentors = new SelectList(MentorAndCareerDropDownData.Mentors, "Id", "FullName");
                ViewBag.model = MentorAndCareerDropDownData.Mentors;

                return View(mentee);
            }
            await _service.AddNewMenteeAsync(mentee);
            return RedirectToAction("Login", "Mentees");



        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var menteeDetails = await _service.GetByIdAsync(id);

            if (menteeDetails == null) return View("NotFound");
            return View(menteeDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var menteeDetails = await _service.GetByIdAsync(id);
            if (menteeDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Mentees));
        }

        public async Task<IActionResult> Details(int id)
        {
            var menteeDetails = await _service.GetMenteeByIdAsync(id);
            if (menteeDetails == null) return View("NotFound");
            return View(menteeDetails);
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Email)
        {
            if (Email != null)
            {
                var user = await _service.GetMenteeByEmailAsync(Email);
                if (user != null){
                    return RedirectToAction("Account", "Mentees", new { id = user.Id });
                }else
                {
                    return View();
                }
            }else{
                    return View();
            }
            

        }

        public async Task<IActionResult> Account(int id)
        {
            var menteeDetails = await _service.GetMenteeByIdAsync(id);
            if (menteeDetails == null) return View("NotFound");
            return View(menteeDetails);
        }

        [HttpPost]
        public IActionResult ChooseMentor(string FullName, string Email, Enum Gender, Enum EducationLevel, int CareerId, string ExecutiveSummary, NewMenteeVM mentee)
        {
            ViewBag.fullName = FullName;
            ViewBag.email = Email;
            ViewBag.gender = Gender;
            ViewBag.educationLevel = EducationLevel;
            ViewBag.careerId = CareerId;
            ViewBag.executiveSummary = ExecutiveSummary;

            return View();
        }

        public IActionResult ChooseMentor()
        {
            var getMenteeObjectFromSession = HttpContext.Session.GetComplexObjectSession<SessionModel>("RegisterMentorMentees");



            var mentorMenteeViewModel = new MentorMenteeViewModel();

            if (getMenteeObjectFromSession != null)
            {
                mentorMenteeViewModel.Mentee = getMenteeObjectFromSession!.Mentees!.FirstOrDefault();
            }
            return View(mentorMenteeViewModel);
        }

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var mentorDetails = _service.GetMentorByIdAsync(id);

        //    if (mentorDetails == null) return View("NotFound");

        //    var response = new NewMentorVM()
        //    {
        //        Id = mentorDetails.Id,
        //        FullName = mentorDetails.Result.FullName,
        //        Email = mentorDetails.Result.Email,
        //        Gender = mentorDetails.Result.Gender,
        //        JobTitle = mentorDetails.Result.JobTitle,
        //        ExecutiveSummary = mentorDetails.Result.ExecutiveSummary,
        //        PlaceOfWork = mentorDetails.Result.PlaceOfWork,
        //        CareerId = (int)mentorDetails.Result.CareerId,



        //    };
        //    var MentorDropDownData = await _service.GetCareerDropDownValues();
        //    ViewBag.careers = new SelectList(MentorDropDownData.Careers, "Id", "Category");
        //    return View(response);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int Id, string FullName, string Email, string JobTitle, string ExecutiveSummary, string PlaceOfWork, int CareerId, string Password, string ConfirmPassword, Enum Gender, NewMentorVM mentor)
        //{
        //    if (Id != mentor.Id && ConfirmPassword == Password)
        //    {
        //        return View("NotFound");
        //    }
        //    var result = new
        //    {
        //        FullName = FullName,
        //        Email = Email,
        //        JobTitle = JobTitle,
        //        ExecutiveSummary = ExecutiveSummary,
        //        PlaceOfWork = PlaceOfWork,
        //        CareerId = CareerId,
        //        Password = Password,
        //        ConfirmPassword = ConfirmPassword,
        //    };

        //    if (result == null || Gender == null)
        //    {
        //        var MentorDropDownData = await _service.GetCareerDropDownValues();
        //        ViewBag.careers = new SelectList(MentorDropDownData.Careers, "Id", "Category");
        //        return View(mentor);
        //    }
        //    await _service.UpdateMentorAsync(mentor);
        //    return RedirectToAction(nameof(Mentors));
        //}

    }


}
