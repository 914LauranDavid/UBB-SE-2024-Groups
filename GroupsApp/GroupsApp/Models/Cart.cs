using GroupsApp.Models.MarketplacePosts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupsApp.Models
{
    public class Cart
    {
        private Guid userId;
        private Guid marketplacePostId;

        public Guid UserId { get => userId; set => userId = value; }
        public Guid MarketplacePostId { get => marketplacePostId; set => marketplacePostId = value; }

        public User User { get; set; }

        public MarketplacePost MarketplacePost { get; set; }

        public Cart(Guid userId, Guid marketplacePostId)
        {
            this.userId = userId;
            this.marketplacePostId = marketplacePostId;
        }

        public Cart()
        {
            this.userId = Guid.NewGuid();
            this.marketplacePostId = Guid.NewGuid();
        }
    }
}