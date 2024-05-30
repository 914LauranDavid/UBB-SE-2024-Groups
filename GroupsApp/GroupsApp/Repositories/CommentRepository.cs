using GroupsApp.Data;
using GroupsApp.Models;
using System.ComponentModel.Design;

namespace GroupsApp.Repositories
{
    public class CommentRepository(GroupsAppContext context)
    {
        private readonly GroupsAppContext _context = context;

        
        //public Comment AddComment(Comment comment)
        //{
        //    Comment savedComment = _context.Comments.Add(comment).Entity;
        //    _context.SaveChanges();
        //    return savedComment;
        //}

        //public Comment? GetComment(Guid commentId) 
        //{
        //    return _context.Comments.Find(commentId);        
        //}

        //public Comment UpdateComment(Comment comment)
        //{
        //    Comment? foundComment = _context.Comments.Find(commentId);

        //    if (foundComment != null)
        //    {
        //        throw new Exception("Comment not found");
        //    }
        //    foundComment.Content = comment.Content;
        //    Comment updatedComment = _context.Comments.Update(foundComment).Entity;
        //    _context.SaveChanges();
        //    return updatedComment;

        //}

        //public void DeleteComment(Guid commentId)
        //{
        //    Comment? foundComment = _context.Comments.Find(commentId);

        //    if (foundComment != null) {
        //        throw new Exception("Comment not found");
        //    }
        //    _context.Comments.Remove(foundComment);
        //    _context.SaveChanges();
        //}

        //public List<Comment> GetAllComments()
        //{
        //    return [.. _context.Comments];
        //}
    }
}
