using GroupsApp.Models.MarketplacePosts;

namespace GroupsApp.Repositories
{
    public interface IDonationPostRepository
    {
        public DonationPost AddDonationPost(DonationPost donationPost);
        public DonationPost? GetDonationPostById(Guid donationPostId);
        public DonationPost UpdateDonationPost(DonationPost donationPost);
        public void DeleteDonationPost(Guid donationPostId);
        public List<DonationPost> GetAllDonationPosts();
    }
}
