using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
      
     
        

        Task<IEnumerable<Comment>> GetCommentsByArticleID(Guid articleID);
        Task<IEnumerable<Comment>> GetRepliedComments(Guid parentCommentID);
        Task<Comment> ReplyToComment(Comment replyToCommentDTO);
        Task DeleteCommentAndReplies(Guid commentId);
    }
}
