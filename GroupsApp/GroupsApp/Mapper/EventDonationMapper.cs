using GroupsApp.Models;
using GroupsApp.Payload.DTO;

namespace GroupsApp.Mapper
{
    public class EventDonationMapper
    {
        public static EventDonation EventDonationDTOToEventDonation(EventDonationDTO eventDonationDTO)
        {
            return new EventDonation(eventDonationDTO.EventDonationId, eventDonationDTO.EventId, eventDonationDTO.UserId, eventDonationDTO.Amount);
        }

        public static EventDonationDTO EventDonationToEventDonationDTO(EventDonation eventDonation)
        {
            EventDonationDTO eventDonationDTO = new EventDonationDTO();
            eventDonationDTO.EventDonationId = eventDonation.EventDonationId;
            eventDonationDTO.EventId = eventDonation.EventId;
            eventDonationDTO.UserId = eventDonation.UserId;
            eventDonationDTO.Amount = eventDonation.Amount;
            return eventDonationDTO;
        }
    }
}
