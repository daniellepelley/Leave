using Hermes.Leave.Services.Model;

namespace Hermes.Leave.Services
{
    public class ApprovalService
    {
        private readonly IUser _user;

        public ApprovalService(IUser user)
        {
            _user = user;
        }

        public void Approve(LeaveItem leave)
        {
            if (_user.IsApprover)
            {
                leave.Status = LeaveItemStatus.Approved;
            }
        }

        public void Reject(LeaveItem leave)
        {
            if (_user.IsApprover)
            {
                leave.Status = LeaveItemStatus.Rejected;
            }
        }
    }
}