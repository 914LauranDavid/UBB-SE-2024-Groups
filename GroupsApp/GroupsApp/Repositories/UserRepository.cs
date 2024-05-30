using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repository
{
    public class UserRepository(GroupsAppContext context)
    {
        private readonly GroupsAppContext _context = context;

        public User AddUser(User user)
        {
            User savedUser = _context.Users.Add(user).Entity;
            _context.SaveChanges();
            return savedUser;
        }

        public User? GetUserById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public User UpdateUser(User user)
        {
            User? foundUser = _context.Users.Find(user.UserId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            foundUser.FullName = user.FullName;
            foundUser.Email = user.Email;
            foundUser.Password = user.Password;
            foundUser.PhoneNumber = user.PhoneNumber;
            foundUser.Username = user.Username;
            foundUser.BirthDay = user.BirthDay;
            User updatedUser = _context.Users.Update(foundUser).Entity;
            _context.SaveChanges();
            return updatedUser;
        }

        public void DeleteUser(User user)
        {
            User? foundUser = _context.Users.Find(user.UserId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }




    }
}
