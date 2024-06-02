using GroupsApp.Models.MarketplacePosts;

namespace GroupsApp.Repositories
{
    public interface IFixedPricePostRepository
    {
        public FixedPricePost AddFixedPricePost(FixedPricePost fixedPricePost);
        public FixedPricePost UpdateFixedPricePost(FixedPricePost fixedPricePost);
        public FixedPricePost? GetFixedPricePostById(Guid id);
        public List<FixedPricePost> GetAllFixedPricePosts();
        public void DeleteFixedPricePost(Guid id);
    }
}
