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
using GroupsApp.Payloads.DTO;

namespace GroupsApp.Controllers
{
    public class CartsController : Controller
    {
        private readonly IUserService _userService;

        const string UNKNOWN_AUTHOR = "Unknown Author";

        public CartsController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            //var groupsAppContext = _context.GroupPosts.Include(g => g.Author).Include(g => g.Group);
            //return View(await groupsAppContext.ToListAsync());
            var groupPosts = this._userService.GetPostsFromCart(Guid.Parse("4f02e552-c02b-48d4-8d7c-1162bcdab88c"));
            return View(groupPosts.Value);
        }


        // GET: Carts/UserCart/5 
        public async Task<IActionResult> UserCart(Guid? cartOwnerId)
        {
            if (cartOwnerId == null)
            {
                return NotFound();
            }

            ViewBag.CartOwnerId = cartOwnerId;

            var postsResult = _userService.GetPostsFromCart((Guid)cartOwnerId);
            if (postsResult == null || postsResult.Value == null || !postsResult.Value.Any())
            {
                ViewBag.Message = "Your cart is empty.";
                ViewBag.AuthorDictionary = new Dictionary<Guid, string>();
                return View(new List<MarketplacePostDTO>());
            }

            ViewBag.AuthorDictionary = GetAuthorDictionary(postsResult.Value);
            return View(postsResult.Value);
        }


        // GET: Carts/Delete/5/2
        public async Task<IActionResult> Delete(Guid? cartOwnerId, Guid? idOfPostToRemove)
        {
            if (cartOwnerId == null || idOfPostToRemove == null)
            {
                return NotFound();
            }
            
            return View(new Cart((Guid)cartOwnerId, (Guid)idOfPostToRemove));
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? cartOwnerId, Guid? idOfPostToRemove)
        {
            if (cartOwnerId == null || idOfPostToRemove == null)
            {
                return NotFound();
            }

            try
            {
                _userService.RemovePostFromCart((Guid)idOfPostToRemove, (Guid)cartOwnerId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(UserCart), new { cartOwnerId = cartOwnerId });
        }

        private Dictionary<Guid, string> GetAuthorDictionary(IEnumerable<MarketplacePostDTO> posts)
        {
            var authorDictionary = new Dictionary<Guid, string>();
            foreach (var post in posts)
            {
                ActionResult<User> authorResult = _userService.GetUserById((Guid)post.AuthorId);
                if (authorResult != null && authorResult.Value != null)
                {
                    authorDictionary[post.MarketplacePostId] = authorResult.Value.Username;
                }
                else
                {
                    authorDictionary[post.MarketplacePostId] = UNKNOWN_AUTHOR;
                }
            }

            return authorDictionary;
        }
    }
}
