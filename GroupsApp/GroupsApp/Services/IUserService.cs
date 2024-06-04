using GroupsApp.Models;
using GroupsApp.Payload.DTO;
using GroupsApp.Payloads.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GroupsApp.Services
{
    public interface IUserService
    {
        void AddPostToCart(Guid postId, Guid userId);
        void AddPostToFavorites(Guid postId, Guid userId);
        ActionResult<UserDto> AddUser(UserDto userDto);
        ActionResult<List<MarketplacePostDTO>> GetFavoritePosts(Guid userId);
        ActionResult<User> GetUserById(Guid id);
        ActionResult<List<User>> GetUsers();
        bool IsUserInGroup(Guid userId, Guid groupId);
        void RemovePostFromCart(Guid postId, Guid userId);
        void RemovePostFromFavorites(Guid postId, Guid userId);
        void RemoveUser(Guid userId);
        ActionResult<User> UpdateUser(UserDto userDto);
        ActionResult<List<MarketplacePostDTO>> GetPostsFromCart(Guid userId);
        void BanUserFromGroup(Guid userId, Guid groupId);
    }
}