using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public interface ITagsRepository
    {
        void AddTagsToPost(GroupPost groupPost, List<Tag> tags);
        List<Tag> GetAllTags();
        void UpdatePostTags(GroupPost groupPost, List<Tag> tags);
    }
}
