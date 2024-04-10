using kolomentor.Data.Base;
using kolomentor.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace kolomentor.Models
{
    public class SkillType : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public int pseudoMentorId { get; set;}
        public string SkillTypeTitle { get; set; }
        [Required(ErrorMessage = "The Skill Type Description field cannot be empty")]
        [StringLength(150, MinimumLength =50, ErrorMessage ="Input must be between 50 and 100 characters")]
        public string SkillTypeTitleDescription { get; set; }
        public int? SkillId { get; set; }
        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }
        public List<SkillTypeTopic> SkillTypeTopics { get; set; }



    }
}
