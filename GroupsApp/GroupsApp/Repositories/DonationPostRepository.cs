using GroupsApp.Data;
using GroupsApp.Models.MarketplacePosts;
using System.Reflection.Metadata;

namespace GroupsApp.Repositories
{
    public class DonationPostRepository(GroupsAppContext context) : IMarketplacePostRepository
    {
        private readonly GroupsAppContext _context = context;

        public MarketplacePost AddMarketplacePost(MarketplacePost marketplacePost)
        {
            DonationPost savedDonationPost = _context.DonationPosts.Add((DonationPost) marketplacePost).Entity;
            _context.SaveChanges();
            return savedDonationPost;
        }

        public void DeleteMarketplacePost(Guid id)
        {
            DonationPost? oldPost = _context.DonationPosts.Find(id);
            if(oldPost == null)
                throw new Exception("Donation post not found");
            _context.DonationPosts.Remove(oldPost);
            _context.SaveChanges();
        }

        public List<MarketplacePost> GetAllMarketplacePosts()
        {
            return [.. _context.DonationPosts];
        }

        public MarketplacePost? GetMarketplacePostById(Guid id)
        {
            return _context.DonationPosts.Find(id);
        }

        public MarketplacePost UpdateMarketplacePost(MarketplacePost marketplacePost)
        {
            DonationPost donationPostCast = (DonationPost)marketplacePost;
            DonationPost? oldPost = _context.DonationPosts.Find(donationPostCast.MarketplacePostId);
            if(oldPost == null)
                throw new Exception("Donation post not found");
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
            oldPost.DonationLink = donationPostCast.DonationLink;
            oldPost.CurrentDonationAmount = donationPostCast.CurrentDonationAmount;
            DonationPost updatedDonationPost = _context.DonationPosts.Update(oldPost).Entity;
            _context.SaveChanges();
            return updatedDonationPost;
        }
    }
}
