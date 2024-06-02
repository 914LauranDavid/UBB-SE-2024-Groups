using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public interface ICommentRepository
    {
        public Comment AddComment(Comment comment);
        public Comment? GetComment(Guid commentId);
        public Comment UpdateComment(Comment comment);
        public void DeleteComment(Guid commentId);
        public List<Comment> GetAllComments();
    }
}
