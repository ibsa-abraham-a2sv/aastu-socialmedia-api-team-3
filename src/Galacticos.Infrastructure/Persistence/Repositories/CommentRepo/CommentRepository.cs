using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Galacticos.Application.DTOs.Comments;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Galacticos.Infrastructure.Data;
using Galacticos.Domain.Errors;
using AutoMapper;

namespace Galacticos.Infrastructure.Persistence.Repositories.CommentRepo
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApiDbContext _context;
        private IMapper _mapper;
        public CommentRepository(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ErrorOr<CommentResponesDTO> CreateComment(Comment comment)
        {
            Console.WriteLine("CommentRepo: "+comment.ToString());
            _context.comments.Add(comment);

            if (_context.SaveChanges() == 0)
            {
                return Errors.Comment.CommentCreationFailed;
            }
            _context.SaveChanges();
            return _mapper.Map<CommentResponesDTO>(comment);
        }

        public bool DeleteComment(Comment comment)
        {
            _context.comments.Remove(comment);
            if (_context.SaveChanges() == 0)
            {
                return false;
            }
            return true;
        }

        public Comment? GetCommentById(Guid id)
        {
            var com = _context.comments.FirstOrDefault(x=>x.Id == id);
            if(com == null)
            {
                return null;
            }
            return com;
        }

        public List<CommentResponesDTO> GetCommentsByPostId(Guid postId)
        {
            var comments = _context.comments.Where(x=>x.PostId == postId);
            return _mapper.Map<List<CommentResponesDTO>>(comments);
        }

        public CommentResponesDTO UpdateComment(Comment comment)
        {
            _context.comments.Update(comment);
            _context.SaveChanges();
            return _mapper.Map<CommentResponesDTO>(comment);
        }

    }
}