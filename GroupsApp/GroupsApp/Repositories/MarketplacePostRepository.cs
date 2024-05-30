using GroupsApp.Data;
using GroupsApp.Models.MarketplacePosts;

namespace GroupsApp.Repositories
{
    public class MarketplacePostRepository(GroupsAppContext context) : IMarketplacePostRepository
    {
        private readonly GroupsAppContext _context = context;
        public MarketplacePost AddMarketplacePost(MarketplacePost marketplacePost)
        {
            MarketplacePost savedPost = _context.MarketplacePosts.Add(marketplacePost).Entity;
            _context.SaveChanges();
            return savedPost;
        }

        public void DeleteMarketplacePost(Guid id)
        {
            MarketplacePost? oldPost = _context.MarketplacePosts.Find(id);
            if (oldPost == null) { 
                throw new Exception("Marketplace post not found");
            }
            _context.MarketplacePosts.Remove(oldPost);
            _context.SaveChanges();
        }

        public List<MarketplacePost> GetAllMarketplacePosts()
        {
            return [.. _context.MarketplacePosts];
        }

        public MarketplacePost? GetMarketplacePostById(Guid id)
        {
            return _context.MarketplacePosts.Find(id);
        }

        public MarketplacePost UpdateMarketplacePost(MarketplacePost marketplacePost)
        {
            MarketplacePost? oldPost = _context.MarketplacePosts.Find(marketplacePost.MarketplacePostId);

            if (oldPost == null)
            {
                throw new Exception("Marketplace post not found");
            }

            oldPost.AuthorId = marketplacePost.AuthorId;
            oldPost.Description = marketplacePost.Description;
            oldPost.Title = marketplacePost.Title;
            oldPost.MediaContent = marketplacePost.MediaContent;
            oldPost.IsPromoted = marketplacePost.IsPromoted;
            oldPost.GroupId = marketplacePost.GroupId;
            oldPost.IsActive = marketplacePost.IsActive;
            oldPost.EndDate = marketplacePost.EndDate;
            oldPost.Location = marketplacePost.Location;
            oldPost.Type = marketplacePost.Type;
            MarketplacePost updatedPost = _context.Update(oldPost).Entity;
            _context.SaveChanges();
            return updatedPost;

        }
    }
}
