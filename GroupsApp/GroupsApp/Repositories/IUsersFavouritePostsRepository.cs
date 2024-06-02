using GroupsApp.Models;
using System;
using System.Collections.Generic;

namespace GroupsApp.Repositories
{
    public interface IUsersFavouritePostsRepository
    {
        UsersFavoritePosts AddUsersFavoritePosts(UsersFavoritePosts usersFavoritePosts);
        UsersFavoritePosts? GetUsersFavoritePostsById(Guid id);
        void DeleteUsersFavoritePosts(UsersFavoritePosts usersFavoritePosts);
        List<UsersFavoritePosts> GetAllUsersFavouritePosts();
    }
}