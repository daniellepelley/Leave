using System.Linq;
using Hermes.Leave.Services.Model;
using NUnit.Framework;

namespace Hermes.Leave.Services.Test
{
    public class ApprovalTest
    {
        public ApprovalService CreateSut(IUser user)
        {
            return new ApprovalService(user);
        }

        [Test]
        public void AnApproverCanApproveLeave()
        {
            var leave = new LeaveItem
            {
                Status = LeaveItemStatus.AwaitingApproval
            };
            
            var approver = new User
            {
                IsApprover = true
            };

            var sut = CreateSut(approver);
            
            sut.Approve(leave);

            Assert.AreEqual(LeaveItemStatus.Approved, leave.Status);
        }

        [Test]
        public void ANonApproverCannnotApproveLeave()
        {
            var leave = new LeaveItem
            {
                Status = LeaveItemStatus.AwaitingApproval
            };

            var approver = new User
            {
                IsApprover = false
            };

            var sut = CreateSut(approver);

            sut.Approve(leave);

            Assert.AreEqual(LeaveItemStatus.AwaitingApproval, leave.Status);
        }

        [Test]
        public void AnApproverCanReectLeave()
        {
            var leave = new LeaveItem
            {
                Status = LeaveItemStatus.AwaitingApproval
            };

            var approver = new User
            {
                IsApprover = true
            };

            var sut = CreateSut(approver);

            sut.Reject(leave);

            Assert.AreEqual(LeaveItemStatus.Rejected, leave.Status);
        }

        [Test]
        public void ANonApproverCannnotRejectLeave()
        {
            var leave = new LeaveItem
            {
                Status = LeaveItemStatus.AwaitingApproval
            };

            var approver = new User
            {
                IsApprover = false
            };

            var sut = CreateSut(approver);

            sut.Reject(leave);

            Assert.AreEqual(LeaveItemStatus.AwaitingApproval, leave.Status);
        }
    }
}