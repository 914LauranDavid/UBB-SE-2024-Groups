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
        private readonly GroupsAppContext _context;
        private readonly IUserService _userService;

        public CartsController(GroupsAppContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }


        // GET: Carts/UserCart/5 
        public async Task<IActionResult> UserCart(Guid? userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            var postsResult = _userService.GetPostsFromCart((Guid)userId);
            if (postsResult == null || postsResult.Value == null || !postsResult.Value.Any())
            {
                ViewBag.Message = "Your cart is empty.";
                return View(new List<MarketplacePostDTO>());
            }

            return View(postsResult.Value);
        }


        // GET: Carts/Delete/5/2
        public async Task<IActionResult> Delete(Guid? userId, Guid? postId)
        {
            if (userId == null || postId == null)
            {
                return NotFound();
            }
            
            return View(new Cart((Guid)userId, (Guid)postId));
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? userId, Guid? postId)
        {
            if (userId == null || postId == null)
            {
                return NotFound();
            }

            try
            {
                _userService.RemovePostFromCart((Guid)postId, (Guid)userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(UserCart), new { id = userId });
        }

    }
}
