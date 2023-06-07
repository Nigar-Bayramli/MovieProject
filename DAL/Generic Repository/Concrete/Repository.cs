using DAL;
using Entities.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MVCAPP.DAL.Generic_Repository.Abstract;
using System.Linq.Expressions;
using IEntity = Entities.Models.Entity.IEntity;

namespace MVCAPP.DAL.Generic_Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly MyAppDbContext _context;
        private readonly DbSet<T> _entities;    

        public Repository(MyAppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public int Id { get; set; }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        
        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

     
        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
          
               IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }

     

        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }

}
