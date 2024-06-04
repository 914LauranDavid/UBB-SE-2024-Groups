using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupsApp.Models
{
    public class UsersFavoritePosts
    {
        private Guid userId;
        private Guid marketplacePostId;

        public UsersFavoritePosts(Guid userId, Guid postId)
        {
            this.userId = userId;
            this.marketplacePostId = postId;
        }

        public UsersFavoritePosts()
        {
            this.userId = Guid.NewGuid();
            this.marketplacePostId = Guid.NewGuid();
        }

        public Guid UserId { get => userId; set => userId = value; }
        public Guid MarketplacePostId { get => marketplacePostId; set => marketplacePostId = value; }
    }
}
