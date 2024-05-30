using GroupsApp.Models;
using System;
using System.Collections.Generic;

namespace GroupsApp.Repositories
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User? GetUserById(Guid id);
        User UpdateUser(User user);
        void DeleteUser(User user);
        List<User> GetAllUsers();
    }
}