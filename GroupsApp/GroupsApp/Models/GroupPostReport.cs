using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupsApp.Models
{
    public class GroupPostReport
    {
        private Guid reportId;
        private Guid userId;
        private Guid postId;
        private string reasonForReporting;
        private DateTime dateOfReport;

        public GroupPostReport(Guid userId, Guid postId, string reasonForReporting)
        {
            this.reportId = Guid.NewGuid();
            this.userId = userId;
            this.postId = postId;
            this.reasonForReporting = reasonForReporting;
            this.dateOfReport = DateTime.Now;
        }

        public GroupPostReport(Guid id, Guid userId, Guid postId, string reasonForReporting, DateTime dateOfReport)
        {
            this.reportId = id;
            this.userId = userId;
            this.postId = postId;
            this.reasonForReporting = reasonForReporting;
            this.dateOfReport = dateOfReport;
        }

        public GroupPostReport()
        {
            this.reportId = Guid.NewGuid();
            this.userId = Guid.NewGuid();
            this.postId = Guid.NewGuid();
            this.reasonForReporting = Constants.EMPTY_STRING;
            this.dateOfReport = DateTime.Now;
        }

        public Guid ReportId { get => reportId; }
        public Guid UserId { get => userId; }
        public Guid PostId { get => postId; }
        public string ReasonForReporting { get => reasonForReporting; set => reasonForReporting = value; }
        public DateTime DateOfReport { get => dateOfReport; set => dateOfReport = value; }

        public User Reporter { get; set; }

        public GroupPost ReportedPost { get; set; }
    }
}
