using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class PollAnswerRepository(GroupsAppContext context)
{
        private readonly GroupsAppContext _context = context;

        public PollAnswer AddPollAnswer(PollAnswer pollAnswer)
        {
            PollAnswer savedPollAnswer = _context.PollAnswers.Add(pollAnswer).Entity;
            _context.SaveChanges();
            return savedPollAnswer;
        }

        //
        public PollAnswer? GetPollAnswerByIds(Guid pollOptionId, Guid userId)
        {
            return _context.PollAnswers.Find(pollOptionId, userId);
        }

        public void DeletePollAnswer(PollAnswer pollAnswer)
        {
            PollAnswer? foundPollAnswer = _context.PollAnswers.Find(pollAnswer);
            if (foundPollAnswer == null)
            {
                throw new Exception("PollAnswer not found");
            }
            _context.PollAnswers.Remove(foundPollAnswer);
            _context.SaveChanges();
        }

        public List<PollAnswer> GetAllPollAnswers()
        {
            return [.. _context.PollAnswers];
        }
    }
}
