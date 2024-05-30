using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public interface IEventReviewRepository
    {
        public EventReview AddEventReview(EventReview eventReview);
        public EventReview UpdateEventReview(EventReview eventReview);
        public void DeleteEventReview(Guid userId, Guid eventId);
        public List<EventReview> GetAllEventReviews();
        public List<EventReview> GetEventReviewsByEventId(Guid id);
        public List<EventReview> GetEventReviewsByUserId(Guid id);
    }
}
