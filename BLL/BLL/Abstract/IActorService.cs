


using Entities;
using MVCAPP.DTOS.DTOS;

namespace MVCAPP.BLL.Abstract
{
    public interface IActorService
    {

        Task<List<ActorToListDTO>> GetAsync();
        Task AddAsync(ActorToAddDTO actor);
        Task<Actor> GetByIdAsync(int id);

       
       Task UpdateAsync(int id, ActorToUpdateDTO actor);
        Task DeleteAsync(int id);
    }
}
