using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BulldozerServer.Mapper;
using GroupsApp.Data;
using GroupsApp.Models.MarketplacePosts;
using GroupsApp.Payloads.DTO;
using GroupsApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Hosting;

namespace GroupsApp.Services
{
    public class PostService : IPostService
    {
        private readonly MarketplacePostRepository _marketplacePostRepository;

        public PostService(MarketplacePostRepository marketplacePostRepository)
        {
            _marketplacePostRepository = marketplacePostRepository;
        }
        public IEnumerable<MarketplacePost> GetMarketplacePosts()
        {
            return _marketplacePostRepository.GetAllMarketplacePosts();
        }

        public MarketplacePostDTO AddMarketplacePost(MarketplacePostDTO marketplacePostDTO)
        {
            var marketplacePost = MarketplacePostMapper.MapMarketplacePostDTOToMarketplacePost(marketplacePostDTO);
            var context = _marketplacePostRepository.AddMarketplacePost(marketplacePost);
            // _marketplacePostRepository.SaveChanges();
            return MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(context);
        }
        public  void RemoveMarketplacePost(MarketplacePostDTO marketplacePostDTO)
        {
            var marketplacePost = MarketplacePostMapper.MapMarketplacePostDTOToMarketplacePost(marketplacePostDTO);
            var postToDelete = _marketplacePostRepository.GetMarketplacePostById(marketplacePost.MarketplacePostId);
            if (postToDelete == null)
            {
                throw new Exception("Post doesn't exist!");
            }
             _marketplacePostRepository.DeleteMarketplacePost(marketplacePost.MarketplacePostId);
            // await _marketplacePostRepository.SaveChangesAsync();
        }
        public MarketplacePost GetMarketplacePostById(Guid id)
        {
            var postToDelete =  _marketplacePostRepository.GetMarketplacePostById(id);
            if (postToDelete == null)
            {
                throw new Exception("Post doesn't exist!");
            }
            return postToDelete;
        }
    }
}
