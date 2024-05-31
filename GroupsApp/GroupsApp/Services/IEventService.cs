using GroupsApp.Models;
using GroupsApp.Payload.DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GroupsApp.Services
{
    public interface IEventService
    {
        Event CreateEvent(EventDTO eventDTO);
        Event UpdateEvent(EventDTO eventDTO);
        void DeleteEventById(Guid id);

        List<Event> GetAllEvents();
        Event GetEventById(Guid id);
    }
}
