using GroupsApp.Data;
using GroupsApp.Models;
using System.Composition;

namespace GroupsApp.Repositories
{
    public class ReportRepository(GroupsAppContext context)
    {
        private readonly GroupsAppContext _context = context;

        /*
        public Report AddReport(Report report)
        {
            Report savedReport = _context.Reports.Add(report).Entity;
            _context.SaveChanges();
            return savedReport;
        }

        public Report? GetReportById(Guid id)
        {
            return _context.Reports.Find(report.ReportId);   
        }

        public Report UpdateReport(Report report)
        {
            Report? foundReport = _context.Reports.Find(report.ReportId);
            if (foundReport != null)
            {
                throw new Exception("Report not found");
            }
            foundReport.ReasonForReporting = report.ReasonForReporting;
            Report updatedReport = _context.Reports.Update(foundReport).Entity;
            _context.SaveChanges();
            return updatedReport;
        }

        public void DeleteReport(Report report)
        {
            Report? foundReport = _context.Reports.Find(report.ReportId);
            if (foundReport != null)
            {
                throw new Exception("Report not found");
            }
            _context.Reports.Remove(report);
            _context.SaveChanges();
        }

        public List<Report> GetAllReports()
        {
            return [.. _context.Reports];
        }
        */
    }
}
