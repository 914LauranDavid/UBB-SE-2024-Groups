using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class MarketplacePostReviewRepository(GroupsAppContext context): IMarketplacePostReviewRepository
    {
        /*
        private readonly GroupsAppContext _context = context;

        
        public MarketplacePostReview AddReview(MarketplacePostReview review)
        {
            MarketplacePostReview savedReview = _context.MarketplacePostReviews.Add(review).Entity;
            _context.SaveChanges();
            return savedReview;
        }

        public MarketplacePostReview? GetReviewById(Guid reviewId)
        {
            return _context.MarketplacePostReviews.Find(reviewId);
        }

        public MarketplacePostReview UpdateReview(MarketplacePostReview review)
        {
            MarketplacePostReview? foundReview = _context.MarketplacePostReviews.Find(review.ReviewId);
            if (foundReview != null)
            {
                throw new Exception("Review not found");
            }
            foundReview.Content = review.Content;
            foundReview.Rating = review.Rating;
            MarketplacePostReview updatedReview = _context.MarketplacePostReviews.Update(review).Entity;
            _context.SaveChanges();
            return updatedReview;
        }

        public void DeleteReview(Review review) {
            Review? foundReview = _context.Reviews.Find(review.ReviewId);
            if (foundReview != null)
            {
                throw new Exception("Review not found");
            }
            _context.Reviews.Remove(review);
            _context.SaveChanges();
        }

        public List<Review> GetAllReviews()
        {
            return [.. _context.Reviews];
        }
        */
    }
}
