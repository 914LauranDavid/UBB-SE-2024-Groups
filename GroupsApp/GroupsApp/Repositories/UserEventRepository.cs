using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class UserEventRepository : IUserEventRepository
    {
        private readonly GroupsAppContext _context;

        public UserEventRepository(GroupsAppContext context)
        {
            _context = context;
        }

        public UserEvent AddUserEvent(UserEvent userEvent)
        {
            _context.UserEvents.Add(userEvent);
            _context.SaveChanges();
            return userEvent;
        }

        public UserEvent? GetUserEventById(Guid userId, Guid eventId)
        {
            return _context.UserEvents.SingleOrDefault(ue => ue.UserId == userId && ue.EventId == eventId);
        }

        public UserEvent UpdateUserEvent(UserEvent userEvent)
        {
            UserEvent? foundUserEvent = _context.UserEvents.SingleOrDefault(ue => ue.UserId == userEvent.UserId && ue.EventId == userEvent.EventId);
            if (foundUserEvent == null)
            {
                throw new Exception("UserEvent not found");
            }
            foundUserEvent.Status = userEvent.Status;
            UserEvent updatedUserEvent = _context.UserEvents.Update(foundUserEvent).Entity;
            _context.SaveChanges();
            return updatedUserEvent;
        }

        public void DeleteUserEvent(Guid userId, Guid eventId)
        {
            UserEvent? foundUserEvent = _context.UserEvents.SingleOrDefault(ue => ue.UserId == userId && ue.EventId == eventId);
            if (foundUserEvent == null)
            {
                throw new Exception("UserEvent not found");
            }
            _context.UserEvents.Remove(foundUserEvent);
            _context.SaveChanges();
        }

        public List<UserEvent> GetAllUserEvents()
        {
            return _context.UserEvents.ToList();
        }

        public List<UserEvent> GetUserEventsByUserId(Guid userId)
        {
            return _context.UserEvents.Where(ue => ue.UserId == userId).ToList();
        }

        public List<UserEvent> GetUserEventsByEventId(Guid eventId)
        {
            return _context.UserEvents.Where(ue => ue.EventId == eventId).ToList();
        }
    }
}
