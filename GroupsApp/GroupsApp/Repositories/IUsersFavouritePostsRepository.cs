using GroupsApp.Models;
using System;
using System.Collections.Generic;

namespace GroupsApp.Repositories
{
    public interface IUsersFavouritePostsRepository
    {
        UsersFavoritePosts AddUsersFavoritePosts(UsersFavoritePosts usersFavoritePosts);
        public UsersFavoritePosts GetUsersFavoritePostsById(Guid id);
        void DeleteUsersFavoritePosts(UsersFavoritePosts usersFavoritePosts);
        public List<UsersFavoritePosts> GetAllUsersFavouritePosts();
        public List<Guid> GetMarketplacePostIdsByUserId(Guid userId);
    }
}