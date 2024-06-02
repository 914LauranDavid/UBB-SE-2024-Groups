using GroupsApp.Models;
using GroupsApp.Payload.DTO;

namespace GroupsApp.Mapper
{
    public class EventReportMapper
    {
        public static EventReportDTO EventReportToEventReportDTO(EventReport eventReport)
        {
            EventReportDTO eventReportDTO = new EventReportDTO();
            eventReportDTO.EventId = eventReport.EventId;
            eventReportDTO.UserId = eventReport.UserId;
            eventReportDTO.ReportTypeValue = eventReport.ReportTypeValue;
            return eventReportDTO;
        }

        public static EventReport EventReportDTOToEventReport(EventReportDTO eventReportDTO)
        {
            return new EventReport(eventReportDTO.EventId, eventReportDTO.UserId, eventReportDTO.ReportTypeValue);
        }
    }
}
