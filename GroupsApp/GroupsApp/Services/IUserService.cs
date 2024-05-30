using GroupsApp.Models;
using GroupsApp.Payload.DTO;
using GroupsApp.Payloads.DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GroupsApp.Services
{
    public interface IUserService
    {
        void AddPostToCart(Guid postId, Guid userId);
        void AddPostToFavorites(Guid postId, Guid userId);
        UserDto AddUser(UserDto userDto);
        List<MarketplacePostDTO> GetFavoritePosts(Guid userId);
        User GetUserById(Guid id);
        List<User> GetUsers();
        bool IsUserInGroup(Guid userId, Guid groupId);
        void RemovePostFromCart(Guid postId, Guid userId);
        void RemovePostFromFavorites(Guid postId, Guid userId);
        void RemoveUser(Guid userId);
        User UpdateUser(UserDto userDto);
        List<MarketplacePostDTO> GetPostsFromCart(Guid userId);
    }
}