using GroupsApp.Data;
using GroupsApp.Models.MarketplacePosts;
using System.Reflection.Metadata;

namespace GroupsApp.Repositories
{
    public class DonationPostRepository(GroupsAppContext context) : IDonationPostRepository
    {
        private readonly GroupsAppContext _context = context;

        public DonationPost AddDonationPost(DonationPost donationPost)
        {
            DonationPost savedDonationPost = _context.DonationPosts.Add((DonationPost)donationPost).Entity;
            _context.SaveChanges();
            return savedDonationPost;
        }

        public void DeleteDonationPost(Guid donationPostId)
        {
            DonationPost? oldPost = _context.DonationPosts.Find(donationPostId);
            if(oldPost == null)
                throw new Exception("Donation post not found");
            _context.DonationPosts.Remove(oldPost);
            _context.SaveChanges();
        }

        public List<DonationPost> GetAllDonationPosts()
        {
            return [.. _context.DonationPosts];
        }

        public DonationPost? GetDonationPostById(Guid donationPostId)
        {
            return _context.DonationPosts.Find(donationPostId);
        }

        public DonationPost UpdateDonationPost(DonationPost donationPost)
        {
            DonationPost donationPostCast = (DonationPost)donationPost;
            DonationPost? oldPost = _context.DonationPosts.Find(donationPostCast.MarketplacePostId);
            if(oldPost == null)
                throw new Exception("Donation post not found");
            oldPost.AuthorId = donationPost.AuthorId;
            oldPost.Description = donationPost.Description;
            oldPost.Title = donationPost.Title;
            oldPost.MediaContent = donationPost.MediaContent;
            oldPost.IsPromoted = donationPost.IsPromoted;
            oldPost.GroupId = donationPost.GroupId;
            oldPost.IsActive = donationPost.IsActive;
            oldPost.EndDate = donationPost.EndDate;
            oldPost.Location = donationPost.Location;
            oldPost.Type = donationPost.Type;
            oldPost.DonationLink = donationPostCast.DonationLink;
            oldPost.CurrentDonationAmount = donationPostCast.CurrentDonationAmount;
            DonationPost updatedDonationPost = _context.DonationPosts.Update(oldPost).Entity;
            _context.SaveChanges();
            return updatedDonationPost;
        }
    }
}
