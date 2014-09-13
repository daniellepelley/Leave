using Hermes.Leave.Services.Model;

namespace Hermes.Leave.Services
{
    public class ApprovalService
    {
        public void Approve(LeaveItem leave)
        {
            leave.Status = LeaveItemStatus.Approved;
        }

        public void Reject(LeaveItem leave)
        {
            leave.Status = LeaveItemStatus.Rejected;
        }
    }
}