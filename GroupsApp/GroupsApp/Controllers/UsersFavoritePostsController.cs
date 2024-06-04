﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupsApp.Data;
using GroupsApp.Models;
using GroupsApp.Services;

namespace GroupsApp.Controllers
{
    public class UsersFavoritePostsController : Controller
    {
        private readonly IUserService userService;
        private readonly IPostService postService;

        public UsersFavoritePostsController(IUserService userService, IPostService postService)
        {
            this.userService = userService;
            this.postService = postService;
        }

        // GET: UsersFavoritePosts
        public async Task<IActionResult> Index()
        {
            //return View(postService.GetMarketplacePosts());
            var favoritePosts = this.userService.GetFavoritePosts(Guid.Parse("2fda6ef7-ca09-4c63-9c25-dd4e31f67374"));
            return View(favoritePosts.Value);
        }

        // GET: MarketplacePosts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketplacePost = postService.GetMarketplacePostById(id.Value);

            if (marketplacePost == null)
            {
                return NotFound();
            }

            return View(marketplacePost);
        }

        // GET: UsersFavoritePosts/Delete/5/2
        public async Task<IActionResult> Delete(Guid? userId, Guid? postId)
        {
            Console.WriteLine(userId);
            Console.WriteLine(postId);
            if (userId == null || postId == null)
            {
                return NotFound();
            }

            return View(new UsersFavoritePosts((Guid)userId, (Guid)postId));
        }

        // POST: UsersFavoritePosts/Delete/5/2
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid userId, Guid marketPlacePostId)
        {
            Console.WriteLine(userId);
            Console.WriteLine(marketPlacePostId);
            var usersFavoritePosts = userService.GetFavoritePosts(userId);
            if (usersFavoritePosts != null)
            {
                userService.RemovePostFromFavorites(marketPlacePostId, userId);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
