using kolomentor.Data.Base;
using kolomentor.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace kolomentor.Models
{
    public class SkillTypeTopic : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public int pseudoMentorId {get; set;}
        public string SkillTypeTopicTitle { get; set; }
        [Required(ErrorMessage = "The Description field cannot be empty")]
        [StringLength(150, MinimumLength =50, ErrorMessage ="Input must be between 50 and 100 characters")]
        public string SkillTypeTopicDescription { get; set; }
        public int? SkillTypeId { get; set; }
        [ForeignKey("SkillTypeId")]
        public SkillType SkillType { get; set; }
    }
}
