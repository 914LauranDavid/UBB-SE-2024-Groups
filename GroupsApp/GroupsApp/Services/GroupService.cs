using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using BulldozerServer.Mapper;
using GroupsApp.Data;
using GroupsApp.Models;
using GroupsApp.Payload.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using GroupsApp.Repositories;
using GroupsApp.Mapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GroupsApp.Services
{
    public class GroupService : IGroupService
    {
        private GroupsAppContext context;
        private readonly GroupRepository _groupRepository;

        public GroupService(GroupRepository groupRepository)
        {
            this._groupRepository = groupRepository;
        }

        //TODO
        public Group CreateGroup(GroupDTO groupDTO)
        {
            var group = GroupMapper.GroupDTOToGroup(groupDTO);
  
            try {
                var savedGroup = this._groupRepository.AddGroup(group);
                MembershipDTO membershipDTO = new MembershipDTO
                {
                    GroupId = group.GroupId,
                    UserId = group.OwnerId,
                    JoinDate = DateOnly.FromDateTime(DateTime.Now),
                    IsAdmin = true,
                    IsTO = false,
                    IsBanned = false
                };
                this.AddMemberToGroup(membershipDTO);

                return savedGroup;
            }
            catch (Exception error)
            {
                throw new Exception("Error", error);
            }

            
        }

        //TODO
        public Group UpdateGroup(GroupDTO groupDTO)
        {
            var group = GroupMapper.GroupDTOToGroup(groupDTO);
            try {
                return this._groupRepository.UpdateGroup(group);
            } catch(Exception error)
            {
                throw new Exception("Error", error);
            }
        }

        public void DeleteGroup(Guid groupId)
        {
            try {
                this._groupRepository.DeleteGroupById(groupId);
            }
            catch (Exception error)
            {
                throw new Exception("Error deleting a group", error);
            }
           
        }

        //TODO
        public Membership AddMemberToGroup(MembershipDTO membershipDTO)
        {
            Guid userId = membershipDTO.UserId;
            Guid groupId = membershipDTO.GroupId;

            if (this._groupRepository.CheckUserInGroup(groupId, userId)==true)
            {
                throw new Exception("User is already in group");
            }

            Membership membership = MembershipMapper.MembershipDTOToMembership(membershipDTO);

            return this._groupRepository.AddMemberToGroup(membership);
        }

        public async void RemoveMemberFromGroup(Guid groupId, Guid userId)
        {
            try
            {
                this._groupRepository.RemoveMemberFromGroup(groupId, userId);
            }
            catch (Exception error)
            {
                throw new Exception("Error", error);
            }

        }

        public ICollection<GroupPostDTO> GetGroupPosts(Guid groupId)
        {
            return this._groupRepository.GetGroupPosts(groupId);
        }
        //TODO 
        public Membership UpdateMembership(MembershipDTO membershipDTO)
        {
            Guid userId = membershipDTO.UserId;
            Guid groupId = membershipDTO.GroupId;

            Membership membership = MembershipMapper.MembershipDTOToMembership(membershipDTO);
            try
            {
                return this._groupRepository.UpdateMembership(membership);
            }
            catch (Exception error)
            {
                throw new Exception("Error", error);
            }

        }
        //TODO
        public JoinRequest AddNewRequestToJoinGroup(JoinRequestDTO joinRequestDTO)
        {
            JoinRequest joinRequest = JoinRequestMapper.JoinRequestDTOToJoinRequest(joinRequestDTO);
            return this._groupRepository.CreateJoinRequest(joinRequest);
        }

        public void AcceptRequestToJoinGroup(JoinRequestDTO joinRequestDTO)
        {
            JoinRequest joinRequest = JoinRequestMapper.JoinRequestDTOToJoinRequest(joinRequestDTO);
            try
            {
                this._groupRepository.AcceptRequestToJoinGroup(joinRequest);
            }catch(Exception error)
            {
                throw new Exception("Error", error);
            }
        }

        public async void RejectRequestToJoinGroup(Guid joinRequestId)
        {
            try
            {
                this._groupRepository.RejectRequestToJoinGroup(joinRequestId);
            }
            catch(Exception error)
            {
                throw new Exception("Error", error);
            }
        }
        //TODO
        public void CreateNewPostOnGroupChat(Guid groupId, Guid groupMemberId, string postContent, string postImage)
        {
            Guid postId = Guid.NewGuid();
            DateTime postDate = DateTime.Now;
            Group? group = this._groupRepository.GetGroupById(groupId);
            if (group == null)
            {
                throw new Exception("Group not found");
            }

            Membership? groupMembership = group.Memberships.FirstOrDefault(m => m.UserId == groupMemberId);
            if (groupMembership == null)
            {
                throw new Exception("User not in group");
            }

            if (groupMembership.IsAdmin || group.AllowanceOfPostage)
            {
                GroupPost newPost = new GroupPost(postId, groupMemberId, groupId, postContent, postImage, DateTime.Now, false, false);
                group.GroupPosts.Add(newPost);
            }
        }

        public List<User> GetGroupMembers(Guid groupId)
        {
            // Get the Group from the GroupRepository
            var members = this._groupRepository.GetGroupMembers( groupId);

            return members;
        }

        public bool IsUserInGroup(Guid groupId, Guid groupMemberId)
        {
            return this._groupRepository.IsUserInGroup(groupId, groupMemberId);
        }

        public List<JoinRequest> GetRequestsToJoinFromGroup(Guid groupId)
        {
            // Get the Group from the GroupRepository
            return this._groupRepository.GetRequestsToJoinFromGroup(groupId);
        }

        public List<Group> GetAllGroupsUserBelongsTo(Guid groupMemberId)
        {
            // Get the GroupMember from the GroupMemberRepository
            return this._groupRepository.GetAllGroupsUserBelongsTo(groupMemberId);
        }

        public Group GetGroupById(Guid groupId)
        {
            try
            {
                return this._groupRepository.GetGroupById(groupId);
            }catch(Exception error)
            {
                throw new Exception("Error", error);
            }
     
        }

        public List<GroupDTO> GetAllGroups()
        {
            var groups = this._groupRepository.GetAllGroups();
            var groupDTOs = new List<GroupDTO>();
            foreach(var group in groups)
            {
                groupDTOs.Add(GroupMapper.GroupToGroupDTO(group));
            }
            return groupDTOs;
        }
    }
}