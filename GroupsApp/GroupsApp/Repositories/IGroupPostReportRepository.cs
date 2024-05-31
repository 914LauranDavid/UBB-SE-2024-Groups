using GroupsApp.Models;
using System;
using System.Collections.Generic;

namespace GroupsApp.Repositories
{
    public interface IGroupPostReportRepository
    {
        GroupPostReport AddGroupPostReport(GroupPostReport groupPostReport);
       //GroupPostReport? GetGroupPostReportById(Guid id);
        GroupPostReport UpdateGroupPostReport(GroupPostReport report);
        void DeleteGroupPostReport(GroupPostReport report);
        List<GroupPostReport> GetAllGroupPostReports();
    }
}