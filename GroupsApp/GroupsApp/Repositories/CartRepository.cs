using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class CartRepository(GroupsAppContext context):ICartRepository
    {
        private readonly GroupsAppContext _context = context;

        public Cart AddCart(Cart cart)
        {
            Cart savedCart = _context.Cart.Add(cart).Entity;
            _context.SaveChanges();
            return savedCart;
        }

        public Cart GetCartById(Guid userId, Guid marketplaceId) {
            return _context.Cart.Find(userId, marketplaceId);
        }

        /*
        public Cart UpdateCart(Cart cart)
        {
            Cart? foundCart = _context.Cart.Find(cart.UserId, cart.MarketplacePostId);
            if (foundCart == null)
            {
                throw new Exception("Cart not found");
            }
            Cart updatedCart = _context.Cart.Update(foundCart).Entity;
            _context.SaveChanges();
            return updatedCart;
        }
         */

        public void DeleteCart(Cart cart)
        {
            Cart? foundCart = _context.Cart.Find(cart.UserId, cart.MarketplacePostId);
            if (foundCart == null)
            {
                throw new Exception("Cart not found");
            }
            _context.Cart.Remove(foundCart);
            _context.SaveChanges();
        }

        public List<Cart> GetAllCarts()
        {
            return [.. _context.Cart];
        }
        public List<Guid> GetMarketplacePostIdsByUserId(Guid userId)
        {
            return _context.Cart
                .Where(cart => cart.UserId == userId)
                .Select(cart => cart.MarketplacePostId)
                .ToList();
        }
    }
}
