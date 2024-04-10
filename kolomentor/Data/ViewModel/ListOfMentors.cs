using kolomentor.Models;

namespace kolomentor.Data.ViewModel
{
    public class ListOfMentors
    {
        public ListOfMentors()
        {
            Mentors = new List<Mentor> { new Mentor() };
        }
        public List<Mentor> Mentors { get; set; }
    }
}
