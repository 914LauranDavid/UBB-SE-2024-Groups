using GroupsApp.Models.MarketplacePosts;
using GroupsApp.Payloads.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GroupsApp.Services
{
    public interface IPostService
    {
        MarketplacePostDTO AddMarketplacePost(MarketplacePostDTO marketplacePostDTO);
        MarketplacePost AddMarketplacePost(MarketplacePost marketplacePostDTO);
        MarketplacePost GetMarketplacePostById(Guid id);
        IEnumerable<MarketplacePost> GetMarketplacePosts();
        void RemoveMarketplacePost(MarketplacePostDTO marketplacePostDTO);
    }
}