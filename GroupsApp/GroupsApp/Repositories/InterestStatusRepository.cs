using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class InterestStatusRepository(GroupsAppContext context)
    {
        private readonly GroupsAppContext _context = context;
        
        /*
        public InterestStatus AddInterestStatus(InterestStatus interestStatus)
        {
            InterestStatus savedInterestStatus = _context.InterestStatuses.Add(interestStatus).Entity;
            _context.SaveChanges();
            return savedInterestStatus;
        }

        public InterestStatus? GetInterestStatusById(Guid interestStatusId)
        {
            return _context.InterestStatuses.Find(interestStatusId);
        }

        public InterestStatus UpdateInterestStatus(InterestStatus interestStatus)
        {
            InterestStatus? foundInterestStatus _context.InterestStatuses.Find(interestStatus.InterestStatusId);
            if (foundInterestStatus != null)
            {
                throw new Exception("InterestStatus not found");
            }

            InterestStatus updatedInterestStatus = _context.InterestStatuses.Update(foundInterestStatus).Entity;
            _context.SaveChanges();
            return updatedInterestStatus;
        }

        public void DeleteInterestStatusById(InterestStatus interestStatus)
        {
            InterestStatus? foundInterestStatus _context.InterestStatuses.Find(interestStatus.InterestStatusId);
            if (foundInterestStatus != null)
            {
                throw new Exception("InterestStatus not found");
            }
            _context.InterestStatuses.Remove(interestStatus)
            _context.SaveChanges();
        }

        public List<InterestStatus> GetAllInterestStatuses()
        {
            return [.. _context.InterestStatuses]
        }
        */
    }
}
