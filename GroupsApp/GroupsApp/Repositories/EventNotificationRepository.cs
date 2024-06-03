using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class EventNotificationRepository : IEventNotificationRepository
    {
        private readonly GroupsAppContext _context;

        public EventNotificationRepository(GroupsAppContext context)
        {
            _context = context;
        }

        public EventNotification AddEventNotification(EventNotification eventNotification)
        {
            _context.EventNotifications.Add(eventNotification);
            _context.SaveChanges();
            return eventNotification;
        }

        public EventNotification UpdateEventNotification(EventNotification eventNotification)
        {
            _context.EventNotifications.Update(eventNotification);
            _context.SaveChanges();
            return eventNotification;
        }

        public EventNotification? GetEventNotificationById(Guid id)
        {
            return _context.EventNotifications.Find(id);
        }

        public List<EventNotification> GetAllEventNotifications()
        {
            return _context.EventNotifications.ToList();
        }
    }
}
