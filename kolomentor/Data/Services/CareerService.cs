using kolomentor.Data.Base;
using kolomentor.Models;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Data.Services
{

    public class CareerService : EntityBaseRepository<Career>, ICareerService
    {
        public CareerService(AppDbContext appDbcontext) : base(appDbcontext) { }

    }
}
