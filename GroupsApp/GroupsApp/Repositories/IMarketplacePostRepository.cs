using GroupsApp.Models.MarketplacePosts;

namespace GroupsApp.Repositories
{
    public interface IMarketplacePostRepository
    {
        public MarketplacePost AddMarketplacePost(MarketplacePost marketplacePost);
        public void DeleteMarketplacePost(Guid id);
        public MarketplacePost UpdateMarketplacePost(MarketplacePost marketplacePost);
        public MarketplacePost? GetMarketplacePostById(Guid id);
        public List<MarketplacePost> GetAllMarketplacePosts();
    }
}
