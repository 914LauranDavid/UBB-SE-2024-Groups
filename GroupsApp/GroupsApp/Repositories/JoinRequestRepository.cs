using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class JoinRequestRepository(GroupsAppContext context) : IJoinRequestRepository
    {
        private readonly GroupsAppContext _context;

        public JoinRequest AddJoinRequest(JoinRequest joinRequest)
        {
            JoinRequest savedJoinRequest = _context.JoinRequests.Add(joinRequest).Entity;
            _context.SaveChanges();
            return savedJoinRequest;
        }

        public JoinRequest? GetJoinRequestById(Guid joinRequestId)
        {
            return _context.JoinRequests.Find(joinRequestId);
        }

        // Irrelevant
        public JoinRequest UpdateUser(JoinRequest joinRequest)
        {
            JoinRequest? foundJoinRequest = _context.JoinRequests.Find(joinRequest.JoinRequestId);
            if (foundJoinRequest == null)
            {
                throw new Exception("JoinRequest not found");
            }
            foundJoinRequest.User = joinRequest.User;
            foundJoinRequest.Group = joinRequest.Group;
            JoinRequest updatedJoinRequest = _context.JoinRequests.Update(foundJoinRequest).Entity;
            _context.SaveChanges();
            return updatedJoinRequest;
        }

        public void DeleteJoinRequest(JoinRequest joinRequest) {
            JoinRequest? foundJoinRequest = _context.JoinRequests.Find(joinRequest.JoinRequestId);
            if (foundJoinRequest == null)
            {
                throw new Exception("JoinRequest not found");
            }
            _context.JoinRequests.Remove(foundJoinRequest);
            _context.SaveChanges();
        }

        public List<JoinRequest> GetAllJoinRequests()
        {
            return [.. _context.JoinRequests];
        }
    }
}
