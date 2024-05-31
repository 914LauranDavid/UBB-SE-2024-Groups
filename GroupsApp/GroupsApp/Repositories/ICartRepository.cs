using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public interface ICartRepository
    {
        public Cart AddCart(Cart cart);
        public Cart GetCartById(Guid userId, Guid marketplaceId);
        public void DeleteCart(Cart cart);
        public List<Cart> GetAllCarts();
        public List<Guid> GetMarketplacePostIdsByUserId(Guid userId);

    }
}
