using kolomentor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace kolomentor.Data.ViewModel
{
    public class MentorMenteeViewModel
    {
        public Mentee? Mentee { get; set; }
        public int MentorId { get; set; }
        public IEnumerable<SelectListItem>? Mentors { get; set; }
    }
}
