using GroupsApp.Models;
using GroupsApp.Payload.DTO;

namespace GroupsApp.Services
{
    public interface IPollService
    {
        public List<PollDTO> GetGroupPolls(Guid groupId);
        public PollDTO AddNewPoll(PollDTO pollDTO);
        public PollDTO GetPollById(Guid idPoll);
    }
}
