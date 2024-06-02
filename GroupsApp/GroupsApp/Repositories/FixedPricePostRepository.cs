using GroupsApp.Data;
using GroupsApp.Models.MarketplacePosts;

namespace GroupsApp.Repositories
{
    public class FixedPricePostRepository(GroupsAppContext context) : IFixedPricePostRepository
    {
        private readonly GroupsAppContext _context = context;
        public FixedPricePost AddFixedPricePost(FixedPricePost fixedPricePost)
        {
            FixedPricePost fixedPricePostCast = (FixedPricePost)fixedPricePost;
            FixedPricePost savedFixedPricePost = _context.FixedPricePosts.Add(fixedPricePostCast).Entity;
            _context.SaveChanges();
            return savedFixedPricePost;
        }

        public void DeleteFixedPricePost(Guid id)
        {
            FixedPricePost? oldPost = _context.FixedPricePosts.Find(id);
            if (oldPost == null)
            {
                throw new Exception("Post not found");
            }
            _context.FixedPricePosts.Remove(oldPost);
            _context.SaveChanges();
        }

        public List<FixedPricePost> GetAllFixedPricePosts()
        {
            return [.. _context.FixedPricePosts];
        }

        public FixedPricePost? GetFixedPricePostById(Guid id)
        {
            return _context.FixedPricePosts.Find(id);
        }

        public FixedPricePost UpdateFixedPricePost(FixedPricePost fixedPricePost)
        {
            FixedPricePost fixedPricePostCast = (FixedPricePost)fixedPricePost;
            FixedPricePost? oldPost = _context.FixedPricePosts.Find(fixedPricePostCast.MarketplacePostId);
            if (oldPost == null)
            {
                throw new Exception("Post not found");
            }
            oldPost.AuthorId = fixedPricePost.AuthorId;
            oldPost.Description = fixedPricePost.Description;
            oldPost.Title = fixedPricePost.Title;
            oldPost.MediaContent = fixedPricePost.MediaContent;
            oldPost.IsPromoted = fixedPricePost.IsPromoted;
            oldPost.GroupId = fixedPricePost.GroupId;
            oldPost.IsActive = fixedPricePost.IsActive;
            oldPost.EndDate = fixedPricePost.EndDate;
            oldPost.Location = fixedPricePost.Location;
            oldPost.Type = fixedPricePost.Type;
            oldPost.Price = fixedPricePostCast.Price;
            oldPost.IsNegotiable = fixedPricePostCast.IsNegotiable;
            oldPost.DeliveryType = fixedPricePostCast.DeliveryType;
            FixedPricePost updatedFixedPricePost = _context.FixedPricePosts.Update(oldPost).Entity;
            _context.SaveChanges();
            return updatedFixedPricePost;
        }
    }
}
