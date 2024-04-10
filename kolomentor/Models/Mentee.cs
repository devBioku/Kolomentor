using kolomentor.Data.Base;
using kolomentor.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace kolomentor.Models
{
    public class Mentee : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string ExecutiveSummary { get; set; }
        public EducationLevel EducationLevel { get; set; }

        //Mentor Relationship
        public int? MentorId { get; set; }
        [ForeignKey("MentorId")]
        public Mentor Mentor { get; set; }

        public int? CareerId { get; set; }
        [ForeignKey("CareerId")]
        public Career Career { get; set; }


    }
}
