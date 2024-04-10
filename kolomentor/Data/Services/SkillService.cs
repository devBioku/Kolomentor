using kolomentor.Data.Base;
using kolomentor.Models;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Data.Services
{

    public class SkillService : EntityBaseRepository<Skill>, ISkillService
    {
        public SkillService(AppDbContext appDbcontext) : base(appDbcontext) { }

    }
}
