
using DAL;

using Entities.Models.Entity;
using System.Linq.Expressions;
using IEntity = Entities.Models.Entity.IEntity;

namespace MVCAPP.DAL.Generic_Repository.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    
    {
      
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
    
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
       
    }
}