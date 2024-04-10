using kolomentor.Models;

namespace kolomentor.Data.ViewModel
{
    public class DropDownCareer
    {
        public DropDownCareer()
        {
            Careers = new List<Career> 
            { 
                new Career()
            };
        }
        public List<Career> Careers { get; set; }
    }
}
