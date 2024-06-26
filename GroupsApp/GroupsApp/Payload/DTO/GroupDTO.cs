﻿namespace GroupsApp.Payload.DTO
{
    public class GroupDTO
    {
        private Guid groupId;
        private Guid ownerId;
        private string groupName;
        private string description;
        private DateTime createdDate;
        private bool isPublic;
        private bool allowanceOfPostage;
        public Guid GroupId { get => groupId; set => groupId = value; }
        public Guid OwnerId { get => ownerId; set => ownerId = value; }
        public string GroupName { get => groupName; set => groupName = value; }
        public string Description { get => description; set => description = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public bool IsPublic { get => isPublic; set => isPublic = value; }
        public bool AllowanceOfPostage { get => allowanceOfPostage; set => allowanceOfPostage = value; }
    }
}
