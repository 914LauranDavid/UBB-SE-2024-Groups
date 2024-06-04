using Microsoft.Build.ObjectModelRemoting;

namespace GroupsApp.Models
{
    public class Tag
    {

        private Guid tagId;

        private string tagName;
        public Guid TagId { get => tagId; set => tagId = value; }
        public string TagName { get => tagName; set => tagName = value; }

        public Tag()
        {
        }

        public Tag(Guid tagId, string tagName)
        {
            TagId = tagId;
            TagName = tagName;
        }

        public ICollection<GroupPost> TaggedPosts { get; set; } = new List<GroupPost>();
    }
}
