using AutoMapper;
using BLL.BLL.Abstract;
using DAL;
using DTOS.DTOS.CommentDTOS;
using Entities.Models;
using MVCAPP.DAL.Generic_Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class CommentService : ICommentService
    {
        IMapper _mapper;

        IRepository<Comment> _repository;
        MyAppDbContext _appDbContext;
        public CommentService(IMapper mapper, IRepository<Comment> repository, MyAppDbContext myAppDbContext)
        {

            _mapper = mapper;

            _repository = repository;
            _appDbContext = myAppDbContext;

        }
        public async Task AddAsync(CommentToAddDTO dto, int id)
        {
            Comment Comment = _mapper.Map<Comment>(dto);
            Comment.UserId = id;
            await _repository.AddAsync(Comment);

        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);

        }

        public async Task<List<CommentToListDTO>> GetAsync()
        {
            List<Comment> Comments = await _repository.GetAllAsync(x => x.User, c => c.Movie);
            List<CommentToListDTO> dtos = _mapper.Map<List<CommentToListDTO>>(Comments);
            return dtos;
        }

        public async Task<Comment> GetByIdAsync(int id)
        {

            Comment comment = await _repository.GetByIdAsync(id);

            return comment;
        }

        public bool HasPermissionAsync(int usrid, int commentId)
        {
            Comment comment = _appDbContext.Comments.FirstOrDefault(x => x.UserId == usrid && x.Id == commentId);
            return comment != null;

        }

        public async Task UpdateAsync(int id, CommentToUpdateDTO dto)
        {
            Comment comment = await _repository.GetByIdAsync(id);

          
           
            comment.UserComment = dto.UserComment;
            await _repository.UpdateAsync(comment);

        }

    }
}
