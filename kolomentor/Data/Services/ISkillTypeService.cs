using kolomentor.Data.Base;
using kolomentor.Models;

namespace kolomentor.Data.Services
{
    public interface ISkillTypeService: IEntityBaseRepository<SkillType>
    {
        Task<SkillType> GetSkillTypeByIdAsync(int Id);


    }
}
