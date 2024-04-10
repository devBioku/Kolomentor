using kolomentor.Models;

namespace kolomentor.Data.ViewModel
{
    public class DropDownMentorandCareer
    {
        public DropDownMentorandCareer()
        {
            Mentors = new List<Mentor> { new Mentor() };
            Careers = new List<Career> { new Career() };
        }
        public List<Mentor> Mentors { get; set; }
        public List<Career> Careers { get; set; }

    }
}
