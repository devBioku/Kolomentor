using kolomentor.Data.Base;
using kolomentor.Models;

namespace kolomentor.Data.Services
{
    public interface ISkillTypeTopicService: IEntityBaseRepository<SkillTypeTopic>
    {

        Task<SkillTypeTopic> GetSkillTypeTopicByIdAsync(int Id);


    }
}
