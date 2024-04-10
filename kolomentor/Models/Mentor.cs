using kolomentor.Data.Base;
using kolomentor.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolomentor.Models
{
    public class Mentor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Full Name should be between 2 and 20 characters")]
        [Required(ErrorMessage = "The Full Name Field is Required")]
        public string FullName { get; set; }


        [StringLength(50, MinimumLength = 2, ErrorMessage = "Email should be between 2 and 20 characters")]
        [EmailAddress(ErrorMessage = "Please check the email address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please choose your Gender")]
        public Gender Gender { get; set; }


        [Required(ErrorMessage = "The Job title Field is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Job title should be between 2 and 15 characters")]
        public string JobTitle { get; set; }


        [Required(ErrorMessage = "The Executive Summary Field is Required")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Executive Summary should be between 2 and 15 characters")]
        public string ExecutiveSummary { get; set; }



        [Required(ErrorMessage = "The Place Of Work Field is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Place Of Work should be between 2 and 15 characters")]
        public string PlaceOfWork { get; set; }



        //Mentee Relationship
        public List<Mentee> Mentees { get; set; }

        //Guest Relationship
        public List<Guest> Guests { get; set; }

        public List<Skill> Skills { get; set; }



        //Career
        public int? CareerId { get; set; }
        [ForeignKey("CareerId")]
        public Career Career { get; set; }

        //Mentor Resource Relationship
        public List<Mentor_Material> Mentors_Materials { get; set; }
    }
}
