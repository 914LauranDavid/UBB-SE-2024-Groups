namespace GroupsApp.Models
{
    public class PostTag
    {
        public Guid PostTagId { get; set; }
        public Guid PostId { get; set; }

        public PostTag() { }

        public PostTag(Guid postTagId, Guid postId)
        {
            PostTagId = postTagId;
            PostId = postId;
        }
    }
}
