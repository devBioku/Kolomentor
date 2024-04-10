using DocumentFormat.OpenXml.Vml.Office;
using kolomentor.Data.Services;
using kolomentor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.Linq.Expressions;

namespace kolomentor.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        private readonly AppDbContext _appDbContext;

        public EntityBaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Create/Add to the database
        public async Task AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        //---------------------Reading from the Database ------------------------//

        //Get all 
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _appDbContext.Set<T>().ToListAsync();
            return result;
        }
        //Get by ID
        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _appDbContext.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            var res = await _appDbContext.Set<T>().FindAsync(id);

            return result;
        }
        //---------------------------------------------------------------------//


        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _appDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _appDbContext.Set<T>().FirstAsync(n => n.Id == id);
            EntityEntry entityEntry = _appDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _appDbContext.SaveChangesAsync();
        }

        async Task<IEnumerable> IEntityBaseRepository<T>.GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _appDbContext.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

    }
}

