using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class GroupPostRepository(GroupsAppContext context)
    {
        private readonly GroupsAppContext _context = context;

        public GroupPost AddGroupPost(GroupPost groupPost)
        {
            _context.GroupPosts.Add(groupPost);
            _context.SaveChanges();
            return groupPost;
        }

        public GroupPost? GetGroupPostById(Guid id)
        {
            return _context.GroupPosts.Find(id);
        }

        public List<GroupPost> GetAllGroupPosts()
        {
            return [.. _context.GroupPosts];
        }

        public GroupPost UpdateGroupPost(GroupPost groupPost)
        {
            GroupPost? foundGroupPost = _context.GroupPosts.Find(groupPost.GroupPostId);
            if (foundGroupPost == null) throw new Exception("Group post not found");
            foundGroupPost.Description = groupPost.Description;
            foundGroupPost.MediaContent = groupPost.MediaContent;
            foundGroupPost.IsPinned = groupPost.IsPinned;
            foundGroupPost.AdminOnly = groupPost.AdminOnly;
            GroupPost updatedGroupPost = _context.GroupPosts.Update(foundGroupPost).Entity;
            _context.SaveChanges();
            return updatedGroupPost;
        }

        public void DeleteGroupPost(Guid id)
        {
            var groupPost = _context.GroupPosts.Find(id);
            if (groupPost != null)
            {
                _context.GroupPosts.Remove(groupPost);
                _context.SaveChanges();
            }
            else throw new Exception("Group post not found");
        }

    }
}
