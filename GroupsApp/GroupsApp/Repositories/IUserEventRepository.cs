using GroupsApp.Models;
using System;
using System.Collections.Generic;

namespace GroupsApp.Repositories
{
    public interface IUserEventRepository
    {
        UserEvent AddUserEvent(UserEvent userEvent);
        UserEvent? GetUserEventById(Guid userId, Guid eventId);
        UserEvent UpdateUserEvent(UserEvent userEvent);
        void DeleteUserEvent(Guid userId, Guid eventId);
        List<UserEvent> GetAllUserEvents();
        List<UserEvent> GetUserEventsByUserId(Guid userId);
        List<UserEvent> GetUserEventsByEventId(Guid eventId);
    }
}