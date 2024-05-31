using GroupsApp.Models;
using GroupsApp.Payload.DTO;

namespace GroupsApp.Mapper
{
    public class EventReviewMapper
    {
        public static EventReview EventExpenseDTOToEventExpense(EventReviewDTO eventReviewDTO)
        {
            return new EventReview(eventReviewDTO.UserId, eventReviewDTO.EventId, eventReviewDTO.Score, eventReviewDTO.ReviewDescription);
        }

        public static EventReviewDTO EventReviewToEventReviewDTO(EventReview eventReview)
        {
            EventReviewDTO eventReviewDTO = new EventReviewDTO();
            eventReviewDTO.EventId = eventReview.EventId;
            eventReviewDTO.UserId = eventReview.UserId;
            eventReviewDTO.Score = eventReview.Score;
            eventReviewDTO.ReviewDescription = eventReview.ReviewDescription;

            return eventReviewDTO;
        }
    }
}
