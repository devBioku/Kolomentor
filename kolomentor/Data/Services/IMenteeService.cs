using kolomentor.Data.Base;
using kolomentor.Data.ViewModel;
using kolomentor.Models;

namespace kolomentor.Data.Services
{
    public interface IMenteeService : IEntityBaseRepository<Mentee>
    {
        Task<DropDownMentorandCareer> GetMentorandCareerDropDownValues();

        Task<Mentee> GetMenteeByIdAsync(int Id);
        Task<Mentee> GetMenteeByEmailAsync(string Email);

        Task AddNewMenteeAsync(NewMenteeVM data);
    }
}
