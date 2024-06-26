﻿

using GroupsApp.Models;
using GroupsApp.Payload.DTO;

namespace GroupsApp.Mapper
{
    public class GroupMapper
    {
        public static GroupDTO GroupToGroupDTO(Group group)
        {
            GroupDTO groupDTO = new GroupDTO();
            groupDTO.GroupId = group.GroupId;
            groupDTO.OwnerId = group.OwnerId;
            groupDTO.CreatedDate = group.CreatedDate;
            groupDTO.Description = group.Description;
            groupDTO.GroupName = group.GroupName;
            groupDTO.AllowanceOfPostage = group.AllowanceOfPostage;
            return groupDTO;
        }

        public static Group GroupDTOToGroup(GroupDTO groupDTO)
        {
            return new Group(groupDTO.GroupId, groupDTO.OwnerId, groupDTO.GroupName, groupDTO.Description, groupDTO.CreatedDate, groupDTO.IsPublic, groupDTO.AllowanceOfPostage);
        }
    }
}
