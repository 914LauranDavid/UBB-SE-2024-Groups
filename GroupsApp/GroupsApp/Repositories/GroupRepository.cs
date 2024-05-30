using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class GroupRepository(GroupsAppContext context):IGroupRepository
    {
        private readonly GroupsAppContext _context = context;

        public Group AddGroup(Group group)
        {
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

    }
}
