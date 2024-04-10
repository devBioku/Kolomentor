using kolomentor.Models;
using kolomentor.Data.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolomentor.Models
{
    public class Mentorship : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public int? MenteeId { get; set; }
        [ForeignKey("MenteeId")]
        public Mentee? Mentee { get; set; }

        public int? MentorId { get; set; }
        [ForeignKey("MentorId")]
        public Mentor? Mentor { get; set; }

    }
}
