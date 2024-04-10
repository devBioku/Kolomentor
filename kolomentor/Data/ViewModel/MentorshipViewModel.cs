using kolomentor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace kolomentor.Data.ViewModel
{
    public class MentorshipViewModel
    {
        public Mentee? Mentee { get; set; }
        public Mentor? Mentor { get; set; }

    }
}
