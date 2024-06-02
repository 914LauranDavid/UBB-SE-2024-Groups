using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public interface IGroupPostReposiory
    {
        public GroupPost AddGroupPost(GroupPost groupPost);
        public GroupPost UpdateGroupPost(GroupPost groupPost);
        public GroupPost? GetGroupPostById(Guid id);
        public List<GroupPost> GetAllGroupPosts();
        public void DeleteGroupPost(Guid id);
    }
}
