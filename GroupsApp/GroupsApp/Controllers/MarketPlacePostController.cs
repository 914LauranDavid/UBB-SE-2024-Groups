﻿
using GroupsApp.Mapper;
using GroupsApp.Payloads.DTO;
using GroupsApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BulldozerServer.Controllers
{
    [Route("/[controller]")]
    public class MarketPlacePostController : Controller
    {
        private IPostService postService;

        public MarketPlacePostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpPost]
        public IActionResult AddMarketplacePost(MarketplacePostDTO marketplacePostDTO)
        {
            try
            {
                // MarketplacePostDTO marketplacePostDTO = MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(post);
                var context = this.postService.AddMarketplacePost(marketplacePostDTO);
                return Ok(context);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        public IActionResult RemoveMarketplacePost(MarketplacePostDTO marketplacePostDTO)
        {
            try
            {
                // MarketplacePostDTO marketplacePostDTO = MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(post);
                this.postService.RemoveMarketplacePost(marketplacePostDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarketplacePostById(Guid id)
        {
            try
            {
                var post = await this.postService.GetMarketplacePostById(id);
                MarketplacePostDTO marketplacePostDTO = MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(post);
                return Ok(marketplacePostDTO);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketplacePostDTO>>> GetMarketplacePosts()
        {
            var result = await postService.GetMarketplacePosts();

            if (result == null || result.Value == null)
            {
                return NotFound();
            }

            var posts = result.Value;

            var marketplacePostDTOs = new List<MarketplacePostDTO>();
            foreach (var post in posts)
            {
                marketplacePostDTOs.Add(MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(post));
            }

            return Ok(marketplacePostDTOs);
        }
    }
}
