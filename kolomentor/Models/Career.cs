using DocumentFormat.OpenXml.Wordprocessing;
using kolomentor.Data.Base;
using kolomentor.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolomentor.Models
{
    public class Career : IEntityBase
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The System Cannot Identify you as a mentor")]
        public int MentorId { get; set; }

        [Display(Name = "Career Title")]
        [Required(ErrorMessage = "The Career field cannot be empty")]
        [StringLength(25, MinimumLength =2, ErrorMessage ="Input must be between 2 and 25 characters")]
        public string Category { get; set; }

        [Display(Name = "Career Description")]
        [Required(ErrorMessage = "The Description field cannot be empty")]
        [StringLength(200, MinimumLength = 50, ErrorMessage = "Input must be between 50 and 200 characters")]
        public string Description { get; set; }

        // Mentor Relationship
        public List<Mentor> Mentors { get; set; }

        public List<Mentee> Mentees { get; set; }
    }
}
