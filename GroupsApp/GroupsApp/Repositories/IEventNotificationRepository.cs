using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public interface IEventNotificationRepository
    {
        public EventNotification AddEventNotification(EventNotification eventNotification);
        public EventNotification UpdateEventNotification(EventNotification eventNotification);
        public EventNotification? GetEventNotificationById(Guid id);
        public List<EventNotification> GetAllEventNotifications();
    }
}
