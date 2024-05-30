using GroupsApp.Models;
using System;
using System.Collections.Generic;

namespace GroupsApp.Repositories
{
    public interface IMembershipRepository
    {
        Membership AddMembership(Membership membership);
        Membership? GetMembershipById(Guid userId, Guid groupId);
        void DeleteMembership(Membership membership);
        Membership UpdateMembership(Membership membership);
        List<Membership> GetAllMemberships();
    }
}