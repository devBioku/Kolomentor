using kolomentor.Data.Base;
using kolomentor.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace kolomentor.Models
{
    public class NewMenteeVM
    {

        public int Id { get; set; }

        [Display(Name = "Enter your full name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Full Name should be between 2 and 50 characters")]
        [Required(ErrorMessage = "The Full Name Field is Required")]
        public string FullName { get; set; }


        [Display(Name = "Enter your Email ")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Email should be between 2 and 50 characters")]
        [EmailAddress(ErrorMessage = "Please check the email address")]
        [Required(ErrorMessage = "Email Field is Required")]
        public string Email { get; set; }


        //[Display(Name = "Select your Gender")]
        [Required(ErrorMessage = "Please choose your Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Choose a career")]
        [Required(ErrorMessage = "The Career Field is Required")]
        public int CareerId { get; set; }


        //[Display(Name = "What is your highest level of education")]
        [Required(ErrorMessage = "Please choose your Education Level")]
        public EducationLevel EducationLevel { get; set; }

        [Display(Name = "Describe yourself")]
        [Required(ErrorMessage = "The ExecutiveSummary Field is Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "ExecutiveSummary should be between 2 and 100 characters")]
        public string ExecutiveSummary { get; set; }


        [Display(Name = "Choose a mentor")]
        [Required(ErrorMessage = "You have to choose a mentor to complete your registration")]
        public int MentorId { get; set; }


        //[Required(ErrorMessage = "The PlaceOfWork Field is Required")]
        //[StringLength(30, MinimumLength = 2, ErrorMessage = "PlaceOfWork should be between 2 and 30 characters")]
        //public string PlaceOfWork { get; set; }

        //[Required(ErrorMessage = "The Password Field is Required")]
        //[StringLength(30, MinimumLength = 2, ErrorMessage = "Password should be between 2 and 30 characters")]
        //public string Password { get; set; }

        //[Required(ErrorMessage = "The ConfirmPassword Field is Required")]
        //[StringLength(30, MinimumLength = 2, ErrorMessage = "ConfirmPassword should be between 2 and 30 characters")]
        //public string ConfirmPassword { get; set; }

    }
}
