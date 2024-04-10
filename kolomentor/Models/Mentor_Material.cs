using System.ComponentModel.DataAnnotations.Schema;

namespace kolomentor.Models
{

    public class Mentor_Material
    {
        //Mentor Relationship
        public int? MentorId { get; set; }
        [ForeignKey("MentorId")]
        public Mentor Mentor { get; set; }

        //Resource Relationship
        public int? MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        public Material Material { get; set; }
    }
}
