using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public interface IEventRepository
    {
        public Event AddEvent(Event marketplaceEvent);
        public void DeleteEvent(Event marketplaceEvent);
        public Event UpdateEvent(Event marketplaceEvent);
        public Event? GetEventById(Guid id);
        public List<Event> GetAllEvents();
        public void DeleteEventById(Guid eventId);

    }
}
