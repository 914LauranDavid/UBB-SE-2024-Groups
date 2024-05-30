using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public interface IGroupRepository
    {
        public Group AddGroup(Group group);
        public Group? GetGroupById(Guid id);
        public Group UpdateGroup(Group group);
        public void DeleteGroup(Group group);
        public List<Group> GetAllGroups();
    }
}
