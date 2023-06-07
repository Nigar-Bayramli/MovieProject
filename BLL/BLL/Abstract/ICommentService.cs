using DTOS.DTOS.CommentDTOS;
using Entities;
using MVCAPP.DTOS.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL.Abstract
{
    public interface ICommentService
    {
        Task<List<CommentToListDTO>> GetAsync();
        Task AddAsync(CommentToAddDTO actor, int id);

        bool HasPermissionAsync(int id, int usrid);

        Task UpdateAsync(int id, CommentToUpdateDTO actor);
        Task DeleteAsync(int id);
    }
}
