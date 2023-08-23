using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Galacticos.Application.DTOs.Comments;
using Galacticos.Domain.Entities;

namespace Galacticos.Application.Persistence.Contracts
{
    public interface ICommentRepository
    {
        ErrorOr<CommentResponesDTO> CreateComment(Comment comment);
        Comment? GetCommentById(Guid id);
        List<CommentResponesDTO> GetCommentsByPostId(Guid postId);
        CommentResponesDTO UpdateComment(Comment comment);
        bool DeleteComment(Comment comment);   
    }
}