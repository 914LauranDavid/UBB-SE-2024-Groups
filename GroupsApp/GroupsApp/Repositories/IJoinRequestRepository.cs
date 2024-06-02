using GroupsApp.Models;
using System;
using System.Collections.Generic;

namespace GroupsApp.Repositories
{
    public interface IJoinRequestRepository
    {
        JoinRequest AddJoinRequest(JoinRequest joinRequest);
        JoinRequest? GetJoinRequestById(Guid joinRequestId);
        JoinRequest UpdateUser(JoinRequest joinRequest);
        void DeleteJoinRequest(JoinRequest joinRequest);
        List<JoinRequest> GetAllJoinRequests();
    }
}