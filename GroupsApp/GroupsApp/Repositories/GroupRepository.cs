using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class GroupRepository(GroupsAppContext context):IGroupRepository
    {
        private readonly GroupsAppContext _context = context;

        public Group AddGroup(Group group)
        {
            if (_context.Groups.Find(group.GroupId)!=null) {
                throw new Exception("Group with this id already exists!");
            }
            Group savedGroup = _context.Groups.Add(group).Entity;
            _context.SaveChanges();
            return savedGroup;
        }

        public Group? GetGroupById(Guid id)
        {
            return _context.Groups.Find(id);
        }

        public void DeleteGroup(Group group)
        {
            Group? foundGroup = _context.Groups.Find(group.GroupId);
            if (foundGroup == null)
            {
                throw new Exception("Group not found");
            }
            _context.Groups.Remove(group);
            _context.SaveChanges();
        }

        public Group UpdateGroup(Group group)
        {
            Group? foundGroup = _context.Groups.Find(group.GroupId);
            if (foundGroup == null)
            {
                throw new Exception("Group not found");
            }
            foundGroup.Description = group.Description;
            foundGroup.GroupName = group.GroupName;
            foundGroup.IsPublic = group.IsPublic;
            foundGroup.AllowanceOfPostage = group.AllowanceOfPostage;
            Group updatedGroup = _context.Groups.Update(foundGroup).Entity;
            _context.SaveChanges();
            return updatedGroup;
        }

        public List<Group> GetAllGroups()
        {
            return [.. _context.Groups];
        }

        public List<Group> GetAllGroupsUserBelongsTo(Guid groupMemberId)
        {
            var groups = _context.Groups.Join(
             _context.Memberships,
             group => group.GroupId,
             membership => membership.GroupId,
             (group, membership) => new { Group = group, Membership = membership })
         .Where(joined => joined.Membership.UserId == groupMemberId)
         .Select(joined => joined.Group)
         .ToList();

            return groups;
        }

        public List<JoinRequest> GetRequestsToJoinFromGroup(Guid groupId)
        {
            // Get the Group from the GroupRepository
            var allRequestsFromGroup = _context.JoinRequests.Where(request => request.GroupId == groupId).ToList();
            return allRequestsFromGroup;
        }

        public void RemoveMemberFromGroup(Guid groupId, Guid userId)
        {
            var membership = context.Memberships.Find(groupId, userId);
            if (membership == null)
            {
                throw new Exception("User doesn't belong to this group");
            }
            _context.Memberships.Remove(membership);
            _context.SaveChanges();
        }

        public void RejectRequestToJoinGroup(Guid joinRequestId)
        {
            var request = _context.JoinRequests.Find(joinRequestId);
            if (request == null)
            {
                throw new Exception("User didn't request to join this group");
            }
            _context.JoinRequests.Remove(request);
            _context.SaveChanges();
        }

        public void List<User> GeGroupMembers(Guid groupId){
            var members = _context.Users.Join(
             _context.Memberships,
             user => user.UserId,
             membership => membership.UserId,
             (user, membership) => new { User = user, Membership = membership })
         .Where(joined => joined.Membership.GroupId == groupId)
         .Select(joined => joined.User)
         .ToList();
            return members
        }
        
        public bool IsUserInGroup(Guid groupId, Guid groupMemberId)
        {
            var membership = _context.Memberships.Find(groupId, groupMemberId);
            if (membership == null)
            {
                return false;
            }
            return true;
        }

        public void AcceptRequestToJoinGroup(JoinRequest joinRequest)
        {
            if (_context.JoinRequests.Find(joinRequest.JoinRequestId) == null)
            {
                throw new Exception("User didn't request to join this group");
            }
            _context.Memberships.Add(new Membership(joinRequest.GroupId, joinRequest.UserId));
            _context.JoinRequests.Remove(joinRequest);
            _context.SaveChanges();
        }

        public bool CheckUserInGroup(Guid groupId, Guid userId)
        {
            if (_context.Memberships.Find(groupId, userId) != null)
            {
                return true;
            }
            return false;   
        }

        public Membership AddMemberToGroup(Membership membership)
        {
            Membership addedMembership = _context.Memberships.Add(membership).Entity;
            _context.SaveChanges();
            return addedMembership
        }

        public List<GroupPost> GetGroupPosts(Guid groupId)
        {
            var posts = _context.GroupPosts.Where(post => post.GroupId == groupId).ToList();
            return posts.Select(post => GroupPostMapper.GroupPostToGroupPostDTO(post)).ToList();
        }

        public Membership UpdateMembership(Membership membership)
        {
            if(this.CheckUserInGroup(membership.GroupId, membership.UserId) == false)
            {
                throw new Exception("User doesn't belong to this group");

            }
            var updatedMembership = _context.Memberships.Update(membership).Entity;
            _context.SaveChanges();
            return updatedMembership;
        }

        public JoinRequest AddNewRequestToJoinGroup(JoinRequest joinRequest)
        {
            JoinRequest addedJoinRequest = _context.JoinRequests.Add(joinRequest).Entity;
            _context.SaveChanges();
            return addedJoinRequest;
        }
    }
}
