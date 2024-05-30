using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class EventRepository(GroupsAppContext context):IEventRepository
    {
        private readonly GroupsAppContext _context = context;

        public Event AddEvent(Event marketplaceEvent)
        {
            _context.Events.Add(marketplaceEvent);
            _context.SaveChanges();
            return marketplaceEvent;
        }

        public Event? GetEventById(Guid id)
        {
            return _context.Events.Find(id);
        }

        public Event UpdateEvent(Event marketplaceEvent)
        {
            Event? foundEvent = _context.Events.Find(marketplaceEvent.EventId);
            if (foundEvent == null)
            {
                throw new Exception("Event not found");
            }
            foundEvent.OrganizerId = marketplaceEvent.OrganizerId;
            foundEvent.EventName = marketplaceEvent.EventName;
            foundEvent.Categories = marketplaceEvent.Categories;
            foundEvent.Location = marketplaceEvent.Location;
            foundEvent.MaxParticipants = marketplaceEvent.MaxParticipants;
            foundEvent.Description = marketplaceEvent.Description;
            foundEvent.StartDate = marketplaceEvent.StartDate;
            foundEvent.EndDate = marketplaceEvent.EndDate;
            foundEvent.BannerURL = marketplaceEvent.BannerURL;
            foundEvent.LogoURL = marketplaceEvent.LogoURL;
            foundEvent.AgeLimit = marketplaceEvent.AgeLimit;
            foundEvent.EntryFee = marketplaceEvent.EntryFee;
            Event updatedEvent = _context.Events.Update(foundEvent).Entity;
            _context.SaveChanges();
            return updatedEvent;
        }

        public void DeleteEvent(Event marketplaceEvent)
        {
            Event? foundEvent = _context.Events.Find(marketplaceEvent.EventId);
            if (foundEvent == null)
            {
                throw new Exception("Event not found");
            }
            _context.Events.Remove(foundEvent);
            _context.SaveChanges();
        }

        public List<Event> GetAllEvents()
        {
            return _context.Events.ToList();
        }
    }
}
