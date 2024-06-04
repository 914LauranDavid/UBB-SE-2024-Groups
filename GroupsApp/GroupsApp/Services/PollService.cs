using GroupsApp.Mapper;
using GroupsApp.Models;
using GroupsApp.Payload.DTO;
using GroupsApp.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GroupsApp.Services
{
    public class PollService : IPollService
    {
        private readonly IPollRepository _pollRepository;

        public PollService(IPollRepository pollRepository)
        {
            _pollRepository = pollRepository;
        }

        public PollDTO AddNewPoll(PollDTO pollDTO)
        {
            Poll pollToAdd = PollMapper.MapPollDtoToPoll(pollDTO);

            if(_pollRepository.GetPollById(pollToAdd.PollId) != null)
            {
                throw new Exception("Poll already added!");
            }
            return PollMapper.MapPollToPollDTO(_pollRepository.AddPoll(pollToAdd));
        }

        public List<PollDTO> GetGroupPolls(Guid groupId)
        {
            return _pollRepository.GetAllPolls().Select(p => PollMapper.MapPollToPollDTO(p)).ToList();
        }

        public PollDTO GetPollById(Guid idPoll)
        {
            Poll? pollWithGivenId = _pollRepository.GetPollById(idPoll);
            if(pollWithGivenId == null)
            {
                throw new Exception("No poll with this id");
            }
            return PollMapper.MapPollToPollDTO(pollWithGivenId);
        }
    }
}
