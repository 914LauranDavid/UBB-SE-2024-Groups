using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class MembershipRepository(GroupsAppContext context) : IMembershipRepository
    {
        private readonly GroupsAppContext _context = context;

        public Membership AddMembership(Membership membership)
        {
            Membership savedMembership = _context.Memberships.Add(membership).Entity;
            _context.SaveChanges();
            return savedMembership;
        }

        public Membership? GetMembershipById(Guid userId, Guid groupId)
        {
            return _context.Memberships.Find(userId, groupId);
        }

        public void DeleteMembership(Membership membership)
        {
            Membership? foundMembership = _context.Memberships.Find(membership.UserId, membership.GroupId);
            if (foundMembership == null)
            {
                throw new Exception("Membership not found");
            }
            _context.Memberships.Remove(membership);
            _context.SaveChanges();
        }

        public Membership UpdateMembership(Membership membership)
        {
            Membership? foundMembership = _context.Memberships.Find(membership.UserId, membership.GroupId);
            if (foundMembership == null)
            {
                throw new Exception("Membership not found");
            }
            foundMembership.IsAdmin = membership.IsAdmin;
            foundMembership.IsBanned = membership.IsBanned;
            foundMembership.IsTimedOut = membership.IsTimedOut;
            Membership updatedMembership = _context.Memberships.Update(foundMembership).Entity;
            _context.SaveChanges();
            return updatedMembership;
        }

        public List<Membership> GetAllMemberships()
        {
            return [.. _context.Memberships];
        }
    }
}
