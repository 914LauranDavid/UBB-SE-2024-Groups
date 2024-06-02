using GroupsApp.Data;
using GroupsApp.Models.MarketplacePosts;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace GroupsApp.Repositories
{
    public class AuctionPostRepository(GroupsAppContext context) : IAuctionPostRepository
    {
        private readonly GroupsAppContext _context = context;

        public MarketplacePost AddMarketplacePost(MarketplacePost marketplacePost)
        {
            AuctionPost savedActionPost = _context.AuctionPosts.Add((AuctionPost)marketplacePost).Entity;
            _context.SaveChanges();
            return savedActionPost;
        }

        public void DeleteMarketplacePost(Guid id)
        {
            AuctionPost? oldPost = _context.AuctionPosts.Find(id);
            if (oldPost == null)
                throw new Exception("Auction post not found");
            _context.AuctionPosts.Remove(oldPost);
            _context.SaveChanges();
        }

        public List<MarketplacePost> GetAllMarketplacePosts()
        {
            return [.. _context.AuctionPosts];
        }

        public MarketplacePost? GetMarketplacePostById(Guid id)
        {
            return _context.AuctionPosts.Find(id);
        }

        public MarketplacePost UpdateMarketplacePost(MarketplacePost marketplacePost)
        {
            AuctionPost auctionPostCast = (AuctionPost)marketplacePost;
            AuctionPost? oldPost = _context.AuctionPosts.Find(auctionPostCast.MarketplacePostId);
            if (oldPost == null)
                throw new Exception("Auction post not found");
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
            oldPost.Price = auctionPostCast.Price;
            oldPost.IsNegotiable = auctionPostCast.IsNegotiable;
            oldPost.DeliveryType = auctionPostCast.DeliveryType;
            oldPost.CurrentPriceLeader = auctionPostCast.CurrentPriceLeader;
            oldPost.CurrentBidPrice = auctionPostCast.CurrentBidPrice;
            oldPost.MinimumBidPrice = auctionPostCast.MinimumBidPrice;
            AuctionPost savedPost = _context.AuctionPosts.Update(oldPost).Entity;
            _context.SaveChanges();
            return savedPost;
        }
    }
}
