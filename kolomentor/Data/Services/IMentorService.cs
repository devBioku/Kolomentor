using kolomentor.Data.Base;
using kolomentor.Data.ViewModel;
using kolomentor.Models;

namespace kolomentor.Data.Services
{
    public interface IMentorService : IEntityBaseRepository<Mentor>
    {

        Task<Mentor> GetMentorByIdAsync(int Id);
        Task<DropDownCareer> GetCareerDropDownValues();
        Task AddNewMentorAsync(NewMentorVM data);
        Task UpdateMentorAsync(NewMentorVM data);
        Task<Mentor>GetAllMentorAsync();
    }
}
