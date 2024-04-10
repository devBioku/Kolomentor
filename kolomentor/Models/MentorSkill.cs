using kolomentor.Data.Base;
using kolomentor.Data.Enums;
using kolomentor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolomentor.Models
{
    public class MentorSkill: IEntityBase
    {
        public int Id { get; set; }
        public Skill? Skill { get; set; }
        public Mentor? Mentor { get; set; }

    }
}
