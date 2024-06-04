using System;
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

        public UsersFavoritePostsController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: UsersFavoritePosts
        public async Task<IActionResult> Index()
        {
            //return View(postService.GetMarketplacePosts());
            var favoritePosts = this.userService.GetFavoritePosts(Guid.Parse("2fda6ef7-ca09-4c63-9c25-dd4e31f67374"));
            return View(favoritePosts.Value);
        }

        // GET: UsersFavoritePosts/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersFavoritePosts = userService.GetFavoritePosts(id);

            if (usersFavoritePosts == null)
            {
                return NotFound();
            }

            return View(usersFavoritePosts);
        }

        // POST: UsersFavoritePosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid postId, Guid userId)
        {

            var usersFavoritePosts = userService.GetFavoritePosts(userId);
            if (usersFavoritePosts != null)
            {
                userService.RemovePostFromFavorites(postId, userId);
            }

            return RedirectToAction(nameof(userId));
        }
    }
}
