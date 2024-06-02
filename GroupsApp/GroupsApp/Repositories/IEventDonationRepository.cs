using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public interface IEventDonationRepository
    {
        public EventDonation AddEventDonation(EventDonation eventDonation);
        public EventDonation? GetEventDonationById(Guid id);
        public EventDonation UpdateEventDonation(EventDonation eventDonation);
        public void DeleteEventDonation(EventDonation eventDonation);
        public List<EventDonation> GetAllEventDonations();
    }
}
