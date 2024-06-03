using GroupsApp.Models;
using GroupsApp.Payload.DTO;

namespace GroupsApp.Mapper
{
    public static class EventMapper
    {
        public static Event EventDTOToEvent(EventDTO eventDTO)
        {
            return new Event(eventDTO.EventId, eventDTO.OrganizerId, eventDTO.EventName, eventDTO.Categories, eventDTO.Location, eventDTO.MaxParticipants, eventDTO.Description, eventDTO.StartDate, eventDTO.EndDate, eventDTO.BannerURL, eventDTO.LogoURL, eventDTO.AgeLimit, eventDTO.EntryFee);
        }

        public static EventDTO EventToEventDTO(Event eventX)
        {
            EventDTO eventDTO = new EventDTO();
            eventDTO.EventId = eventX.EventId;
            return eventDTO;
        }
    }
}
