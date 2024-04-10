using kolomentor.Data.Base;
using kolomentor.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace kolomentor.Models
{
    public class Skill : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        [Required(ErrorMessage = "The Description field cannot be empty")]
        [StringLength(150, MinimumLength =50, ErrorMessage ="Input must be between 50 and 100 characters")]
        public string Description { get; set; }
        public int? MentorId { get; set; }
        [ForeignKey("MentorId")]
        public Mentor Mentor { get; set; }
        public List<SkillType> SkillTypes { get; set; }
    }
}
