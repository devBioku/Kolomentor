using kolomentor.Data.Base;
using kolomentor.Data.Enums;
using kolomentor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolomentor.Models
{
    public class MentorMenteeModel : IEntityBase
    {
        public int Id { get; set; }
        public Mentee? Mentee { get; set; }
        public Mentor? Mentor { get; set; }
        public int? CareerId { get; set; }
        [ForeignKey("CareerId")]
        public Career Career { get; set; }
        public int MentorId { get; set; }

    }
}
