using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class EventReviewRepository
    {
        private readonly GroupsAppContext _context;

        public EventReviewRepository(GroupsAppContext context)
        {
            _context = context;
        }

        public EventReview AddEventReview(EventReview eventReview)
        {
            _context.EventReviews.Add(eventReview);
            _context.SaveChanges();
            return eventReview;
        }

        public EventReview? GetEventReviewById(Guid userId, Guid eventId)
        {
            return _context.EventReviews.SingleOrDefault(er => er.UserId == userId && er.EventId == eventId);
        }

        public EventReview UpdateEventReview(EventReview eventReview)
        {
            EventReview? foundEventReview = _context.EventReviews.SingleOrDefault(er => er.UserId == eventReview.UserId && er.EventId == eventReview.EventId);
            if (foundEventReview == null)
            {
                throw new Exception("Event review not found");
            }
            foundEventReview.Score = eventReview.Score;
            foundEventReview.ReviewDescription = eventReview.ReviewDescription;
            EventReview updatedEventReview = _context.EventReviews.Update(foundEventReview).Entity;
            _context.SaveChanges();
            return updatedEventReview;
        }

        public void DeleteEventReview(Guid userId, Guid eventId)
        {
            EventReview? foundEventReview = _context.EventReviews.SingleOrDefault(er => er.UserId == userId && er.EventId == eventId);
            if (foundEventReview == null)
            {
                throw new Exception("Event review not found");
            }
            _context.EventReviews.Remove(foundEventReview);
            _context.SaveChanges();
        }

        public List<EventReview> GetAllEventReviews()
        {
            return _context.EventReviews.ToList();
        }

        public List<EventReview> GetEventReviewsByEventId(Guid eventId)
        {
            return _context.EventReviews.Where(er => er.EventId == eventId).ToList();
        }

        public List<EventReview> GetEventReviewsByUserId(Guid userId)
        {
            return _context.EventReviews.Where(er => er.UserId == userId).ToList();
        }
    }
}
