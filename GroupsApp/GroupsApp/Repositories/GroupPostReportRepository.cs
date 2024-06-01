using GroupsApp.Data;
using GroupsApp.Models;
using System.Composition;

namespace GroupsApp.Repositories
{
    public class GroupPostReportRepository(GroupsAppContext context):IGroupPostReportRepository
    {
        private readonly GroupsAppContext _context = context;

        
        public GroupPostReport AddGroupPostReport(GroupPostReport groupPostReport)
        {
            GroupPostReport savedReport = _context.GroupPostReports.Add(groupPostReport).Entity;
            _context.SaveChanges();
            return savedReport;
        }
        

       // public GroupPostReport? GetGroupPostReportById(Guid id)
       // {
      //      return _context.GroupPostReports.Find(groupPostReport.ReportId);   
       // }

        public GroupPostReport UpdateGroupPostReport(GroupPostReport report)
        {
            GroupPostReport? foundReport = _context.GroupPostReports.Find(report.ReportId);
            if (foundReport != null)
            {
                throw new Exception("Report not found");
            }
            foundReport.ReasonForReporting = report.ReasonForReporting;
            GroupPostReport updatedReport = _context.GroupPostReports.Update(foundReport).Entity;
            _context.SaveChanges();
            return updatedReport;
        }

        public void DeleteGroupPostReport(GroupPostReport report)
        {
            GroupPostReport? foundReport = _context.GroupPostReports.Find(report.ReportId);
            if (foundReport != null)
            {
                throw new Exception("Report not found");
            }
            _context.GroupPostReports.Remove(report);
            _context.SaveChanges();
        }

        public List<GroupPostReport> GetAllGroupPostReports()
        {
            return [.. _context.GroupPostReports];
        }
        
    }
}
