using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.GenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;

namespace Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly AppDbContext _dbContext;

        public CommentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // Additional Methods

        public async Task<IEnumerable<Comment>> GetCommentsByArticleID(Guid articleID)
        {
            return await _dbContext.Comments
                .Where(c => c.ArticleID == articleID)
                .Include(c => c.Author) 
                .ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetRepliedComments(Guid parentCommentID)
        {
            return await _dbContext.Comments
                .Where(c => c.ParentCommentID == parentCommentID)
                .Include(c => c.Author)
                .ToListAsync();
        }


        public async Task DeleteCommentAndReplies(Guid commentId)
            {
                var commentToDelete = await _dbContext.Comments
                    .Include(c => c.RepliedComments)
                    .FirstOrDefaultAsync(c => c.ID == commentId);

                if (commentToDelete != null)
                {
                    // Recursive delete of replies
                    foreach (var reply in commentToDelete.RepliedComments.ToList())
                    {
                        await DeleteCommentAndReplies(reply.ID);
                    }

                    _dbContext.Comments.Remove(commentToDelete);
                    await _dbContext.SaveChangesAsync();
                }
            }


       public async Task<Comment> GetRepliedComment(Guid ID)
        {
            return await _dbContext.Comments
                .Where(c => c.ID == ID)
                .Include(c => c.Author)
                .Include(c => c.ParentComment)
                .FirstOrDefaultAsync();
        }



        public async Task<Comment> ReplyToComment(Comment replyToCommentDTO)
        {
            // Assuming the DTO has necessary information for creating a reply comment
            var replyComment = new Comment
            {
                ArticleID = replyToCommentDTO.ArticleID,
                Content = replyToCommentDTO.Content,
                ParentCommentID = replyToCommentDTO.ParentCommentID,
                CreatedAt = DateTime.UtcNow, // Set the creation timestamp
                UpdatedAt = DateTime.UtcNow, // Set the update timestamp
                AuthorID = replyToCommentDTO.AuthorID, // Assuming AuthorID is available in the DTO
                // Include other properties as needed

                
            };

            // Add the reply comment to the database
            var addedComment = await Add(replyComment);

            var RepliedComment = await GetRepliedComment(addedComment.ID);

            // Return the added comment
            return RepliedComment;
        }
    }
}
