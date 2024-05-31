using Microsoft.AspNetCore.Mvc;
using GroupsApp.Services;
using Microsoft.EntityFrameworkCore;
using GroupsApp.Models;
using GroupsApp.Payload.DTO;
using GroupsApp.Payloads.DTO;


namespace GroupsApp.WPF_Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService service)
        {
            userService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok( userService.GetUsers());
            // try
            // {
            // }
            // catch (Exception e)
            // {
            //    return NotFound(e);
            // }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(Guid id)
        {
            try
            {
                var user =  userService.GetUserById(id);
                return user;
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<UserDto> AddUser(UserDto userDto)
        {
            var createdUser =  userService.AddUser(userDto);
            return Ok(createdUser);
        }

        [HttpDelete]
        public async Task<ActionResult<User>> DeleteUser(Guid userId)
        {
           // Guid ownerId = Guid.Parse(Request.Query["id"]);
           userService.RemoveUser(userId);
           return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateUser(UserDto userDto)
        {
             userService.UpdateUser(userDto);
            return NoContent();
        }

        [HttpGet("{userId}/favoritePosts")]
        public ActionResult<IEnumerable<MarketplacePostDTO>> GetFavoritePosts(Guid userId)
        {
            try
            {
                List<MarketplacePostDTO> marketplacePosts =  userService.GetFavoritePosts(userId).Value;
                return Ok(marketplacePosts);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpGet("{userId}/cart")]
        public ActionResult<IEnumerable<MarketplacePostDTO>> GetPostsFromCart(Guid userId)
        {
            try
            {
                return userService.GetPostsFromCart(userId).Value;
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpPost("{userId}/cart/{postId}")]
        public async Task<ActionResult<User>> AddPostToCart(Guid userId, Guid postId)
        {
                userService.AddPostToCart(postId, userId);
                return Ok();
        }

        [HttpPost("{userId}/favoritePosts/{postId}")]
        public ActionResult<User> AddPostToFavorites(Guid userId, Guid postId)
        {
            try
            {
                userService.AddPostToFavorites(postId, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpDelete("{userId}/cart/{postId}")]
        public ActionResult<User> RemovePostFromCart(Guid userId, Guid postId)
        {
            try
            {
                userService.RemovePostFromCart(postId, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpDelete("{userId}/favoritePosts/{postId}")]
        public ActionResult<User> RemovePostFromFavorites(Guid userId, Guid postId)
        {
            try
            {
                userService.RemovePostFromFavorites(postId, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        private bool UserExists(Guid id)
        {
            return userService.GetUsers().Value.Any(e => e.UserId == id);
        }
    }
}

