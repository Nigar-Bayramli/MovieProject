using AutoMapper;
using BLL.BLL.Abstract;
using DTOS.DTOS.CommentDTOS;
using Entities;
using Entities.Models;
using MVCAPP.DAL.Generic_Repository.Abstract;
using MVCAPP.DTOS.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL.Concrete
{
    public class CommentService : ICommentService
    {

        IMapper _mapper;

        IRepository<Comment> _repository;
        public CommentService(IMapper mapper, IRepository<Comment> repository)
        {

            _mapper = mapper;

            _repository = repository;

        }
        public async Task AddAsync(CommentToAddDTO dto)
        {
            Comment Comment = _mapper.Map<Comment>(dto);
            await _repository.AddAsync(Comment);

        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);

        }

        public async Task<List<CommentToListDTO>> GetAsync()
        {
            List<Comment> Comments = await _repository.GetAllAsync();
            List<CommentToListDTO> dtos = _mapper.Map<List<CommentToListDTO>>(Comments);
            return dtos;
        }

        public async Task<Comment> GetByIdAsync(int id)
        {

            Comment comment = await _repository.GetByIdAsync(id);

            return comment;
        }

        public async Task UpdateAsync(int id, CommentToUpdateDTO dto)
        {
            Comment comment = await _repository.GetByIdAsync(id);

            comment.DateTime = dto.DateTime;
            comment.MovieId = dto.MovieId;
            comment.UserId  = dto.UserId;
            comment.UserComment = dto.UserComment;  
            await _repository.UpdateAsync(comment);

        }
    }
}
