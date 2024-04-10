using kolomentor.Data.Base;
using kolomentor.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolomentor.Models
{
    public class NewMentorVM
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Full Name should be between 2 and 20 characters")]
        [Required(ErrorMessage = "The Full Name Field is Required")]
        public string FullName { get; set; }


        [StringLength(50, MinimumLength = 2, ErrorMessage = "Email should be between 2 and 20 characters")]
        [EmailAddress(ErrorMessage = "Please check the email address")]
        [Required(ErrorMessage = "The Email Field is Required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please choose your Gender")]
        public Gender Gender { get; set; }


        [Required(ErrorMessage = "The Job Title Field is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Profession should be between 2 and 15 characters")]
        public string JobTitle { get; set; }



        [Required(ErrorMessage = "The ExecutiveSummary Field is Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "ExecutiveSummary should be between 2 and 15 characters")]
        public string ExecutiveSummary { get; set; }



        [Required(ErrorMessage = "The PlaceOfWork Field is Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "PlaceOfWork should be between 2 and 30 characters")]
        public string PlaceOfWork { get; set; }

        [Required(ErrorMessage = "The Password Field is Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Password should be between 2 and 30 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The ConfirmPassword Field is Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "ConfirmPassword should be between 2 and 30 characters")]
        public string ConfirmPassword { get; set; }



        [Required(ErrorMessage = "The MaterialIds Field is Required")]
        public List<int> MaterialIds { get; set; }

        //Career
        public int CareerId { get; set; }
    }
}
