using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace kolomentor.Models
{

    public class Material
    {
        [Key]
        public int Id { get; set; }
        public string Video { get; set; }
        public string Pdf { get; set; }
        public string Images { get; set; }
        public string Other { get; set; }

        //Mentor Resource Relationship
        public List<Mentor_Material> Mentors_Materials { get; set; }
    }
}
