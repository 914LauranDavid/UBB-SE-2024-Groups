using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class EventDonationRepository: IEventDonationRepository
    {
        private readonly GroupsAppContext _context;

        public EventDonationRepository(GroupsAppContext context)
        {
            _context = context;
        }

        public EventDonation AddEventDonation(EventDonation eventDonation)
        {
            _context.EventDonations.Add(eventDonation);
            _context.SaveChanges();
            return eventDonation;
        }

        public EventDonation? GetEventDonationById(Guid id)
        {
            return _context.EventDonations.Find(id);
        }

        public EventDonation UpdateEventDonation(EventDonation eventDonation)
        {
            EventDonation? foundEventDonation = _context.EventDonations.Find(eventDonation.EventDonationId);
            if (foundEventDonation == null)
            {
                throw new Exception("Event donation not found");
            }
            foundEventDonation.EventId = eventDonation.EventId;
            foundEventDonation.UserId = eventDonation.UserId;
            foundEventDonation.Amount = eventDonation.Amount;
            EventDonation updatedEventDonation = _context.EventDonations.Update(foundEventDonation).Entity;
            _context.SaveChanges();
            return updatedEventDonation;
        }

        public void DeleteEventDonation(EventDonation eventDonation)
        {
            EventDonation? foundEventDonation = _context.EventDonations.Find(eventDonation.EventDonationId);
            if (foundEventDonation == null)
            {
                throw new Exception("Event donation not found");
            }
            _context.EventDonations.Remove(foundEventDonation);
            _context.SaveChanges();
        }

        public List<EventDonation> GetAllEventDonations()
        {
            return _context.EventDonations.ToList();
        }
    }
}
