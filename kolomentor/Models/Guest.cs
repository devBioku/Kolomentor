using kolomentor.Data.Base;
using kolomentor.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolomentor.Models
{
    public class Guest : IEntityBase
    {
        public int Id { get; set; }
        public string CareerCategory { get; set; }
        public string Email { get; set; }

        //Mentor Relationship
        public int? MentorId { get; set; }
        [ForeignKey("MentorId")]
        public Mentor Mentor { get; set; }

    }
}
