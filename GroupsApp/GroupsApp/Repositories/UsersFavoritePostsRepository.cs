﻿using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class UsersFavouritePostsRepository(GroupsAppContext context) : IUsersFavouritePostsRepository
    {
        private readonly GroupsAppContext _context = context;

        public UsersFavoritePosts AddUsersFavoritePosts(UsersFavoritePosts usersFavoritePosts)
        {
            UsersFavoritePosts savedUsersFavoritePosts = _context.UsersFavoritePosts.Add(usersFavoritePosts).Entity;
            _context.SaveChanges();
            return savedUsersFavoritePosts;
        }

        //Find by userId, Idk if there are different ones for different marketplaces -Gugu
        public UsersFavoritePosts GetUsersFavoritePostsById(Guid userId)
        {
            return _context.UsersFavoritePosts.Find(userId);
        }

        //Irrelevant
        /*public UsersFavoritePosts UpdateUsersFavoritePosts(UsersFavoritePosts usersFavoritePosts)
        {
            UsersFavoritePosts? foundUsersFavoritePosts = _context.UsersFavoritePosts.Find(usersFavoritePosts.UserId);
            if (foundUsersFavoritePosts == null)
            {
                throw new Exception("UsersFavoritePosts not found");
            }
            UsersFavoritePosts updatedUsersFavoritePosts = _context.UsersFavoritePosts.Update(foundUsersFavoritePosts).Entity;
            _context.SaveChanges();
            return updatedUsersFavoritePosts;
        }*/

        public void DeleteUsersFavoritePosts(UsersFavoritePosts usersFavoritePosts) {
            UsersFavoritePosts foundUsersFavoritePosts = _context.UsersFavoritePosts.Find(usersFavoritePosts.UserId, usersFavoritePosts.MarketplacePostId);
            if (foundUsersFavoritePosts == null)
            {
                throw new Exception("UsersFavoritePosts not found");
            }
            _context.Remove(foundUsersFavoritePosts);
            _context.SaveChanges();
        }

        public List<UsersFavoritePosts> GetAllUsersFavouritePosts()
        {
            return _context.UsersFavoritePosts.ToList();
        }

        public List<Guid> GetMarketplacePostIdsByUserId(Guid userId)
        {
            return _context.UsersFavoritePosts
                .Where(cart => cart.UserId == userId)
                .Select(cart => cart.MarketplacePostId)
                .ToList();
        }
    }
}
