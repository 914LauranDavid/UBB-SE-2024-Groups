﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BulldozerServer.Mapper;
using GroupsApp.Data;
using GroupsApp.Models;
using GroupsApp.Payload.DTO;
using GroupsApp.Payloads.DTO;
using GroupsApp.Repositories;
using GroupsApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GroupsApp.Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;
        private MarketplacePostRepository _marketplacePostRepository;
        private CartRepository _cartRepository;
        private UsersFavoritePostsRepository _usersFavoritePostsRepository;
        private GroupRepository _groupRepository;

        public UserService(UserRepository userRepository, MarketplacePostRepository marketplacePostRepository, CartRepository cartRepository, UsersFavoritePostsRepository usersFavoritePostsRepository, GroupRepository groupRepository)
        {
            _userRepository = userRepository;
            _marketplacePostRepository = marketplacePostRepository;
            _cartRepository = cartRepository;
            _usersFavoritePostsRepository = usersFavoritePostsRepository;
            _groupRepository = groupRepository;
        }

        public void AddPostToCart(Guid postId, Guid userId)
        {
            var foundUser = _userRepository.GetUserById(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var foundPost = _marketplacePostRepository.GetMarketplacePostById(postId);
            if (foundPost == null)
            {
                throw new Exception("Post not found");
            }
            Cart cart = new Cart { UserId = userId, MarketplacePostId = postId };
            _cartRepository.AddCart(cart);
        }

        public void AddPostToFavorites(Guid postId, Guid userId)
        {
            var foundUser = _userRepository.GetUserById(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var foundPost = _marketplacePostRepository.GetMarketplacePostById(postId);
            if (foundPost == null)
            {
                throw new Exception("Post not found");
            }
            UsersFavoritePosts usersFavoritePosts = new UsersFavoritePosts { UserId = userId, MarketplacePostId = postId };
            var result = _usersFavoritePostsRepository.AddUsersFavoritePosts(usersFavoritePosts);
        }

        public UserDto AddUser(UserDto userDto)
        {
            // comments
            var addedUser = _userRepository.AddUser(UserMapper.MapUserDtoToUser(userDto));
            return UserMapper.MapUserToUserDto(addedUser);
        }

        public List<MarketplacePostDTO> GetFavoritePosts(Guid userId)
        {
            var foundUser = _userRepository.GetUserById(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var favoritePosts = _marketplacePostRepository.GetMarketplacePostsByAuthorId(userId).ToList();
            return favoritePosts.Select(post => MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(post)).ToList();
        }

        public User GetUserById(Guid id)
        {
            var foundUser = _userRepository.GetUserById(id);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            return foundUser;
        }

        public List<User> GetUsers()
        {
            var users =_userRepository.GetAllUsers();
            // if (users == null)
            // {
            //    throw new Exception("No users found");
            // }
            return users;
        }

        public bool IsUserInGroup(Guid userId, Guid groupId)
        {
            var foundUser = _userRepository.GetUserById(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var foundGroup = _groupRepository.GetGroupById(groupId);
            if (foundGroup == null)
            {
                throw new Exception("Group not found");
            }
            return foundUser.GroupsPartOf.Contains(foundGroup);
        }

        public void RemovePostFromCart(Guid postId, Guid userId)
        {
            var foundUser = _userRepository.GetUserById(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var foundPost = _marketplacePostRepository.GetMarketplacePostById(postId);
            if (foundPost == null)
            {
                throw new Exception("Post not found");
            }
            foundUser.PostsInCart.Remove(foundPost);
        }

        public void RemovePostFromFavorites(Guid postId, Guid userId)
        {
            var foundUser = _userRepository.GetUserById(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var foundPost = _marketplacePostRepository.GetMarketplacePostById(postId);
            if (foundPost == null)
            {
                throw new Exception("Post not found");
            }
            foundUser.FavoritePosts.Remove(foundPost);
        }

        public void RemoveUser(Guid userId)
        {
            var userToRemove = _userRepository.GetUserById(userId);
            if (userToRemove == null)
            {
                throw new Exception("User not found");
            }
            _userRepository.DeleteUser(userToRemove);
        }

        public User UpdateUser(UserDto userDto)
        {
            var foundUser = _userRepository.GetUserById(userDto.UserId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            foundUser.Username = userDto.Username;
            foundUser.FullName = userDto.FullName;
            foundUser.Email = userDto.Email;
            foundUser.PhoneNumber = userDto.PhoneNumber;
            foundUser.Password = userDto.Password;
            foundUser.BirthDay = userDto.BirthDay;
            _userRepository.UpdateUser(foundUser);
            return foundUser;
        }

        public List<MarketplacePostDTO> GetPostsFromCart(Guid userId)
        {
            var foundUser = _userRepository.GetUserById(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            List<Guid> postIds = _cartRepository.GetMarketplacePostIdsByUserId(userId);
        
            List<MarketplacePostDTO> posts = new List<MarketplacePostDTO>();
            foreach (Guid id in postIds)
            {
                var post = _marketplacePostRepository.GetMarketplacePostById(id);
                if (post != null)
                {
                    posts.Add(MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(post));
                }
            }
            return posts;
        }
    }
}
