using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class PollOptionRepository(GroupsAppContext context)
    {
        private readonly GroupsAppContext _context = context;

        public PollOption AddPollOption(PollOption pollOption)
        {
            PollOption savedPollOption = _context.PollOptions.Add(pollOption).Entity;
            _context.SaveChanges();
            return savedPollOption;
        }

        public PollOption? GetPollOptionById(Guid pollOptionId)
        {
            return _context.PollOptions.Find(pollOptionId);
        }

        public PollOption UpdatePollOption(PollOption pollOption)
        {
            PollOption? foundPollOption = _context.PollOptions.Find(pollOption.PollOptionId);
            if (foundPollOption == null)
            {
                throw new Exception("PollOption not found");
            }
            foundPollOption.Option = pollOption.Option;
            PollOption updatedPollOption = _context.PollOptions.Update(foundPollOption).Entity;
            _context.SaveChanges();
            return updatedPollOption;
        }

        public void DeletePollOption(PollOption pollOption)
        {
            PollOption? foundPollOption = _context.PollOptions.Find(pollOption.PollOptionId);
            if (foundPollOption == null)
            {
                throw new Exception("PollOption not found");
            }
            _context.PollOptions.Remove(pollOption);
            _context.SaveChanges();
        }

        public List<PollOption> GetAllPollOptions()
        {
            return [.. _context.PollOptions];
        }
    }
}
