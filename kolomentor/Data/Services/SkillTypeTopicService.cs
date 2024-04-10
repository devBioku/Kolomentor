using kolomentor.Data.Base;
using kolomentor.Models;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Data.Services
{

    public class SkillTypeTopicService : EntityBaseRepository<SkillTypeTopic>, ISkillTypeTopicService
    {
        private readonly AppDbContext _appDbcontext;
        public SkillTypeTopicService(AppDbContext appDbcontext) : base(appDbcontext) 
        { 
            _appDbcontext = appDbcontext;
        }

        public async Task<SkillTypeTopic> GetSkillTypeTopicByIdAsync(int Id)
        {
            try
            {
                var skillDetails = await _appDbcontext.SkillTypeTopics
                    .Include(sk => sk.SkillType)
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
