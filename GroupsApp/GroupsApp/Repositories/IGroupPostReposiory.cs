using GroupsApp.Models;
using GroupsApp.Payload.DTO;

namespace GroupsApp.Repositories
{
    public interface IGroupPostReposiory
    {
        public GroupPost AddGroupPost(GroupPost groupPost);
        public GroupPost UpdateGroupPost(GroupPost groupPost);
        public GroupPost? GetGroupPostById(Guid id);
        public List<GroupPost> GetAllGroupPosts();
        public void DeleteGroupPost(Guid id);

        List<GroupPost> DeleteAllPostByUser(Guid userId);
        List<GroupPostDTO> GetTaggedGroupPosts(Guid groupId, List<Tag> tags);
    }
}
