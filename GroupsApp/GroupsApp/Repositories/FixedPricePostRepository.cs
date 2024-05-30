using GroupsApp.Data;
using GroupsApp.Models.MarketplacePosts;

namespace GroupsApp.Repositories
{
    public class FixedPricePostRepository(GroupsAppContext context) : IMarketplacePostRepository
    {
        private readonly GroupsAppContext _context = context;
        public MarketplacePost AddMarketplacePost(MarketplacePost marketplacePost)
        {
            FixedPricePost fixedPricePostCast = (FixedPricePost)marketplacePost;
            FixedPricePost savedFixedPricePost = _context.FixedPricePosts.Add(fixedPricePostCast).Entity;
            _context.SaveChanges();
            return savedFixedPricePost;
        }

        public void DeleteMarketplacePost(Guid id)
        {
            FixedPricePost? oldPost = _context.FixedPricePosts.Find(id);
            if (oldPost == null)
            {
                throw new Exception("Post not found");
            }
            _context.FixedPricePosts.Remove(oldPost);
            _context.SaveChanges();
        }

        public List<MarketplacePost> GetAllMarketplacePosts()
        {
            return [.. _context.FixedPricePosts];
        }

        public MarketplacePost? GetMarketplacePostById(Guid id)
        {
            return _context.FixedPricePosts.Find(id);
        }

        public MarketplacePost UpdateMarketplacePost(MarketplacePost marketplacePost)
        {
            FixedPricePost fixedPricePostCast = (FixedPricePost)marketplacePost;
        }
    }
}
