﻿using GroupsApp.Models;
using GroupsApp.Payload.DTO;

namespace GroupsApp.Mapper
{
    public class MembershipMapper
    {
        public static MembershipDTO MembershipToMembershipDTO(Membership membership)
        {
          MembershipDTO membershipDTO = new MembershipDTO();
          membershipDTO.UserId = membership.UserId;
          membershipDTO.GroupId = membership.GroupId;
          membershipDTO.JoinDate = membership.JoinDate;
          membershipDTO.IsBanned = membership.IsBanned;
          membershipDTO.IsAdmin = membership.IsAdmin;
          membershipDTO.IsTO = membership.IsTimedOut;
          return membershipDTO;
        }
        public static Membership MembershipDTOToMembership(MembershipDTO membershipDTO)
        {
           return new Membership(membershipDTO.GroupId, membershipDTO.UserId, membershipDTO.JoinDate, membershipDTO.IsBanned, membershipDTO.IsTO, membershipDTO.IsAdmin);
        }
    }
}
