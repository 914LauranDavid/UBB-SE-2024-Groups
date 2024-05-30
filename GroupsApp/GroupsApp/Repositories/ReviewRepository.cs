using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class ReviewRepository(GroupsAppContext context)
    {
        private readonly GroupsAppContext _context = context;

        /*
        public Review AddReview(Review review)
        {
            Review savedReview = _context.Reviews.Add(review).Entity;
            _context.SaveChanges();
            return savedReview;
        }

        public Review? GetReviewById(Guid reviewId)
        {
            return _context.Reviews.Find(reviewId);
        }

        public Review UpdateReview(Review review)
        {
            Review? foundReview = _context.Reviews.Find(review.ReviewId);
            if (foundReview != null)
            {
                throw new Exception("Review not found");
            }
            foundReview.Content = review.Content;
            foundReview.Rating = review.Rating;
            Review updatedReview = _context.Reviews.Update(review).Entity;
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
