using kolomentor.Data.Base;
using kolomentor.Models;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Data.Services
{

    public class SkillTypeService : EntityBaseRepository<SkillType>, ISkillTypeService
    {
        private readonly AppDbContext _appDbcontext;

        public SkillTypeService(AppDbContext appDbcontext) : base(appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        public async Task<SkillType> GetSkillTypeByIdAsync(int Id)
        {
            try
            {
                var skillDetails = await _appDbcontext.SkillTypes
                    .Include(sk => sk.Skill)
                    .FirstOrDefaultAsync(n => n.Id == Id);
                return skillDetails;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
            
        }
    }
}
