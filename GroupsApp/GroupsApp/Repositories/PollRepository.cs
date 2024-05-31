using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class PollRepository(GroupsAppContext context) : IPollRepository
    {
        private readonly GroupsAppContext _context;

        public Poll AddPoll(Poll poll)
        {
            Poll savedPoll = _context.Polls.Add(poll).Entity;
            _context.SaveChanges();
            return savedPoll;
        }

        public Poll? GetPollById(Guid id)
        {
            return _context.Polls.Find(id);
        }

        public Poll UpdatePoll(Poll poll)
        {
            Poll? foundPoll = _context.Polls.Find(poll.PollId);
            if (foundPoll == null)
                throw new Exception("Poll not found");
            foundPoll.Description = poll.Description;
            foundPoll.EndDate = poll.EndDate;
            foundPoll.IsPinned = poll.IsPinned;
            foundPoll.IsVisible = poll.IsVisible;
            foundPoll.IsMultipleChoice = poll.IsMultipleChoice;
            foundPoll.IsAnonymous = poll.IsAnonymous;
            Poll updatedPoll = _context.Polls.Update(foundPoll).Entity;
            _context.SaveChanges();
            return foundPoll;
        }

        public void DeletePoll(Poll poll)
        {
            Poll? foundPoll = _context.Polls.Find(poll.PollId);
            if (foundPoll == null) throw new Exception("Poll not found");
            _context.Polls.Remove(foundPoll);
            _context.SaveChanges();
        }

        public List<Poll> GetAllPolls()
        {
            return [.. _context.Polls];
        }
    }
}
