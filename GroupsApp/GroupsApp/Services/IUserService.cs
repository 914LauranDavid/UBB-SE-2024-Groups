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
        Task<UserDto> AddUser(UserDto userDto);
        Task<List<MarketplacePostDTO>> GetFavoritePosts(Guid userId);
        Task<User> GetUserById(Guid id);
        Task<List<User>> GetUsers();
        Task<bool> IsUserInGroup(Guid userId, Guid groupId);
        void RemovePostFromCart(Guid postId, Guid userId);
        void RemovePostFromFavorites(Guid postId, Guid userId);
        void RemoveUser(Guid userId);
        Task<User> UpdateUser(UserDto userDto);
        Task<List<MarketplacePostDTO>> GetPostsFromCart(Guid userId);
    }
}