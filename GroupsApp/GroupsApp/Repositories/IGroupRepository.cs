using GroupsApp.Models;
using GroupsApp.Payload.DTO;

namespace GroupsApp.Repositories
{
    public interface IGroupRepository
    {
        public Group AddGroup(Group group);
        public Group? GetGroupById(Guid id);
        public Group UpdateGroup(Group group);
        public void DeleteGroup(Group group);
        public List<Group> GetAllGroups();

        public void DeleteGroupById(Guid groupId);

        public bool CheckUserInGroup(Guid groupId, Guid userId);

        public Membership AddMemberToGroup(Membership membership);

        public void RemoveMemberFromGroup(Guid groupId, Guid userId);

        public List<GroupPostDTO> GetGroupPosts(Guid groupId);

        public Membership UpdateMembership(Membership membership);

        public JoinRequest CreateJoinRequest(JoinRequest joinRequest);

        public List<User> GetGroupMembers(Guid groupId);

        public void AcceptRequestToJoinGroup(JoinRequest joinRequest);






    }
}
