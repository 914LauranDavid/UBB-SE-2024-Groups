using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class TagsRepository(GroupsAppContext context): ITagsRepository
    {
        private readonly GroupsAppContext _context = context;

        public void AddTagsToPost(GroupPost groupPost, List<Tag> tags)
        {
            foreach (Tag tag in tags)
            {
                PostTag postTagConnection = new PostTag(tag.TagId, groupPost.GroupPostId);
                _context.PostTags.Add(postTagConnection);
            }
            _context.SaveChanges();
        }

        public List<Tag> GetAllTags()
        {
            return [.. _context.Tags];
        }

        public void UpdatePostTags(GroupPost groupPost, List<Tag> tags)
        {
            foreach (Tag tag in tags) { 
                PostTag? postTagConnection = _context.PostTags.Find(tag.TagId, groupPost.GroupPostId);
                if (postTagConnection == null)
                {
                    PostTag newTagConnection = new PostTag(tag.TagId, groupPost.GroupPostId);
                    _context.PostTags.Add(newTagConnection);
                }
            }

            List<PostTag> postTagsToDelete = _context.PostTags.Where(pt => pt.PostId == groupPost.GroupPostId).ToList();
            foreach (PostTag postTag in postTagsToDelete)
            {
                if (!tags.Any(t => t.TagId == postTag.PostTagId))
                {
                    _context.PostTags.Remove(postTag);
                }
            }
            _context.SaveChanges();
        }
    }
}
