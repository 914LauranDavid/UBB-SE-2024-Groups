using GroupsApp.Models;
using GroupsApp.Payload.DTO;

namespace GroupsApp.Mapper
{
    public class EventMapper
    {
        public static Event EventDTOToEvent(EventDTO eventDTO)
        {
            return new Event(eventDTO.EventId, eventDTO.OrganizerId, eventDTO.EventName, eventDTO.Categories, eventDTO.Location, eventDTO.MaxParticipants, eventDTO.Description, eventDTO.StartDate, eventDTO.EndDate, eventDTO.BannerURL, eventDTO.LogoURL, eventDTO.AgeLimit, eventDTO.EntryFee);
        }

        /*public static EventDTO EventToEventDTO(Event event)
        {
            EventDTO eventDTO = new EventDTO();
            eventDTO.EventId = event.EventId;
            return eventDTO;
        }*/
    }
}
