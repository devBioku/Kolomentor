using kolomentor.Data.Base;
using kolomentor.Models;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Data.Services
{
    public class GuestService : EntityBaseRepository<Guest>, IGuestService
    {
        public GuestService(AppDbContext appDbcontext) : base(appDbcontext) { }
        
    }
}
